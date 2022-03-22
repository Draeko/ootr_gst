using OOTRandoLibrary.InteractiveImplementation;

namespace OOTRandoLibrary
{
    public class EmptyBox : InteractiveBox
    {
        public string? BoxType { get; set; }

        protected override void Click_DragDrop(object sender, DragEventArgs e)
        {
            var imageName = (string)e.Data.GetData(DataFormats.Text);
            var image = Image.FromFile(@"Resources/" + imageName);
            this.Image = image;
        }
    }
}