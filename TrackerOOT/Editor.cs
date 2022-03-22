using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TrackerOOT.EditorObjects;

namespace TrackerOOT
{
    public partial class Editor : Form
    {
        Layout CurrentLayout = new Layout();
        private Point MouseDownLocation = new Point();
        private MenuStrip MenuBar = new MenuStrip();
        
        private ToolStripMenuItem FileMenu = new ToolStripMenuItem("File");
        private ToolStripMenuItem LoadJson = new ToolStripMenuItem("Load layout from JSON file");
        private ToolStripMenuItem SaveJson = new ToolStripMenuItem("Save layout as JSON");

        private ToolStripMenuItem AddElement = new ToolStripMenuItem("Add ...");
        private ToolStripMenuItem NewItem = new ToolStripMenuItem("New Item");
        private ToolStripMenuItem NewMedallion = new ToolStripMenuItem("New Medallion");
        private ToolStripMenuItem NewSong = new ToolStripMenuItem("New Song");

        public ToolStripMenuItem ItemLocation = new ToolStripMenuItem("Location : 0 | 0");

        public static HashSet<Control> ListFocusedControl = new HashSet<Control>();

        public Editor()
        {
            InitializeComponent();
        }

        public Editor(Layout layout)
        {
            CurrentLayout = layout;
            this.Controls.Clear();
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(layout.App_Settings.Width, layout.App_Settings.Height);
            this.Size = new Size(layout.App_Settings.Width, layout.App_Settings.Height);
            this.BackColor = layout.App_Settings.BackgroundColor;
            this.Name = "Editor";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.ResumeLayout(false);

            this.MouseDown += Editor_MouseDown;
            this.MouseMove += Editor_MouseMove;

            MenuBar.Name = "MenuBar";
            MenuBar.Items.Add(FileMenu);
            FileMenu.DropDownItems.Add(LoadJson);
            LoadJson.Enabled = false;
            FileMenu.DropDownItems.Add(SaveJson);
            SaveJson.Click += Save_Click;

            MenuBar.Items.Add(AddElement);
            AddElement.DropDownItems.Add(NewItem);
            NewItem.Click += NewItem_Click;
            AddElement.DropDownItems.Add(NewMedallion);
            AddElement.DropDownItems.Add(NewSong);

            ItemLocation.Name = "MenuItemLocation";
            MenuBar.Items.Add(ItemLocation);
            this.MainMenuStrip = MenuBar;
            this.Controls.Add(MenuBar);
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            ObjectPoint newObject = new ObjectPoint();
            newObject.Name = "New Element";
            newObject.X = 0;
            newObject.Y = 24;
            newObject.Size = new Size(32, 32);
            newObject.ImageCollection = new string[] { "no-song_16x16.png" };
            JSONItem newElement = new JSONItem(newObject);
            this.Controls.Add(newElement);
            newElement.BringToFront();
        }

