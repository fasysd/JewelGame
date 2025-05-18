using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_JewelGame._Scripts
{
    public partial class JewelGrid
    {
        public Control _Parent { get; set; }
        public TableLayoutPanel _TableLayoutPanel { get; set; }// dùng để hiện thị, tự động căn chỉnh kích cỡ các ô Jewel theo kích thước bảng

        private const int _gridSize = 10;//kích thước bàn cờ
        private const int _tileSize = 50;//kích cỡ ô chọn
        private JewelTile[,] _grid = new JewelTile[_gridSize, _gridSize];//lưu các jewel ( vị trí, loại), dùng để truy xuất nhanh hơn là dùng TableLayoutPanel
        private JewelTile _firstJewel = null;//ô Jewel được chọn số 1
        private bool _canInteract = true;//trạng thái có thể swap các o Jewel hay không

        public JewelGrid(Control parent)
        {
            //tạo TableLayoutPanel
            _TableLayoutPanel = new TableLayoutPanel
            {
                RowCount = _gridSize,
                ColumnCount = _gridSize,
                Width = _gridSize * _tileSize,
                Height = _gridSize * _tileSize,
                Margin = new Padding(0),
                //Bảng Jewel ở giữa và tiếp giáp với lề trên
                Location = new Point(-_gridSize * _tileSize / 2 + parent.Size.Width / 2, 0),//Bảng Jewel sẽ luôn ở chính giữa form
                Anchor = AnchorStyles.Top,//Bảng Jewel sẽ luôn trên cùng của form
            };

            //Kích cỡ các ô Jewel sẽ thay đổi theo kích thước của TableLayoutPanel
            for (int i = 0; i < _gridSize; i++)
            {
                _TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _gridSize));
                _TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _gridSize));
            }

            for (int X = 0; X < _gridSize; X++)
            {
                for (int Y = 0; Y < _gridSize; Y++)
                {
                    JewelTile tile = new JewelTile(
                        X: X, 
                        Y: Y, 
                        Size: _tileSize, 
                        Type: JewelTile._GetRandomType(), 
                        Click: _clickJewel
                    );

                    _grid[X, Y] = tile;
                    _TableLayoutPanel.Controls.Add(tile, X, Y); // Gắn vào lưới tại vị trí (column, row)
                }
            }
            _Parent = parent;
            parent.Controls.Add(_TableLayoutPanel);
            _renderJewelGrid();
            _resolveJewelGrid().ContinueWith( task => { });
        }

        private void _clickJewel(object sender, EventArgs e)
        {
            Control tile = sender as Control;
            if (tile == null | !_canInteract) return;

            Point point = (Point)tile.Tag;

            //Chọn ô thứ nhất
            if (_firstJewel == null)
            {
                _firstJewel = _grid[point.X, point.Y];
                _firstJewel._SelectTile();
            }
            //Chọn ô thứ 2
            else
            {
                JewelTile secondTile = _grid[point.X, point.Y];
                if (_firstJewel._IsAdjacent(secondTile))//Kiểm tra liền kề
                {
                    _firstJewel._SwapType_And_Render(secondTile);//Đổi vị trí

                    //Bắt đầu lượt
                    _canInteract = false;// không thế tương tác với bảng
                    _resolveJewelGrid().ContinueWith(task => //Xử lý bảng
                    {
                        //Kết thúc lượt
                        _canInteract = true; // Có thể tương tác lại với bảng
                        //Tổng kết Jewel thu thập được
                    });


                }
                _firstJewel._DeselectTile();
                _firstJewel = null;//Thiết lập lại ô được chọn
            }
        }

        private async Task _resolveJewelGrid()//Xử lý bảng
        {

            List<JewelTile> listPoints = _findMatches();// danh sách bộ ba tìm được
            while (listPoints.Count > 0)//Có bộ 3
            {
                foreach (var item in listPoints)//Chuyển các bộ 3 thành ô trống
                {
                    await Task.Delay(80);
                    item._SetEmpty_And_Render();
                }

                while (_updateJewelGrid() != 0)//Chờ các ô bị đẩy xuống hết đến khi không còn ô trống
                {
                    await Task.Delay(200);
                }
                listPoints = _findMatches();//Kiểm tra bộ 3 lại lần nữa
            }
        }

        private List<JewelTile> _findMatches()
        {
            //Trả về số bộ 3 phù hợp ( bộ 3 cộng 3, bộ 4 cộng 6, bộ 5 cộng 9)
            HashSet<JewelTile> points = new HashSet<JewelTile>();
            for (int X = 0; X < _gridSize; X++)
            {
                for (int Y = 0; Y < _gridSize; Y++)
                {
                    int pointValue = _grid[X, Y].Type;

                    //Kiểm tra hàng ngang
                    if (X < _gridSize - 2 && _grid[X + 1, Y]._IsType(pointValue) && _grid[X + 2, Y]._IsType(pointValue))
                    {
                        points.Add(_grid[X, Y]);
                        points.Add(_grid[X + 1, Y]);
                        points.Add(_grid[X + 2, Y]);
                        //Cộng điểm
                    }

                    //Kiểm tra hàng dọc
                    if (Y < _gridSize - 2 && _grid[X, Y + 1]._IsType(pointValue) && _grid[X, Y + 2]._IsType(pointValue))
                    {
                        points.Add(_grid[X, Y]);
                        points.Add(_grid[X, Y + 1]);
                        points.Add(_grid[X, Y + 2]);
                        //Cộng điểm
                    }
                }
            }
            return points.ToList<JewelTile>();
        }

        private int _updateJewelGrid()//Cập nhật lại bảng ô để lấp các vị trí trống, nhưng chỉ lấp xuống 1 ô
        {
            int numberOfBlackTiles = 0;
            for (int X = _gridSize - 1; X >= 0; X--)
            {
                for (int Y = _gridSize - 1; Y >= 0; Y--)
                {
                    if (_grid[X, Y]._IsEmpty())
                    {
                        for (int pY_1 = Y; pY_1 > 0; pY_1--)
                        {
                            _grid[X, pY_1]._SetType_And_Render(_grid[X, pY_1 - 1].Type);
                        }
                        _grid[X, 0]._SetType_And_Render(JewelTile._GetRandomType());
                        numberOfBlackTiles++;
                    }
                }
            }
            return numberOfBlackTiles;
        }

        private void _renderJewelGrid()//Cập nhật lại toàn phần hiển thị
        {
            foreach (var item in _grid)
            {
                item._Render();
            }
        }
    }
}









