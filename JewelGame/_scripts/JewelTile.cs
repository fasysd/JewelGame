using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_JewelGame._Scripts
{
    public partial class JewelTile : PictureBox
    {
        static private Random random = new Random();
        static public Image[] _images;
        static public int _GetRandomType() => random.Next(_images.Length);

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Type { get; private set; }

        private int _emptyType = _images.Length;

        static JewelTile()
        {
            string basePath = Path.Combine(Application.StartupPath, "..\\..\\Resources");
            _images = new Image[6];
            for (int i = 0; i < 6; i++)
            {
                string path = Path.Combine(basePath, $"Sprite-000{i + 1}.png");
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Không tìm thấy file ảnh: {path}");
                _images[i] = Image.FromFile(path);
            }
        }
        public JewelTile(int X, int Y, int Size, int Type, EventHandler Click)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(Size, Size);
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            _SetPoint(X, Y);
            this._SetType_And_Render(Type);
            this.Click += Click;
        }

        public void _AdjacentTile()
        {
            this.BackColor = Color.Orange;
        }
        public void _NonAdjacentTile()
        {
            this.BackColor = Color.Transparent;
        }
        public void _SelectTile()
        {
            this.BackColor = Color.Yellow;
        }
        public void _DeselectTile()
        {
            this.BackColor = Color.Transparent;
        }
        public void _SetPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Tag = new Point(X, Y);
        }
        public void _SetEmpty() => this.Type = this._emptyType;
        public void _SetType(int newType) => this.Type = newType;
        public void _Render()
        {
            this.Image = this._IsEmpty()
                ? null
                : _images[this.Type];
        }
        public bool _IsAdjacent(JewelTile jewelTile)
        {
            int dx = Math.Abs(this.X - jewelTile.X);
            int dy = Math.Abs(this.Y - jewelTile.Y);
            return (dx + dy == 1);
        }
        public bool _IsType(int type) => this.Type == type;
        public void _SwapType(JewelTile jewelTile)
        {
            int oldType = this.Type;

            this._SetType(jewelTile.Type);
            jewelTile._SetType(oldType);
        }
        public bool _IsEmpty() => this.Type == this._emptyType;


        public void _SetEmpty_And_Render()
        {
            _SetEmpty();
            _Render();
        }
        public void _SetType_And_Render(int newType)
        {
            _SetType(newType);
            _Render();
        }
        public void _SwapType_And_Render(JewelTile jewelTile)
        {
            this._SwapType(jewelTile);

            this._Render();
            jewelTile._Render();
        }
    }
}
