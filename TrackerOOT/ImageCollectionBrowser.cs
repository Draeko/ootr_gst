using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerOOT.EditorObjects;

namespace TrackerOOT
{
    public partial class ImageCollectionBrowser : Form
    {
        public List<string> ImageCollection;

        public ImageCollectionBrowser()
        {
            InitializeComponent();
        }

        public ImageCollectionBrowser(JSONItem data)
        {
            InitializeComponent();
            ImageCollection = data.ImageCollection.ToList();
            refreshListBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.InitialDirectory = "./Resources/";
                openfile.Filter = "Image Files (*.PNG)|*.PNG|All files (*.*)|*.*";
                openfile.FilterIndex = 2;
                openfile.RestoreDirectory = true;

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    var name = openfile.FileName.Split('\\');

                    this.ImageCollection.Add(name[name.Length - 1]);
                    refreshListBox();
                }
            }
        }

        private void refreshListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(this.ImageCollection.ToArray());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.ImageCollection.Remove(listBox1.SelectedItem.ToString());
            refreshListBox();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