        private void Editor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Draw rectangle and select controls to add them as focused
            }            
        }

        private void Editor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F2)
            {
                if (MenuBar.Visible) MenuBar.Hide();
                else MenuBar.Show();
            }
            if (keyData == Keys.Up)
            {
                foreach (var control in ListFocusedControl)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y - 1);
                }
            }
            if (keyData == Keys.Down)
            {
                foreach (var control in ListFocusedControl)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y + 1);
                }
            }
            if (keyData == Keys.Left)
            {
                foreach (var control in ListFocusedControl)
                {
                    control.Location = new Point(control.Location.X - 1, control.Location.Y);
                }
            }
            if (keyData == Keys.Right)
            {
                foreach (var control in ListFocusedControl)
                {
                    control.Location = new Point(control.Location.X + 1, control.Location.Y);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                savefile.InitialDirectory = ".\\Layouts\\";
                savefile.Filter = "JSON File (*.json)|*.json";

                string json =
                "{\n" +
                "   \"AppSize\" : {\n" +
                "       \"Width\": " + this.Size.Width + ",\n" +
                "       \"Height\": " + this.Size.Height + ",\n" +
                "       \"BackgroundColor\": \"30, 30, 30\"\n" +
                "  },\n" +
                "   \"Items\" : [\n";

                string items = string.Empty;
                string medallions = string.Empty;
                string songs = string.Empty;
                string guaranteedHints = string.Empty;
                string sometimesHints = string.Empty;
                string gossipStones = string.Empty;
                string chronometers = string.Empty;
                string panelWoth = string.Empty;
                string panelBarren = string.Empty;
                string goModes = string.Empty;
                string collectedItems = string.Empty;

                if (CurrentLayout.ListItems.Count > 0)
                {
                    foreach (var item in CurrentLayout.ListItems)
                    {
                        items += JsonConvert.SerializeObject(item, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListMedallions.Count > 0)
                {
                    foreach (var medaillion in CurrentLayout.ListMedallions)
                    {
                        medallions += JsonConvert.SerializeObject(medaillion, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListSongs.Count > 0)
                {
                    foreach (var song in CurrentLayout.ListSongs)
                    {
                        songs += JsonConvert.SerializeObject(song, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListGuaranteedHints.Count > 0)
                {
                    foreach (var guaranteedHint in CurrentLayout.ListGuaranteedHints)
                    {
                        guaranteedHints += JsonConvert.SerializeObject(guaranteedHint, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListSometimesHints.Count > 0)
                {
                    foreach (var sometimesHint in CurrentLayout.ListSometimesHints)
                    {
                        sometimesHints += JsonConvert.SerializeObject(sometimesHint, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListGossipStones.Count > 0)
                {
                    foreach (var gossipStone in CurrentLayout.ListGossipStones)
                    {
                        gossipStones += JsonConvert.SerializeObject(gossipStone, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListChronometers.Count > 0)
                {
                    foreach (var chrono in CurrentLayout.ListChronometers)
                    {
                        chronometers += JsonConvert.SerializeObject(chrono, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListPanelWotH.Count > 0)
                {
                    foreach (var woth in CurrentLayout.ListPanelWotH)
                    {
                        panelWoth += JsonConvert.SerializeObject(woth, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListPanelBarren.Count > 0)
                {
                    foreach (var barren in CurrentLayout.ListPanelBarren)
                    {
                        panelBarren += JsonConvert.SerializeObject(barren, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListGoMode.Count > 0)
                {
                    foreach (var goMode in CurrentLayout.ListGoMode)
                    {
                        goModes += JsonConvert.SerializeObject(goMode, Formatting.Indented) + ",\n";
                    }
                }
                if (CurrentLayout.ListCollectedItems.Count > 0)
                {
                    foreach (var collected in CurrentLayout.ListCollectedItems)
                    {
                        collectedItems += JsonConvert.SerializeObject(collected, Formatting.Indented) + ",\n";
                    }
                }

                json +=
                    items + "],\n" +
                    "   \"Medallions\" : [\n" +
                    medallions + "],\n" +
                    "   \"Songs\" : [\n" +
                    songs + "],\n" +
                    "   \"GuaranteedHints\" : [\n" +
                    guaranteedHints + "],\n" +
                    "   \"SometimesHints\" : [\n" +
                    sometimesHints + "],\n" +
                    "   \"GossipStones\" : [\n" +
                    gossipStones + "],\n" +
                    "   \"Chronometers\" : [\n" +
                    chronometers + "],\n" +
                    "   \"PanelWoth\" : [\n" +
                    panelWoth + "],\n" +
                    "   \"PanelBarren\" : [\n" +
                    panelBarren + "],\n" +
                    "   \"GoMode\" : [\n" +
                    goModes + "],\n" +
                    "   \"CollectedItems\" : [\n" +
                    collectedItems + "],\n" +
                    "}";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savefile.FileName, json);
                }
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            if (CurrentLayout.ListItems.Count > 0)
            {
                foreach (var item in CurrentLayout.ListItems)
                {
                    this.Controls.Add(new JSONItem(item));
                }
            }
            if (CurrentLayout.ListMedallions.Count > 0)
            {
                foreach (var medallion in CurrentLayout.ListMedallions)
                {
                    this.Controls.Add(new JSONMedallion(medallion));
                }
            }
            if (CurrentLayout.ListCollectedItems.Count > 0)
            {
                foreach (var collectedItem in CurrentLayout.ListCollectedItems)
                {
                    this.Controls.Add(new JSONCollectedItem(collectedItem));
                }
            }
            if (CurrentLayout.ListSongs.Count > 0)
            {
                foreach (var song in CurrentLayout.ListSongs)
                {
                    this.Controls.Add(new JSONSong(song));
                }
            }
            if (CurrentLayout.ListGuaranteedHints.Count > 0)
            {
                foreach (var guaranteedHint in CurrentLayout.ListGuaranteedHints)
                {
                    this.Controls.Add(new JSONGuranteedHints(guaranteedHint));
                }
            }
            if (CurrentLayout.ListGossipStones.Count > 0)
            {
                foreach (var gossipStone in CurrentLayout.ListGossipStones)
                {
                    this.Controls.Add(new JSONGossipStone(gossipStone));
                }
            }
            if (CurrentLayout.ListSometimesHints.Count > 0)
            {
                foreach (var sometimesHint in CurrentLayout.ListSometimesHints)
                {
                    this.Controls.Add(new JSONSometimesHint(sometimesHint));
                }
            }
            if (CurrentLayout.ListChronometers.Count > 0)
            {
                foreach (var chrono in CurrentLayout.ListChronometers)
                {
                    this.Controls.Add(new JSONChronometer(chrono));
                }
            }
            if (CurrentLayout.ListPanelWotH.Count > 0)
            {
                foreach (var woth in CurrentLayout.ListPanelWotH)
                {
                    this.Controls.Add(new JSONPanelWoth(woth));
                }
            }
            if (CurrentLayout.ListPanelBarren.Count > 0)
            {
                foreach (var barren in CurrentLayout.ListPanelBarren)
                {
                    this.Controls.Add(new JSONPanelBarren(barren));
                }
            }
            if (CurrentLayout.ListGoMode.Count > 0)
            {
                foreach (var goMode in CurrentLayout.ListGoMode)
                {
                    this.Controls.Add(new JSONGoMode(goMode));
                }
            }
        }
    }
}
