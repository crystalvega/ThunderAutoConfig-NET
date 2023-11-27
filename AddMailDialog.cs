using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ThunderAutoConfig_NET
{
    public partial class AddMailDialog : Form
    {
        public string[] AvalibleDomens { private get; set; }
        public bool InDomensList { get; private set; }
        public string Mail { get; private set; }
        public string SMTP { get; private set; }
        public string IMAP { get; private set; }
        private bool customMail = false;
        private bool isClosedByButton = false;

        public AddMailDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            label2.Visible = false;
            if (!customMail)
            {
                Mail = textBox1.Text;
                AvalibleDomens = new string[1] { "mail.ru" };
                bool validmail = IsEmailValid(textBox1.Text);
                if (!validmail)
                {
                    label2.Text = "Значение email не является правильным email адресом!\r\n";
                    label2.Visible = true;
                    textBox1.ReadOnly = false;
                }
                else
                {
                    if (AvalibleDomens.Contains(Mail.Split('@')[1]))
                    {
                        InDomensList = true;
                        isClosedByButton = true;
                        Close();
                    }
                    else
                    {
                        label3.Visible = true;
                        label4.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        button2.Enabled = true;
                        Size = new Size(345, 286);
                        button1.Location = new Point(161, 216);
                        button2.Location = new Point(242, 216);
                        label2.Location = new Point(15, 187);
                        customMail = true;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    label2.Text = "Значение IMAP и SMTP не могут являться пустыми!\r\n";
                    label2.Visible = true;
                }
                else
                {
                    IMAP = textBox2.Text;
                    SMTP = textBox3.Text;
                    InDomensList = false;
                    isClosedByButton = true;
                    Close();
                }
            }
        }

        static bool IsEmailValid(string email)
        {
            // Используем регулярное выражение для проверки адреса электронной почты
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);

            // Проверяем соответствие регулярному выражению
            return regex.IsMatch(email);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Enabled = false;
            textBox1.ReadOnly = false;
            Size = new Size(345, 184);
            button1.Location = new Point(161, 120);
            button2.Location = new Point(242, 120);
            label2.Location = new Point(15, 90);
            customMail = false;
        }

        private void AddMailDialog_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            Size = new Size(345, 184);
            button1.Location = new Point(161, 120);
            button2.Location = new Point(242, 120);
            label2.Location = new Point(15, 90);
        }

        private void AddMailDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosedByButton)
            {
                // Форма закрыта через кнопку
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Форма закрыта через крестик
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
