using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_7_1
{
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        List<string> word = new List<string>();
        List<string> Chinese = new List<string>();
        List<string> speech = new List<string>();
        List<bool> icon = new List<bool>();
        Random random = new Random();
        Font font2;
        int num;
        int cord;
        public Form2(List<string> word1, List<string> chinese1, List<string> speech1 , List<bool>icon1, Font font, Form1 form1)
        {
            InitializeComponent();

            word = word1;
            Chinese= chinese1;
            speech = speech1;
            icon = icon1;
            font2 = font;
            f1 = form1;
            this.FormClosed += Form2_FormClosed;
        }

        private void label_set()
        {
            label1.Text = "單字: " + word[num];
            label2.Text = "中文: " + Chinese[num];
            label3.Text = "詞性: " + speech[num];
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            num = random.Next(word.Count);
            label1.Font = font2;
            label2.Font = font2;
            label3.Font = font2;
            label_set();
            panel1.Visible = false;
            if (icon[num] == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                icon[num] = true;
            }
            else
            {
                icon[num] = false;
            }
            num = random.Next(word.Count);
            panel1.Visible = false;
            label_set();
            if (icon[num] == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void Form2_FormClosed(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                icon[num] = true;
            }
            else
            {
                icon[num] = false;
            }
            this.Hide();
            f1.icon = this.icon;
            f1.Show();
        }
    }
}
