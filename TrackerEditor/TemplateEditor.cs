using Newtonsoft.Json;
using OOTRandoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerEditor
{
    public partial class TemplateEditor : Form
    {
        private Point mouseLocation;

        public TemplateEditor()
        {
            InitializeComponent();
        }

        public TemplateEditor(string file)
        {
            InitializeComponent();

            Layout CurrentLayout = new Layout();
            CurrentLayout.LoadLayout(this, file);
        }

        private void TemplateEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm editFrom = new EditForm(this, mouseLocation, Guid.NewGuid().ToString());
            editFrom.Show();
        }

        private void TemplateEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
                mouseLocation = e.Location;
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
        }

        private void ExportJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            saveFileDialog.Title = "Save JSON file";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Layouts";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                StringBuilder sbItem = new StringBuilder();
                sbItem.Append("Items :");

                foreach (var control in this.Controls)
                {
                    if (control is EditorEmptyBox)
                    {
                        var emptyBox = control as EditorEmptyBox;
                        if (emptyBox != null && emptyBox.BoxType == "Item")
                        {
                            Item box = new Item();
                            box.BoxName = emptyBox.BoxName;
                            box.Location = emptyBox.Location;
                            box.BoxSize = emptyBox.BoxSize;
                            box.Tag = emptyBox.Tag;
                            box.ImageCollection = emptyBox.ImageCollection;

                            string item = JsonConvert.SerializeObject(box, Formatting.Indented,
                                new JsonSerializerSettings
                                {
                                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                                });
                            sbItem.Append(item);
                            sbItem.Append(',');
                        }
                    }
                }
                File.WriteAllText(saveFileDialog.FileName, sbItem.ToString());
            }
        }

        private void TemplateEditor_Load(object sender, EventArgs e)
        {
            this.MouseDown += TemplateEditor_MouseDown;
            this.CenterToScreen();
        }
    }
}
