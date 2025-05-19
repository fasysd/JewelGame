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
        public TableLayoutPanel _TableLayoutPanel { get; private set; }// dùng để hiện thị, tự động căn chỉnh kích cỡ các ô Jewel theo kích thước bảng
        public event Action _OnStartTurn;
        public event Action<int[]> _OnEndTurn;

        private const int _gridCount = 10;//kích thước bàn cờ
        private const int _tileSize = 50;//kích cỡ ô chọn
        private JewelTile[,] _grid = new JewelTile[_gridCount, _gridCount];//lưu các jewel ( vị trí, loại), dùng để truy xuất nhanh hơn là dùng TableLayoutPanel
        private JewelTile _firstJewel = null;//ô Jewel được chọn số 1
        private bool _canInteract = true;//trạng thái có thể swap các o Jewel hay không

        public JewelGrid(Control parent)
        {
            //tạo TableLayoutPanel
            _TableLayoutPanel = new TableLayoutPanel
            {
                RowCount = _gridCount,
                ColumnCount = _gridCount,
                Width = _gridCount * _tileSize,
                Height = _gridCount * _tileSize,
                Margin = new Padding(0),
                //Bảng Jewel ở giữa và tiếp giáp với lề trên
                Location = new Point(-_gridCount * _tileSize / 2 + parent.Size.Width / 2, 0),//Bảng Jewel sẽ luôn ở chính giữa form
                Anchor = AnchorStyles.Top,//Bảng Jewel sẽ luôn trên cùng của form
            };

            //Kích cỡ các ô Jewel sẽ thay đổi theo kích thước của TableLayoutPanel
            for (int i = 0; i < _gridCount; i++)
            {
                _TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _gridCount));
                _TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _gridCount));
            }

            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    JewelTile tile = new JewelTile(
                        X: rowX,
                        Y: columnY,
                        Size: _tileSize,
                        Type: JewelTile._GetRandomType(), 
                        Click: _clickJewel
                    );

                    _grid[rowX, columnY] = tile;
                    _TableLayoutPanel.Controls.Add(tile, rowX, columnY); // Gắn vào lưới tại vị trí (column, row)
                }
            }
            parent.Controls.Add(_TableLayoutPanel);
            _startTurn();
        }

        private void _clickJewel(object sender, EventArgs e)
        {
            Control tile = sender as Control;
            if (tile == null | !_canInteract) return;

            Point point = (Point)tile.Tag;

            //Chọn ô thứ nhất
            if (_firstJewel == null) _setFirstJewel(point);
            //Chọn ô thứ 2
            else
            {
                JewelTile secondTile = _grid[point.X, point.Y];
                if (_firstJewel._IsAdjacent(secondTile))//Kiểm tra liền kề
                {
                    _firstJewel._SwapType_And_Render(secondTile);//Đổi vị trí

                    _startTurn();
                }
                _removeFirstJewel();
            }
        }

        private async Task<int[]> _resolveJewelGrid()//Xử lý bảng
        {
            int[] result = new int[JewelTile._images.Length];//index là Type của jewel, value là số lượng jewel loại index thu thập được
            List<JewelTile> listPoints = _findMatches();// danh sách bộ ba tìm được
            while (listPoints.Count > 0)//Có bộ 3
            {
                foreach (var item in listPoints)//Chuyển các bộ 3 thành ô trống
                {
                    result[item.Type] += 1;
                    await Task.Delay(80);
                    item._SetEmpty_And_Render();
                }

                while (_updateJewelGrid() != 0)//Chờ các ô bị đẩy xuống hết đến khi không còn ô trống
                {
                    await Task.Delay(200);
                }
                listPoints = _findMatches();//Kiểm tra bộ 3 lại lần nữa
            }

        return result;
        }

        private List<JewelTile> _findMatches()
        {
            //Trả về số bộ 3 phù hợp ( bộ 3 cộng 3, bộ 4 cộng 6, bộ 5 cộng 9)
            HashSet<JewelTile> points = new HashSet<JewelTile>();
            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    int pointValue = _grid[rowX, columnY].Type;

                    //Kiểm tra hàng ngang
                    if (rowX < _gridCount - 2 && _grid[rowX + 1, columnY]._IsType(pointValue) && _grid[rowX + 2, columnY]._IsType(pointValue))
                    {
                        points.Add(_grid[rowX, columnY]);
                        points.Add(_grid[rowX + 1, columnY]);
                        points.Add(_grid[rowX + 2, columnY]);
                        //Cộng điểm
                    }

                    //Kiểm tra hàng dọc
                    if (columnY < _gridCount - 2 && _grid[rowX, columnY + 1]._IsType(pointValue) && _grid[rowX, columnY + 2]._IsType(pointValue))
                    {
                        points.Add(_grid[rowX, columnY]);
                        points.Add(_grid[rowX, columnY + 1]);
                        points.Add(_grid[rowX, columnY + 2]);
                        //Cộng điểm
                    }
                }
            }
            return points.ToList<JewelTile>();
        }

        private int _updateJewelGrid()//Cập nhật lại bảng ô để lấp các vị trí trống, nhưng chỉ lấp xuống 1 ô
        {
            int numberOfBlackTiles = 0;
            for (int rowX = _gridCount - 1; rowX >= 0; rowX--)
            {
                for (int columnY = _gridCount - 1; columnY >= 0; columnY--)
                {
                    if (_grid[rowX, columnY]._IsEmpty())
                    {
                        for (int pY_1 = columnY; pY_1 > 0; pY_1--)
                        {
                            _grid[rowX, pY_1]._SetType_And_Render(_grid[rowX, pY_1 - 1].Type);
                        }
                        _grid[rowX, 0]._SetType_And_Render(JewelTile._GetRandomType());
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
        private void _setFirstJewel(Point point)
        {
            _firstJewel = _grid[point.X, point.Y];
            _firstJewel._SelectTile();
            if (_firstJewel.X + 1 != _gridCount) _grid[_firstJewel.X + 1, _firstJewel.Y]?._AdjacentTile();
            if (_firstJewel.X - 1 != -1) _grid[_firstJewel.X - 1, _firstJewel.Y]?._AdjacentTile();
            if (_firstJewel.Y + 1 != _gridCount) _grid[_firstJewel.X, _firstJewel.Y + 1]?._AdjacentTile();
            if (_firstJewel.Y - 1 != -1) _grid[_firstJewel.X, _firstJewel.Y - 1]?._AdjacentTile();
        }
        private void _removeFirstJewel()
        {
            _firstJewel._DeselectTile();
            if (_firstJewel.X + 1 != _gridCount) _grid[_firstJewel.X + 1, _firstJewel.Y]?._NonAdjacentTile();
            if (_firstJewel.X - 1 != -1) _grid[_firstJewel.X - 1, _firstJewel.Y]?._NonAdjacentTile();
            if (_firstJewel.Y + 1 != _gridCount) _grid[_firstJewel.X, _firstJewel.Y + 1]?._NonAdjacentTile();
            if (_firstJewel.Y - 1 != -1) _grid[_firstJewel.X, _firstJewel.Y - 1]?._NonAdjacentTile();
            _firstJewel = null;//Thiết lập lại ô được chọn
        }
        private void _startTurn()
        {
            _OnStartTurn?.Invoke();//Bắt đầu lượt
            _canInteract = false;// không thế tương tác với bảng
            _resolveJewelGrid().ContinueWith(task => //Xử lý bảng
            {
                //Kết thúc lượt
                _canInteract = true; // Có thể tương tác lại với bảng
                _OnEndTurn?.Invoke(task.Result);//Tổng kết Jewel thu thập được

                string textShow = "";
                for (int i = 0; i < task.Result.Length; i++)
                {
                    textShow += i.ToString() + " / " + task.Result[i].ToString() + "\n";
                }
                MessageBox.Show(textShow);
            });
        }
    }
}