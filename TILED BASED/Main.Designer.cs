﻿namespace TILED_BASED
{
    partial class MAIN
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 50;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCT_CANVAS.BackColor = System.Drawing.Color.DimGray;
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(18, 183);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1612, 802);
            this.PCT_CANVAS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            this.PCT_CANVAS.Paint += new System.Windows.Forms.PaintEventHandler(this.PCT_CANVAS_Paint);
            // 
            // MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1648, 1126);
            this.Controls.Add(this.PCT_CANVAS);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MAIN";
            this.Text = "SCROLLER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MAIN_Load);
            this.SizeChanged += new System.EventHandler(this.MAIN_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MAIN_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer TIMER;
    }
}

