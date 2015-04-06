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
    public partial class OutputWindow : Form
    {
        public static string lastContent;

        public OutputWindow()
        {
            InitializeComponent();
            this.FormClosing += OutputWindow_FormClosing;
            RestoreLastContentWhenInstantiating();
        }

        /// <summary>
        /// Sends a line of output to the window, adds a date and newline character
        /// </summary>
        public void Println(string s)
        {
            txtOutput.Text += DateTime.Now.ToString("yyyy-mm-dd H:mm:ss:fff     ") + s + Environment.NewLine;
        }

        /// <summary>
        /// Sends output to the window
        /// </summary>
        public void Print(string s)
        {
            txtOutput.Text += s;
        }

        private void StoreContentWhenClosing()
        {
            lastContent = txtOutput.Text;
        }

        private void RestoreLastContentWhenInstantiating()
        {
            txtOutput.Text = lastContent;
        }

        private void OutputWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreContentWhenClosing();
            Println("Output Window closed");
        }

        private void wordwrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtOutput.WordWrap = !txtOutput.WordWrap;
            wordwrapToolStripMenuItem.Checked = txtOutput.WordWrap;
        }
    }
}
