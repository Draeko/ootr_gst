using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrackerOOT
{
    class Item : PictureBox
    {
        List<string> listImageName = new List<string>();
        bool isMouseDown = false;

        Size ItemSize;
        public Item(ObjectPoint data)
        {
            if(data.ImageCollection != null)
                listImageName = data.ImageCollection.ToList();

            ItemSize = data.Size;

            this.BackColor = Color.Transparent;
            if (listImageName.Count > 0)
            {
                this.Name = listImageName[data.IndexFirstImage];
                this.Image = Image.FromFile(@"Resources/" + listImageName[data.IndexFirstImage]);
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Size = ItemSize;
            }            
            this.Location = new Point(data.X, data.Y);
            this.TabStop = false;
            this.AllowDrop = false;
            this.MouseUp += this.Click_MouseUp;
            this.MouseDown += this.Click_MouseDown;
            this.MouseMove += this.Click_MouseMove;
            if(Form1.EnableMouseWheel_Items)
                this.MouseWheel += this.Item_MouseWheel;
        }

        private void Item_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (Form1.MouseWheel_Items_IncreaseWithScrollUp) ItemNextImage(); else ItemPreviousImage();
            }

            if(e.Delta < 0)
            {
                if (Form1.MouseWheel_Items_IncreaseWithScrollUp) ItemPreviousImage(); else ItemNextImage();
            }
        }

        private void ItemNextImage()
        {
            var index = listImageName.FindIndex(x => x == this.Name);
            if (index >= listImageName.Count - 1)
            {
                this.Image = Image.FromFile(@"Resources/" + listImageName[0]);
                this.Name = listImageName[0];
            }
            else
            {
                this.Image = Image.FromFile(@"Resources/" + listImageName[index + 1]);
                this.Name = listImageName[index + 1];
            }
        }

        private void ItemPreviousImage()
        {
            var index = listImageName.FindIndex(x => x == this.Name);
            if (index == 0)
            {
                this.Image = Image.FromFile(@"Resources/" + listImageName[listImageName.Count - 1]);
                this.Name = listImageName[listImageName.Count - 1];
            }
            else
            {
                this.Image = Image.FromFile(@"Resources/" + listImageName[index - 1]);
                this.Name = listImageName[index - 1];
            }
        }

        private void Click_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ItemNextImage();
            }
        }

        private void Click_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1)
                isMouseDown = false;
            else isMouseDown = true;
        }

        private void Click_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                if(listImageName.Count > 1)
                    this.DoDragDrop(listImageName[1], DragDropEffects.Copy);
                isMouseDown = false;
            }
        }
    }
}
