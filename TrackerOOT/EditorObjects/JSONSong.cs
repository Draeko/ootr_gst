using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrackerOOT.EditorObjects
{
    class JSONSong : PictureBox
    {
        ObjectPointSong InteractiveElement;

        private Point MouseDownLocation;
        private ContextMenuStrip OptionMenu = new ContextMenuStrip();

        ToolStripTextBox ToolStripName = new ToolStripTextBox();
        ToolStripTextBox ToolStripX = new ToolStripTextBox();
        ToolStripTextBox ToolStripY = new ToolStripTextBox();
        ToolStripTextBox ToolStripWidth = new ToolStripTextBox();
        ToolStripTextBox ToolStripHeight = new ToolStripTextBox();
        ToolStripMenuItem SaveButton = new ToolStripMenuItem("Save");

        public JSONSong(ObjectPointSong interactiveElement)
        {
            InteractiveElement = interactiveElement;
            this.Name = interactiveElement.Name;
            this.Location = new Point(interactiveElement.X, interactiveElement.Y);
            this.Size = interactiveElement.Size;
            this.Image = Image.FromFile(@"Resources/" + interactiveElement.ImageCollection[0]);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.MouseHover += InteractiveElement_MouseHover;
            this.MouseLeave += InteractiveElement_MouseLeave;
            this.MouseMove += InteractiveElement_MouseMove;
            this.MouseDown += InteractiveElement_MouseDown;
            this.MouseClick += InteractiveElement_MouseClick;

            ToolStripName.Text = interactiveElement.Name;
            ToolStripX.Text = interactiveElement.X.ToString();
            ToolStripY.Text = interactiveElement.Y.ToString();
            ToolStripWidth.Text = interactiveElement.Size.Width.ToString();
            ToolStripHeight.Text = interactiveElement.Size.Height.ToString();

            SaveButton.Click += SaveButton_Click;

            OptionMenu.Items.AddRange
            (
                new ToolStripItem[]
                {
                    ToolStripName,
                    ToolStripX,
                    ToolStripY,
                    ToolStripWidth,
                    ToolStripHeight,
                    SaveButton
                }
            );

            PictureBox TinyImage = new PictureBox();
            TinyImage.BackColor = Color.Transparent;
            TinyImage.Image = Image.FromFile(@"Resources/no-song_16x16.png");
            TinyImage.SizeMode = PictureBoxSizeMode.StretchImage;
            TinyImage.Size = new Size(TinyImage.Image.Width, TinyImage.Image.Height);
            TinyImage.Location = new Point(
                    (this.Size.Width - TinyImage.Width) / 2,
                    this.Size.Height - TinyImage.Height
                );
            this.Controls.Add(TinyImage);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var item = this.Parent.Controls.Find(InteractiveElement.Name, false).ToList()[0];
            item.Name = ToolStripName.Text;
            item.Location = new Point(Convert.ToInt32(ToolStripX.Text), Convert.ToInt32(ToolStripY.Text));
            item.Size = new Size(Convert.ToInt32(ToolStripWidth.Text), Convert.ToInt32(ToolStripHeight.Text));
        }

        private void InteractiveElement_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                OptionMenu.Show(Cursor.Position);
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
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }

            InteractiveElement.X = this.Location.X;
            InteractiveElement.Y = this.Location.Y;
            ToolStripX.Text = this.Location.X.ToString();
            ToolStripY.Text = this.Location.Y.ToString();
        }

        private void InteractiveElement_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void InteractiveElement_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(90, 0, 0, 0);
        }
    }
}
