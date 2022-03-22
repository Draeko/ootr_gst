using OOTRandoLibrary.InteractiveImplementation;

namespace OOTRandoLibrary
{
    public abstract class EditableBox : InteractiveBox
    {
        private MenuStrip MenuStrip = new MenuStrip();
        private ToolStripMenuItem MenuRightClick = new ToolStripMenuItem("MenuRightClick");
        private ToolStripMenuItem Edit = new ToolStripMenuItem("Edit");

        public EditableBox()
        {
            MenuStrip.Name = "MenuRightClick";
            MenuStrip.Items.Add(MenuRightClick);
            MenuRightClick.DropDownItems.Add(Edit);
            Edit.Click += Edit_Click; ;
        }

        protected abstract void Edit_Click(object? sender, EventArgs e);

        protected override void Click_DragDrop(object sender, DragEventArgs e)
        {
        }

        protected void Click_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1)
                isMouseDown = false;
            else isMouseDown = true;
        }

        protected new void Click_DragEnter(object sender, DragEventArgs e) { }

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
