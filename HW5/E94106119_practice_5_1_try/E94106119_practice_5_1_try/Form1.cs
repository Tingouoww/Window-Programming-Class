using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace E94106119_practice_5_1_try
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = false;
        }

        Button[] b = new Button[36];
        Random rand = new Random();
        int[] ans_num = new int[3];
        int time_count;
        bool player;

        private void Button_play() 
        {
            for (int k = 0; k < 36; k++)
            {
                b[k] = new Button();
                b[k].SetBounds(54 * (k % 12) + 50, 54 * (k / 12) + 200, 50, 50);
                if (k > 9)
                {
                    b[k].Text = ((char)(k + 55)).ToString();
                }
                else
                {
                    b[k].Text = k.ToString();
                }

                Controls.Add(b[k]);
            }

            for (int i = 0; i < 3; i++)
            {
                ans_num[i] = rand.Next(0, 36);
                if (i > 0)
                {
                    while (ans_num[i] == ans_num[i - 1])
                    {
                        ans_num[i] = rand.Next(0, 36);
                    }
                }
                else { }
                b[ans_num[i]].BackColor = Color.LightGreen;
            }
        }

        private void Time_Reset()
        {
            timer1.Enabled = false;
            timer1.Interval = 1000;
            time_count = 5;
        }

        private void Game_Reset()
        {
            button1.Enabled = true;
            button1.Visible = true;
            label_state.Text = "";
            label_time.Text = "";
            player = false;
            for (int i = 0; i < 36; i++)
            {
                Controls.Remove(b[i]);
            }
        }
        private void Prepare_Game()
        {
            button1.Enabled = false;
            button1.Visible = false;
            label_state.Text = "準備階段";
            player = false;
            Button_play();
            Time_Reset();
            timer1.Enabled = true;
        }

        private void Game_Start()
        {
            for (int j = 0; j < 36; j++)
            {
                b[j].BackColor = SystemColors.Control;
            }
            player = true;
            label_state.Text = "玩家階段";
            timer1.Enabled = true;
        }

        private void Game_Over()
        {
            bool lose = false;
            int win = 0;
            for(int i = 0; i < 36; i++)
            {
                if (b[i].BackColor == Color.LightBlue)
                {
                    bool right = false;
                    for(int j = 0; j < 3; j++)
                    {
                        if(i == ans_num[j])
                        {
                            b[i].BackColor = Color.LightGreen;
                            win++;
                            right = true;
                            break;
                        }
                    }
                    if(right == false)
                    {
                        b[i].BackColor = Color.Red;
                        lose = true;
                    }
                }
                else
                {
                    for(int k  = 0; k < 3; k++)
                    {
                        if(i == ans_num[k])
                        {
                            b[i].BackColor = Color.Red;
                            lose = true;
                        }
                    }
                }
            }

            DialogResult result;
            if ((win == 3) && (lose == false))
            {
                result = MessageBox.Show("You win!", "你真是金頭腦", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                result = MessageBox.Show("You lose!\nTry again", "腦袋不夠用喔", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            if (result == DialogResult.OK)
            {
                Game_Reset();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prepare_Game();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_time.Text = time_count.ToString();
            if (time_count == 0)
            {
                Time_Reset();
                if (player)
                {
                    Game_Over();
                    player = false;
                }
                else
                {
                    Game_Start();
                }
            }
            else
            {
                time_count--;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int press;
            bool condition1 = (((int)e.KeyCode >= 48) && ((int)e.KeyCode <= 57));
            bool condition2 = (((int)e.KeyCode >= 65) && ((int)e.KeyCode <= 90));
            if (player)
            {
                if (condition1)
                {
                    press = (int)e.KeyCode - 48;
                    b[press].BackColor = Color.LightBlue;
                }
                else if (condition2)
                {
                    press = (int)e.KeyCode - 55;
                    b[press].BackColor= Color.LightBlue;
                }
            }
        }
    }
}