//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Net;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

//namespace Project_GameKimCuong._Scripts
//{
//    public partial class JewelGrid
//    {
//        public Control _Parent { get; set; }
//        public TableLayoutPanel _TableLayoutPanel { get; set; }

//        private const int _gridSize = 10;//kích thước bàn cờ
//        private const int _tileSize = 50;//kích cỡ ô chọn
//        private int[,] _jewelGrid = new int[_gridSize, _gridSize];
//        private PictureBox[,] _grid = new PictureBox[_gridSize, _gridSize];
//        private Random _rand = new Random();
//        private Point? _firstJewel = null;
//        private bool _canInteract = true;

//        //Màu sắc của kim cương, màu cuối cùng là màu kim cương đã thu thập
//        private Color[] _colors = new Color[]
//        {
//            Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.White
//        };

//        public JewelGrid(Control parent)
//        {
//            _TableLayoutPanel = new TableLayoutPanel
//            {
//                RowCount = _gridSize,
//                ColumnCount = _gridSize,
//                Width = _gridSize * _tileSize,
//                Height = _gridSize * _tileSize,
//                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
//                Margin = new Padding(0),
//                Location = new Point(-_gridSize * _tileSize / 2 + parent.Size.Width / 2, 0),
//                Anchor = AnchorStyles.Top,
//            };

//            for (int i = 0; i < _gridSize; i++)
//            {
//                _TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _gridSize));
//                _TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _gridSize));
//            }

//            for (int Y = 0; Y < _gridSize; Y++)
//            {
//                for (int X = 0; X < _gridSize; X++)
//                {
//                    _jewelGrid[X, Y] = _rand.Next(_colors.Length - 1);

//                    PictureBox tile = new PictureBox();
//                    _grid[X, Y] = tile;
//                    _TableLayoutPanel.Controls.Add(tile, X, Y); // Gắn vào lưới tại vị trí (column, row)
//                    tile.Size = new Size(_tileSize, _tileSize);
//                    tile.Dock = DockStyle.Fill;
//                    tile.Margin = new Padding(0);
//                    tile.Tag = new Point(X, Y);
//                    tile.Click += _clickJewel;

//                    _setTypeOfJewel(X, Y);
//                }
//            }
//            _Parent = parent;
//            parent.Controls.Add(_TableLayoutPanel);
//            _resolveJewelGrid();
//        }

//        private void _clickJewel(object sender, EventArgs e)
//        {
//            Control tile = sender as Control;
//            if (tile == null | !_canInteract) return;

//            Point point = (Point)tile.Tag;

//            if (_firstJewel == null)
//            {
//                _firstJewel = point;
//                _setTypeOfJewel(point, Color.Black);
//            }
//            else
//            {
//                Point secondTile = point;
//                if (_isAdjacent(_firstJewel.Value, secondTile))//Kiểm tra liền kề
//                {
//                    _swapJewels(_firstJewel.Value, secondTile);//Đổi vị trí
//                    _resolveJewelGrid();
//                }
//                _updateColors();
//                _firstJewel = null;//Thiết lập lại ô được chọn
//            }
//        }

