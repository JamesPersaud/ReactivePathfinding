namespace ReactivePathfinding.WinformsVis
{
    partial class StartForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCentre = new System.Windows.Forms.Button();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.lblMaxY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(239, 103);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Confirm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set the start location for this experiment";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(38, 45);
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(75, 20);
            this.numX.TabIndex = 3;
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(38, 68);
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(75, 20);
            this.numY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnCentre
            // 
            this.btnCentre.Location = new System.Drawing.Point(38, 103);
            this.btnCentre.Name = "btnCentre";
            this.btnCentre.Size = new System.Drawing.Size(75, 23);
            this.btnCentre.TabIndex = 7;
            this.btnCentre.Text = "Centre";
            this.btnCentre.UseVisualStyleBackColor = true;
            this.btnCentre.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblMaxX
            // 
            this.lblMaxX.AutoSize = true;
            this.lblMaxX.Location = new System.Drawing.Point(132, 47);
            this.lblMaxX.Name = "lblMaxX";
            this.lblMaxX.Size = new System.Drawing.Size(35, 13);
            this.lblMaxX.TabIndex = 8;
            this.lblMaxX.Text = "label4";
            // 
            // lblMaxY
            // 
            this.lblMaxY.AutoSize = true;
            this.lblMaxY.Location = new System.Drawing.Point(132, 70);
            this.lblMaxY.Name = "lblMaxY";
            this.lblMaxY.Size = new System.Drawing.Size(35, 13);
            this.lblMaxY.TabIndex = 9;
            this.lblMaxY.Text = "label4";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 138);
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
            this.Name = "StartForm";
            this.Text = "Starting Location";
            this.Load += new System.EventHandler(this.StartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCentre;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.Label lblMaxY;
    }
}