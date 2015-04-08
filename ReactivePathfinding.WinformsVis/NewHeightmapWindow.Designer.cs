namespace ReactivePathfinding.WinformsVis
{
    partial class NewHeightmapWindow
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpProcedural = new System.Windows.Forms.GroupBox();
            this.numSmooth = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRandomSeed = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.numSpectral = new System.Windows.Forms.NumericUpDown();
            this.numGain = new System.Windows.Forms.NumericUpDown();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.numLacunarity = new System.Windows.Forms.NumericUpDown();
            this.numOctaves = new System.Windows.Forms.NumericUpDown();
            this.numSampleHeight = new System.Windows.Forms.NumericUpDown();
            this.numSampleWidth = new System.Windows.Forms.NumericUpDown();
            this.numSeed = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMapWidth = new System.Windows.Forms.NumericUpDown();
            this.numMapHeight = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.grpProcedural.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLacunarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create a new Heightmap";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(13, 47);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 14);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type";
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(212, 44);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(134, 22);
            this.ddlType.TabIndex = 2;
            this.ddlType.SelectedIndexChanged += new System.EventHandler(this.ddlType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Map Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sample Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sample Height";
            // 
            // grpProcedural
            // 
            this.grpProcedural.Controls.Add(this.numSmooth);
            this.grpProcedural.Controls.Add(this.label12);
            this.grpProcedural.Controls.Add(this.btnRandomSeed);
            this.grpProcedural.Controls.Add(this.label11);
            this.grpProcedural.Controls.Add(this.numFrequency);
            this.grpProcedural.Controls.Add(this.numSpectral);
            this.grpProcedural.Controls.Add(this.numGain);
            this.grpProcedural.Controls.Add(this.numOffset);
            this.grpProcedural.Controls.Add(this.numLacunarity);
            this.grpProcedural.Controls.Add(this.numOctaves);
            this.grpProcedural.Controls.Add(this.numSampleHeight);
            this.grpProcedural.Controls.Add(this.numSampleWidth);
            this.grpProcedural.Controls.Add(this.numSeed);
            this.grpProcedural.Controls.Add(this.label10);
            this.grpProcedural.Controls.Add(this.label9);
            this.grpProcedural.Controls.Add(this.label8);
            this.grpProcedural.Controls.Add(this.label7);
            this.grpProcedural.Controls.Add(this.label6);
            this.grpProcedural.Controls.Add(this.label5);
            this.grpProcedural.Controls.Add(this.label3);
            this.grpProcedural.Controls.Add(this.label4);
            this.grpProcedural.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProcedural.Location = new System.Drawing.Point(16, 143);
            this.grpProcedural.Name = "grpProcedural";
            this.grpProcedural.Size = new System.Drawing.Size(336, 333);
            this.grpProcedural.TabIndex = 7;
            this.grpProcedural.TabStop = false;
            this.grpProcedural.Text = "Procedural Parameters";
            // 
            // numSmooth
            // 
            this.numSmooth.DecimalPlaces = 2;
            this.numSmooth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSmooth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numSmooth.Location = new System.Drawing.Point(196, 233);
            this.numSmooth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numSmooth.Name = "numSmooth";
            this.numSmooth.Size = new System.Drawing.Size(134, 22);
            this.numSmooth.TabIndex = 23;
            this.numSmooth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 14);
            this.label12.TabIndex = 22;
            this.label12.Text = "Smooth";
            // 
            // btnRandomSeed
            // 
            this.btnRandomSeed.Location = new System.Drawing.Point(196, 32);
            this.btnRandomSeed.Name = "btnRandomSeed";
            this.btnRandomSeed.Size = new System.Drawing.Size(38, 23);
            this.btnRandomSeed.TabIndex = 13;
            this.btnRandomSeed.Text = "rnd";
            this.btnRandomSeed.UseVisualStyleBackColor = true;
            this.btnRandomSeed.Click += new System.EventHandler(this.btnRandomSeed_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 14);
            this.label11.TabIndex = 21;
            this.label11.Text = "Frequency";
            // 
            // numFrequency
            // 
            this.numFrequency.DecimalPlaces = 1;
            this.numFrequency.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFrequency.Location = new System.Drawing.Point(196, 149);
            this.numFrequency.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrequency.Name = "numFrequency";
            this.numFrequency.Size = new System.Drawing.Size(134, 22);
            this.numFrequency.TabIndex = 20;
            this.numFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSpectral
            // 
            this.numSpectral.DecimalPlaces = 1;
            this.numSpectral.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpectral.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSpectral.Location = new System.Drawing.Point(196, 205);
            this.numSpectral.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpectral.Name = "numSpectral";
            this.numSpectral.Size = new System.Drawing.Size(134, 22);
            this.numSpectral.TabIndex = 19;
            // 
            // numGain
            // 
            this.numGain.DecimalPlaces = 1;
            this.numGain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numGain.Location = new System.Drawing.Point(196, 303);
            this.numGain.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGain.Name = "numGain";
            this.numGain.Size = new System.Drawing.Size(134, 22);
            this.numGain.TabIndex = 18;
            // 
            // numOffset
            // 
            this.numOffset.DecimalPlaces = 1;
            this.numOffset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOffset.Location = new System.Drawing.Point(196, 275);
            this.numOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(134, 22);
            this.numOffset.TabIndex = 17;
            // 
            // numLacunarity
            // 
            this.numLacunarity.DecimalPlaces = 1;
            this.numLacunarity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLacunarity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLacunarity.Location = new System.Drawing.Point(196, 177);
            this.numLacunarity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLacunarity.Name = "numLacunarity";
            this.numLacunarity.Size = new System.Drawing.Size(134, 22);
            this.numLacunarity.TabIndex = 16;
            // 
            // numOctaves
            // 
            this.numOctaves.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOctaves.Location = new System.Drawing.Point(196, 121);
            this.numOctaves.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numOctaves.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOctaves.Name = "numOctaves";
            this.numOctaves.Size = new System.Drawing.Size(134, 22);
            this.numOctaves.TabIndex = 15;
            this.numOctaves.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSampleHeight
            // 
            this.numSampleHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSampleHeight.Location = new System.Drawing.Point(196, 91);
            this.numSampleHeight.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numSampleHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSampleHeight.Name = "numSampleHeight";
            this.numSampleHeight.Size = new System.Drawing.Size(134, 22);
            this.numSampleHeight.TabIndex = 14;
            this.numSampleHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numSampleWidth
            // 
            this.numSampleWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSampleWidth.Location = new System.Drawing.Point(196, 63);
            this.numSampleWidth.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numSampleWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSampleWidth.Name = "numSampleWidth";
            this.numSampleWidth.Size = new System.Drawing.Size(134, 22);
            this.numSampleWidth.TabIndex = 13;
            this.numSampleWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numSeed
            // 
            this.numSeed.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSeed.Location = new System.Drawing.Point(240, 34);
            this.numSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSeed.Name = "numSeed";
            this.numSeed.Size = new System.Drawing.Size(90, 22);
            this.numSeed.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Spectral Exp.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "Gain";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Offset";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Lacunarity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Octaves";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Seed";
            // 
            // numMapWidth
            // 
            this.numMapWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMapWidth.Location = new System.Drawing.Point(212, 72);
            this.numMapWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numMapWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMapWidth.Name = "numMapWidth";
            this.numMapWidth.Size = new System.Drawing.Size(134, 22);
            this.numMapWidth.TabIndex = 8;
            this.numMapWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numMapHeight
            // 
            this.numMapHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMapHeight.Location = new System.Drawing.Point(212, 100);
            this.numMapHeight.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numMapHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMapHeight.Name = "numMapHeight";
            this.numMapHeight.Size = new System.Drawing.Size(134, 22);
            this.numMapHeight.TabIndex = 9;
            this.numMapHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(277, 492);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Confirm";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(16, 492);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // NewHeightmapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 527);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.numMapHeight);
            this.Controls.Add(this.numMapWidth);
            this.Controls.Add(this.grpProcedural);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewHeightmapWindow";
            this.Text = "New Heightmap";
            this.grpProcedural.ResumeLayout(false);
            this.grpProcedural.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLacunarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpProcedural;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSpectral;
        private System.Windows.Forms.NumericUpDown numGain;
        private System.Windows.Forms.NumericUpDown numOffset;
        private System.Windows.Forms.NumericUpDown numLacunarity;
        private System.Windows.Forms.NumericUpDown numOctaves;
        private System.Windows.Forms.NumericUpDown numSampleHeight;
        private System.Windows.Forms.NumericUpDown numSampleWidth;
        private System.Windows.Forms.NumericUpDown numSeed;
        private System.Windows.Forms.NumericUpDown numMapWidth;
        private System.Windows.Forms.NumericUpDown numMapHeight;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnRandomSeed;
        private System.Windows.Forms.NumericUpDown numSmooth;
        private System.Windows.Forms.Label label12;
    }
}