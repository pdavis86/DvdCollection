using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvdCollection.ImportUi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePathTextBox.Text = openFileDialog1.FileName;
            }
            else
            {
                FilePathTextBox.Clear();
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            //todo: replace hard-coded key
            var os = new Core.Services.OmdbService("{replaceme}");
            var ms = new Core.Services.MediaService(new Data.Context(), os);

            var result = Task.Run(async () => await ms.AddAsync(FilePathTextBox.Text, ImdbIdTextBox.Text)).Result;

            if (result.IsSuccess)
            {
                MessageBox.Show("Done");
                FilePathTextBox.Text = null;
                ImdbIdTextBox.Text = null;
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }

    }
}
