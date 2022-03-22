﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerOOT
{
    public class Layout
    {

        public List<ObjectPoint> ListItems = new List<ObjectPoint>();
        public List<ObjectPointSong> ListSongs = new List<ObjectPointSong>();
        public List<ObjectPoint> ListDoubleItems = new List<ObjectPoint>();
        public List<ObjectPointCollectedItem> ListCollectedItems = new List<ObjectPointCollectedItem>();
        public List<ObjectPointMedallion> ListMedallions = new List<ObjectPointMedallion>();
        public List<ObjectPoint> ListGuaranteedHints = new List<ObjectPoint>();
        public List<ObjectPoint> ListGossipStones = new List<ObjectPoint>();
        public List<ObjectPointLabel> ListSometimesHints = new List<ObjectPointLabel>();
        public List<ObjectPointLabel> ListChronometers = new List<ObjectPointLabel>();
        public List<ObjectPanelWotH> ListPanelWotH = new List<ObjectPanelWotH>();
        public List<ObjectPanelBarren> ListPanelBarren = new List<ObjectPanelBarren>();
        public List<ObjectPointGoMode> ListGoMode = new List<ObjectPointGoMode>();

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

                    if (category.Key.ToString() == "Items")
                    {
                        foreach (var element in category.Value)
                        {
                            ListItems.Add(JsonConvert.DeserializeObject<ObjectPoint>(element.ToString()));
                        }

                    }
                    if (category.Key.ToString() == "Songs")
                    {
                        foreach (var element in category.Value)
                        {
                            ListSongs.Add(JsonConvert.DeserializeObject<ObjectPointSong>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "DoubleItems")
                    {
                        foreach (var element in category.Value)
                        {
                            ListDoubleItems.Add(JsonConvert.DeserializeObject<ObjectPoint>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "CollectedItems")
                    {
                        foreach (var element in category.Value)
                        {
                            ListCollectedItems.Add(JsonConvert.DeserializeObject<ObjectPointCollectedItem>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "Medallions")
                    {
                        foreach (var element in category.Value)
                        {
                            ListMedallions.Add(JsonConvert.DeserializeObject<ObjectPointMedallion>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "GuaranteedHints")
                    {
                        foreach (var element in category.Value)
                        {
                            ListGuaranteedHints.Add(JsonConvert.DeserializeObject<ObjectPoint>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "GossipStones")
                    {
                        foreach (var element in category.Value)
                        {
                            ListGossipStones.Add(JsonConvert.DeserializeObject<ObjectPoint>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "SometimesHints")
                    {
                        foreach (var element in category.Value)
                        {
                            ListSometimesHints.Add(JsonConvert.DeserializeObject<ObjectPointLabel>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "Chronometers")
                    {
                        foreach (var element in category.Value)
                        {
                            ListChronometers.Add(JsonConvert.DeserializeObject<ObjectPointLabel>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "PanelWoth")
                    {
                        foreach (var element in category.Value)
                        {
                            ListPanelWotH.Add(JsonConvert.DeserializeObject<ObjectPanelWotH>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "PanelBarren")
                    {
                        foreach (var element in category.Value)
                        {
                            ListPanelBarren.Add(JsonConvert.DeserializeObject<ObjectPanelBarren>(element.ToString()));
                        }
                    }

                    if (category.Key.ToString() == "GoMode")
                    {
                        foreach (var element in category.Value)
                        {
                            ListGoMode.Add(JsonConvert.DeserializeObject<ObjectPointGoMode>(element.ToString()));
                        }
                    }
                }

                form.Size = new Size(App_Settings.Width, App_Settings.Height);
                form.BackColor = App_Settings.BackgroundColor;

                if (ListItems.Count > 0)
                {
                    foreach (var item in ListItems)
                    {
                        form.Controls.Add(new Item(item));
                    }
                }

                if (ListSongs.Count > 0)
                {
                    foreach (var song in ListSongs)
                    {
                        if (song.Visible)
                            form.Controls.Add(new Song(song));
                    }
                }

                if (ListDoubleItems.Count > 0)
                {
                    foreach (var doubleItem in ListDoubleItems)
                    {
                        form.Controls.Add(new DoubleItem(doubleItem));
                    }
                }

                if (ListCollectedItems.Count > 0)
                {
                    foreach (var item in ListCollectedItems)
                    {
                        if (item.Visible)
                            form.Controls.Add(new CollectedItem(item));
                    }
                }

                if (ListMedallions.Count > 0)
                {
                    foreach (var medallion in ListMedallions)
                    {
                        if (medallion.Visible)
                        {
                            var element = new Medallion(medallion);
                            form.Controls.Add(element);
                            form.Controls.Add(element.SelectedDungeon);
                            element.SetSelectedDungeonLocation();
                            element.SelectedDungeon.BringToFront();
                        }
                    }
                }

                if (ListGuaranteedHints.Count > 0)
                {
                    foreach (var item in ListGuaranteedHints)
                    {
                        form.Controls.Add(new GuaranteedHint(item));
                    }
                }

                if (ListGossipStones.Count > 0)
                {
                    foreach (var item in ListGossipStones)
                    {
                        form.Controls.Add(new GossipStone(item));
                    }
                }

                if (ListSometimesHints.Count > 0)
                {
                    foreach (var item in ListSometimesHints)
                    {
                        if (item.Visible)
                            form.Controls.Add(new SometimesHint(listSometimesHintsSuggestions, item));
                    }
                }

                if (ListChronometers.Count > 0)
                {
                    foreach (var item in ListChronometers)
                    {
                        if (item.Visible)
                            form.Controls.Add(new Chronometer(item).ChronoLabel);
                    }
                }

                if (ListPanelWotH.Count > 0)
                {
                    foreach (var item in ListPanelWotH)
                    {
                        if (item.Visible)
                        {
                            var newPanel = new PanelWothBarren(item);
                            newPanel.PanelWoth(listPlacesWithTag, item);
                            form.Controls.Add(newPanel);
                            form.Controls.Add(newPanel.textBoxCustom.SuggestionContainer);
                            newPanel.SetSuggestionContainer();
                        }
                    }
                }

                if (ListPanelBarren.Count > 0)
                {
                    foreach (var item in ListPanelBarren)
                    {
                        if (item.Visible)
                        {
                            var newPanel = new PanelWothBarren(item);
                            newPanel.PanelBarren(listPlacesWithTag, item);
                            form.Controls.Add(newPanel);
                            form.Controls.Add(newPanel.textBoxCustom.SuggestionContainer);
                            newPanel.SetSuggestionContainer();
                        }
                    }
                }

                if (ListGoMode.Count > 0)
                {
                    foreach (var item in ListGoMode)
                    {
                        if (item.Visible)
                        {
                            var element = new GoMode(item);
                            form.Controls.Add(element);
                            element.SetLocation();
                        }
                    }
                }
            }
        }
    }

    public class ObjectPoint
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Size Size { get; set; }
        public string[] ImageCollection { get; set; }
        public int IndexFirstImage { get; set; }
    }

    public class ObjectPointSong
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Size Size { get; set; }
        public bool Visible { get; set; }
        public string DragAndDropImageName { get; set; }
        public string[] ImageCollection { get; set; }
        public string[] TinyImageCollection { get; set; }
        public string ActiveSongImage { get; set; }
        public string ActiveTinySongImage { get; set; }
    }

    public class ObjectPointMedallion
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Size Size { get; set; }
        public bool Visible { get; set; }
        public string[] ImageCollection { get; set; }
        public MedallionLabel Label { get; set; }
        
        public class MedallionLabel
        {
            public string[] TextCollection { get; set; }
            public int FontSize { get; set; }
            public string FontName { get; set; }
            public FontStyle FontStyle { get; set; }
        }
    }

    public class ObjectPointLabel
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public Color BackColor { get; set; }
        public int FontSize { get; set; }
        public string FontName { get; set; }
        public FontStyle FontStyle { get; set; }
        public Color FontColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ObjectPanelWotH
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public Color BackColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NbMaxRows { get; set; }
        public bool IsScrollable { get; set; }

        public string TextBoxName { get; set; }
        public Color TextBoxBackColor { get; set; }
        public string TextBoxFontName { get; set; }
        public int TextBoxFontSize { get; set; }
        public FontStyle TextBoxFontStyle { get; set; }
        public int TextBoxWidth { get; set; }
        public int TextBoxHeight { get; set; }
        public string TextBoxText { get; set; }

        public Color LabelColor { get; set; }
        public Color LabelColor2 { get; set; }
        public Color LabelColor3 { get; set; }
        public Color LabelBackColor { get; set; }
        public string LabelFontName { get; set; }
        public int LabelFontSize { get; set; }
        public FontStyle LabelFontStyle { get; set; }
        public int LabelWidth { get; set; }
        public int LabelHeight { get; set; }
        public Size GossipStoneSize { get; set; }
        public string[] GossipStoneImageCollection { get; set; }
    }

    public class ObjectPanelBarren
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public Color BackColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NbMaxRows { get; set; }
        public bool IsScrollable { get; set; }

        public string TextBoxName { get; set; }
        public Color TextBoxBackColor { get; set; }
        public string TextBoxFontName { get; set; }
        public int TextBoxFontSize { get; set; }
        public FontStyle TextBoxFontStyle { get; set; }
        public int TextBoxWidth { get; set; }
        public int TextBoxHeight { get; set; }
        public string TextBoxText { get; set; }

        public Color LabelColor { get; set; }
        public Color LabelBackColor { get; set; }
        public string LabelFontName { get; set; }
        public int LabelFontSize { get; set; }
        public FontStyle LabelFontStyle { get; set; }
        public int LabelWidth { get; set; }
        public int LabelHeight { get; set; }
    }

    public class ObjectPointGoMode
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Size Size { get; set; }
        public bool Visible { get; set; }
        public string[] ImageCollection { get; set; }
        public string BackgroundImage { get; set; }
    }

    public class ObjectPointCollectedItem
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Size Size { get; set; }
        public bool Visible { get; set; }
        public string[] ImageCollection { get; set; }
        public string LabelFontName { get; set; }
        public int LabelFontSize { get; set; }
        public FontStyle LabelFontStyle { get; set; }
        public Color LabelColor { get; set; }
    }

    public class AppSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackgroundColor { get;set; }
    }
}
