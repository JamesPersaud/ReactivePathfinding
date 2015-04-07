﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.WinformsVis
{
    public partial class MainWindow : Form
    {
        //window display flags
        private bool ShowOutputWindow = true;
        private OutputWindow outputWindow;
        private Version version;

        //Experiment
        Experiment currentExperiment = null;

        public MainWindow()
        {
            InitializeComponent();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //initialize interface components
            CreateOutputWindow();
            outputWindow.Println("Application Started - running version " + version.ToString());
        }

        private void UpdateControlPanel()
        {
            if(currentExperiment != null)
            {
                lblExperimentName.Text = currentExperiment.Name;
            }
        }

        private void EnableExperimentMenu()
        {
            experimentToolStripMenuItem.Enabled = true;
        }

        private void CreateOutputWindow()
        {
            outputWindow = new OutputWindow();
            outputWindow.FormClosed += outputWindow_FormClosed;            
        }

        void outputWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowOutputWindow = false;
            outputToolStripMenuItem1.Checked = false;
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
            outputToolStripMenuItem1.Checked = ShowOutputWindow;
        }                      

        /// <summary>
        /// Show version information
        /// </summary>        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reactive Pathfinding" 
                + Environment.NewLine + Environment.NewLine
                + "Copyright © 2015" + Environment.NewLine 
                + "James Persaud" + Environment.NewLine
                + "The Open University" + Environment.NewLine + Environment.NewLine
                + "Running version " + version.ToString()
                , "About Reactive Pathfinding");
        }

        /// <summary>
        /// show or hide the output window
        /// </summary>  
        private void outputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToggleOutputVisibility();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        /// <summary>
        /// Start a new experiment
        /// </summary>        
        private void newExperimentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateExperiment createDialog = new CreateExperiment())
            {
                if(createDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentExperiment = new Experiment(createDialog.Name);
                    EnableExperimentMenu();
                    UpdateControlPanel();
                }
            }
        }

        private void newRandomTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flatPlaneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void conicalHillToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
