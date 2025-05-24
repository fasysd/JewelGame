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
        static public Image[] _images_oulineBackgrout;
        public static int _emptyType;
        static public int _GetRandomType() => random.Next(_images.Length);

        public Point Point;
        public int X => Point.X;
        public int Y => Point.Y;
        public int Type;


        static JewelTile()
        {
            string basePath = Path.Combine(Application.StartupPath, "..\\..\\Resources");

            _images = new Image[6];
            for (int i = 0; i < _images.Length; i++)
            {
                string path = Path.Combine(basePath, $"Sprite-000{i + 1}.png");
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Không tìm thấy file ảnh: {path}");
                _images[i] = Image.FromFile(path);
            }

            _images_oulineBackgrout = new Image[4];
            for (int i = 0; i < _images_oulineBackgrout.Length; i++)
            {
                string path = Path.Combine(basePath, $"Sprite-Outline-000{i + 1}-sheet.png");
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Không tìm thấy file ảnh: {path}");
                _images_oulineBackgrout[i] = Image.FromFile(path);
            }
            _emptyType = _images.Length;
        }
        public JewelTile()
        {
            this.Name = "PictureBox_JewelTile_" + X + "/" + Y;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void _AdjacentTile()
        {
            this.BackgroundImage = _images_oulineBackgrout[3];
        }
        public void _NonAdjacentTile()
        {
            this.BackgroundImage = null;
        }
        public void _SelectTile()
        {
            this.BackgroundImage = _images_oulineBackgrout[2];
        }
        public void _DeselectTile()
        {
            this.BackgroundImage = null;
        }
        public void _SetEmpty() => this.Type = _emptyType;
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
        public bool _IsEmpty() => this.Type == _emptyType;


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
