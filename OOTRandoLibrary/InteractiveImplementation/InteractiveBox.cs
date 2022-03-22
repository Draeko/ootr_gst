using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTRandoLibrary.InteractiveImplementation
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class InteractiveBox : PictureBox
    {
        protected bool isMouseDown;
        protected abstract void Click_DragDrop(object sender, DragEventArgs e);

        [JsonProperty]
        public string BoxName
        {
            get { return Name; }
            set { Name = value; }
        }
        [JsonProperty]
        public int X { get; set; }
        [JsonProperty]
        public int Y { get; set; }
        [JsonProperty]
        public Size BoxSize
        {
            get { return Size; }
            set { Size = value; }
        }
        [JsonProperty]
        public List<string>? ImageCollection { get; set; }
        [JsonProperty]
        public int IndexActiveImage { get; set; }
        [JsonProperty]
        public string? ActiveImagePath { get; set; }
        [JsonProperty]
        public override Boolean AllowDrop { get; set; }
        [JsonProperty]
        public Boolean BoxVisible
        {
            get { return Visible; }
            set { Visible = value; }
        }

        private MenuStrip MenuBar = new MenuStrip();

        public virtual void LoadData()
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(X, Y);
            this.TabStop = false;
            this.MouseUp += this.Click_MouseUp;
            this.MouseDown += this.Click_MouseDown;
            
            if (this.AllowDrop)
            {
                this.MouseMove += this.Click_MouseMove;
                this.DragEnter += this.Click_DragEnter;
                this.DragDrop += this.Click_DragDrop;
            }

            if (ImageCollection.Count > 0)
            {
                this.Image = Image.FromFile(@"Resources/" + this.ImageCollection[IndexActiveImage]);
                //this.Image = Image.FromFile(this.ImageCollection[IndexActiveImage]);
                this.ActiveImagePath = this.ImageCollection[IndexActiveImage];
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        protected void Click_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1)
                isMouseDown = false;
            else isMouseDown = true;
        }

        protected void Click_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        protected void Click_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                this.DoDragDrop(this.ActiveImagePath, DragDropEffects.Copy);
                isMouseDown = false;
            }
        }

        protected void Click_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) NextImage();
        }

        protected void NextImage()
        {
            var index = ImageCollection.FindIndex(x => x == this.ActiveImagePath);
            if (index >= ImageCollection.Count - 1)
            {
                this.Image = Image.FromFile(@"Resources/" + ImageCollection[0]);
                this.ActiveImagePath = ImageCollection[0];
            }
            else
            {
                this.Image = Image.FromFile(@"Resources/" + ImageCollection[index + 1]);
                this.ActiveImagePath = ImageCollection[index + 1];
            }
        }

        protected void PreviousImage()
        {
            var index = ImageCollection.FindIndex(x => x == this.ActiveImagePath);
            if (index == 0)
            {
                this.Image = Image.FromFile(@"Resources/" + ImageCollection[ImageCollection.Count - 1]);
                this.ActiveImagePath = ImageCollection[ImageCollection.Count - 1];
            }
            else
            {
                this.Image = Image.FromFile(@"Resources/" + ImageCollection[index - 1]);
                this.ActiveImagePath = ImageCollection[index - 1];
            }
        }

        protected void Action_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                NextImage();
            }
            if (e.Delta < 0)
            {
                PreviousImage();
            }
        }
    }
}
