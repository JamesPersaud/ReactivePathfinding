using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactivePathfinding.WinformsVis
{
    public partial class CreateExperiment : Form
    {
        public string Name;

        public CreateExperiment()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                Name = txtName.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                lblNameValidation.Visible = true;
            }
        }

        private void CreateExperiment_Load(object sender, EventArgs e)
        {
            btnCreate.Select();
        }        

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)            
                btnCreate.PerformClick();            
        }        
    }
}
