﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerOOT
{
    class PanelWothBarren : Panel
    {
        public List<WotH> ListWotH = new List<WotH>();
        public List<Barren> ListBarren = new List<Barren>();
        ObjectPanelWotH JsonSettings = new ObjectPanelWotH();

        public TextBoxCustom textBoxCustom;
        private string[] ListImage_WothItemsOption;
        Size GossipStoneSize;
        int NbMaxRows;
        Label LabelSettings = new Label();

        public PanelWothBarren(ObjectPanelWotH data)
        {
            JsonSettings = data;
            GossipStoneSize = data.GossipStoneSize;
            this.BackColor = data.BackColor;
            this.Location = new Point(data.X, data.Y);
            this.Name = data.Name;
            this.Size = new Size(data.Width, data.Height);
            this.TabStop = false;
            if(data.IsScrollable)
                this.MouseWheel += Panel_MouseWheel;
        }

        public PanelWothBarren(ObjectPanelBarren data)
        {
            this.BackColor = data.BackColor;
            this.Location = new Point(data.X, data.Y);
            this.Name = data.Name;
            this.Size = new Size(data.Width, data.Height);
            this.TabStop = false;
            if (data.IsScrollable)
                this.MouseWheel += Panel_MouseWheel;
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            var panel = (Panel)sender;
            if (e.Delta < 0)
            {
                foreach (var element in panel.Controls)
                {
                    if (element is Label)
                        ((Label)element).Location = new Point(((Label)element).Location.X, ((Label)element).Location.Y - 15);
                    if (element is GossipStone)
                        ((GossipStone)element).Location = new Point(((GossipStone)element).Location.X, ((GossipStone)element).Location.Y - 15);
                    if (element is TextBox)
                        ((TextBox)element).Location = new Point(((TextBox)element).Location.X, ((TextBox)element).Location.Y - 15);
                }
            }
            if (e.Delta > 0)
            {
                foreach (var element in panel.Controls)
                {
                    if (element is Label)
                        ((Label)element).Location = new Point(((Label)element).Location.X, ((Label)element).Location.Y + 15);
                    if (element is GossipStone)
                        ((GossipStone)element).Location = new Point(((GossipStone)element).Location.X, ((GossipStone)element).Location.Y + 15);
                    if (element is TextBox)
                        ((TextBox)element).Location = new Point(((TextBox)element).Location.X, ((TextBox)element).Location.Y + 15);
                }
            }
            ((PanelWothBarren)panel).SetSuggestionContainer();
        }

        public void SetSuggestionContainer()
        {
            textBoxCustom.SetSuggestionsContainerLocation(this.Location);
            textBoxCustom.SuggestionContainer.BringToFront();
        }

        private void textBoxCustom_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        #region Woth
        public void PanelWoth(Dictionary<string, string> PlacesWithTag, ObjectPanelWotH data)
        {
            ListImage_WothItemsOption = data.GossipStoneImageCollection;
            NbMaxRows = data.NbMaxRows;

            LabelSettings = new Label
            {
                ForeColor = data.LabelColor,
                BackColor = data.LabelBackColor,
                Font = new Font(data.LabelFontName, data.LabelFontSize, data.LabelFontStyle),
                Width = data.LabelWidth,
                Height = data.LabelHeight
            };

            textBoxCustom = new TextBoxCustom
                (
                    PlacesWithTag,
                    new Point(0, 0),
                    data.TextBoxBackColor,
                    new Font(data.TextBoxFontName, data.TextBoxFontSize, data.TextBoxFontStyle),
                    data.TextBoxName,
                    new Size(data.TextBoxWidth, data.TextBoxHeight),
                    data.TextBoxText
                );
            textBoxCustom.TextBoxField.KeyDown += textBoxCustom_KeyDown_WotH;
            textBoxCustom.TextBoxField.MouseClick += textBoxCustom_MouseClick;
            textBoxCustom.SuggestionContainer.DoubleClick += SuggestionContainer_DoubleClick_Woth;
            textBoxCustom.SuggestionContainer.KeyUp += SuggestionContainer_KeyUp_Woth;
            this.Controls.Add(textBoxCustom.TextBoxField);
        }

        private void AddWoth(ObjectPanelWotH data)
        {
            if (ListWotH.Count < NbMaxRows)
            {
                if (textBoxCustom.TextBoxField.Text != string.Empty)
                {
                    var selectedPlace = textBoxCustom.TextBoxField.Text.ToUpper().Trim();

                    WotH newWotH = null;
                    if (ListWotH.Count <= 0)
                        newWotH = new WotH(selectedPlace, ListImage_WothItemsOption, new Point(2, -LabelSettings.Height), LabelSettings, GossipStoneSize, new Color[] { data.LabelColor, data.LabelColor2, data.LabelColor3 });
                    else
                    {
                        var lastLocation = ListWotH.Last().LabelPlace.Location;
                        newWotH = new WotH(selectedPlace, ListImage_WothItemsOption, lastLocation, LabelSettings, GossipStoneSize, new Color[] { data.LabelColor, data.LabelColor2, data.LabelColor3 });

                    }
                    ListWotH.Add(newWotH);
                    this.Controls.Add(newWotH.LabelPlace);
                    newWotH.LabelPlace.MouseClick += LabelPlace_MouseClick_WotH;

                    foreach (var gossipStone in newWotH.listGossipStone)
                    {
                        this.Controls.Add(gossipStone);
                    }
                    //Move TextBoxCustom
                    textBoxCustom.newLocation(new Point(2, newWotH.LabelPlace.Location.Y + newWotH.LabelPlace.Height), this.Location);
                }
            }
            textBoxCustom.TextBoxField.Text = string.Empty;
        }

        private void SuggestionContainer_DoubleClick_Woth(object sender, EventArgs e)
        {
            textBoxCustom.TextBoxField.Text = textBoxCustom.SuggestionContainer.SelectedItem.ToString();
            textBoxCustom.TextBoxField.Focus();
            textBoxCustom.SuggestionContainer.Hide();
            textBoxCustom.SuggestionContainerIsFocus = false;

            AddWoth(JsonSettings);
        }

        private void SuggestionContainer_KeyUp_Woth(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxCustom.TextBoxField.Text = textBoxCustom.SuggestionContainer.SelectedItem.ToString();
                textBoxCustom.TextBoxField.Focus();
                textBoxCustom.SuggestionContainer.Hide();
                textBoxCustom.SuggestionContainerIsFocus = false;

                AddWoth(JsonSettings);
            }
        }

        private void textBoxCustom_KeyDown_WotH(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AddWoth(JsonSettings);
            }
        }
        private void LabelPlace_MouseClick_WotH(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var label = (Label)sender;
                var woth = this.ListWotH.Where(x => x.LabelPlace.Name == label.Name).ToList()[0];
                this.RemoveWotH(woth);
            }
        }

        public void RemoveWotH(WotH woth)
        {
            ListWotH.Remove(woth);

            this.Controls.Remove(woth.LabelPlace);
            foreach (var gossipStone in woth.listGossipStone)
            {
                this.Controls.Remove(gossipStone);
            }

            for (int i = 0; i < ListWotH.Count; i++)
            {
                var wothLabel = ListWotH[i].LabelPlace;
                wothLabel.Location = new Point(2, (i * wothLabel.Height));

                for (int j = 0; j < ListWotH[i].listGossipStone.Count; j++)
                {
                    ListWotH[i].listGossipStone[j].Location =
                        new Point(wothLabel.Width + 5 + (j * (ListWotH[i].listGossipStone[j].Width + 2)), wothLabel.Location.Y);
                }
            }
            textBoxCustom.newLocation(new Point(2, ListWotH.Count * woth.LabelPlace.Height), this.Location);
        }
        #endregion

        #region Barren
        public void PanelBarren(Dictionary<string, string> PlacesWithTag, ObjectPanelBarren data)
        {
            NbMaxRows = data.NbMaxRows;

            LabelSettings = new Label
            {
                ForeColor = data.LabelColor,
                BackColor = data.LabelBackColor,
                Font = new Font(data.LabelFontName, data.LabelFontSize, data.LabelFontStyle),
                Width = data.LabelWidth,
                Height = data.LabelHeight
            };

            textBoxCustom = new TextBoxCustom
                (
                    PlacesWithTag,
                    new Point(0, 0),
                    data.TextBoxBackColor,
                    new Font(data.TextBoxFontName, data.TextBoxFontSize, data.TextBoxFontStyle),
                    data.TextBoxName,
                    new Size(data.TextBoxWidth, data.TextBoxHeight),
                    data.TextBoxText
                );
            textBoxCustom.TextBoxField.KeyDown += textBoxCustom_KeyDown_Barren;
            textBoxCustom.TextBoxField.MouseClick += textBoxCustom_MouseClick;
            textBoxCustom.SuggestionContainer.DoubleClick += SuggestionContainer_DoubleClick_Barren;
            textBoxCustom.SuggestionContainer.KeyUp += SuggestionContainer_KeyUp_Barren;
            this.Controls.Add(textBoxCustom.TextBoxField);
        }

        private void AddBarren()
        {
            if (ListBarren.Count < NbMaxRows)
            {
                var selectedPlace = textBoxCustom.TextBoxField.Text.ToUpper().Trim();
                var find = ListBarren.Where(x => x.Name == selectedPlace);
                if (find.Count() <= 0)
                {
                    Barren newBarren = null;
                    if (ListBarren.Count <= 0)
                        newBarren = new Barren(selectedPlace, new Point(2, -LabelSettings.Height), LabelSettings);
                    else
                    {
                        var lastLocation = ListBarren.Last().LabelPlace.Location;
                        newBarren = new Barren(selectedPlace, lastLocation, LabelSettings);
                    }
                    ListBarren.Add(newBarren);
                    this.Controls.Add(newBarren.LabelPlace);
                    newBarren.LabelPlace.MouseClick += LabelPlace_MouseClick_Barren;
                    textBoxCustom.newLocation(new Point(2, newBarren.LabelPlace.Location.Y + newBarren.LabelPlace.Height), this.Location);
                }
            }
            textBoxCustom.TextBoxField.Text = string.Empty;
        }

        private void SuggestionContainer_DoubleClick_Barren(object sender, EventArgs e)
        {
            textBoxCustom.TextBoxField.Text = textBoxCustom.SuggestionContainer.SelectedItem.ToString();
            textBoxCustom.TextBoxField.Focus();
            textBoxCustom.SuggestionContainer.Hide();
            textBoxCustom.SuggestionContainerIsFocus = false;

            AddBarren();
        }

        private void SuggestionContainer_KeyUp_Barren(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxCustom.TextBoxField.Text = textBoxCustom.SuggestionContainer.SelectedItem.ToString();
                textBoxCustom.TextBoxField.Focus();
                textBoxCustom.SuggestionContainer.Hide();
                textBoxCustom.SuggestionContainerIsFocus = false;

                AddBarren();
            }
        }

        private void textBoxCustom_KeyDown_Barren(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                AddBarren();
            }
        }

        private void LabelPlace_MouseClick_Barren(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var label = (Label)sender;
                var barren = this.ListBarren.Where(x => x.LabelPlace.Name == label.Name).ToList()[0];
                this.RemoveBarren(barren);
            }
        }
        public void RemoveBarren(Barren barren)
        {
            ListBarren.Remove(barren);

            this.Controls.Remove(barren.LabelPlace);

            for (int i = 0; i < ListBarren.Count; i++)
            {
                var wothLabel = ListBarren[i].LabelPlace;
                wothLabel.Location = new Point(2, (i * wothLabel.Height));
            }
            textBoxCustom.newLocation(new Point(2, ListBarren.Count * barren.LabelPlace.Height), this.Location);
        }
        #endregion
    }
}
