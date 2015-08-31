using System;
using System.Collections.Generic;
using ReactivePathfinding.Core;
using System.Windows.Forms;

namespace ReactivePathfinding.WinformsVis
{
    public class LoadSaveInterface
    {
        /// <summary>
        /// Save the heightmap separately from the rest of the experiment
        /// </summary>        
        public static void SaveHeightmap(Heightmap map)
        {
            if (map != null)
            {
                string oldfilename = map.Filename;

                SaveFileDialog saveHeightmap = new SaveFileDialog();
                saveHeightmap.Filter = "Heightmap|*." + FilesystemSettings.FILE_EXTENSION_HEIGHTMAP;
                saveHeightmap.Title = "Save current Heightmap";
                saveHeightmap.FileName = oldfilename;
                saveHeightmap.InitialDirectory = FilesystemSettings.CurrentPath + FilesystemSettings.PathSeparator + FilesystemSettings.FILE_PATH_HEIGHTMAP;

                bool retry = false;
                do
                {
                    retry = false;
                    if (saveHeightmap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (saveHeightmap.FileName != "")
                        {
                            string fullpath = saveHeightmap.FileName;
                            string[] parts = fullpath.Split(new string[] { FilesystemSettings.PathSeparator }, StringSplitOptions.None);
                            string name = parts[parts.Length - 1];

                            if (name.EndsWith("." + FilesystemSettings.FILE_EXTENSION_HEIGHTMAP))
                            {
                                name.Replace("." + FilesystemSettings.FILE_EXTENSION_HEIGHTMAP, "");
                            }

                            if (!map.SaveAs(name, fullpath))                            
                            {
                                DialogResult result = MessageBox.Show(
                                    "Filesystem error, see log", "Heightmap not saved",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button2);

                                retry = (result == System.Windows.Forms.DialogResult.Retry);
                            }
                        }
                        else
                        {
                            Logging.Instance.Log("Unable to save Heightmap, no file name specified");
                            DialogResult result = MessageBox.Show(
                                "Invalid filename", "Heightmap not saved",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);

                            retry = (result == System.Windows.Forms.DialogResult.Retry);
                        }
                    }
                } while (retry);                
            }
        }

        /// <summary>
        /// load a heightmap
        /// </summary>        
        public static Heightmap LoadHeightmap()
        {            
            OpenFileDialog loadHeightmap = new OpenFileDialog();
            loadHeightmap.Filter = "Heightmap|*." + FilesystemSettings.FILE_EXTENSION_HEIGHTMAP;
            loadHeightmap.Title = "Load Heightmap";
            loadHeightmap.FileName = "";
            loadHeightmap.InitialDirectory = FilesystemSettings.CurrentPath + FilesystemSettings.PathSeparator + FilesystemSettings.FILE_PATH_HEIGHTMAP;

            bool retry = false;
            do
            {
                retry = false;
                if (loadHeightmap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (loadHeightmap.FileName != "")
                    {
                        string fullpath = loadHeightmap.FileName;
                        Heightmap map = Heightmap.LoadFromFile(fullpath);

                        if (map == null)                        
                        {
                            DialogResult result = MessageBox.Show(
                                "Filesystem error, see log", "Heightmap not loaded",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2);

                            retry = (result == System.Windows.Forms.DialogResult.Retry);
                        }

                        return map;
                    }
                    else
                    {
                        Logging.Instance.Log("Unable to load Heightmap, no file name specified");
                        DialogResult result = MessageBox.Show(
                            "Invalid filename", "Heightmap not loaded",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);

                        retry = (result == System.Windows.Forms.DialogResult.Retry);
                    }
                }
            } while (retry);

            return null;
        }

        /// <summary>
        /// Save the agent topology separately from the rest of the experiment
        /// </summary>        
        public static void SaveAgentTemplate(AgentTemplate temp)
        {
            if (temp != null)
            {
                string oldfilename = temp.Filename;

                SaveFileDialog saveTemplate = new SaveFileDialog();
                saveTemplate.Filter = "Agent Template|*." + FilesystemSettings.FILE_EXTENSION_TEMPLATE;
                saveTemplate.Title = "Save current Agent template";
                saveTemplate.FileName = oldfilename;
                saveTemplate.InitialDirectory = FilesystemSettings.CurrentPath + FilesystemSettings.PathSeparator + FilesystemSettings.FILE_PATH_TEMPLATE;

                bool retry = false;
                do
                {
                    retry = false;
                    if (saveTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (saveTemplate.FileName != "")
                        {
                            string fullpath = saveTemplate.FileName;
                            string[] parts = fullpath.Split(new string[] { FilesystemSettings.PathSeparator }, StringSplitOptions.None);
                            string name = parts[parts.Length - 1];

                            if (name.EndsWith("." + FilesystemSettings.FILE_EXTENSION_TEMPLATE))
                            {
                                name.Replace("." + FilesystemSettings.FILE_EXTENSION_TEMPLATE, "");
                            }

                            if (!temp.SaveAs(name, fullpath))
                            {
                                DialogResult result = MessageBox.Show(
                                    "Filesystem error, see log", "Template not saved",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button2);

                                retry = (result == System.Windows.Forms.DialogResult.Retry);
                            }
                        }
                        else
                        {
                            Logging.Instance.Log("Unable to save Template, no file name specified");
                            DialogResult result = MessageBox.Show(
                                "Invalid filename", "Template not saved",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);

                            retry = (result == System.Windows.Forms.DialogResult.Retry);
                        }
                    }
                } while (retry);
            }
        }

        /// <summary>
        /// load an agent template
        /// </summary>        
        public static AgentTemplate LoadAgentTemplate()
        {
            OpenFileDialog loadTemplate = new OpenFileDialog();
            loadTemplate.Filter = "Agent Template|*." + FilesystemSettings.FILE_EXTENSION_TEMPLATE;
            loadTemplate.Title = "Load Template";
            loadTemplate.FileName = "";
            loadTemplate.InitialDirectory = FilesystemSettings.CurrentPath + FilesystemSettings.PathSeparator + FilesystemSettings.FILE_PATH_TEMPLATE;

            bool retry = false;
            do
            {
                retry = false;
                if (loadTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (loadTemplate.FileName != "")
                    {
                        string fullpath = loadTemplate.FileName;
                        AgentTemplate temp = AgentTemplate.LoadFromFile(fullpath);

                        if (temp == null)
                        {
                            DialogResult result = MessageBox.Show(
                                "Filesystem error, see log", "Template not loaded",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2);

                            retry = (result == System.Windows.Forms.DialogResult.Retry);
                        }

                        return temp;
                    }
                    else
                    {
                        Logging.Instance.Log("Unable to load Template, no file name specified");
                        DialogResult result = MessageBox.Show(
                            "Invalid filename", "Template not loaded",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);

                        retry = (result == System.Windows.Forms.DialogResult.Retry);
                    }
                }
            } while (retry);

            return null;
        }
    }
}
