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
            this.newExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveExperimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExperimentAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRandomTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTerrainTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flatPlaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conicalHillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainViewContainer = new System.Windows.Forms.SplitContainer();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblExperimentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTerrain = new System.Windows.Forms.TextBox();
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
            // newExperimentToolStripMenuItem
            // 
            this.newExperimentToolStripMenuItem.Name = "newExperimentToolStripMenuItem";
            this.newExperimentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.newExperimentToolStripMenuItem.Text = "New Experiment";
            this.newExperimentToolStripMenuItem.Click += new System.EventHandler(this.newExperimentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // loadExperimentToolStripMenuItem
            // 
            this.loadExperimentToolStripMenuItem.Name = "loadExperimentToolStripMenuItem";
            this.loadExperimentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadExperimentToolStripMenuItem.Text = "Load Experiment";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // saveExperimentToolStripMenuItem
            // 
            this.saveExperimentToolStripMenuItem.Enabled = false;
            this.saveExperimentToolStripMenuItem.Name = "saveExperimentToolStripMenuItem";
            this.saveExperimentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveExperimentToolStripMenuItem.Text = "Save Experiment";
            // 
            // saveExperimentAsToolStripMenuItem
            // 
            this.saveExperimentAsToolStripMenuItem.Enabled = false;
            this.saveExperimentAsToolStripMenuItem.Name = "saveExperimentAsToolStripMenuItem";
            this.saveExperimentAsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveExperimentAsToolStripMenuItem.Text = "Save Experiment As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.eDITToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // outputToolStripMenuItem1
            // 
            this.outputToolStripMenuItem1.Name = "outputToolStripMenuItem1";
            this.outputToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.outputToolStripMenuItem1.Text = "Output";
            this.outputToolStripMenuItem1.Click += new System.EventHandler(this.outputToolStripMenuItem1_Click);
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
            this.experimentToolStripMenuItem.Enabled = false;
            this.experimentToolStripMenuItem.Name = "experimentToolStripMenuItem";
            this.experimentToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.experimentToolStripMenuItem.Text = "Experiment";
            // 
            // newRandomTerrainToolStripMenuItem
            // 
            this.newRandomTerrainToolStripMenuItem.Name = "newRandomTerrainToolStripMenuItem";
            this.newRandomTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newRandomTerrainToolStripMenuItem.Text = "New Procedural Terrain";
            this.newRandomTerrainToolStripMenuItem.Click += new System.EventHandler(this.newRandomTerrainToolStripMenuItem_Click);
            // 
            // newTerrainTemplateToolStripMenuItem
            // 
            this.newTerrainTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatPlaneToolStripMenuItem,
            this.conicalHillToolStripMenuItem});
            this.newTerrainTemplateToolStripMenuItem.Name = "newTerrainTemplateToolStripMenuItem";
            this.newTerrainTemplateToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.newTerrainTemplateToolStripMenuItem.Text = "New Terrain from Template";
            // 
            // flatPlaneToolStripMenuItem
            // 
            this.flatPlaneToolStripMenuItem.Name = "flatPlaneToolStripMenuItem";
            this.flatPlaneToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.flatPlaneToolStripMenuItem.Text = "Flat Plane";
            this.flatPlaneToolStripMenuItem.Click += new System.EventHandler(this.flatPlaneToolStripMenuItem_Click);
            // 
            // conicalHillToolStripMenuItem
            // 
            this.conicalHillToolStripMenuItem.Name = "conicalHillToolStripMenuItem";
            this.conicalHillToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.conicalHillToolStripMenuItem.Text = "Conical Hill";
            this.conicalHillToolStripMenuItem.Click += new System.EventHandler(this.conicalHillToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            // 
            // loadTerrainToolStripMenuItem
            // 
            this.loadTerrainToolStripMenuItem.Name = "loadTerrainToolStripMenuItem";
            this.loadTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.loadTerrainToolStripMenuItem.Text = "Load Terrain";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // saveTerrainToolStripMenuItem
            // 
            this.saveTerrainToolStripMenuItem.Name = "saveTerrainToolStripMenuItem";
            this.saveTerrainToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.saveTerrainToolStripMenuItem.Text = "Save Terrain As";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.pnlControls.Controls.Add(this.txtTerrain);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.lblExperimentName);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(196, 706);
            this.pnlControls.TabIndex = 0;
            // 
            // lblExperimentName
            // 
            this.lblExperimentName.AutoSize = true;
            this.lblExperimentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperimentName.ForeColor = System.Drawing.Color.White;
            this.lblExperimentName.Location = new System.Drawing.Point(4, 4);
            this.lblExperimentName.Name = "lblExperimentName";
            this.lblExperimentName.Size = new System.Drawing.Size(115, 16);
            this.lblExperimentName.TabIndex = 0;
            this.lblExperimentName.Text = "No Experiment";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Terrain";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTerrain
            // 
            this.txtTerrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtTerrain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTerrain.Location = new System.Drawing.Point(0, 315);
            this.txtTerrain.Multiline = true;
            this.txtTerrain.Name = "txtTerrain";
            this.txtTerrain.ReadOnly = true;
            this.txtTerrain.Size = new System.Drawing.Size(196, 391);
            this.txtTerrain.TabIndex = 2;
            this.txtTerrain.WordWrap = false;
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
        private System.Windows.Forms.Label lblExperimentName;
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
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTerrain;
    }
}

