using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactivePathfinding.Core;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;    

namespace ReactivePathfinding.WinformsVis
{
    public partial class PreviewWindow : Form
    {
        public int MapScale = 1;
        public PreviewScheme scheme = PreviewScheme.CLOUDS;
        private Heightmap map;

        public Heightmap Map
        {
            get { return map; }
            set
            {
                map = value;
                pnlPreview.Size = new Size(map.Settings.MapWidth * MapScale, map.Settings.MapHeight * MapScale);
            }
        }

        public PreviewWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Draw a preview of the heightmap at the specified scale and in the specified colour scheme
        /// </summary>        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.CornflowerBlue);

            PixelFormat format = PixelFormat.Format24bppRgb; //3 bits per pixel
            int bpp = 3;

            //Create a byte array containing heightmap data                
            int heightCount = Map.Settings.MapWidth * Map.Settings.MapHeight;
            byte[] bytes = new byte[heightCount * bpp];
            
            for (int i = 0; i < heightCount; i++)
            {
                float y = Map.GetHeight(i % Map.Settings.MapWidth, i / Map.Settings.MapWidth);
                y = (y + 1f) /2f; //transform height from the range -1 to 1, to the range 0 - 1;
                //clamp y
                if(y < 0) y =0;
                else if (y > 1) y=1;

                if (scheme == PreviewScheme.CLOUDS)
                {
                    byte b = (byte)(y * 256);                    
                    bytes[i * bpp] = b;
                    bytes[i * bpp + 1] = b;
                    bytes[i * bpp + 2] = b;
                }
                else if (scheme == PreviewScheme.MOUNTAINS)
                {

                }
                else if (scheme == PreviewScheme.ISLANDS)
                {

                }
            }

            //create a bitmap and copy in the bits
            Bitmap bmp = new Bitmap(Map.Settings.MapWidth, Map.Settings.MapHeight,format);
            BitmapData bdata = bmp.LockBits(new Rectangle(0, 0, Map.Settings.MapWidth, Map.Settings.MapHeight), ImageLockMode.ReadWrite,format);
            //copy the bits in
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bdata.Scan0, bytes.Length);
            bmp.UnlockBits(bdata);            

            Graphics g = pnlPreview.CreateGraphics();
            g.Clear(Color.CornflowerBlue);            
            g.DrawImage(bmp, 0, 0);

            base.OnPaint(e);
        }

        private void islandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = false;
            greyscaleToolStripMenuItem.Checked = false;
            islandsToolStripMenuItem.Checked = true;
            scheme = PreviewScheme.ISLANDS;
            this.Invalidate(true);
        }

        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            MapScale = 1;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            this.Invalidate(true);
        }

        private void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            MapScale = 2;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            this.Invalidate(true);
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            MapScale = 4;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            this.Invalidate(true);
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = false;
            greyscaleToolStripMenuItem.Checked = true;
            islandsToolStripMenuItem.Checked = false;
            scheme = PreviewScheme.CLOUDS;
            this.Invalidate(true);
        }

        private void terrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = true;
            greyscaleToolStripMenuItem.Checked = false;
            islandsToolStripMenuItem.Checked = false;
            scheme = PreviewScheme.MOUNTAINS;
            this.Invalidate(true);
        }
    }

    public enum PreviewScheme
    {
        CLOUDS,MOUNTAINS,ISLANDS
    }
}
