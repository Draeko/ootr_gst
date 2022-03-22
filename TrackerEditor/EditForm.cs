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
    public partial class EditForm : Form
    {
        private Form? parentForm;
        private Point CursorPosition;
        private EditorEmptyBox EditBox;

        public EditForm(Form form, Point _MousePosition, string guid)
        {
            InitializeComponent();            
            this.parentForm = form;
            this.textBox_Name.Text = guid;
            this.CursorPosition = _MousePosition;
            textBox_LocationX.Text = this.CursorPosition.X.ToString();
            textBox_LocationY.Text = this.CursorPosition.Y.ToString();
            textBox_SizeX.Text = "32";
            textBox_SizeY.Text = "32";
        }

        public EditForm(EditorEmptyBox box)
        {
            InitializeComponent();

            EditBox = box;
            this.textBox_Name.Text = box.BoxName;
            this.textBox_LocationX.Text = box.Location.X.ToString();
            this.textBox_LocationY.Text = box.Location.Y.ToString();
            this.textBox_SizeX.Text = box.BoxSize.Width.ToString(); 
            this.textBox_SizeY.Text = box.BoxSize.Height.ToString();
            this.comboBox_Type.SelectedItem = box.BoxType;
            if (box.ImageCollection != null && box.ImageCollection.Count > 0)
            {
                LoadExistingImageCollection(box.ImageCollection);
            }
        }

        private void LoadExistingImageCollection(List<string> listImagePath)
        {
            string directory = Directory.GetCurrentDirectory();
            foreach (var imagePath in listImagePath)
            {
                string relativePath = imagePath.Replace(directory, "");
                if(relativePath.StartsWith('\\')) relativePath = relativePath.Remove(0, 1);
                PictureBox pictureBox = new PictureBox()
                {
                    Size = new Size(32, 32),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pictureBox.Click += PictureBox_Click;
                int nbControl = groupBox_ImageCollection.Controls.Count;
                if (nbControl > 0)
                {
                    Control lastControl = groupBox_ImageCollection.Controls[nbControl - 1];
                    pictureBox.Location = new Point(lastControl.Location.X + lastControl.Width, lastControl.Location.Y);
                }
                else
                {
                    pictureBox.Location = new Point(10, 23);
                }
                pictureBox.Image = Image.FromFile(@relativePath);
                pictureBox.Name = relativePath;
                groupBox_ImageCollection.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_Click(object? sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb != null)
            {
                if (pb.BorderStyle != BorderStyle.None)
                {
                    pb.BorderStyle = BorderStyle.None;
                } 
                else
                {
                    pb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void Button_ImageCollectionBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image PNG (*.png)|*.png";
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\Resources";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadExistingImageCollection(openFileDialog1.FileNames.ToList());
            }
        }

        private void Button_ImageCollectionRemove_Click(object sender, EventArgs e)
        {
            List<PictureBox> pbToRemove = new List<PictureBox>();
            List<string> pbToMove = new List<string>();
            foreach (var pb in this.groupBox_ImageCollection.Controls.OfType<PictureBox>())
            {
                if (pb != null)
                {
                    if (pb.BorderStyle == BorderStyle.FixedSingle)
                    {
                        pbToRemove.Add(pb);
                    } 
                    else
                    {
                        pbToMove.Add(pb.Name);
                    }
                }
            }

            groupBox_ImageCollection.Controls.Clear();
            LoadExistingImageCollection(pbToMove);
        }

        private void Button_AddLabel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_RemoveLabel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void Button_TinyImageCollectionMoveRight_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_TinyImageCollectionMoveLeft_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_TinyImageCollectionBrowse_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (EditBox == null)
            {
                EditorEmptyBox emptyBox = new EditorEmptyBox();
                emptyBox.BorderStyle = BorderStyle.FixedSingle;
                emptyBox.BoxName = textBox_Name.Text;
                emptyBox.BoxType = comboBox_Type.Text;
                emptyBox.Location = new Point(Convert.ToInt32(textBox_LocationX.Text), Convert.ToInt32(textBox_LocationY.Text));
                emptyBox.BoxSize = new Size(Convert.ToInt32(textBox_SizeX.Text), Convert.ToInt32(textBox_SizeY.Text));
                emptyBox.ImageCollection = new List<string>();
                emptyBox.SizeMode = PictureBoxSizeMode.StretchImage;

                int nbControl = groupBox_ImageCollection.Controls.Count;
                if (nbControl > 0)
                {
                    foreach (Control control in groupBox_ImageCollection.Controls)
                    {
                        emptyBox.ImageCollection.Add(control.Name);
                    }
                }

                if (emptyBox.ImageCollection[0] != null)
                {
                    emptyBox.Image = Image.FromFile(emptyBox.ImageCollection[0]);
                }

                parentForm.Controls.Add(emptyBox);
            }
            else
            {
                EditBox.BoxName = textBox_Name.Text;
                EditBox.BoxType = comboBox_Type.Text;
                EditBox.Location = new Point(Convert.ToInt32(textBox_LocationX.Text), Convert.ToInt32(textBox_LocationY.Text));
                EditBox.BoxSize = new Size(Convert.ToInt32(textBox_SizeX.Text), Convert.ToInt32(textBox_SizeY.Text));
                EditBox.ImageCollection = new List<string>();

                int nbControl = groupBox_ImageCollection.Controls.Count;
                if (nbControl > 0)
                {
                    foreach (Control control in groupBox_ImageCollection.Controls)
                    {
                        EditBox.ImageCollection.Add(control.Name);
                    }
                }

                if (EditBox.ImageCollection[0] != null)
                {
                    EditBox.Image = Image.FromFile(EditBox.ImageCollection[0]);
                }
            }
            this.Close();
            this.Dispose();
        }

        /**
         * 
         */
        private void Button_ImageCollectionMoveRight_Click(object sender, EventArgs e)
        {
            var listImagePath = new List<string>();
            foreach (var pb in groupBox_ImageCollection.Controls.OfType<PictureBox>())
            {
                listImagePath.Add(pb.Name);
                if(pb.BorderStyle == BorderStyle.FixedSingle)
                {
                    swapPictureBox(ref listImagePath, groupBox_ImageCollection.Controls.GetChildIndex(pb));
                }
            }
            groupBox_ImageCollection.Controls.Clear();

        }

        private void swapPictureBox(ref List<string> listImagePath, int index)
        {
            if(index > 0)
            {
                listImagePath.Add(listImagePath[index-1]);
                listImagePath.Remove(listImagePath[index-1]);
            }
        }

        private void Button_ImageCollectionMoveLeft_Click(object sender, EventArgs e)
        {
            var listImagePath = new List<string>();
            foreach (var pb in groupBox_ImageCollection.Controls.OfType<PictureBox>())
            {
                listImagePath.Add(pb.Name);
                if (pb.BorderStyle == BorderStyle.FixedSingle)
                {
                    swapPictureBox(ref listImagePath, groupBox_ImageCollection.Controls.GetChildIndex(pb));
                }
            }
            groupBox_ImageCollection.Controls.Clear(); 
            LoadExistingImageCollection(listImagePath);
        }
    }
}
