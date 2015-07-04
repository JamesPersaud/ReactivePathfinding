namespace ReactivePathfinding.WinformsVis
{
    partial class AgentForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddlAgentTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSensorRadius = new System.Windows.Forms.NumericUpDown();
            this.numSensorAngle = new System.Windows.Forms.NumericUpDown();
            this.ddlSensorType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddSensor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddlConnectionActuator = new System.Windows.Forms.ComboBox();
            this.ddlConnectionSensor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlConnectionType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.lstSensors = new System.Windows.Forms.ListBox();
            this.lstConnections = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSensorRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensorAngle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(407, 581);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Confirm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 581);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ddlAgentTemplate
            // 
            this.ddlAgentTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAgentTemplate.FormattingEnabled = true;
            this.ddlAgentTemplate.Location = new System.Drawing.Point(108, 52);
            this.ddlAgentTemplate.Name = "ddlAgentTemplate";
            this.ddlAgentTemplate.Size = new System.Drawing.Size(374, 21);
            this.ddlAgentTemplate.TabIndex = 2;
            this.ddlAgentTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.ddlAgentTemplate.SelectionChangeCommitted += new System.EventHandler(this.ddlAgentTemplate_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set the agent topology for this experiment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose Template";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numSensorRadius);
            this.groupBox1.Controls.Add(this.numSensorAngle);
            this.groupBox1.Controls.Add(this.ddlSensorType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAddSensor);
            this.groupBox1.Location = new System.Drawing.Point(15, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 79);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Sensor";
            // 
            // numSensorRadius
            // 
            this.numSensorRadius.DecimalPlaces = 2;
            this.numSensorRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSensorRadius.Location = new System.Drawing.Point(225, 48);
            this.numSensorRadius.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSensorRadius.Name = "numSensorRadius";
            this.numSensorRadius.Size = new System.Drawing.Size(120, 20);
            this.numSensorRadius.TabIndex = 16;
            // 
            // numSensorAngle
            // 
            this.numSensorAngle.DecimalPlaces = 2;
            this.numSensorAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSensorAngle.Location = new System.Drawing.Point(53, 48);
            this.numSensorAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numSensorAngle.Name = "numSensorAngle";
            this.numSensorAngle.Size = new System.Drawing.Size(120, 20);
            this.numSensorAngle.TabIndex = 15;
            // 
            // ddlSensorType
            // 
            this.ddlSensorType.FormattingEnabled = true;
            this.ddlSensorType.Location = new System.Drawing.Point(53, 21);
            this.ddlSensorType.Name = "ddlSensorType";
            this.ddlSensorType.Size = new System.Drawing.Size(292, 21);
            this.ddlSensorType.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Radius";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Angle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type";
            // 
            // btnAddSensor
            // 
            this.btnAddSensor.Location = new System.Drawing.Point(386, 45);
            this.btnAddSensor.Name = "btnAddSensor";
            this.btnAddSensor.Size = new System.Drawing.Size(75, 23);
            this.btnAddSensor.TabIndex = 0;
            this.btnAddSensor.Text = "Add";
            this.btnAddSensor.UseVisualStyleBackColor = true;
            this.btnAddSensor.Click += new System.EventHandler(this.btnAddSensor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlConnectionActuator);
            this.groupBox2.Controls.Add(this.ddlConnectionSensor);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ddlConnectionType);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAddConnection);
            this.groupBox2.Location = new System.Drawing.Point(15, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 84);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Connection";
            // 
            // ddlConnectionActuator
            // 
            this.ddlConnectionActuator.FormattingEnabled = true;
            this.ddlConnectionActuator.Location = new System.Drawing.Point(225, 52);
            this.ddlConnectionActuator.Name = "ddlConnectionActuator";
            this.ddlConnectionActuator.Size = new System.Drawing.Size(120, 21);
            this.ddlConnectionActuator.TabIndex = 20;
            this.ddlConnectionActuator.SelectedIndexChanged += new System.EventHandler(this.ddlConnectionActuator_SelectedIndexChanged);
            // 
            // ddlConnectionSensor
            // 
            this.ddlConnectionSensor.FormattingEnabled = true;
            this.ddlConnectionSensor.Location = new System.Drawing.Point(53, 52);
            this.ddlConnectionSensor.Name = "ddlConnectionSensor";
            this.ddlConnectionSensor.Size = new System.Drawing.Size(120, 21);
            this.ddlConnectionSensor.TabIndex = 19;
            this.ddlConnectionSensor.SelectedIndexChanged += new System.EventHandler(this.ddlConnectionSensor_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Actuator";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sensor";
            // 
            // ddlConnectionType
            // 
            this.ddlConnectionType.FormattingEnabled = true;
            this.ddlConnectionType.Location = new System.Drawing.Point(53, 25);
            this.ddlConnectionType.Name = "ddlConnectionType";
            this.ddlConnectionType.Size = new System.Drawing.Size(292, 21);
            this.ddlConnectionType.TabIndex = 17;
            this.ddlConnectionType.SelectedIndexChanged += new System.EventHandler(this.ddlConnectionType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Type";
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(386, 50);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(75, 23);
            this.btnAddConnection.TabIndex = 1;
            this.btnAddConnection.Text = "Add";
            this.btnAddConnection.UseVisualStyleBackColor = true;
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // lstSensors
            // 
            this.lstSensors.FormattingEnabled = true;
            this.lstSensors.Location = new System.Drawing.Point(15, 267);
            this.lstSensors.Name = "lstSensors";
            this.lstSensors.Size = new System.Drawing.Size(467, 121);
            this.lstSensors.TabIndex = 8;
            // 
            // lstConnections
            // 
            this.lstConnections.FormattingEnabled = true;
            this.lstConnections.Location = new System.Drawing.Point(15, 407);
            this.lstConnections.Name = "lstConnections";
            this.lstConnections.Size = new System.Drawing.Size(467, 160);
            this.lstConnections.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Connections";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sensors";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(96, 581);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // AgentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 616);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstConnections);
            this.Controls.Add(this.lstSensors);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlAgentTemplate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "AgentForm";
            this.Text = "Agent Topology";
            this.Load += new System.EventHandler(this.AgentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSensorRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensorAngle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlAgentTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstSensors;
        private System.Windows.Forms.ListBox lstConnections;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddSensor;
        private System.Windows.Forms.Button btnAddConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSensorRadius;
        private System.Windows.Forms.NumericUpDown numSensorAngle;
        private System.Windows.Forms.ComboBox ddlSensorType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlConnectionType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlConnectionActuator;
        private System.Windows.Forms.ComboBox ddlConnectionSensor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReset;
    }
}