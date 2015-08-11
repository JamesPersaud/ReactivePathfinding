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
            this.saveTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.setTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStartPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAgentTopologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.calculateBestPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainViewContainer = new System.Windows.Forms.SplitContainer();
            this.pnlSimControls = new System.Windows.Forms.Panel();
            this.icnStop = new System.Windows.Forms.PictureBox();
            this.icnFaster = new System.Windows.Forms.PictureBox();
            this.icnSlower = new System.Windows.Forms.PictureBox();
            this.icnPause = new System.Windows.Forms.PictureBox();
            this.icnPlay = new System.Windows.Forms.PictureBox();
            this.lblFPS = new System.Windows.Forms.Label();
            this.glControl = new OpenTK.GLControl();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblBestPathCost = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFitnessExplanation = new System.Windows.Forms.TextBox();
            this.lblBestAvg = new System.Windows.Forms.Label();
            this.lblBestMax = new System.Windows.Forms.Label();
            this.lblBestMin = new System.Windows.Forms.Label();
            this.lblGenAvg = new System.Windows.Forms.Label();
            this.lblGenMax = new System.Windows.Forms.Label();
            this.lblGenMin = new System.Windows.Forms.Label();
            this.lblGenWon = new System.Windows.Forms.Label();
            this.lblGenExp = new System.Windows.Forms.Label();
            this.lblGenAct = new System.Windows.Forms.Label();
            this.lblGenAge = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numtimeout = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numLifetime = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.lblGenerationAgelbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkMutCross = new System.Windows.Forms.CheckBox();
            this.chkMutSelect = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numGenerations = new System.Windows.Forms.NumericUpDown();
            this.ddlFitness = new System.Windows.Forms.ComboBox();
            this.numElites = new System.Windows.Forms.NumericUpDown();
            this.numMutation = new System.Windows.Forms.NumericUpDown();
            this.numCrossover = new System.Windows.Forms.NumericUpDown();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExperimentFilename = new System.Windows.Forms.Label();
            this.lblExperimentName = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.chkArithCross = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).BeginInit();
            this.MainViewContainer.Panel1.SuspendLayout();
            this.MainViewContainer.Panel2.SuspendLayout();
            this.MainViewContainer.SuspendLayout();
            this.pnlSimControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnFaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnSlower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnPlay)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
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
            this.saveTerrainToolStripMenuItem,
            this.toolStripMenuItem3,
            this.setTargetToolStripMenuItem,
            this.setStartPositionToolStripMenuItem,
            this.newAgentTopologyToolStripMenuItem,
            this.toolStripSeparator3,
            this.calculateBestPathToolStripMenuItem});
            this.experimentToolStripMenuItem.Enabled = false;
            this.experimentToolStripMenuItem.Name = "experimentToolStripMenuItem";
            this.experimentToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.experimentToolStripMenuItem.Text = "Experiment";
            // 
            // newRandomTerrainToolStripMenuItem
            // 
            this.newRandomTerrainToolStripMenuItem.Name = "newRandomTerrainToolStripMenuItem";
            this.newRandomTerrainToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.newRandomTerrainToolStripMenuItem.Text = "New Procedural Heightmap";
            this.newRandomTerrainToolStripMenuItem.Click += new System.EventHandler(this.newRandomTerrainToolStripMenuItem_Click);
            // 
            // newTerrainTemplateToolStripMenuItem
            // 
            this.newTerrainTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatPlaneToolStripMenuItem,
            this.conicalHillToolStripMenuItem});
            this.newTerrainTemplateToolStripMenuItem.Name = "newTerrainTemplateToolStripMenuItem";
            this.newTerrainTemplateToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.newTerrainTemplateToolStripMenuItem.Text = "New Heightmap from Template";
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
            this.toolStripMenuItem2.Size = new System.Drawing.Size(265, 6);
            // 
            // loadTerrainToolStripMenuItem
            // 
            this.loadTerrainToolStripMenuItem.Name = "loadTerrainToolStripMenuItem";
            this.loadTerrainToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.loadTerrainToolStripMenuItem.Text = "Load Heightmap";
            // 
            // saveTerrainToolStripMenuItem
            // 
            this.saveTerrainToolStripMenuItem.Name = "saveTerrainToolStripMenuItem";
            this.saveTerrainToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.saveTerrainToolStripMenuItem.Text = "Save Heightmap As";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(265, 6);
            // 
            // setTargetToolStripMenuItem
            // 
            this.setTargetToolStripMenuItem.Name = "setTargetToolStripMenuItem";
            this.setTargetToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.setTargetToolStripMenuItem.Text = "Set Target";
            this.setTargetToolStripMenuItem.Click += new System.EventHandler(this.setTargetToolStripMenuItem_Click);
            // 
            // setStartPositionToolStripMenuItem
            // 
            this.setStartPositionToolStripMenuItem.Name = "setStartPositionToolStripMenuItem";
            this.setStartPositionToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.setStartPositionToolStripMenuItem.Text = "Set Start Position";
            this.setStartPositionToolStripMenuItem.Click += new System.EventHandler(this.setStartPositionToolStripMenuItem_Click);
            // 
            // newAgentTopologyToolStripMenuItem
            // 
            this.newAgentTopologyToolStripMenuItem.Name = "newAgentTopologyToolStripMenuItem";
            this.newAgentTopologyToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.newAgentTopologyToolStripMenuItem.Text = "Set Agent Topology";
            this.newAgentTopologyToolStripMenuItem.Click += new System.EventHandler(this.newAgentTopologyToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(265, 6);
            // 
            // calculateBestPathToolStripMenuItem
            // 
            this.calculateBestPathToolStripMenuItem.Name = "calculateBestPathToolStripMenuItem";
            this.calculateBestPathToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.calculateBestPathToolStripMenuItem.Text = "Calculate Best Path";
            this.calculateBestPathToolStripMenuItem.Click += new System.EventHandler(this.calculateBestPathToolStripMenuItem_Click);
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
            this.MainViewContainer.Panel1.Controls.Add(this.pnlSimControls);
            this.MainViewContainer.Panel1.Controls.Add(this.lblFPS);
            this.MainViewContainer.Panel1.Controls.Add(this.glControl);
            this.MainViewContainer.Panel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // MainViewContainer.Panel2
            // 
            this.MainViewContainer.Panel2.Controls.Add(this.pnlControls);
            this.MainViewContainer.Size = new System.Drawing.Size(1008, 706);
            this.MainViewContainer.SplitterDistance = 800;
            this.MainViewContainer.TabIndex = 3;
            // 
            // pnlSimControls
            // 
            this.pnlSimControls.BackColor = System.Drawing.Color.White;
            this.pnlSimControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSimControls.Controls.Add(this.icnStop);
            this.pnlSimControls.Controls.Add(this.icnFaster);
            this.pnlSimControls.Controls.Add(this.icnSlower);
            this.pnlSimControls.Controls.Add(this.icnPause);
            this.pnlSimControls.Controls.Add(this.icnPlay);
            this.pnlSimControls.Location = new System.Drawing.Point(615, 664);
            this.pnlSimControls.Name = "pnlSimControls";
            this.pnlSimControls.Size = new System.Drawing.Size(193, 39);
            this.pnlSimControls.TabIndex = 2;
            // 
            // icnStop
            // 
            this.icnStop.BackColor = System.Drawing.Color.White;
            this.icnStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icnStop.Image = global::ReactivePathfinding.WinformsVis.Properties.Resources.stop;
            this.icnStop.Location = new System.Drawing.Point(155, 3);
            this.icnStop.Name = "icnStop";
            this.icnStop.Size = new System.Drawing.Size(32, 32);
            this.icnStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icnStop.TabIndex = 4;
            this.icnStop.TabStop = false;
            // 
            // icnFaster
            // 
            this.icnFaster.BackColor = System.Drawing.Color.White;
            this.icnFaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icnFaster.Image = global::ReactivePathfinding.WinformsVis.Properties.Resources.faster;
            this.icnFaster.Location = new System.Drawing.Point(117, 3);
            this.icnFaster.Name = "icnFaster";
            this.icnFaster.Size = new System.Drawing.Size(32, 32);
            this.icnFaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icnFaster.TabIndex = 3;
            this.icnFaster.TabStop = false;
            // 
            // icnSlower
            // 
            this.icnSlower.BackColor = System.Drawing.Color.White;
            this.icnSlower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icnSlower.Image = global::ReactivePathfinding.WinformsVis.Properties.Resources.slower;
            this.icnSlower.Location = new System.Drawing.Point(79, 3);
            this.icnSlower.Name = "icnSlower";
            this.icnSlower.Size = new System.Drawing.Size(32, 32);
            this.icnSlower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icnSlower.TabIndex = 2;
            this.icnSlower.TabStop = false;
            // 
            // icnPause
            // 
            this.icnPause.BackColor = System.Drawing.Color.White;
            this.icnPause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icnPause.Image = global::ReactivePathfinding.WinformsVis.Properties.Resources.pause;
            this.icnPause.Location = new System.Drawing.Point(41, 3);
            this.icnPause.Name = "icnPause";
            this.icnPause.Size = new System.Drawing.Size(32, 32);
            this.icnPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icnPause.TabIndex = 1;
            this.icnPause.TabStop = false;
            // 
            // icnPlay
            // 
            this.icnPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icnPlay.Image = global::ReactivePathfinding.WinformsVis.Properties.Resources.play;
            this.icnPlay.Location = new System.Drawing.Point(3, 3);
            this.icnPlay.Name = "icnPlay";
            this.icnPlay.Size = new System.Drawing.Size(32, 32);
            this.icnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icnPlay.TabIndex = 0;
            this.icnPlay.TabStop = false;
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPS.ForeColor = System.Drawing.Color.White;
            this.lblFPS.Location = new System.Drawing.Point(12, 679);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(0, 16);
            this.lblFPS.TabIndex = 1;
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(800, 706);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glControl_KeyUp);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseEnter += new System.EventHandler(this.glControl_MouseEnter);
            this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlControls.Controls.Add(this.chkArithCross);
            this.pnlControls.Controls.Add(this.label23);
            this.pnlControls.Controls.Add(this.lblBestPathCost);
            this.pnlControls.Controls.Add(this.label22);
            this.pnlControls.Controls.Add(this.txtFitnessExplanation);
            this.pnlControls.Controls.Add(this.lblBestAvg);
            this.pnlControls.Controls.Add(this.lblBestMax);
            this.pnlControls.Controls.Add(this.lblBestMin);
            this.pnlControls.Controls.Add(this.lblGenAvg);
            this.pnlControls.Controls.Add(this.lblGenMax);
            this.pnlControls.Controls.Add(this.lblGenMin);
            this.pnlControls.Controls.Add(this.lblGenWon);
            this.pnlControls.Controls.Add(this.lblGenExp);
            this.pnlControls.Controls.Add(this.lblGenAct);
            this.pnlControls.Controls.Add(this.lblGenAge);
            this.pnlControls.Controls.Add(this.label21);
            this.pnlControls.Controls.Add(this.label20);
            this.pnlControls.Controls.Add(this.label19);
            this.pnlControls.Controls.Add(this.label18);
            this.pnlControls.Controls.Add(this.label17);
            this.pnlControls.Controls.Add(this.numtimeout);
            this.pnlControls.Controls.Add(this.label16);
            this.pnlControls.Controls.Add(this.numLifetime);
            this.pnlControls.Controls.Add(this.label15);
            this.pnlControls.Controls.Add(this.label12);
            this.pnlControls.Controls.Add(this.label14);
            this.pnlControls.Controls.Add(this.label7);
            this.pnlControls.Controls.Add(this.label13);
            this.pnlControls.Controls.Add(this.lblGeneration);
            this.pnlControls.Controls.Add(this.lblGenerationAgelbl);
            this.pnlControls.Controls.Add(this.label11);
            this.pnlControls.Controls.Add(this.chkMutCross);
            this.pnlControls.Controls.Add(this.chkMutSelect);
            this.pnlControls.Controls.Add(this.label10);
            this.pnlControls.Controls.Add(this.label9);
            this.pnlControls.Controls.Add(this.lblSeed);
            this.pnlControls.Controls.Add(this.label8);
            this.pnlControls.Controls.Add(this.numGenerations);
            this.pnlControls.Controls.Add(this.ddlFitness);
            this.pnlControls.Controls.Add(this.numElites);
            this.pnlControls.Controls.Add(this.numMutation);
            this.pnlControls.Controls.Add(this.numCrossover);
            this.pnlControls.Controls.Add(this.numPopSize);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.lblExperimentFilename);
            this.pnlControls.Controls.Add(this.lblExperimentName);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(204, 706);
            this.pnlControls.TabIndex = 0;
            // 
            // lblBestPathCost
            // 
            this.lblBestPathCost.AutoSize = true;
            this.lblBestPathCost.ForeColor = System.Drawing.Color.White;
            this.lblBestPathCost.Location = new System.Drawing.Point(131, 480);
            this.lblBestPathCost.Name = "lblBestPathCost";
            this.lblBestPathCost.Size = new System.Drawing.Size(53, 13);
            this.lblBestPathCost.TabIndex = 54;
            this.lblBestPathCost.Text = "Unknown";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(3, 479);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 14);
            this.label22.TabIndex = 53;
            this.label22.Text = "Best path cost";
            // 
            // txtFitnessExplanation
            // 
            this.txtFitnessExplanation.BackColor = System.Drawing.Color.Black;
            this.txtFitnessExplanation.ForeColor = System.Drawing.Color.White;
            this.txtFitnessExplanation.Location = new System.Drawing.Point(6, 336);
            this.txtFitnessExplanation.Multiline = true;
            this.txtFitnessExplanation.Name = "txtFitnessExplanation";
            this.txtFitnessExplanation.ReadOnly = true;
            this.txtFitnessExplanation.Size = new System.Drawing.Size(186, 81);
            this.txtFitnessExplanation.TabIndex = 52;
            // 
            // lblBestAvg
            // 
            this.lblBestAvg.AutoSize = true;
            this.lblBestAvg.ForeColor = System.Drawing.Color.White;
            this.lblBestAvg.Location = new System.Drawing.Point(132, 682);
            this.lblBestAvg.Name = "lblBestAvg";
            this.lblBestAvg.Size = new System.Drawing.Size(13, 13);
            this.lblBestAvg.TabIndex = 51;
            this.lblBestAvg.Text = "0";
            // 
            // lblBestMax
            // 
            this.lblBestMax.AutoSize = true;
            this.lblBestMax.ForeColor = System.Drawing.Color.White;
            this.lblBestMax.Location = new System.Drawing.Point(132, 668);
            this.lblBestMax.Name = "lblBestMax";
            this.lblBestMax.Size = new System.Drawing.Size(13, 13);
            this.lblBestMax.TabIndex = 50;
            this.lblBestMax.Text = "0";
            // 
            // lblBestMin
            // 
            this.lblBestMin.AutoSize = true;
            this.lblBestMin.ForeColor = System.Drawing.Color.White;
            this.lblBestMin.Location = new System.Drawing.Point(132, 654);
            this.lblBestMin.Name = "lblBestMin";
            this.lblBestMin.Size = new System.Drawing.Size(13, 13);
            this.lblBestMin.TabIndex = 49;
            this.lblBestMin.Text = "0";
            // 
            // lblGenAvg
            // 
            this.lblGenAvg.AutoSize = true;
            this.lblGenAvg.ForeColor = System.Drawing.Color.White;
            this.lblGenAvg.Location = new System.Drawing.Point(132, 631);
            this.lblGenAvg.Name = "lblGenAvg";
            this.lblGenAvg.Size = new System.Drawing.Size(13, 13);
            this.lblGenAvg.TabIndex = 48;
            this.lblGenAvg.Text = "0";
            // 
            // lblGenMax
            // 
            this.lblGenMax.AutoSize = true;
            this.lblGenMax.ForeColor = System.Drawing.Color.White;
            this.lblGenMax.Location = new System.Drawing.Point(132, 617);
            this.lblGenMax.Name = "lblGenMax";
            this.lblGenMax.Size = new System.Drawing.Size(13, 13);
            this.lblGenMax.TabIndex = 47;
            this.lblGenMax.Text = "0";
            // 
            // lblGenMin
            // 
            this.lblGenMin.AutoSize = true;
            this.lblGenMin.ForeColor = System.Drawing.Color.White;
            this.lblGenMin.Location = new System.Drawing.Point(132, 603);
            this.lblGenMin.Name = "lblGenMin";
            this.lblGenMin.Size = new System.Drawing.Size(13, 13);
            this.lblGenMin.TabIndex = 46;
            this.lblGenMin.Text = "0";
            // 
            // lblGenWon
            // 
            this.lblGenWon.AutoSize = true;
            this.lblGenWon.ForeColor = System.Drawing.Color.White;
            this.lblGenWon.Location = new System.Drawing.Point(132, 578);
            this.lblGenWon.Name = "lblGenWon";
            this.lblGenWon.Size = new System.Drawing.Size(13, 13);
            this.lblGenWon.TabIndex = 45;
            this.lblGenWon.Text = "0";
            // 
            // lblGenExp
            // 
            this.lblGenExp.AutoSize = true;
            this.lblGenExp.ForeColor = System.Drawing.Color.White;
            this.lblGenExp.Location = new System.Drawing.Point(132, 564);
            this.lblGenExp.Name = "lblGenExp";
            this.lblGenExp.Size = new System.Drawing.Size(13, 13);
            this.lblGenExp.TabIndex = 44;
            this.lblGenExp.Text = "0";
            // 
            // lblGenAct
            // 
            this.lblGenAct.AutoSize = true;
            this.lblGenAct.ForeColor = System.Drawing.Color.White;
            this.lblGenAct.Location = new System.Drawing.Point(132, 550);
            this.lblGenAct.Name = "lblGenAct";
            this.lblGenAct.Size = new System.Drawing.Size(13, 13);
            this.lblGenAct.TabIndex = 43;
            this.lblGenAct.Text = "0";
            // 
            // lblGenAge
            // 
            this.lblGenAge.AutoSize = true;
            this.lblGenAge.ForeColor = System.Drawing.Color.White;
            this.lblGenAge.Location = new System.Drawing.Point(132, 526);
            this.lblGenAge.Name = "lblGenAge";
            this.lblGenAge.Size = new System.Drawing.Size(13, 13);
            this.lblGenAge.TabIndex = 42;
            this.lblGenAge.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 681);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 14);
            this.label21.TabIndex = 41;
            this.label21.Text = "Best avg.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 667);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 14);
            this.label20.TabIndex = 40;
            this.label20.Text = "Best max.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(3, 653);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 14);
            this.label19.TabIndex = 39;
            this.label19.Text = "Best min.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 630);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 14);
            this.label18.TabIndex = 38;
            this.label18.Text = "Avg. fitness";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 616);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 14);
            this.label17.TabIndex = 37;
            this.label17.Text = "Max. fitness";
            // 
            // numtimeout
            // 
            this.numtimeout.Location = new System.Drawing.Point(134, 448);
            this.numtimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numtimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numtimeout.Name = "numtimeout";
            this.numtimeout.Size = new System.Drawing.Size(58, 20);
            this.numtimeout.TabIndex = 31;
            this.numtimeout.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 602);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 14);
            this.label16.TabIndex = 36;
            this.label16.Text = "Min. fitness";
            // 
            // numLifetime
            // 
            this.numLifetime.Location = new System.Drawing.Point(134, 423);
            this.numLifetime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLifetime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLifetime.Name = "numLifetime";
            this.numLifetime.Size = new System.Drawing.Size(58, 20);
            this.numLifetime.TabIndex = 30;
            this.numLifetime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numLifetime.ValueChanged += new System.EventHandler(this.numLifetime_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 577);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 14);
            this.label15.TabIndex = 35;
            this.label15.Text = "Reached target";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(3, 449);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 29;
            this.label12.Text = "Agent Timeout";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 563);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 14);
            this.label14.TabIndex = 34;
            this.label14.Text = "Expired";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "Agent Lifespan";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 549);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 14);
            this.label13.TabIndex = 33;
            this.label13.Text = "Active";
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.ForeColor = System.Drawing.Color.White;
            this.lblGeneration.Location = new System.Drawing.Point(132, 513);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(13, 13);
            this.lblGeneration.TabIndex = 27;
            this.lblGeneration.Text = "0";
            // 
            // lblGenerationAgelbl
            // 
            this.lblGenerationAgelbl.AutoSize = true;
            this.lblGenerationAgelbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerationAgelbl.ForeColor = System.Drawing.Color.White;
            this.lblGenerationAgelbl.Location = new System.Drawing.Point(3, 526);
            this.lblGenerationAgelbl.Name = "lblGenerationAgelbl";
            this.lblGenerationAgelbl.Size = new System.Drawing.Size(31, 14);
            this.lblGenerationAgelbl.TabIndex = 32;
            this.lblGenerationAgelbl.Text = "Age";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 26;
            this.label11.Text = "Generation";
            // 
            // chkMutCross
            // 
            this.chkMutCross.AutoSize = true;
            this.chkMutCross.Location = new System.Drawing.Point(135, 248);
            this.chkMutCross.Name = "chkMutCross";
            this.chkMutCross.Size = new System.Drawing.Size(15, 14);
            this.chkMutCross.TabIndex = 25;
            this.chkMutCross.UseVisualStyleBackColor = true;
            this.chkMutCross.CheckedChanged += new System.EventHandler(this.chkMutCross_CheckedChanged);
            // 
            // chkMutSelect
            // 
            this.chkMutSelect.AutoSize = true;
            this.chkMutSelect.Location = new System.Drawing.Point(135, 224);
            this.chkMutSelect.Name = "chkMutSelect";
            this.chkMutSelect.Size = new System.Drawing.Size(15, 14);
            this.chkMutSelect.TabIndex = 24;
            this.chkMutSelect.UseVisualStyleBackColor = true;
            this.chkMutSelect.CheckedChanged += new System.EventHandler(this.chkMutSelect_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "Mutate on cross.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "Mutate on select";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.ForeColor = System.Drawing.Color.White;
            this.lblSeed.Location = new System.Drawing.Point(132, 65);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(13, 13);
            this.lblSeed.TabIndex = 21;
            this.lblSeed.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "Generations to run";
            // 
            // numGenerations
            // 
            this.numGenerations.Location = new System.Drawing.Point(135, 114);
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(58, 20);
            this.numGenerations.TabIndex = 19;
            this.numGenerations.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ddlFitness
            // 
            this.ddlFitness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFitness.FormattingEnabled = true;
            this.ddlFitness.Location = new System.Drawing.Point(6, 309);
            this.ddlFitness.Name = "ddlFitness";
            this.ddlFitness.Size = new System.Drawing.Size(187, 21);
            this.ddlFitness.TabIndex = 17;
            this.ddlFitness.SelectionChangeCommitted += new System.EventHandler(this.ddlFitness_SelectionChangeCommitted);
            // 
            // numElites
            // 
            this.numElites.Location = new System.Drawing.Point(135, 141);
            this.numElites.Name = "numElites";
            this.numElites.Size = new System.Drawing.Size(58, 20);
            this.numElites.TabIndex = 16;
            this.numElites.ValueChanged += new System.EventHandler(this.numElites_ValueChanged);
            // 
            // numMutation
            // 
            this.numMutation.Location = new System.Drawing.Point(135, 193);
            this.numMutation.Name = "numMutation";
            this.numMutation.Size = new System.Drawing.Size(58, 20);
            this.numMutation.TabIndex = 15;
            this.numMutation.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numMutation.ValueChanged += new System.EventHandler(this.numMutation_ValueChanged);
            // 
            // numCrossover
            // 
            this.numCrossover.Location = new System.Drawing.Point(135, 167);
            this.numCrossover.Name = "numCrossover";
            this.numCrossover.Size = new System.Drawing.Size(58, 20);
            this.numCrossover.TabIndex = 14;
            this.numCrossover.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCrossover.ValueChanged += new System.EventHandler(this.numCrossover_ValueChanged);
            // 
            // numPopSize
            // 
            this.numPopSize.Location = new System.Drawing.Point(135, 88);
            this.numPopSize.Name = "numPopSize";
            this.numPopSize.Size = new System.Drawing.Size(58, 20);
            this.numPopSize.TabIndex = 13;
            this.numPopSize.ValueChanged += new System.EventHandler(this.numPopSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fitness function";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Elites";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mutation Rate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Crossover Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pop. size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seed";
            // 
            // lblExperimentFilename
            // 
            this.lblExperimentFilename.AutoSize = true;
            this.lblExperimentFilename.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperimentFilename.ForeColor = System.Drawing.Color.White;
            this.lblExperimentFilename.Location = new System.Drawing.Point(3, 31);
            this.lblExperimentFilename.Name = "lblExperimentFilename";
            this.lblExperimentFilename.Size = new System.Drawing.Size(0, 16);
            this.lblExperimentFilename.TabIndex = 3;
            // 
            // lblExperimentName
            // 
            this.lblExperimentName.AutoSize = true;
            this.lblExperimentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperimentName.ForeColor = System.Drawing.Color.White;
            this.lblExperimentName.Location = new System.Drawing.Point(3, 9);
            this.lblExperimentName.Name = "lblExperimentName";
            this.lblExperimentName.Size = new System.Drawing.Size(115, 16);
            this.lblExperimentName.TabIndex = 0;
            this.lblExperimentName.Text = "No Experiment";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 270);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(121, 14);
            this.label23.TabIndex = 55;
            this.label23.Text = "Arithmetical cross.";
            // 
            // chkArithCross
            // 
            this.chkArithCross.AutoSize = true;
            this.chkArithCross.Location = new System.Drawing.Point(135, 271);
            this.chkArithCross.Name = "chkArithCross";
            this.chkArithCross.Size = new System.Drawing.Size(15, 14);
            this.chkArithCross.TabIndex = 56;
            this.chkArithCross.UseVisualStyleBackColor = true;
            this.chkArithCross.CheckedChanged += new System.EventHandler(this.chkArithCross_CheckedChanged);
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
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainViewContainer.Panel1.ResumeLayout(false);
            this.MainViewContainer.Panel1.PerformLayout();
            this.MainViewContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).EndInit();
            this.MainViewContainer.ResumeLayout(false);
            this.pnlSimControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnFaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnSlower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnPlay)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem newExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveExperimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveExperimentAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem experimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTerrainTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flatPlaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conicalHillToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadTerrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTerrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Panel pnlSimControls;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem setTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStartPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRandomTerrainToolStripMenuItem;
        private System.Windows.Forms.PictureBox icnStop;
        private System.Windows.Forms.PictureBox icnFaster;
        private System.Windows.Forms.PictureBox icnSlower;
        private System.Windows.Forms.PictureBox icnPause;
        private System.Windows.Forms.PictureBox icnPlay;
        private System.Windows.Forms.ToolStripMenuItem newAgentTopologyToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.CheckBox chkMutCross;
        private System.Windows.Forms.CheckBox chkMutSelect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numGenerations;
        private System.Windows.Forms.ComboBox ddlFitness;
        private System.Windows.Forms.NumericUpDown numElites;
        private System.Windows.Forms.NumericUpDown numMutation;
        private System.Windows.Forms.NumericUpDown numCrossover;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExperimentFilename;
        private System.Windows.Forms.Label lblExperimentName;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numtimeout;
        private System.Windows.Forms.NumericUpDown numLifetime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblGenerationAgelbl;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblBestAvg;
        private System.Windows.Forms.Label lblBestMax;
        private System.Windows.Forms.Label lblBestMin;
        private System.Windows.Forms.Label lblGenAvg;
        private System.Windows.Forms.Label lblGenMax;
        private System.Windows.Forms.Label lblGenMin;
        private System.Windows.Forms.Label lblGenWon;
        private System.Windows.Forms.Label lblGenExp;
        private System.Windows.Forms.Label lblGenAct;
        private System.Windows.Forms.Label lblGenAge;
        private System.Windows.Forms.TextBox txtFitnessExplanation;
        private System.Windows.Forms.Label lblBestPathCost;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem calculateBestPathToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkArithCross;
        private System.Windows.Forms.Label label23;
    }
}

