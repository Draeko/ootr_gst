﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerOOT
{
    class WotH
    {
        public Label LabelPlace;
        public List<GossipStone> listGossipStone = new List<GossipStone>();
        public string Name;
        int LabelPlaceNbClick = 0;
        Color woth1;
        Color woth2;
        Color woth3;

        public WotH(string selectedPlace, string[] listImage, Point lastLabelLocation, Label labelSettings, Size gossipStoneSize, Color[] wothColors)
        {
            this.Name = selectedPlace;

            this.LabelPlace = new Label
            {
                Name = Guid.NewGuid().ToString(),
                Text = selectedPlace,
                ForeColor = labelSettings.ForeColor,
                BackColor = labelSettings.BackColor,
                Font = labelSettings.Font,
                Width = labelSettings.Width,
                Height = labelSettings.Height,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            
            this.LabelPlace.Location = new Point(2, lastLabelLocation.Y + LabelPlace.Height);
            this.LabelPlace.MouseDown += new MouseEventHandler(label_woth_MouseDown);

            if (listImage.Length > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    GossipStone newGossipStone = new GossipStone(this.Name + "_GossipStone" + i, 0, 0, listImage, gossipStoneSize);
                    newGossipStone.Location = 
                        new Point(LabelPlace.Width + 5 + ((newGossipStone.Width+2) * i ), LabelPlace.Location.Y);
                    listGossipStone.Add(newGossipStone);
                }
            }

            this.woth1 = wothColors[0];
            this.woth2 = wothColors[1];
            this.woth3 = wothColors[2];
        }

        private void label_woth_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (LabelPlaceNbClick)
                {
                    case 0:
                        LabelPlace.ForeColor = woth2;
                        LabelPlaceNbClick++;
                        break;
                    case 1:
                        LabelPlace.ForeColor = woth3;
                        LabelPlaceNbClick++;
                        break;
                    case 2:
                        LabelPlace.ForeColor = woth1;
                        LabelPlaceNbClick = 0;
                        break;
                }
            }            
        }
    }
}
