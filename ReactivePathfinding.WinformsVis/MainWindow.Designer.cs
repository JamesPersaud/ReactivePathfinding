namespace ReactivePathfinding.WinformsVis
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainViewContainer = new System.Windows.Forms.SplitContainer();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblControlsTitle = new System.Windows.Forms.Label();
            this.newExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExperimentAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.experimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRandomTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTerrainTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.flatPlaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conicalHillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).BeginInit();
            this.MainViewContainer.Panel2.SuspendLayout();
            this.MainViewContainer.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.experimentToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newExperimentToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadExperimentToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveExperimentToolStripMenuItem,
            this.saveExperimentAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.eDITToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // outputToolStripMenuItem1
            // 
            this.outputToolStripMenuItem1.Name = "outputToolStripMenuItem1";
            this.outputToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.outputToolStripMenuItem1.Text = "Output";
            this.outputToolStripMenuItem1.Click += new System.EventHandler(this.outputToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainViewContainer
            // 
            this.MainViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainViewContainer.Location = new System.Drawing.Point(0, 24);
            this.MainViewContainer.Name = "MainViewContainer";
            // 
            // MainViewContainer.Panel1
            // 
            this.MainViewContainer.Panel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // MainViewContainer.Panel2
            // 
            this.MainViewContainer.Panel2.Controls.Add(this.pnlControls);
            this.MainViewContainer.Size = new System.Drawing.Size(1008, 706);
            this.MainViewContainer.SplitterDistance = 808;
            this.MainViewContainer.TabIndex = 3;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlControls.Controls.Add(this.lblControlsTitle);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(196, 706);
            this.pnlControls.TabIndex = 0;
            // 
            // lblControlsTitle
            // 
            this.lblControlsTitle.AutoSize = true;
            this.lblControlsTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlsTitle.ForeColor = System.Drawing.Color.White;
            this.lblControlsTitle.Location = new System.Drawing.Point(4, 4);
            this.lblControlsTitle.Name = "lblControlsTitle";
            this.lblControlsTitle.Size = new System.Drawing.Size(115, 16);
            this.lblControlsTitle.TabIndex = 0;
            this.lblControlsTitle.Text = "No Experiment";
            // 
            // newExperimentToolStripMenuItem
            // 
            this.newExperimentToolStripMenuItem.Name = "newExperimentToolStripMenuItem";
            this.newExperimentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.newExperimentToolStripMenuItem.Text = "New Experiment";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // loadExperimentToolStripMenuItem
            // 
            this.loadExperimentToolStripMenuItem.Name = "loadExperimentToolStripMenuItem";
            this.loadExperimentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.loadExperimentToolStripMenuItem.Text = "Load Experiment";
            // 
            // saveExperimentAsToolStripMenuItem
            // 
            this.saveExperimentAsToolStripMenuItem.Enabled = false;
            this.saveExperimentAsToolStripMenuItem.Name = "saveExperimentAsToolStripMenuItem";
            this.saveExperimentAsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveExperimentAsToolStripMenuItem.Text = "Save Experiment As";
            // 
            // saveExperimentToolStripMenuItem
            // 
            this.saveExperimentToolStripMenuItem.Enabled = false;
            this.saveExperimentToolStripMenuItem.Name = "saveExperimentToolStripMenuItem";
            this.saveExperimentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveExperimentToolStripMenuItem.Text = "Save Experiment";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // experimentToolStripMenuItem
            // 
            this.experimentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRandomTerrainToolStripMenuItem,
            this.newTerrainTemplateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.loadTerrainToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveTerrainToolStripMenuItem});
            this.experimentToolStripMenuItem.Name = "experimentToolStripMenuItem";
            this.experimentToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.experimentToolStripMenuItem.Text = "Experiment";
            // 
            // newRandomTerrainToolStripMenuItem
            // 
            this.newRandomTerrainToolStripMenuItem.Enabled = false;
            this.newRandomTerrainToolStripMenuItem.Name = "newRandomTerrainToolStripMenuItem";
            this.newRandomTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newRandomTerrainToolStripMenuItem.Text = "New Random Terrain";
            // 
            // newTerrainTemplateToolStripMenuItem
            // 
            this.newTerrainTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatPlaneToolStripMenuItem,
            this.conicalHillToolStripMenuItem});
            this.newTerrainTemplateToolStripMenuItem.Enabled = false;
            this.newTerrainTemplateToolStripMenuItem.Name = "newTerrainTemplateToolStripMenuItem";
            this.newTerrainTemplateToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newTerrainTemplateToolStripMenuItem.Text = "New Terrain from Template";
            // 
            // loadTerrainToolStripMenuItem
            // 
            this.loadTerrainToolStripMenuItem.Enabled = false;
            this.loadTerrainToolStripMenuItem.Name = "loadTerrainToolStripMenuItem";
            this.loadTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.loadTerrainToolStripMenuItem.Text = "Load Terrain";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            // 
            // flatPlaneToolStripMenuItem
            // 
            this.flatPlaneToolStripMenuItem.Name = "flatPlaneToolStripMenuItem";
            this.flatPlaneToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.flatPlaneToolStripMenuItem.Text = "Flat Plane";
            // 
            // conicalHillToolStripMenuItem
            // 
            this.conicalHillToolStripMenuItem.Name = "conicalHillToolStripMenuItem";
            this.conicalHillToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.conicalHillToolStripMenuItem.Text = "Step Pyramid";
            // 
            // saveTerrainToolStripMenuItem
            // 
            this.saveTerrainToolStripMenuItem.Enabled = false;
            this.saveTerrainToolStripMenuItem.Name = "saveTerrainToolStripMenuItem";
            this.saveTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.saveTerrainToolStripMenuItem.Text = "Save Terrain As";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.MainViewContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Reactive Pathfinding";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainViewContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).EndInit();
            this.MainViewContainer.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainViewContainer;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblControlsTitle;
        private System.Windows.Forms.ToolStripMenuItem newExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveExperimentAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem experimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRandomTerrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTerrainTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flatPlaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conicalHillToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadTerrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveTerrainToolStripMenuItem;
    }
}

