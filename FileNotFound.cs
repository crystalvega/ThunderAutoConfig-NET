using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ThunderAutoConfig_NET
{
    public partial class FileNotFound : Form
    {
        internal int code = 2;
        public FileNotFound()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string directoryPath = @"C:\Program Files\ConfigNKU\";
            string fileName = "ThunderAutoConfig.cfg";
            string filePath = Path.Combine(directoryPath, fileName);
            string folder = Path.GetDirectoryName(openFileDialog1.FileName);

            // Проверяем, существует ли директория, если нет - создаем её
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Создаем или перезаписываем файл
            File.WriteAllText(filePath, folder);
            code = 0;
            Close();
        }

        private void FileNotFound_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (code == 2)
            { 
                Environment.Exit(code);
            }
        }

        private void FileNotFound_FormClosed(object sender, EventArgs e)
        {
            if (code == 2)
            {
                Environment.Exit(code);
            }
        }
    }
}
