using Newtonsoft.Json;
using OOTRandoLibrary.InteractiveImplementation;

namespace OOTRandoLibrary
{
    public class ItemWithLabel : InteractiveBox
    {
        [JsonProperty]
        public InteractiveLabel interactiveBoxLabel { get; set; }
        
        public override void LoadData()
        {
            base.LoadData();
            interactiveBoxLabel.Font = new Font(interactiveBoxLabel.fontName, interactiveBoxLabel.fontSize, interactiveBoxLabel.fontStyle);
            interactiveBoxLabel.Text = interactiveBoxLabel.TextCollection[0];
            this.MouseWheel += Medallion_MouseWheel;
        }

        private void Medallion_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                MedallionNextLabel();
            }
            else
            {
                MedallionPreviousLabel();
            }
        }

        private void MedallionNextLabel()
        {
            var index = interactiveBoxLabel.TextCollection.ToList().FindIndex(x => x == interactiveBoxLabel.Text);
            if (index == (interactiveBoxLabel.TextCollection.ToList().Count - 1))
                interactiveBoxLabel.Text = interactiveBoxLabel.TextCollection[0];
            else
                interactiveBoxLabel.Text = interactiveBoxLabel.TextCollection[index + 1];
            SetSelectedDungeonLocation();
        }

        private void MedallionPreviousLabel()
        {
            var index = interactiveBoxLabel.TextCollection.ToList().FindIndex(x => x == interactiveBoxLabel.Text);
            if (index == 0)
                interactiveBoxLabel.Text = interactiveBoxLabel.TextCollection[interactiveBoxLabel.TextCollection.ToList().Count - 1];
            else
                interactiveBoxLabel.Text = interactiveBoxLabel.TextCollection[index - 1];
            SetSelectedDungeonLocation();
        }

        public void SetSelectedDungeonLocation()
        {
            interactiveBoxLabel.Location = new Point(this.Location.X + Size.Width / 2 - interactiveBoxLabel.Width / 2, (int)(this.Location.Y + Size.Height * 0.75));
        }

        protected void Click_MouseUp(object sender, MouseEventArgs e)
        {
            base.Click_MouseUp(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                MedallionNextLabel();
            }
        }

        protected override void Click_DragDrop(object sender, DragEventArgs e)
        {
            
        }
    }
}