//        private async Task _resolveJewelGrid()//Xử lý bảng
//        {
//            List<Point> listPoints = _findMatches();//Kiểm tra bộ 3
//            _canInteract = false;
//            while (listPoints.Count > 0)//Có bộ 3
//            {
//                foreach (var item in listPoints)//Chuyển các bộ 3 thành ô trống
//                {
//                    _jewelGrid[item.X, item.Y] = _colors.Length - 1;
//                    await Task.Delay(30);
//                    _setTypeOfJewel(item);
//                }

//                while (_updateJewelGrid() != 0)//Chờ các ô bị đẩy xuống hết đến khi không còn ô trống
//                {
//                    await Task.Delay(200);
//                    _updateColors();
//                }

//                listPoints = _findMatches();//Kiểm tra bộ 3 lại lần nữa
//            }
//            _canInteract = true;
//        }
//        private void _swapJewels(Point point1, Point point2)
//        {
//            //Thay đổi giá trị của 2 ô point1 với point2
//            int oldValue = _jewelGrid[point1.X, point1.Y];
//            _jewelGrid[point1.X, point1.Y] = _jewelGrid[point2.X, point2.Y];
//            _jewelGrid[point2.X, point2.Y] = oldValue;
//        }

//        private bool _isAdjacent(Point point1, Point point2)
//        {
//            //Kiểm tra liền kề của point1 với point2
//            int dx = Math.Abs(point1.X - point2.X);
//            int dy = Math.Abs(point1.Y - point2.Y);
//            return (dx + dy == 1); // chỉ được đổi nếu liền kề
//        }

//        private List<Point> _findMatches()
//        {
//            //Trả về số bộ 3 phù hợp ( bộ 3 cộng 3, bộ 4 cộng 6, bộ 5 cộng 9)
//            List<Point> points = new List<Point>();
//            for (int X = 0; X < _gridSize; X++)
//            {
//                for (int Y = 0; Y < _gridSize; Y++)
//                {
//                    int pointValue = _jewelGrid[X, Y];

//                    //Kiểm tra hàng ngang
//                    if (X < _gridSize - 2 && pointValue == _jewelGrid[X + 1, Y] && pointValue == _jewelGrid[X + 2, Y])
//                    {
//                        points.Add(new Point(X, Y));
//                        points.Add(new Point(X + 1, Y));
//                        points.Add(new Point(X + 2, Y));
//                        //Cộng điểm
//                    }

//                    //Kiểm tra hàng dọc
//                    if (Y < _gridSize - 2 && pointValue == _jewelGrid[X, Y + 1] && pointValue == _jewelGrid[X, Y + 2])
//                    {
//                        points.Add(new Point(X, Y));
//                        points.Add(new Point(X, Y + 1));
//                        points.Add(new Point(X, Y + 2));
//                        //Cộng điểm
//                    }
//                }
//            }
//            return points;
//        }

//        private int _updateJewelGrid()//Cập nhật lại bảng ô để lấp các vị trí trống, nhưng chỉ lấp xuống 1 ô
//        {
//            int numberOfBlackTiles = 0;
//            int valueOfBlackTile = _colors.Length - 1;
//            for (int X = _gridSize - 1; X >= 0; X--)
//            {
//                for (int Y = _gridSize - 1; Y >= 0; Y--)
//                {
//                    int tileValue = _jewelGrid[X, Y];
//                    if (tileValue == valueOfBlackTile)
//                    {
//                        for (int pY_1 = Y; pY_1 > 0; pY_1--)
//                        {
//                            _jewelGrid[X, pY_1] = _jewelGrid[X, pY_1 - 1];
//                        }
//                        _jewelGrid[X, 0] = _rand.Next(valueOfBlackTile);
//                        numberOfBlackTiles++;
//                    }
//                }
//            }
//            return numberOfBlackTiles;
//        }

//        private void _updateColors()//Cập nhật lại toàn phần hiển thị
//        {
//            for (int X = 0; X < _gridSize; X++)
//            {
//                for (int Y = 0; Y < _gridSize; Y++)
//                {
//                    _setTypeOfJewel(X, Y);
//                }
//            }
//        }
//        private void _setTypeOfJewel(Point point, Color color)
//        {
//            _grid[point.X, point.Y].BackColor = color;
//        }
//        private void _setTypeOfJewel(Point point)
//        {
//            _grid[point.X, point.Y].BackColor = _colors[_jewelGrid[point.X, point.Y]];
//        }
//        private void _setTypeOfJewel(int X, int Y)
//        {
//            _grid[X, Y].BackColor = _colors[_jewelGrid[X, Y]];
//        }
//    }
//}