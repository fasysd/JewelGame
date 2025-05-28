using JewelGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JewelGame._Scripts
{
    public partial class JewelGrid: TableLayoutPanel
    {
        //-----------------------------------------------------------------------------
        public int _GridCount => this._gridCount;
        public event Action _OnStartTurn;
        public event Action<int[]> _OnEndTurn;
        //-----------------------------------------------------------------------------
        //-
        //Dữ liệu bảng jewel
        private int _gridCount;//kích thước bàn cờ
        private JewelTile[,] _grid;//lưu các jewel ( vị trí, loại)
        //-
        //Dữ liệu tạm thời bảng jewel
        private JewelTile _firstJewel = null;//ô Jewel được chọn số 1
        private bool _canInteract = true;//trạng thái có thể swap các ô Jewel
        //-----------------------------------------------------------------------------

        public JewelGrid( int GridCount)
        {
            _gridCount = GridCount;
            _grid = new JewelTile[_gridCount, _gridCount];

            this.RowCount = _gridCount;
            this.ColumnCount = _gridCount;
            for (int i = 0; i < _gridCount; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                this.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }
            _setAutoSize();

            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    JewelTile tile = new JewelTile
                    {
                        Point = new Point( rowX, columnY ),
                        Type = JewelTile._GetRandomType(),
                    };
                    tile._Render();
                    tile.Click += _clickJewel;
                    tile.DoubleClick += _doubleClickJewel;

                    _grid[tile.X, tile.Y] = tile;
                    this.Controls.Add(tile, tile.X, tile.Y);
                }
            }

            _resolveJewelGrid(). //Xử lý bảng
                ContinueWith(task =>{});
        }
        public JewelGrid(int GridCount, DataTable Jewels)
        {
            _gridCount = GridCount;
            _grid = new JewelTile[_gridCount, _gridCount];

            this.RowCount = _gridCount;
            this.ColumnCount = _gridCount;
            for (int i = 0; i < _gridCount; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                this.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }
            _setAutoSize();

            for (int rowX = 0; rowX < _gridCount; rowX++)
            {
                for (int columnY = 0; columnY < _gridCount; columnY++)
                {
                    JewelTile tile = new JewelTile
                    {
                        Point = new Point(rowX, columnY),
                        Type = JewelTile._EmptyType,
                    };
                    tile._Render();
                    tile.Click += _clickJewel;
                    tile.DoubleClick += _doubleClickJewel;

                    _grid[tile.X, tile.Y] = tile;
                    this.Controls.Add(tile, tile.X, tile.Y);
                }
            }
            try
            {
                var rows = Jewels.Rows;
                for ( int i = 0; i < rows.Count; i++)
                {
                    int toaDoX = Convert.ToInt32(rows[i]["toaDoX"]);
                    int toaDoY = Convert.ToInt32(rows[i]["toaDoY"]);
                    int loaiJewel = Convert.ToInt32(rows[i]["loaiJewel"]);

                    _grid[toaDoX, toaDoY]._SetType(loaiJewel);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu từ DataTable: " + ex.Message);
            }

            _resolveJewelGrid(). //Xử lý bảng
                ContinueWith(task => { });
        }
        //-----------------------------------------------------------------------------
        public DataTable _GetDataTable_Jewels()
        {
            var result = new DataTable();
            result.Columns.Add("toaDoX", typeof(int));
            result.Columns.Add("toaDoY", typeof(int));
            result.Columns.Add("loaiJewel", typeof(int));
            foreach (var item in _grid)
            {
                var newRow = result.NewRow();
                newRow["toaDoX"] = item.X;
                newRow["toaDoY"] = item.Y;
                newRow["loaiJewel"] = item.Type;
                result.Rows.Add(newRow);
            }
            return result;
        }
        //-----------------------------------------------------------------------------
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
                    _firstJewel._SwapType(secondTile);//Đổi vị trí

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
        //-----------------------------------------------------------------------------
        private async Task<int[]> _resolveJewelGrid()//Xử lý bảng
        {
            //Bắt đầu lượt
            _canInteract = false;// không thế tương tác với bảng

            int[] result = new int[ JewelTile._NumberOftype];//index là Type của jewel, value là số lượng jewel loại index thu thập được
            List<JewelTile> listPoints = _findMatches();// danh sách bộ ba tìm được
            while (listPoints.Count > 0)//Có bộ 3
            {
                foreach (var item in listPoints)//Chuyển các bộ 3 thành ô trống
                {
                    result[item.Type] += 1;
                    item._SetEmpty();
                }
                do
                {
                    await Task.Delay(200);
                }
                while (_updateJewelGrid() != 0);//Lặp lại đến khi các ô bị đẩy xuống hết và không còn ô trống

                listPoints = _findMatches();//Kiểm tra bộ 3 lại lần nữa
            }

            //Kết thúc lượt
            _canInteract = true; // Có thể tương tác lại với bảng
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
        //-----------------------------------------------------------------------------
        private void _setAutoSize()
        {
            this.ParentChanged += (sender, e) =>
            {
                if (this.Parent != null)
                {
                    //Căn chỉnh size hình vuông khi form thay đổi kích cỡ
                    this.Size = this.Parent.Height > this.Parent.Width
                        ? new Size(this.Parent.Width, this.Parent.Width)
                        : new Size(this.Parent.Height, this.Parent.Height);

                    this.Location = new Point(
                        (this.Parent.Width - this.Width) / 2,
                        (this.Parent.Size.Height - this.Height) / 2
                        );

                    this.Parent.SizeChanged += (sender_, e_) =>
                    {
                        this.Size = this.Parent.Height > this.Parent.Width
                            ? new Size(this.Parent.Width, this.Parent.Width)
                            : new Size(this.Parent.Height, this.Parent.Height);

                        this.Location = new Point(
                            (this.Parent.Width - this.Width) / 2,
                            (this.Parent.Size.Height - this.Height) / 2
                            );
                    };
                }
            };
        }
    }
}