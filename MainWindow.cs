using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThunderAutoConfig_NET
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMailDialog addmail = new AddMailDialog();
            DialogResult result = addmail.ShowDialog();
            if (result == DialogResult.OK)
            {
                checkedListBox1.Items.Add("Horosho");
            }
            else if(result == DialogResult.Cancel)
            {
                checkedListBox1.Items.Add("Ploho");
            }
        }
    }
}
