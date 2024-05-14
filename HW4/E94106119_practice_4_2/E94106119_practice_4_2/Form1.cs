using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] b = new Button[3, 4];
        int money = 100;
        int seed = 5;
        int fertilizer = 5;
        int fruit = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    b[j,i] = new Button();
                    b[j,i].SetBounds(100 * j+4, 100 * i+15, 100, 100); //(starting point X, starting point Y, width, heigth)
                    tabPage1.Controls.Add(b[j, i]);
                    b[j, i].BackgroundImageLayout = ImageLayout.Stretch;
                    b[j, i].ImageList = imageList1;
                    b[j, i].ImageIndex = 0;
                    b[j, i].Click += new EventHandler(btn_Click);
                    b[j, i].Name = $"{j}_{i}";
                }
            }
        }
        int[,] water = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] fer_state = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string[] sp = btn.Name.Split('_');
            int row = int.Parse(sp[1]);
            int column = int.Parse(sp[0]);

            if (radioButton1.Checked)
            {
                if((btn.ImageIndex == 1) || (btn.ImageIndex == 2))
                {
                    if (water[row, column] == 0)
                    {
                        water[row, column] = 1;
                        if ((water[row, column] == 1) && (fer_state[row,column] == 1))
                        {
                            btn.ImageIndex++;
                            water[row, column] = 0;
                            fer_state[row, column] = 0;
                        }
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                if(seed <= 0)
                {
                    MessageBox.Show($"種子用完了", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (btn.ImageIndex == 0)
                    {
                        btn.ImageIndex = 1;
                        seed--;
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                if(fertilizer <= 0)
                {
                    MessageBox.Show($"肥料用完了", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((btn.ImageIndex == 1) || (btn.ImageIndex == 2))
                    {
                        if (fer_state[row, column] == 0)
                        {
                            fer_state[row, column] = 1;
                            fertilizer--;
                            if ((water[row, column] == 1) && (fer_state[row, column] == 1))
                            {
                                btn.ImageIndex++;
                                water[row, column] = 0;
                                fer_state[row, column] = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                if(btn.ImageIndex == 3)
                {
                    btn.ImageIndex = 0;
                    fruit++;
                    water[row, column] = 0;
                    fer_state[row, column] = 0;
                }
            }

            label1.Text = $"擁有:{seed}";
            label2.Text = $"擁有:{fertilizer}";
            label3.Text = $"擁有:{fruit}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //無論如何都可以賣果實
            if (checkBox3.Checked)
            {
                if(fruit >= 1)
                {
                    fruit--;
                    money += 40;
                }
            }

            //錢要大於10才能買種子或肥料
            if(money >= 10)
            {
                //種子優先購買
                if (checkBox1.Checked)
                {
                    seed++;
                    money -= 10;
                }
                //再判斷夠不夠錢買肥料
                if(money >= 10)
                {
                    if (checkBox2.Checked)
                    {
                        fertilizer++;
                        money -= 10;
                    }
                }
            }

            label_money.Text = $"金錢:{money}";
            label1.Text = $"擁有:{seed}";
            label2.Text = $"擁有:{fertilizer}";
            label3.Text = $"擁有:{fruit}";
        }

    }
}
