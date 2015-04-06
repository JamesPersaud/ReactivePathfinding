using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactivePathfinding.WinformsVis
{
    public partial class MainWindow : Form
    {
        //window display flags
        private bool ShowOutputWindow = true;
        private OutputWindow outputWindow;
        private Version version;

        public MainWindow()
        {
            InitializeComponent();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //initialize interface components
            CreateOutputWindow();
            outputWindow.Println("Application Started - running version " 
                + version.Major.ToString() + "." 
                + version.Minor.ToString() + "."
                + version.Build.ToString());
        }

        private void CreateOutputWindow()
        {
            outputWindow = new OutputWindow();
            outputWindow.FormClosed += outputWindow_FormClosed;            
        }

        void outputWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowOutputWindow = false;
            outputToolStripMenuItem.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo according to loaded application preferences
            SetOutputVisibility(true);
        }

        private void ToggleOutputVisibility()
        {
            SetOutputVisibility(!ShowOutputWindow);
        }

        private void SetOutputVisibility(bool show)
        {
            if (outputWindow == null || outputWindow.IsDisposed)
                CreateOutputWindow();

            if (show)
            {
                outputWindow.Show();
                outputWindow.Println("Output Window opened");
                this.Focus();
            }
            else
            {
                outputWindow.Hide();
                outputWindow.Println("Output Window closed");
            }

            ShowOutputWindow = show;
            outputToolStripMenuItem.Checked = ShowOutputWindow;
        }

        /// <summary>
        /// show or hide the output window
        /// </summary>        
        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleOutputVisibility();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

