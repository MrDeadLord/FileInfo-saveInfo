using System;
using System.IO;
using System.Windows.Forms;

namespace Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var openedFile = new FileInfo(openFileDialog1.FileName);
                label2.Text = openedFile.Name;
                label4.Text = openedFile.Extension;
                label6.Text = openedFile.FullName;

                var inside = new StreamReader(openFileDialog1.FileName);
                label8.Text = inside.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "info.txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                
                using (var sr = new StreamWriter(fileName))
                {
                    sr.WriteLine("File name: {0}", label2.Text);
                    sr.WriteLine("Extention: {0}", label4.Text);
                    sr.WriteLine("Расположение: {0}", label6.Text);
                    sr.WriteLine("Содержание:");
                    sr.WriteLine(label8.Text);
                }
                
                MessageBox.Show("File saved", "File saved", MessageBoxButtons.OK);
                ActiveForm.Close();
            }
        }
    }
}
