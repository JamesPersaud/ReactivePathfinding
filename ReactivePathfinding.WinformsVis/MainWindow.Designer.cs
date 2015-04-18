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
            this.lblFPS = new System.Windows.Forms.Label();
            this.glControl = new OpenTK.GLControl();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblExperimentFilename = new System.Windows.Forms.Label();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.lblExperimentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).BeginInit();
            this.MainViewContainer.Panel1.SuspendLayout();
            this.MainViewContainer.Panel2.SuspendLayout();
            this.MainViewContainer.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(265, 6);
            // 
            // saveTerrainToolStripMenuItem
            // 
            this.saveTerrainToolStripMenuItem.Name = "saveTerrainToolStripMenuItem";
            this.saveTerrainToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.saveTerrainToolStripMenuItem.Text = "Save Heightmap As";
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
            this.MainViewContainer.Panel1.Controls.Add(this.lblFPS);
            this.MainViewContainer.Panel1.Controls.Add(this.glControl);
            this.MainViewContainer.Panel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // MainViewContainer.Panel2
            // 
            this.MainViewContainer.Panel2.Controls.Add(this.pnlControls);
            this.MainViewContainer.Size = new System.Drawing.Size(1008, 706);
            this.MainViewContainer.SplitterDistance = 808;
            this.MainViewContainer.TabIndex = 3;
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
            this.glControl.Size = new System.Drawing.Size(808, 706);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseEnter += new System.EventHandler(this.glControl_MouseEnter);
            this.glControl.MouseLeave += new System.EventHandler(this.glControl_MouseLeave);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlControls.Controls.Add(this.label8);
            this.pnlControls.Controls.Add(this.numericUpDown6);
            this.pnlControls.Controls.Add(this.button1);
            this.pnlControls.Controls.Add(this.comboBox1);
            this.pnlControls.Controls.Add(this.numericUpDown5);
            this.pnlControls.Controls.Add(this.numericUpDown4);
            this.pnlControls.Controls.Add(this.numericUpDown3);
            this.pnlControls.Controls.Add(this.numericUpDown2);
            this.pnlControls.Controls.Add(this.numericUpDown1);
            this.pnlControls.Controls.Add(this.txtGoal);
            this.pnlControls.Controls.Add(this.label7);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.lblExperimentFilename);
            this.pnlControls.Controls.Add(this.txtContext);
            this.pnlControls.Controls.Add(this.lblExperimentName);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(196, 706);
            this.pnlControls.TabIndex = 0;
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
            // txtContext
            // 
            this.txtContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtContext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtContext.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContext.ForeColor = System.Drawing.Color.White;
            this.txtContext.Location = new System.Drawing.Point(0, 433);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ReadOnly = true;
            this.txtContext.Size = new System.Drawing.Size(196, 273);
            this.txtContext.TabIndex = 2;
            this.txtContext.WordWrap = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pop. size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Crossover Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mutation Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Elitism Thresh.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fitness function";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Goal";
            // 
            // txtGoal
            // 
            this.txtGoal.BackColor = System.Drawing.Color.Black;
            this.txtGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoal.ForeColor = System.Drawing.Color.White;
            this.txtGoal.Location = new System.Drawing.Point(0, 362);
            this.txtGoal.Multiline = true;
            this.txtGoal.Name = "txtGoal";
            this.txtGoal.Size = new System.Drawing.Size(196, 65);
            this.txtGoal.TabIndex = 11;
            this.txtGoal.Text = "The goal of this experiment is to evolve forward motion in the agents";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(135, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(135, 90);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Location = new System.Drawing.Point(135, 153);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown3.TabIndex = 14;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 2;
            this.numericUpDown4.Location = new System.Drawing.Point(135, 179);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown4.TabIndex = 15;
            this.numericUpDown4.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 2;
            this.numericUpDown5.Location = new System.Drawing.Point(135, 207);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown5.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Total Distance"});
            this.comboBox1.Location = new System.Drawing.Point(6, 278);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(135, 116);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown6.TabIndex = 19;
            this.numericUpDown6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "Generations to run";
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
            this.MainViewContainer.Panel1.ResumeLayout(false);
            this.MainViewContainer.Panel1.PerformLayout();
            this.MainViewContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainViewContainer)).EndInit();
            this.MainViewContainer.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
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
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label lblExperimentFilename;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Button button1;
    }
}

