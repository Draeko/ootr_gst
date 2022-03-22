namespace TrackerEditor
{
    partial class TemplateEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBoxToolStripMenuItem,
            this.exportJSONToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 48);
            // 
            // addBoxToolStripMenuItem
            // 
            this.addBoxToolStripMenuItem.Name = "addBoxToolStripMenuItem";
            this.addBoxToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addBoxToolStripMenuItem.Text = "Add box";
            this.addBoxToolStripMenuItem.Click += new System.EventHandler(this.AddBoxToolStripMenuItem_Click);
            // 
            // exportJSONToolStripMenuItem
            // 
            this.exportJSONToolStripMenuItem.Name = "exportJSONToolStripMenuItem";
            this.exportJSONToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportJSONToolStripMenuItem.Text = "Export JSON...";
            this.exportJSONToolStripMenuItem.Click += new System.EventHandler(this.ExportJSONToolStripMenuItem_Click);
            // 
            // TemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "TemplateEditor";
            this.Text = "TemplateEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEditor_FormClosing);
            this.Load += new System.EventHandler(this.TemplateEditor_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem addBoxToolStripMenuItem;
        private ToolStripMenuItem exportJSONToolStripMenuItem;
    }
}