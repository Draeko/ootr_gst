using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerOOT.EditorObjects
{
    public class JSONPictureBox : PictureBox
    {
        protected ContextMenuStrip OptionMenu = new ContextMenuStrip();
        protected ToolStripTextBox ToolStripName = new ToolStripTextBox();
        protected ToolStripTextBox ToolStripX = new ToolStripTextBox();
        protected ToolStripTextBox ToolStripY = new ToolStripTextBox();
        protected ToolStripTextBox ToolStripWidth = new ToolStripTextBox();
        protected ToolStripTextBox ToolStripHeight = new ToolStripTextBox();
        protected ToolStripMenuItem ToolStripImageCollection = new ToolStripMenuItem("[Image collections]");
        protected ToolStripMenuItem ToolStripSaveButton = new ToolStripMenuItem("Save");
        protected ToolStripMenuItem ToolStripRemoveButton = new ToolStripMenuItem("Remove");

        public string[] ImageCollection;

        private ObjectPoint InteractiveElement;

        public void InitJSONPictureBox(ObjectPoint element)
        {
            InteractiveElement = element;
            ToolStripName.Text = element.Name;
            ToolStripX.Text = element.X.ToString();
            ToolStripY.Text = element.Y.ToString();
            ToolStripWidth.Text = element.Size.Width.ToString();
            ToolStripHeight.Text = element.Size.Height.ToString();
            ImageCollection = element.ImageCollection;

            OptionMenu.Items.AddRange
            (
                new ToolStripItem[]
                {
                    ToolStripName,
                    ToolStripX,
                    ToolStripY,
                    ToolStripWidth,
                    ToolStripHeight,
                    ToolStripImageCollection,
                    ToolStripRemoveButton,
                    ToolStripSaveButton
                }
            );

            ToolStripRemoveButton.Click += RemoveButton_Click;
            ToolStripSaveButton.Click += SaveButton_Click;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var item = this.Parent.Controls.Find(InteractiveElement.Name, false).ToList()[0];
            item.Name = ToolStripName.Text;
            item.Location = new Point(Convert.ToInt32(ToolStripX.Text), Convert.ToInt32(ToolStripY.Text));
            item.Size = new Size(Convert.ToInt32(ToolStripWidth.Text), Convert.ToInt32(ToolStripHeight.Text));

            InteractiveElement.Name = ToolStripName.Text;
        }
    }
}
