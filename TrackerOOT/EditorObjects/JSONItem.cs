using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace TrackerOOT.EditorObjects
{
    public class JSONItem : JSONPictureBox
    {
        ObjectPoint InteractiveElement;

        public Point MouseDownLocation;
        
        public JSONItem(ObjectPoint interactiveElement)
        {
            InteractiveElement = interactiveElement;
            InitJSONPictureBox(interactiveElement);
            this.Name = interactiveElement.Name;
            this.Location = new Point(interactiveElement.X, interactiveElement.Y);
            this.Size = interactiveElement.Size;
            this.Image = Image.FromFile(@"Resources/" + interactiveElement.ImageCollection[interactiveElement.IndexFirstImage]);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.MouseHover += InteractiveElement_MouseHover;
            this.MouseLeave += InteractiveElement_MouseLeave;
            this.MouseMove += InteractiveElement_MouseMove;
            this.MouseDown += InteractiveElement_MouseDown;
            this.MouseClick += InteractiveElement_MouseClick;

            this.ToolStripImageCollection.Click += ToolStripImageCollection_Click;
        }

        private void ToolStripImageCollection_Click(object sender, EventArgs e)
        {
            var loadImage = new ImageCollectionBrowser(this);
            if(loadImage.ShowDialog() == DialogResult.OK)
            {
                this.ImageCollection = loadImage.ImageCollection.ToArray();
                this.Image = Image.FromFile(@"Resources/" + this.ImageCollection[0]);
            }
        }

        private void InteractiveElement_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                OptionMenu.Show(Cursor.Position);
            }
            if(e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) != Keys.Control)
            {
                foreach(var control in Editor.ListFocusedControl)
                {
                    control.BackColor = Color.Transparent;
                }
                Editor.ListFocusedControl.Clear();
                this.BackColor = Color.FromArgb(255, 90, 0, 0);
                Editor.ListFocusedControl.Add(this);
            }
            if(e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.BackColor = Color.FromArgb(255, 90, 0, 0);
                Editor.ListFocusedControl.Add(this);
            }
        }

        private void InteractiveElement_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void InteractiveElement_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var deltaX = e.X - MouseDownLocation.X;
                var deltaY = e.Y - MouseDownLocation.Y;
                var menuBar = this.Parent.Controls.Find("MenuBar", false).ToList()[0];
                var menuItemLocation = ((MenuStrip)menuBar).Items.Find("MenuItemLocation", false).ToList()[0];
                if (Editor.ListFocusedControl.Contains(this) && Editor.ListFocusedControl.Count == 1)
                {
                    this.Left += deltaX;
                    this.Top += deltaY;
                    ToolStripX.Text = this.Location.X.ToString();
                    ToolStripY.Text = this.Location.Y.ToString();
                    menuItemLocation.Text = "Location : " + this.Location.X + " | " + this.Location.Y;

                }
                if(Editor.ListFocusedControl.Contains(this) && Editor.ListFocusedControl.Count > 1)
                {
                    this.Left += deltaX;
                    this.Top += deltaY;
                    ToolStripX.Text = this.Location.X.ToString();
                    ToolStripY.Text = this.Location.Y.ToString();
                    menuItemLocation.Text = "Location : " + this.Location.X + " | " + this.Location.Y;

                    foreach (var control in Editor.ListFocusedControl)
                    {
                        if (control.GetType() == typeof(JSONItem) && !control.Equals(this))
                        {
                            control.Left += deltaX;
                            control.Top += deltaY;
                        }
                    }
                }
            }
        }

        private void InteractiveElement_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.Transparent;
        }

        private void InteractiveElement_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(90, 0, 0, 0);
        }
    }
}
