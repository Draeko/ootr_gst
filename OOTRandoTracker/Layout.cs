using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOTRandoLibrary;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOTRandoTracker
{
    public class Layout
    {

        public List<Song> ListSongs = new List<Song>();

        public AppSettings App_Settings = new AppSettings();

        public void LoadLayout(Form form, SortedSet<string> listSometimesHintsSuggestions, Dictionary<string, string> listPlacesWithTag)
        {
            if (Form1.ActiveLayoutName != string.Empty)
            {
                JObject json_layouts = JObject.Parse(File.ReadAllText(@"Layouts/" + Form1.ActiveLayoutName + ".json"));
                foreach (var category in json_layouts)
                {
                    if (category.Key.ToString() == "AppSize")
                    {
                        App_Settings = JsonConvert.DeserializeObject<AppSettings>(category.Value.ToString());
                    }

                    
                    if (category.Key.ToString() == "Songs")
                    {
                        foreach (var element in category.Value)
                        {
                            ListSongs.Add(JsonConvert.DeserializeObject<Song>(element.ToString()));
                        }
                    }

                    
                }

                form.Size = new Size(App_Settings.Width, App_Settings.Height);
                form.BackColor = App_Settings.BackgroundColor;

                
                if (ListSongs.Count > 0)
                {
                    foreach (var song in ListSongs)
                    {
                        if (song.Visible)
                            form.Controls.Add(song);
                    }
                }
            }
        }
    }

    public class AppSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackgroundColor { get;set; }
    }
}
