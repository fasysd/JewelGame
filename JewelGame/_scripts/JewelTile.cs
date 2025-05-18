using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_JewelGame._Scripts
{
    public partial class JewelTile : PictureBox
    {
        static private Random random = new Random();
        static private Image[] _images = new Image[]
        {
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0001.png")),
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0002.png")),
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0003.png")),
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0004.png")),
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0005.png")),
            Image.FromFile(Path.Combine(Application.StartupPath, "..\\..\\Resources\\Sprite-0006.png")),
        };
        static public int _GetRandomType() => random.Next(_images.Length);


        public int X { get; private set; }
        public int Y { get; private set; }
        public int Type { get; private set; }

        private int _emptyType = _images.Length;

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
            int oldType = this.Type;

            this._SetType(jewelTile.Type);
            jewelTile._SetType(oldType);

            this._Render();
            jewelTile._Render();
        }
    }
}
