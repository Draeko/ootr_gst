using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOTRandoLibrary;
using OOTRandoLibrary.InteractiveImplementation;

namespace OOTRandoTrackerGUI
{
    public class Layout
    {
        List<Control> ListControl = new List<Control>();
        public AppSettings? App_Settings = new AppSettings();

        private void LoadElement<T>(string categoryName, KeyValuePair<string, JToken?> keyValuePair) where T : InteractiveBox
        {
            if (keyValuePair.Key.ToString() == categoryName)
            {
                if (keyValuePair.Value != null)
                {
                    foreach (var element in keyValuePair.Value)
                    {
                        T? newElement = JsonConvert.DeserializeObject<T>(element.ToString());
                        if (newElement != null)
                        {
                            newElement.LoadData();
                            ListControl.Add(newElement);
                        }
                        else
                        {
                            //TODO : display error message
                        }
                    }
                }
                else
                {
                    //TODO : display error message
                }
            }
        }

        public void LoadLayout(Form1 form)
        {
            if (form.ActiveLayoutName != string.Empty)
            {
                JObject json_layouts = JObject.Parse(File.ReadAllText(@"Layouts/" + form.ActiveLayoutName + ".json"));
                foreach (var category in json_layouts)
                {
                    if (category.Key.ToString() == "AppSize")
                    {
                        if (category.Value != null)
                        {
                            App_Settings = JsonConvert.DeserializeObject<AppSettings>(category.Value.ToString());
                        }
                        
                    }

                    LoadElement<ItemWithTinyBox>("ItemsWithTinyBoxes", category);
                    LoadElement<Item>("Items", category);
                    LoadElement<EmptyBox>("EmptyBoxes", category);
                    LoadElement<ItemWithLabel>("ItemsWithLabel", category);
                }

                form.Size = new Size(App_Settings.Width, App_Settings.Height);
                form.BackColor = App_Settings.BackgroundColor;

                if(ListControl.Count > 0)
                {
                    foreach (var item in ListControl)
                    {
                        if(item.Visible)
                        {
                            form.Controls.Add(item);
                            if (item.GetType() == typeof(ItemWithLabel))
                            {
                                var medallion = item as ItemWithLabel;
                                form.Controls.Add(medallion.interactiveBoxLabel);
                                medallion.SetSelectedDungeonLocation();
                                medallion.interactiveBoxLabel.BringToFront();

                            }
                        }
                    }
                }
            }
        }
    }
}
