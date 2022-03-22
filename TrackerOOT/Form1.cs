using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TrackerOOT
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> ListPlacesWithTag = new Dictionary<string, string>();
        SortedSet<String> ListPlaces = new SortedSet<String>();
        SortedSet<String> ListSometimesHintsSuggestions = new SortedSet<string>();

        public static Layout CurrentLayout = new Layout();
        PictureBox pbox_collectedSkulls;

        private MenuStrip MenuBar = new MenuStrip();
        private ToolStripMenuItem Editor = new ToolStripMenuItem("Edit Layout");

        public static bool SongMode = false;
        public static bool AutoCheck = false;
        public static string ActiveLayoutName = string.Empty;
        public static bool EnableMouseWheel_Items = false;
        public static bool EnableMouseWheel_Medallions = false;
        public static bool EnableMouseWheel_GossipStones = false;
        public static bool EnableMouseWheel_CollectedItems = false;
        public static bool MouseWheel_Items_IncreaseWithScrollUp = false;
        public static bool MouseWheel_Medallions_IncreaseWithScrollUp = false;
        public static bool MouseWheel_GossipStones_IncreaseWithScrollUp = false;
        public static bool MouseWheel_CollectedItems_IncreaseWithScrollUp = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                this.Controls.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.Form1_Load(sender, new EventArgs());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Items&Hints Tracker v1.8.4";
            this.AcceptButton = null;
            this.MaximizeBox = false;
            MenuBar.Items.Add(Editor);
            Editor.Click += Editor_Click;
            this.Controls.Add(MenuBar);
            MenuBar.Hide();

            ListPlaces.Clear();
            ListPlaces.Add("");
            ListPlacesWithTag.Clear();
            JObject json_places = JObject.Parse(File.ReadAllText(@"oot_places.json"));
            foreach (var property in json_places)
            {
                ListPlaces.Add(property.Key.ToString());
                ListPlacesWithTag.Add(property.Key, property.Value.ToString());
            }

            ListSometimesHintsSuggestions.Clear();
            JObject json_hints = JObject.Parse(File.ReadAllText(@"sometimes_hints.json"));
            foreach (var categorie in json_hints)
            {
                foreach (var hint in categorie.Value)
                {
                    ListSometimesHintsSuggestions.Add(hint.ToString());
                }
            }

            JObject json_properties = JObject.Parse(File.ReadAllText(@"settings.json"));
            foreach (var property in json_properties)
            {
                if (property.Key == "MoveLocationToSong")
                {
                    SongMode = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "AutoCheckSongs")
                {
                    AutoCheck = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "ActiveLayout")
                {
                    ActiveLayoutName = property.Value.ToString();
                }
                if (property.Key == "EnableMouseWheel_Items")
                {
                    EnableMouseWheel_Items = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "EnableMouseWheel_Medallions")
                {
                    EnableMouseWheel_Medallions = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "EnableMouseWheel_GossipStones")
                {
                    EnableMouseWheel_GossipStones = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "EnableMouseWheel_CollectedItems")
                {
                    EnableMouseWheel_CollectedItems = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "MouseWheel_Items_IncreaseWithScrollUp")
                {
                    MouseWheel_Items_IncreaseWithScrollUp = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "MouseWheel_Medallions_IncreaseWithScrollUp")
                {
                    MouseWheel_Medallions_IncreaseWithScrollUp = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "MouseWheel_GossipStones_IncreaseWithScrollUp")
                {
                    MouseWheel_GossipStones_IncreaseWithScrollUp = Convert.ToBoolean(property.Value);
                }
                if (property.Key == "MouseWheel_CollectedItems_IncreaseWithScrollUp")
                {
                    MouseWheel_CollectedItems_IncreaseWithScrollUp = Convert.ToBoolean(property.Value);
                }
            }

            CurrentLayout.LoadLayout(this, ListSometimesHintsSuggestions, ListPlacesWithTag);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                if (MenuBar.Visible) MenuBar.Hide();
                else MenuBar.Show();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

            private void Editor_Click(object sender, EventArgs e)
        {
            Layout editorLayout = new Layout();
            editorLayout.LoadLayout(this, ListSometimesHintsSuggestions, ListPlacesWithTag);

            var window = new Editor(editorLayout);
            window.Show();
        }


        private void changeCollectedSkulls(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.F9) { }
            //button_chrono_Click(sender, new EventArgs());
            if (k.KeyCode == Keys.F11) { }
            //label_collectedSkulls_MouseDown(pbox_collectedSkulls.Controls[0], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            if (k.KeyCode == Keys.F12) { }
            //label_collectedSkulls_MouseDown(pbox_collectedSkulls.Controls[0], new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
        }
    }
}
