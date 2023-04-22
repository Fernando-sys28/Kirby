using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TILED_BASED
{
    public class Sprites
    {
        public Rectangle size,sizeL, display;
        public Bitmap  imgL, imgR;
        public Bitmap imgDisplay;
        int increment;
        Point pos;
        public int imagen {get;set;}
        public int PosY
        {
            get { return display.Y; }
            set { display.Y = value; }
        }

        public int PosX
        {
            get { return size.X; }
            set { size.X = value; }
        }

        public Sprites(Size original, Size display, Point starting, int increment, Bitmap right)
        {
            pos = starting;
            this.increment = increment;
            this.display = new Rectangle(starting.X, starting.Y, display.Width, display.Height);
            this.size = new Rectangle(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgDisplay = right;
            imagen = 0;
        }

        public Sprites(Size original, Size display, Point starting, Bitmap right, Bitmap left)
        {
            pos = starting;
            this.increment = original.Width;
            this.display = new Rectangle(starting.X, starting.Y, display.Width, display.Height);
            this.size = new Rectangle(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgL = left;
            this.imgDisplay = right;
            imagen = 0;
        }


        public Sprites(Size original, Size display, Point starting, Bitmap right)
        {
            pos = starting;
            this.increment = original.Width;
            this.display = new Rectangle(starting.X, starting.Y, display.Width, display.Height);
            this.size = new Rectangle(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgDisplay = right;
            imagen = 0;
        }

        public void Position(int x, int y)
        {
            size.X = x;
            size.Y = y;
        }

        public void Frame(int x)
        {
            size.X = (x * size.Width) % imgDisplay.Width;
        }

        public void MoveReverse()
        {
            imgDisplay = imgR;
            size.X = (increment + size.X) % (-imagen+imgDisplay.Width);
        }


        public void MoveRight()
        {
            imgDisplay = imgR;
            size.X = (increment + size.X) % (-imagen+ imgDisplay.Width);    
        }
        public void MoveLeft()
        {
           size.X -= increment;            
        }
                
        public void Display(Graphics g)
        {
            if (display.Y < pos.Y)
                display.Y+=10;

            g.DrawImage(imgDisplay, display, size, GraphicsUnit.Pixel);
        }
    }
}
