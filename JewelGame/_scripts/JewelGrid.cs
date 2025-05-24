using JewelGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_JewelGame._Scripts
{
    public partial class JewelGrid: TableLayoutPanel
    {
        public event Action _OnStartTurn;
        public event Action<int[]> _OnEndTurn;
        //-
        //Dữ liệu bảng jewel
        private int _gridCount;//kích thước bàn cờ
        private JewelTile[,] _grid;//lưu các jewel ( vị trí, loại)
        //-
        //Dữ liệu tạm thời bảng jewel
        private JewelTile _firstJewel = null;//ô Jewel được chọn số 1
        private bool _canInteract = true;//trạng thái có thể swap các ô Jewel

        public JewelGrid( int GridCount = 10)
        {
            _gridCount = GridCount;
            _grid = new JewelTile[_gridCount, _gridCount];

            this.RowCount = _gridCount;
            this.ColumnCount = _gridCount;
            this.Dock = DockStyle.Fill;
            for (int i = 0; i < _gridCount; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                this.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }
            

            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    JewelTile tile = new JewelTile
                    {
                        Point = new Point( rowX, columnY ),
                        Type = JewelTile._GetRandomType(),
                    };
                    tile.Click += _clickJewel;
                    tile.DoubleClick += _doubleClickJewel;
                    tile._Render();

                    _grid[tile.X, tile.Y] = tile;
                    this.Controls.Add(tile, tile.X, tile.Y);
                }
            }

            _canInteract = false;// không thế tương tác với bảng
            _resolveJewelGrid(). //Xử lý bảng
                ContinueWith(task =>
                {
                    //Kết thúc lượt
                    _canInteract = true; // Có thể tương tác lại với bảng
                });
        }
        public JewelGrid( List<DatabaseGame.Data_jewel> Jewels)
        {
            _gridCount = Convert.ToInt32(Math.Sqrt(Jewels.Count));
            _grid = new JewelTile[_gridCount, _gridCount];

            this.RowCount = _gridCount;
            this.ColumnCount = _gridCount;
            this.Dock = DockStyle.Fill;
            for (int i = 0; i < _gridCount; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                this.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }
            foreach (var item in Jewels)
            {
                if( item.toaDoX < _gridCount && item.toaDoY < _gridCount && _grid[ item.toaDoX, item.toaDoY] == null)
                {
                    JewelTile tile = new JewelTile
                    {
                        Point = new Point(item.toaDoX, item.toaDoY),
                        Type = item.loaiJewel,
                    };
                    tile.Click += _clickJewel;
                    tile.DoubleClick += _doubleClickJewel;
                    tile._Render();

                    _grid[tile.X, tile.Y] = tile;
                    this.Controls.Add(tile, tile.X, tile.Y);
                }
                else MessageBox.Show("Dữ liệu bị lỗi");
            }
            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    if (_grid[rowX, columnY] == null)
                    {
                        JewelTile tile = new JewelTile
                        {
                            Point = new Point(rowX, columnY),
                            Type = JewelTile._emptyType,
                        };
                        tile.Click += _clickJewel;
                        tile.DoubleClick += _doubleClickJewel;
                        tile._Render();

                        _grid[tile.X, tile.Y] = tile;
                        this.Controls.Add(tile, tile.X, tile.Y);
                        
                        MessageBox.Show("Dữ liệu bị lỗi");
                    }
                }
            }
            _canInteract = false;// không thế tương tác với bảng
            _resolveJewelGrid(). //Xử lý bảng
                ContinueWith(task =>
                {
                    _canInteract = true; // Có thể tương tác lại với bảng
                });
        }
        public List<DatabaseGame.Data_jewel> _GetData_Jewels()
        {
            var result = new List<DatabaseGame.Data_jewel>();
            foreach (var item in _grid)
            {
                result.Add( new DatabaseGame.Data_jewel
                {
                    toaDoX = item.X,
                    toaDoY = item.Y,
                    loaiJewel = item.Type,
                });
            }
            return result;
        }

        private void _clickJewel(object sender, EventArgs e)
        {
            JewelTile clickTile = sender as JewelTile;
            if (clickTile == null | !_canInteract) return;
            //Chọn ô thứ nhất
            if (_firstJewel == null)
            {
                _firstJewel = clickTile;
                _firstJewel._SelectTile();
                if (_firstJewel.X + 1 != _gridCount) _grid[_firstJewel.X + 1, _firstJewel.Y]?._AdjacentTile();
                if (_firstJewel.X - 1 != -1) _grid[_firstJewel.X - 1, _firstJewel.Y]?._AdjacentTile();
                if (_firstJewel.Y + 1 != _gridCount) _grid[_firstJewel.X, _firstJewel.Y + 1]?._AdjacentTile();
                if (_firstJewel.Y - 1 != -1) _grid[_firstJewel.X, _firstJewel.Y - 1]?._AdjacentTile();
            }
            //Chọn ô thứ 2
            else
            {
                JewelTile secondTile = clickTile;
                if (_firstJewel._IsAdjacent(secondTile))//Kiểm tra liền kề
                {
                    _firstJewel._SwapType_And_Render(secondTile);//Đổi vị trí

                    _OnStartTurn?.Invoke();//Bắt đầu lượt
                    _canInteract = false;// không thế tương tác với bảng
                    _resolveJewelGrid(). //Xử lý bảng
                        ContinueWith(task =>
                        {
                            //Kết thúc lượt
                            _canInteract = true; // Có thể tương tác lại với bảng
                            _OnEndTurn?.Invoke(task.Result);//Tổng kết Jewel thu thập được
                        });
                }

                _firstJewel._DeselectTile();
                if (_firstJewel.X + 1 != _gridCount) _grid[_firstJewel.X + 1, _firstJewel.Y]?._NonAdjacentTile();
                if (_firstJewel.X - 1 != -1) _grid[_firstJewel.X - 1, _firstJewel.Y]?._NonAdjacentTile();
                if (_firstJewel.Y + 1 != _gridCount) _grid[_firstJewel.X, _firstJewel.Y + 1]?._NonAdjacentTile();
                if (_firstJewel.Y - 1 != -1) _grid[_firstJewel.X, _firstJewel.Y - 1]?._NonAdjacentTile();
                _firstJewel = null;//Thiết lập lại ô được chọn
            }
        }
        private void _doubleClickJewel(object sender, EventArgs e)
        {
            JewelTile clickTile = sender as JewelTile;
            if (clickTile == null | !_canInteract) return;

            //Mở 1 dialog để xem thông tin
            FormXemThongTinJewel formXemThongTinJewel = new FormXemThongTinJewel();
            formXemThongTinJewel._SetJewelTile(clickTile);
            formXemThongTinJewel.ShowDialog();
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
                    item._SetEmpty();
                }
                _renderJewelGrid();

                while (_updateJewelGrid() != 0)//Lặp lại đến khi các ô bị đẩy xuống hết và không còn ô trống
                {
                    _renderJewelGrid();
                    await Task.Delay( 200);
                }
                listPoints = _findMatches();//Kiểm tra bộ 3 lại lần nữa
            }
            return result;
        }

        private List<JewelTile> _findMatches()
        {
            //Lưu các jewel thu thập được;
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
                    }

                    //Kiểm tra hàng dọc
                    if (columnY < _gridCount - 2 && _grid[rowX, columnY + 1]._IsType(pointValue) && _grid[rowX, columnY + 2]._IsType(pointValue))
                    {
                        points.Add(_grid[rowX, columnY]);
                        points.Add(_grid[rowX, columnY + 1]);
                        points.Add(_grid[rowX, columnY + 2]);
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
                            _grid[rowX, pY_1]._SetType(_grid[rowX, pY_1 - 1].Type);
                        }
                        _grid[rowX, 0]._SetType(JewelTile._GetRandomType());
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