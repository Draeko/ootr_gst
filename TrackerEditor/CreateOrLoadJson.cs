namespace TrackerEditor
{
    public partial class CreateOrLoadJson : Form
    {
        public CreateOrLoadJson()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Size = new Size(300, 150);
            this.CenterToScreen();

            this.Text = "Tracker Editor";

            Button newJson = new Button();
            newJson.Text = "Create new template";
            newJson.TextAlign = ContentAlignment.MiddleCenter;
            newJson.Location = new Point(5, 5);
            newJson.Size = new Size((this.Width - 25) / 2, this.Height - 50);
            newJson.Font = new Font("Consolas", 15, FontStyle.Bold);
            newJson.Click += NewJson_Click;

            Button loadJson = new Button();
            loadJson.Text = "Load template";
            loadJson.TextAlign = ContentAlignment.MiddleCenter;
            loadJson.Location = new Point(newJson.Width + 5, 5);
            loadJson.Size = new Size((this.Width - 25) / 2, this.Height - 50);
            loadJson.Font = new Font("Consolas", 15, FontStyle.Bold);
            loadJson.Click += LoadJson_Click;


            this.Controls.Add(newJson);
            this.Controls.Add(loadJson);
        }

        private void NewJson_Click(object? sender, EventArgs e)
        {
            this.Hide();
            TemplateEditor form = new TemplateEditor();
            form.ShowDialog();
        }

        private void LoadJson_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Fichiers json (*.json)|*.json";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\Layouts";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                this.Hide();
                TemplateEditor form = new TemplateEditor(file);
                form.ShowDialog();
                

            }

        }
    }
}