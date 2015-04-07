using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.WinformsVis
{
    public partial class NewTerrainWindow : Form
    {
        public HeightmapSettings Settings;
        public Heightmap Map;
        public static PRNG random = new PRNG();

        public NewTerrainWindow()
        {
            InitializeComponent();

            ddlType.Items.Add(HeightMapType.PROCEDURAL);
            ddlType.Items.Add(HeightMapType.PLANE);
            ddlType.Items.Add(HeightMapType.CONICAL_HILL);
        }        

        /// <summary>
        /// Set up the form 
        /// </summary>        
        public void initialise(HeightmapSettings settings, HeightMapType type)
        {
            ddlType.SelectedItem = type;

            numFrequency.Value = (Decimal)settings.Frequency;
            numGain.Value = (Decimal)settings.Gain;
            numLacunarity.Value = (Decimal)settings.Lacunarity;
            numMapHeight.Value = (Decimal)settings.MapHeight;
            numMapWidth.Value = (Decimal)settings.MapWidth;
            numOctaves.Value = (Decimal)settings.Octaves;
            numOffset.Value = (Decimal)settings.Offset;
            numSampleHeight.Value = (Decimal)settings.SampleHeight;
            numSampleWidth.Value = (Decimal)settings.SampleWidth;
            numSeed.Value = (Decimal)settings.Seed;
            numSpectral.Value = (Decimal)settings.Spectral;

            this.Settings = settings;
        }

        private void updateSettings()
        {
            Settings.Frequency = (float)numFrequency.Value;
            Settings.Gain = (float)numGain.Value;
            Settings.Lacunarity = (float)numLacunarity.Value;
            Settings.MapHeight = (int)numMapHeight.Value;
            Settings.MapWidth = (int)numMapWidth.Value;
            Settings.Octaves = (float)numOctaves.Value;
            Settings.Offset = (float)numOffset.Value;
            Settings.SampleHeight = (int)numSampleHeight.Value;
            Settings.SampleWidth = (int)numSampleWidth.Value;
            Settings.Seed = (int)numSeed.Value;
            Settings.Spectral = (float)numSpectral.Value;
        }

        private void btnRandomSeed_Click(object sender, EventArgs e)
        {
            numSeed.Value = random.GetInt(0, int.MaxValue -1);
        }

        /// <summary>
        /// Create the heightmap and pass it to the calling window
        /// </summary>        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            updateSettings();
            Map = Heightmap.CreateHeightmap(Settings, (HeightMapType)ddlType.SelectedItem);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Create a hightmap for preview
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            updateSettings();
            Map = Heightmap.CreateHeightmap(Settings, (HeightMapType)ddlType.SelectedItem);

            //preview window
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool procedural = ((HeightMapType)ddlType.SelectedItem == HeightMapType.PROCEDURAL);

            if (grpProcedural.Enabled != procedural)
            {
                foreach (Control c in grpProcedural.Controls)                
                    c.Enabled = procedural;

                grpProcedural.Enabled = procedural;
            }
        }
    }
}
