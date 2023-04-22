using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;

namespace TILED_BASED
{
    public partial class MAIN : Form
    {
        Map map;        
        private static Rectangle src, dst;
        private Sprites kirby, dino, back, SKY, industrial, ind;
        string score;
        bool right, left, dinoJump, kirbyJump, kirbyHit, hitleft;
        int elapsed;
        int CONTADOR;
        Thread thread;

        private void MAIN_Load(object sender, EventArgs e)
        {

        }

        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_SizeChanged(object sender, EventArgs e)
        {       
            Init();            
        }

        private void Init()
        {
            map         = new Map();            
            right       = false;
            dinoJump    = false;
            score = string.Empty;//industrial
            elapsed     = 0;
            //--------------------------------------------------
            Size sizeSky = new Size(PCT_CANVAS.Width / 2, PCT_CANVAS.Height );
            Size vizSky     = new Size(PCT_CANVAS.Width*2, PCT_CANVAS.Height);
            SKY             = new Sprites(sizeSky, vizSky, new Point(), 5, Resource1.SKY);
            //---------------------------------------------------------------------------------            
            Size sizeIND = new Size(Resource1.industrial.Width, Resource1.industrial.Height);
            Size vizIND     = new Size(PCT_CANVAS.Width*3, PCT_CANVAS.Height*2);
            industrial = new Sprites(sizeIND, vizIND, new Point(0, -150), 20, Resource1.industrial);

            sizeIND = new Size(Resource1.industrial.Width, Resource1.industrial.Height);
            vizIND = new Size(PCT_CANVAS.Width*3, PCT_CANVAS.Height*3);
            ind = new Sprites(sizeIND, vizIND, new Point(0,0), 10, Resource1.ind);
            //----------------------------------------------------------------------------------
            Size sizeBack   = new Size(PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            Size vizBack    = new Size(PCT_CANVAS.Width, PCT_CANVAS.Height);
            back            = new Sprites(sizeBack, vizBack, new Point(), 15, map.BMP);
            //----------------------------------------------------------------------------------
            Point posDino   = new Point((PCT_CANVAS.Width / 2) - 29, 300); // INITIAL POSITION
            Size sizeDino   = new Size(58,70);                             // ORIGINAL PIXEL SIZE
            Size vizDino    = new Size(50, 60);                             // DINO DISPLAY SIZE
            dino            = new Sprites(sizeDino, vizDino, posDino, Resource1.DINO_00, Resource1.DINO_L);
            //-----------------------------------------------------------------------------------------
            Point posKirby  = new Point(128, 140); // Initial kirby position
            Size sizeKirby  = new Size(480, 550);  // Original pizel size
            Size vizKirby   = new Size(70, 80);     // Kirby display size
            kirby           = new Sprites(sizeKirby, vizKirby, posKirby, Resource1.kirby2);
           
            
        }
        
        private void PCT_CANVAS_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            SKY.Display(e.Graphics);
            ind.Display(e.Graphics);
            back.Display(e.Graphics);   
            dino.Display(e.Graphics);
            kirby.Display(e.Graphics);
            industrial.Display(e.Graphics);
            e.Graphics.DrawString("HOLA " + score, new Font("Arial", 15), Brushes.White, 10, 10);// TEXT FOR SCORING ---
        }
        
        private void CANVAS_Action(int X)
        {
            if (X < 0)
            {          
                SKY.MoveLeft();
                ind.MoveLeft();
                back.MoveLeft();
                dino.MoveReverse();               
                kirby.MoveReverse();
                industrial.MoveLeft();
            }
            if (X > 0)
            {

                SKY.MoveRight();
                ind.MoveRight();
                back.MoveRight();
                dino.MoveRight();               
                kirby.MoveRight();
                industrial.MoveRight();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
            switch (e.KeyCode)
            {                
                case Keys.Left:
                    if (!left)
                    {
                        kirby.Position(0, 550);
                        left = true;
                        hitleft = true;
                    }
                   
                    break;
                case Keys.Right:
                    if (!right)
                    {
                        kirby.Position(0, 0);
                        right = true;
                    }
                    break;             
                case Keys.Up:
                    if (PCT_CANVAS.Height > kirby.display.Height && kirby.PosY > kirby.display.Height)
                    {
                        AsignY();
                        kirby.Position(0, 0);
                        kirby.PosY = kirby.PosY - 60;
                        kirbyJump = true;
                    }
                    break;
                case Keys.A:
                    if (!kirbyHit)
                    {
                        kirby.Position(0, 1625);
                        kirby.imagen=480;
                        kirbyHit = true;
                    }
                    if (hitleft)
                    {
                        kirby.Position(0, 2175);
                        kirby.imagen = 480;
                        hitleft = false;

                    }
                    break;
                case Keys.Space:
                    if (PCT_CANVAS.Height > 20 & kirby.PosY > 20)
                    {
                        AsignY();
                        kirby.Position(0, 1100);
                        kirby.PosY = kirby.PosY - 60;
                        kirby.imagen = 2880;
                        kirbyJump = true;
                    }     
                    break;
            } 
        }
        private void AsignY()
        {
            dino.PosY -= 60;
            dinoJump = true;  
        }
        
        private void MAIN_KeyUp(object sender, KeyEventArgs e)
        {   
            dino.Frame(0);
            kirby.Frame(0);

            if (e.KeyCode == Keys.Right)
                 right = false;
            if (e.KeyCode == Keys.Left)
                left = false;
            if (e.KeyCode == Keys.Up)
                dinoJump = false;//*/
                kirbyJump = false;
            if (e.KeyCode == Keys.A)
                kirbyHit = false;
            if (e.KeyCode == Keys.Space)
                kirbyJump = false;


        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (right)
            {   
                CANVAS_Action(1);
               
            }
            if (left)
            {
                
                CANVAS_Action(-1);
              
            }
            if (kirbyHit)
            {
                kirby.MoveRight();
            }
            if (kirbyJump)
            {
                kirby.MoveRight();
            }

            score = dino.PosY.ToString();

            elapsed++;
            PCT_CANVAS.Invalidate();
        }
    }
}
