namespace ReactivePathfinding.WinformsVis
{
    partial class NewTerrain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numMapWidth = new System.Windows.Forms.NumericUpDown();
            this.numMapHeight = new System.Windows.Forms.NumericUpDown();
            this.numSeed = new System.Windows.Forms.NumericUpDown();
            this.numSampleWidth = new System.Windows.Forms.NumericUpDown();
            this.numSampleHeight = new System.Windows.Forms.NumericUpDown();
            this.numOctaves = new System.Windows.Forms.NumericUpDown();
            this.numLacunarity = new System.Windows.Forms.NumericUpDown();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.numGain = new System.Windows.Forms.NumericUpDown();
            this.numSpectral = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLacunarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectral)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create a new Terrain";
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
            this.ddlType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "Procedural",
            "Flat Plane",
            "Conical Hill"});
            this.ddlType.Location = new System.Drawing.Point(212, 44);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(134, 22);
            this.ddlType.TabIndex = 2;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numSpectral);
            this.groupBox1.Controls.Add(this.numGain);
            this.groupBox1.Controls.Add(this.numOffset);
            this.groupBox1.Controls.Add(this.numLacunarity);
            this.groupBox1.Controls.Add(this.numOctaves);
            this.groupBox1.Controls.Add(this.numSampleHeight);
            this.groupBox1.Controls.Add(this.numSampleWidth);
            this.groupBox1.Controls.Add(this.numSeed);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 271);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procedural Parameters";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Lacunarity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Offset";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "Gain";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Spectral";
            // 
            // numMapWidth
            // 
            this.numMapWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMapWidth.Location = new System.Drawing.Point(212, 72);
            this.numMapWidth.Name = "numMapWidth";
            this.numMapWidth.Size = new System.Drawing.Size(134, 22);
            this.numMapWidth.TabIndex = 8;
            // 
            // numMapHeight
            // 
            this.numMapHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMapHeight.Location = new System.Drawing.Point(212, 100);
            this.numMapHeight.Name = "numMapHeight";
            this.numMapHeight.Size = new System.Drawing.Size(134, 22);
            this.numMapHeight.TabIndex = 9;
            // 
            // numSeed
            // 
            this.numSeed.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSeed.Location = new System.Drawing.Point(196, 34);
            this.numSeed.Name = "numSeed";
            this.numSeed.Size = new System.Drawing.Size(134, 22);
            this.numSeed.TabIndex = 10;
            // 
            // numSampleWidth
            // 
            this.numSampleWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSampleWidth.Location = new System.Drawing.Point(196, 63);
            this.numSampleWidth.Name = "numSampleWidth";
            this.numSampleWidth.Size = new System.Drawing.Size(134, 22);
            this.numSampleWidth.TabIndex = 13;
            // 
            // numSampleHeight
            // 
            this.numSampleHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSampleHeight.Location = new System.Drawing.Point(196, 91);
            this.numSampleHeight.Name = "numSampleHeight";
            this.numSampleHeight.Size = new System.Drawing.Size(134, 22);
            this.numSampleHeight.TabIndex = 14;
            // 
            // numOctaves
            // 
            this.numOctaves.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOctaves.Location = new System.Drawing.Point(196, 119);
            this.numOctaves.Name = "numOctaves";
            this.numOctaves.Size = new System.Drawing.Size(134, 22);
            this.numOctaves.TabIndex = 15;
            // 
            // numLacunarity
            // 
            this.numLacunarity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLacunarity.Location = new System.Drawing.Point(196, 147);
            this.numLacunarity.Name = "numLacunarity";
            this.numLacunarity.Size = new System.Drawing.Size(134, 22);
            this.numLacunarity.TabIndex = 16;
            // 
            // numOffset
            // 
            this.numOffset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOffset.Location = new System.Drawing.Point(196, 175);
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(134, 22);
            this.numOffset.TabIndex = 17;
            // 
            // numGain
            // 
            this.numGain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGain.Location = new System.Drawing.Point(196, 203);
            this.numGain.Name = "numGain";
            this.numGain.Size = new System.Drawing.Size(134, 22);
            this.numGain.TabIndex = 18;
            // 
            // numSpectral
            // 
            this.numSpectral.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpectral.Location = new System.Drawing.Point(196, 231);
            this.numSpectral.Name = "numSpectral";
            this.numSpectral.Size = new System.Drawing.Size(134, 22);
            this.numSpectral.TabIndex = 19;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(271, 420);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Confirm";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(190, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewTerrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 449);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.numMapHeight);
            this.Controls.Add(this.numMapWidth);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitle);
            this.Name = "NewTerrain";
            this.Text = "NewTerrain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLacunarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectral)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}