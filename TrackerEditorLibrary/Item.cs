namespace TrackerEditorLibrary
{
    public class Item : OOTRandoLibrary.Item
    {
        public Item()
        {

        }

        protected new void Click_MouseMove(object sender, MouseEventArgs e) { }

        protected new void Click_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        protected new void Action_MouseWheel(object sender, MouseEventArgs e) { }
    }
}