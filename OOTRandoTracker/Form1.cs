using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace OOTRandoTracker
{
    public partial class Form1 : Form
    {
        public static string ActiveLayoutName = string.Empty;
        public static Layout CurrentLayout = new Layout();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Items&Hints Tracker v1.8.4";
            this.AcceptButton = null;
            this.MaximizeBox = false;
            /*
            JObject json_properties = JObject.Parse(File.ReadAllText(@"settings.json"));
            foreach (var property in json_properties)
            {
                if (property.Key == "ActiveLayout")
                {
                    ActiveLayoutName = property.Value.ToString();
                }
            }
            */
            CurrentLayout.LoadLayout(this, null, null);
        }

    }
}
