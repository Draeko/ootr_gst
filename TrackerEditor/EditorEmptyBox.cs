using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOTRandoLibrary;

namespace TrackerEditor
{
    public class EditorEmptyBox : EmptyBox
    {
        private Point mouseLocation;
        private Point _Offset = Point.Empty;
        private ToolStripMenuItem EditMenu;
        private ToolStripMenuItem RemoveMenu;

        public EditorEmptyBox()
        {
            this.Click += EditorEmptyBox_Click;
            this.MouseMove += EditorEmptyBox_MouseMove;
            this.DragEnter += EditorEmptyBox_DragEnter;
            this.DragDrop += EditorEmptyBox_DragDrop;
            this.MouseDown += EditorEmptyBox_MouseDown;
            this.MouseUp += EditorEmptyBox_MouseUp;
            this.BringToFront();
            this.ContextMenuStrip = new ContextMenuStrip();

            this.EditMenu = new ToolStripMenuItem();
            this.EditMenu.Text = "Edit";
            this.EditMenu.Click += EditMenu_Click;
            this.ContextMenuStrip.Items.Add(EditMenu);

            this.RemoveMenu = new ToolStripMenuItem();
            this.RemoveMenu.Text = "Remove";
            this.RemoveMenu.Click += RemoveMenu_Click;
            this.ContextMenuStrip.Items.Add(RemoveMenu);
        }

        private void RemoveMenu_Click(object? sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EditMenu_Click(object? sender, EventArgs e)
        {
            EditForm editForm = new EditForm(this);
            editForm.Show();
        }

        private void EditorEmptyBox_MouseUp(object? sender, MouseEventArgs e)
        {
            _Offset = Point.Empty;
        }

        private void EditorEmptyBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _Offset = new Point(e.X, e.Y);
            }

            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip.Show(this, e.Location);
            }
        }

        private void EditorEmptyBox_DragDrop(object? sender, DragEventArgs e)
        {

        }

        private void EditorEmptyBox_DragEnter(object? sender, DragEventArgs e)
        {

        }

        private void EditorEmptyBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_Offset != Point.Empty)
            {
                Point newlocation = this.Location;
                newlocation.X += e.X - _Offset.X;
                newlocation.Y += e.Y - _Offset.Y;
                this.Location = newlocation;
            }
        }

        private void EditorEmptyBox_Click(object? sender, EventArgs e)
        {
            
        }
    }
}
