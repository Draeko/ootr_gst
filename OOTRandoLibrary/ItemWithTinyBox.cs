using Newtonsoft.Json;
using OOTRandoLibrary.InteractiveImplementation;

namespace OOTRandoLibrary
{
    public class ItemWithTinyBox : InteractiveBox
    {
        [JsonProperty]
        public List<Item>? ItemCollection { get; set; }
        [JsonProperty]
        public string? DragAndDropImagePath { get; set; }

        public override void LoadData()
        {
            base.LoadData();
            if( ItemCollection != null )
            {
                foreach( InteractiveBox box in ItemCollection )
                {
                    box.MouseUp += TinyPictureBox_MouseUp;
                    box.MouseDown += Click_MouseDown;
                    this.Controls.Add(box);
                    box.BringToFront();

                    if (box.ImageCollection.Count > 0)
                    {
                        box.Image = Image.FromFile(@"Resources/" + box.ImageCollection[box.IndexActiveImage]);
                        box.ActiveImagePath = box.ImageCollection[box.IndexActiveImage];
                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                        box.Location = new Point(box.X, box.Y);
                    }
                }
            }            
        }

        protected void TinyPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            var box = sender as InteractiveBox;
            var index = box.ImageCollection.ToList().FindIndex(x => x == this.ActiveImagePath);
            if (index >= box.ImageCollection.Count - 1)
            {
                box.Image = Image.FromFile(@"Resources/" + box.ImageCollection[0]);
                box.ActiveImagePath = box.ImageCollection[0];
            }
            else
            {
                box.Image = Image.FromFile(@"Resources/" + box.ImageCollection[index + 1]);
                box.ActiveImagePath = box.ImageCollection[index + 1];
            }
        }

        protected override void Click_DragDrop(object sender, DragEventArgs e)
        {
            var imageName = (string)e.Data.GetData(DataFormats.Text);
            var splitname = (imageName.Split('-')[0]).ToLower(System.Globalization.CultureInfo.GetCultureInfo("fr"));

            foreach (var control in this.Parent.Controls)
            {
                if (control.GetType() == typeof(ItemWithTinyBox))
                {
                    var SongName = ((ItemWithTinyBox)control).Name.ToLower(System.Globalization.CultureInfo.GetCultureInfo("fr"));
                    if (splitname.Contains(SongName))
                    {
                        var findOrigin = this.Parent.Controls.Find(SongName, false);
                        if (findOrigin.Length > 0)
                        {
                            var origin = (ItemWithTinyBox)findOrigin[0];
                            origin.Click_MouseUp(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                            if (this.ItemCollection != null && this.ItemCollection.Count > 0)
                            {
                                this.ItemCollection[0].Image = Image.FromFile(@"Resources/" + origin.DragAndDropImagePath);
                                this.ItemCollection[0].Name = origin.Name;
                            }
                        }
                    }
                }
            }
        }
    }
}
