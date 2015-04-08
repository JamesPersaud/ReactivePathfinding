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
        private Bitmap terrainBitmap;

        public Bitmap TerrainBitmap
        {
            get { return terrainBitmap; }            
        }

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
            pnlPreview.Paint += pnlPreview_Paint;            
        }        
        
        /// <summary>
        /// Draw a preview of the heightmap at the specified scale and in the specified colour scheme
        /// </summary>        
        void pnlPreview_Paint(object sender, PaintEventArgs e)
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
                
                byte[] pixel = GetHeightShade(y, scheme);
                    
                bytes[i * bpp] = pixel[0];
                bytes[i * bpp + 1] = pixel[1];
                bytes[i * bpp + 2] = pixel[2];                
            }

            //create a bitmap and copy in the bits
            terrainBitmap = new Bitmap(Map.Settings.MapWidth, Map.Settings.MapHeight,format);
            BitmapData bdata = terrainBitmap.LockBits(new Rectangle(0, 0, Map.Settings.MapWidth, Map.Settings.MapHeight), ImageLockMode.ReadWrite, format);
            //copy the bits in
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bdata.Scan0, bytes.Length);
            terrainBitmap.UnlockBits(bdata);            

            Graphics g = pnlPreview.CreateGraphics();
            g.Clear(Color.CornflowerBlue);
            g.DrawImage(terrainBitmap, 0, 0, terrainBitmap.Width * MapScale, terrainBitmap.Height * MapScale);

            base.OnPaint(e);
        }

        private static byte[] GetHeightShade(float y, PreviewScheme s)
        {
            byte[] bytes = new byte[3];

            byte b = (byte)(y * 255);

            if (s == PreviewScheme.CLOUDS)
            {                
                bytes[0] = b;
                bytes[1] = b;
                bytes[2] = b;
            }
            else if (s == PreviewScheme.MOUNTAINS)
            {
                if (y < 0.5)
                {
                    bytes[0] = (byte)(b/2);
                    bytes[1] = (byte)Math.Min((int)b * 2, 255);
                    bytes[2] = (byte)(b/2);
                }
                else if (y < 0.7)
                {
                    bytes[0] = (byte)Math.Max((int)b -64, 0);
                    bytes[1] = b;
                    bytes[2] = (byte)Math.Min((int)b * 1.25, 255);
                }
                else if (y < 0.9)
                {
                    bytes[0] = (byte)(b / 1.5);
                    bytes[1] = (byte)(b / 1.5);
                    bytes[2] = (byte)(b / 1.5);
                }                
                else
                {
                    bytes[0] = b;
                    bytes[1] = b;
                    bytes[2] = b;
                }
            }

            return bytes;
        }

        public void ForceRedraw()
        {
            pnlPreview.Invalidate();
            TopMost = true;
        }

        private void islandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = false;
            greyscaleToolStripMenuItem.Checked = false;            
            scheme = PreviewScheme.ISLANDS;
            ForceRedraw();
        }

        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            MapScale = 1;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            ForceRedraw();
        }

        private void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            MapScale = 2;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            ForceRedraw();
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            MapScale = 4;
            pnlPreview.Size = new Size(Map.Settings.MapWidth * MapScale, Map.Settings.MapHeight * MapScale);
            ForceRedraw();
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = false;
            greyscaleToolStripMenuItem.Checked = true;            
            scheme = PreviewScheme.CLOUDS;
            ForceRedraw();
        }

        private void terrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrainToolStripMenuItem.Checked = true;
            greyscaleToolStripMenuItem.Checked = false;            
            scheme = PreviewScheme.MOUNTAINS;
            ForceRedraw();
        }
    }

    public enum PreviewScheme
    {
        CLOUDS,MOUNTAINS,ISLANDS
    }
}
