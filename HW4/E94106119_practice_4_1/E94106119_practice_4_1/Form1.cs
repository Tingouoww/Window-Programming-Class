using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_4_1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        int[] password = new int[4];
        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                password[i] = random.Next(0,10);
            }
            btn1.ImageIndex = 0;
            btn2.ImageIndex = 0;
            btn3.ImageIndex = 0;
            btn4.ImageIndex = 0;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if(btn1.ImageIndex  != 9)
            {
                btn1.ImageIndex++;
            }
            else
            {
                btn1.ImageIndex = 0;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.ImageIndex != 9)
            {
                btn2.ImageIndex++;
            }
            else
            {
                btn2.ImageIndex = 0;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.ImageIndex != 9)
            {
                btn3.ImageIndex++;
            }
            else
            {
                btn3.ImageIndex = 0;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.ImageIndex != 9)
            {
                btn4.ImageIndex++;
            }
            else
            {
                btn4.ImageIndex = 0;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int right = 0;
            if(btn1.ImageIndex == password[0])
            {
                right++;
            }
            if(btn2.ImageIndex == password[1])
            {
                right++;
            }
            if( btn3.ImageIndex == password[2])
            {
                right++;
            }
            if(btn4.ImageIndex == password[3])
            {
                right++;
            }

            switch (right)
            {
                case 4:
                    MessageBox.Show($"解鎖成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                
                default:
                    DialogResult result;
                    result = MessageBox.Show($"猜對{right}個位置", "失敗", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                    if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show($"答案是{password[0]}{password[1]}{password[2]}{password[3]}", "正確答案", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {

                    }
                    break;

                
            }
        }
    }
}
