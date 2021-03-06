﻿using System;
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
    public partial class NewHeightmapWindow : Form
    {
        public HeightmapSettings Settings;
        public Heightmap Map;        
        public Experiment Experiment;

        private static PreviewWindow preview = null;

        public NewHeightmapWindow()
        {
            InitializeComponent();            

            this.FormClosing += NewTerrainWindow_FormClosing;

            ddlType.Items.Add(HeightMapType.PROCEDURAL);
            ddlType.Items.Add(HeightMapType.PLANE);
            ddlType.Items.Add(HeightMapType.CONICAL_HILL);
        }

        private bool ValidateSettings()
        {
            if (Settings.MapHeight > Settings.SampleHeight || Settings.MapWidth > Settings.SampleWidth)
            {
                MessageBox.Show("Map dimensions cannot be larger than " + Environment.NewLine + "sample dimensions.","Invalid Settings");
                return false;
            }

            return true;
        }

        void NewTerrainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (preview != null)
                preview.Close();
        }        

        /// <summary>
        /// Set up the form 
        /// </summary>        
        public void initialise(Experiment e ,HeightmapSettings settings, HeightMapType type)
        {
            Experiment = e;
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
            numSmooth.Value = (Decimal)settings.Smooth;

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
            Settings.Smooth = (float)numSmooth.Value;
        }

        private void btnRandomSeed_Click(object sender, EventArgs e)
        {
            numSeed.Value = Experiment.Random.GetInt(0, int.MaxValue -1);
        }

        /// <summary>
        /// Create the heightmap and pass it to the calling window
        /// </summary>        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            updateSettings();

            if (ValidateSettings())
            {
                Map = Heightmap.CreateHeightmap(Settings, (HeightMapType)ddlType.SelectedItem);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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

            if (ValidateSettings())
            {
                Map = Heightmap.CreateHeightmap(Settings, (HeightMapType)ddlType.SelectedItem);

                if (preview == null)
                {
                    preview = new PreviewWindow();
                    preview.Map = Map;
                    preview.Show();
                }
                else
                {
                    preview.Map = Map;
                    preview.ForceRedraw();
                }
            }
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

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
