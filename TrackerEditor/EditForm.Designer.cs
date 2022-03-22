namespace TrackerEditor
{
    partial class EditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_LocationX = new System.Windows.Forms.TextBox();
            this.textBox_LocationY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.button_ImageCollectionBrowse = new System.Windows.Forms.Button();
            this.groupBox_ImageCollection = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_SizeX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_SizeY = new System.Windows.Forms.TextBox();
            this.button_ImageCollectionMoveLeft = new System.Windows.Forms.Button();
            this.button_ImageCollectionMoveRight = new System.Windows.Forms.Button();
            this.checkBox_DragAndDrop = new System.Windows.Forms.CheckBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_DragAndDrop = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_TinyImageCollectionBrowse = new System.Windows.Forms.Button();
            this.button_TinyImageCollectionMoveLeft = new System.Windows.Forms.Button();
            this.button_TinyImageCollectionMoveRight = new System.Windows.Forms.Button();
            this.checkBox_Visible = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_AddLabel = new System.Windows.Forms.Button();
            this.button_RemoveLabel = new System.Windows.Forms.Button();
            this.button_ImageCollectionRemove = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DragAndDrop)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "X :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y :";
            // 
            // textBox_LocationX
            // 
            this.textBox_LocationX.Location = new System.Drawing.Point(32, 17);
            this.textBox_LocationX.Name = "textBox_LocationX";
            this.textBox_LocationX.Size = new System.Drawing.Size(40, 23);
            this.textBox_LocationX.TabIndex = 1;
            // 
            // textBox_LocationY
            // 
            this.textBox_LocationY.Location = new System.Drawing.Point(116, 17);
            this.textBox_LocationY.Name = "textBox_LocationY";
            this.textBox_LocationY.Size = new System.Drawing.Size(40, 23);
            this.textBox_LocationY.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Type :";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Items.AddRange(new object[] {
            "Item",
            "ItemWithTinyBox",
            "ItemWithLabel",
            "EmptyBox"});
            this.comboBox_Type.Location = new System.Drawing.Point(243, 6);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(133, 23);
            this.comboBox_Type.TabIndex = 3;
            // 
            // button_ImageCollectionBrowse
            // 
            this.button_ImageCollectionBrowse.Location = new System.Drawing.Point(11, 217);
            this.button_ImageCollectionBrowse.Name = "button_ImageCollectionBrowse";
            this.button_ImageCollectionBrowse.Size = new System.Drawing.Size(67, 23);
            this.button_ImageCollectionBrowse.TabIndex = 5;
            this.button_ImageCollectionBrowse.Text = "Browse...";
            this.button_ImageCollectionBrowse.UseVisualStyleBackColor = true;
            this.button_ImageCollectionBrowse.Click += new System.EventHandler(this.Button_ImageCollectionBrowse_Click);
            // 
            // groupBox_ImageCollection
            // 
            this.groupBox_ImageCollection.Location = new System.Drawing.Point(11, 148);
            this.groupBox_ImageCollection.Name = "groupBox_ImageCollection";
            this.groupBox_ImageCollection.Size = new System.Drawing.Size(365, 63);
            this.groupBox_ImageCollection.TabIndex = 6;
            this.groupBox_ImageCollection.TabStop = false;
            this.groupBox_ImageCollection.Text = "Image Collection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_LocationX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_LocationY);
            this.groupBox2.Location = new System.Drawing.Point(11, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 50);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox_SizeX);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_SizeY);
            this.groupBox3.Location = new System.Drawing.Point(11, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 50);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "X :";
            // 
            // textBox_SizeX
            // 
            this.textBox_SizeX.Location = new System.Drawing.Point(32, 17);
            this.textBox_SizeX.Name = "textBox_SizeX";
            this.textBox_SizeX.Size = new System.Drawing.Size(40, 23);
            this.textBox_SizeX.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(90, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Y :";
            // 
            // textBox_SizeY
            // 
            this.textBox_SizeY.Location = new System.Drawing.Point(116, 17);
            this.textBox_SizeY.Name = "textBox_SizeY";
            this.textBox_SizeY.Size = new System.Drawing.Size(40, 23);
            this.textBox_SizeY.TabIndex = 2;
            // 
            // button_ImageCollectionMoveLeft
            // 
            this.button_ImageCollectionMoveLeft.Location = new System.Drawing.Point(95, 217);
            this.button_ImageCollectionMoveLeft.Name = "button_ImageCollectionMoveLeft";
            this.button_ImageCollectionMoveLeft.Size = new System.Drawing.Size(26, 23);
            this.button_ImageCollectionMoveLeft.TabIndex = 5;
            this.button_ImageCollectionMoveLeft.Text = "<";
            this.button_ImageCollectionMoveLeft.UseVisualStyleBackColor = true;
            this.button_ImageCollectionMoveLeft.Click += new System.EventHandler(this.Button_ImageCollectionMoveLeft_Click);
            // 
            // button_ImageCollectionMoveRight
            // 
            this.button_ImageCollectionMoveRight.Location = new System.Drawing.Point(127, 217);
            this.button_ImageCollectionMoveRight.Name = "button_ImageCollectionMoveRight";
            this.button_ImageCollectionMoveRight.Size = new System.Drawing.Size(26, 23);
            this.button_ImageCollectionMoveRight.TabIndex = 5;
            this.button_ImageCollectionMoveRight.Text = ">";
            this.button_ImageCollectionMoveRight.UseVisualStyleBackColor = true;
            // 
            // checkBox_DragAndDrop
            // 
            this.checkBox_DragAndDrop.AutoSize = true;
            this.checkBox_DragAndDrop.Location = new System.Drawing.Point(6, 22);
            this.checkBox_DragAndDrop.Name = "checkBox_DragAndDrop";
            this.checkBox_DragAndDrop.Size = new System.Drawing.Size(128, 19);
            this.checkBox_DragAndDrop.TabIndex = 8;
            this.checkBox_DragAndDrop.Text = "Allow Drag&&Drop ?";
            this.checkBox_DragAndDrop.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(304, 548);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(71, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image when Drag&Drop :";
            // 
            // pictureBox_DragAndDrop
            // 
            this.pictureBox_DragAndDrop.Enabled = false;
            this.pictureBox_DragAndDrop.Location = new System.Drawing.Point(140, 47);
            this.pictureBox_DragAndDrop.Name = "pictureBox_DragAndDrop";
            this.pictureBox_DragAndDrop.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_DragAndDrop.TabIndex = 9;
            this.pictureBox_DragAndDrop.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_DragAndDrop);
            this.groupBox4.Controls.Add(this.pictureBox_DragAndDrop);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(193, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 106);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Drag&&Drop";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name :";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(63, 6);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(124, 23);
            this.textBox_Name.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(6, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 63);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Image Collection";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.button_TinyImageCollectionBrowse);
            this.groupBox6.Controls.Add(this.button_TinyImageCollectionMoveLeft);
            this.groupBox6.Controls.Add(this.button_TinyImageCollectionMoveRight);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(11, 246);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(365, 126);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "TinyBox";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // button_TinyImageCollectionBrowse
            // 
            this.button_TinyImageCollectionBrowse.Location = new System.Drawing.Point(6, 91);
            this.button_TinyImageCollectionBrowse.Name = "button_TinyImageCollectionBrowse";
            this.button_TinyImageCollectionBrowse.Size = new System.Drawing.Size(67, 23);
            this.button_TinyImageCollectionBrowse.TabIndex = 5;
            this.button_TinyImageCollectionBrowse.Text = "Browse...";
            this.button_TinyImageCollectionBrowse.UseVisualStyleBackColor = true;
            // 
            // button_TinyImageCollectionMoveLeft
            // 
            this.button_TinyImageCollectionMoveLeft.Location = new System.Drawing.Point(90, 91);
            this.button_TinyImageCollectionMoveLeft.Name = "button_TinyImageCollectionMoveLeft";
            this.button_TinyImageCollectionMoveLeft.Size = new System.Drawing.Size(26, 23);
            this.button_TinyImageCollectionMoveLeft.TabIndex = 5;
            this.button_TinyImageCollectionMoveLeft.Text = "<";
            this.button_TinyImageCollectionMoveLeft.UseVisualStyleBackColor = true;
            // 
            // button_TinyImageCollectionMoveRight
            // 
            this.button_TinyImageCollectionMoveRight.Location = new System.Drawing.Point(122, 91);
            this.button_TinyImageCollectionMoveRight.Name = "button_TinyImageCollectionMoveRight";
            this.button_TinyImageCollectionMoveRight.Size = new System.Drawing.Size(26, 23);
            this.button_TinyImageCollectionMoveRight.TabIndex = 5;
            this.button_TinyImageCollectionMoveRight.Text = ">";
            this.button_TinyImageCollectionMoveRight.UseVisualStyleBackColor = true;
            // 
            // checkBox_Visible
            // 
            this.checkBox_Visible.AutoSize = true;
            this.checkBox_Visible.Location = new System.Drawing.Point(230, 551);
            this.checkBox_Visible.Name = "checkBox_Visible";
            this.checkBox_Visible.Size = new System.Drawing.Size(68, 19);
            this.checkBox_Visible.TabIndex = 8;
            this.checkBox_Visible.Text = "Visible ?";
            this.checkBox_Visible.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBox1);
            this.groupBox7.Controls.Add(this.button_AddLabel);
            this.groupBox7.Controls.Add(this.button_RemoveLabel);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(12, 378);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(364, 160);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Labels";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(83, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(270, 124);
            this.listBox1.TabIndex = 0;
            // 
            // button_AddLabel
            // 
            this.button_AddLabel.Enabled = false;
            this.button_AddLabel.Location = new System.Drawing.Point(5, 22);
            this.button_AddLabel.Name = "button_AddLabel";
            this.button_AddLabel.Size = new System.Drawing.Size(72, 23);
            this.button_AddLabel.TabIndex = 5;
            this.button_AddLabel.Text = "Add";
            this.button_AddLabel.UseVisualStyleBackColor = true;
            // 
            // button_RemoveLabel
            // 
            this.button_RemoveLabel.Enabled = false;
            this.button_RemoveLabel.Location = new System.Drawing.Point(5, 51);
            this.button_RemoveLabel.Name = "button_RemoveLabel";
            this.button_RemoveLabel.Size = new System.Drawing.Size(72, 23);
            this.button_RemoveLabel.TabIndex = 5;
            this.button_RemoveLabel.Text = "Remove";
            this.button_RemoveLabel.UseVisualStyleBackColor = true;
            // 
            // button_ImageCollectionRemove
            // 
            this.button_ImageCollectionRemove.Location = new System.Drawing.Point(170, 217);
            this.button_ImageCollectionRemove.Name = "button_ImageCollectionRemove";
            this.button_ImageCollectionRemove.Size = new System.Drawing.Size(67, 23);
            this.button_ImageCollectionRemove.TabIndex = 5;
            this.button_ImageCollectionRemove.Text = "Remove";
            this.button_ImageCollectionRemove.UseVisualStyleBackColor = true;
            this.button_ImageCollectionRemove.Click += new System.EventHandler(this.Button_ImageCollectionRemove_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 578);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.checkBox_Visible);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_ImageCollection);
            this.Controls.Add(this.button_ImageCollectionMoveRight);
            this.Controls.Add(this.button_ImageCollectionMoveLeft);
            this.Controls.Add(this.button_ImageCollectionRemove);
            this.Controls.Add(this.button_ImageCollectionBrowse);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DragAndDrop)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Label label2;
        private Label label3;
        private TextBox textBox_LocationX;
        private TextBox textBox_LocationY;
        private Label label4;
        private ComboBox comboBox_Type;
        private Button button_ImageCollectionBrowse;
        private GroupBox groupBox_ImageCollection;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label5;
        private TextBox textBox_SizeX;
        private Label label9;
        private TextBox textBox_SizeY;
        private Button button_ImageCollectionMoveLeft;
        private Button button_ImageCollectionMoveRight;
        private CheckBox checkBox_DragAndDrop;
        private Button button_Save;
        private Label label1;
        private PictureBox pictureBox_DragAndDrop;
        private GroupBox groupBox4;
        private Label label6;
        private TextBox textBox_Name;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Button button_TinyImageCollectionBrowse;
        private Button button_TinyImageCollectionMoveLeft;
        private Button button_TinyImageCollectionMoveRight;
        private Label label7;
        private CheckBox checkBox_Visible;
        private GroupBox groupBox7;
        private ListBox listBox1;
        private Button button_AddLabel;
        private Button button_RemoveLabel;
        private Button button_ImageCollectionRemove;
    }
}