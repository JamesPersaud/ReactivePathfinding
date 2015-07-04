namespace ReactivePathfinding.WinformsVis
{
    partial class TargetForm
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
            this.lblMaxY = new System.Windows.Forms.Label();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.btnCentre = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numIntensity = new System.Windows.Forms.NumericUpDown();
            this.numRadius = new System.Windows.Forms.NumericUpDown();
            this.ddlType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaxY
            // 
            this.lblMaxY.AutoSize = true;
            this.lblMaxY.Location = new System.Drawing.Point(209, 67);
            this.lblMaxY.Name = "lblMaxY";
            this.lblMaxY.Size = new System.Drawing.Size(35, 13);
            this.lblMaxY.TabIndex = 19;
            this.lblMaxY.Text = "label4";
            // 
            // lblMaxX
            // 
            this.lblMaxX.AutoSize = true;
            this.lblMaxX.Location = new System.Drawing.Point(209, 44);
            this.lblMaxX.Name = "lblMaxX";
            this.lblMaxX.Size = new System.Drawing.Size(35, 13);
            this.lblMaxX.TabIndex = 18;
            this.lblMaxX.Text = "label4";
            // 
            // btnCentre
            // 
            this.btnCentre.Location = new System.Drawing.Point(15, 240);
            this.btnCentre.Name = "btnCentre";
            this.btnCentre.Size = new System.Drawing.Size(75, 23);
            this.btnCentre.TabIndex = 17;
            this.btnCentre.Text = "Centre";
            this.btnCentre.UseVisualStyleBackColor = true;
            this.btnCentre.Click += new System.EventHandler(this.btnCentre_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "X";
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(115, 68);
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(75, 20);
            this.numY.TabIndex = 14;
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(115, 42);
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(75, 20);
            this.numX.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Set the target location for this experiment";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(196, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Confirm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Base Intensity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Effective Radius";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Emitter Type";
            // 
            // numIntensity
            // 
            this.numIntensity.Location = new System.Drawing.Point(115, 106);
            this.numIntensity.Name = "numIntensity";
            this.numIntensity.Size = new System.Drawing.Size(75, 20);
            this.numIntensity.TabIndex = 23;
            // 
            // numRadius
            // 
            this.numRadius.Location = new System.Drawing.Point(115, 132);
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new System.Drawing.Size(75, 20);
            this.numRadius.TabIndex = 24;
            // 
            // ddlType
            // 
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "Inverse Square"});
            this.ddlType.Location = new System.Drawing.Point(115, 164);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(121, 21);
            this.ddlType.TabIndex = 25;
            // 
            // TargetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.numRadius);
            this.Controls.Add(this.numIntensity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMaxY);
            this.Controls.Add(this.lblMaxX);
            this.Controls.Add(this.btnCentre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button1);
            this.Name = "TargetForm";
            this.Text = "Target Location";
            this.Load += new System.EventHandler(this.TargetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaxY;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.Button btnCentre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numIntensity;
        private System.Windows.Forms.NumericUpDown numRadius;
        private System.Windows.Forms.ComboBox ddlType;
    }
}