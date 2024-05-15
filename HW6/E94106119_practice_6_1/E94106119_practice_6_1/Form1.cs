using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;


namespace E94106119_practice_6_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int time = 0;
        int count = 0;
        private void Time_Reset()
        {
            timer1.Enabled = false;
            time = 0;
            timer1.Interval = 1000;
        }

        private void button_start()
        {
            for(int k = 0; k < 9; k++)
            {
                Controls.Remove(p[k]);
            }
            int row = -1;
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    row++;
                }
                p[i] = new Button();
                p[i].SetBounds(58 + 92 * (i % 3), 31 + 92 * row, 90, 90);
                p[i].BackColor = Color.White;
                p[i].FlatStyle = FlatStyle.Flat;
                p[i].FlatAppearance.BorderColor = Color.White;
                Controls.Add(p[i]);
            }
            p[8].Visible = false;
        }

        OpenFileDialog open = new OpenFileDialog();
        private void button_choose_Click(object sender, EventArgs e)
        {
            open.Filter = "圖片|*.jpg;*.jpeg;*.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                label1.Visible = true;
                label2.Visible = true;
                trackBar1.Enabled = true;
                trackBar1.Visible = true;
                Bitmap origin = new Bitmap(open.FileName);
                Bitmap resize = new Bitmap(270, 270);

                using (Graphics g = Graphics.FromImage(resize))
                {
                    g.DrawImage(origin, 0, 0, 270, 270);
                }
                string Path = open.FileName;
                pictureBox1.Image = resize;
            }
        }

        
        Button [] p = new Button[9]; 
        private void Form1_Load(object sender, EventArgs e)
        {
            Time_Reset();
            trackBar1.Enabled = false;
            trackBar1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Visible = false;

            label3.Text = "時間:00:00";
            label4.Text = "移動步數: 0";

            button_start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(trackBar1.Value == 0)
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible=true;
            }
        }

        Bitmap [] bit = new Bitmap[9];
        private void button_draw_Click(object sender, EventArgs e)
        {  
            if (pictureBox1.Image == null)
            { 
                MessageBox.Show("請先選擇圖片!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                label3.Text = "時間:00:00";
                button_start();
                Time_Reset();
                timer1.Enabled = true;
                for (int i = 0; i < 9; i++)
                {
                    p[i].Enabled = true;
                }
                count = 0;
                label4.Text = $"移動步數:{count}";
                for(int x = 0; x < 9; x++)
                {
                    p[x].Click += pic_Click;
                }
                Bitmap image = new Bitmap(pictureBox1.Image);
                for(int row = 0; row < 3; row++)
                {
                    for(int column = 0; column <3; column++)
                    {
                        Bitmap bitmap = new Bitmap(90, 90);
                        int x = column * 90;
                        int y = row * 90;

                        using(Graphics g = Graphics.FromImage(bitmap))
                        {
                            Rectangle rectangle = new Rectangle(x, y, 90, 90);
                            g.DrawImage(image, new Rectangle(0, 0, 90, 90), rectangle, GraphicsUnit.Pixel);
                        }

                        bit[row * 3 + column] = bitmap;
                    }
                }

                Random random = new Random();
                int[] code = new int[] {0, 1, 2, 3, 4, 5, 6, 7 };
                for(int x = 0; x < 50; x++)
                {
                    int k = random.Next(8);
                    int m = random.Next(8);
                    int reg = code[k];
                    code[k] = code[m];
                    code[m] = reg;
                }

                for(int r = 0; r < 8; r++)
                {
                    p[r].Image = bit[code[r]];
                }
                p[8].Image = bit[8];

            }
        }

        private void pic_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Image image;
            if (button == p[0])
            {
                image = p[0].Image;
                if (p[1].Visible == false)
                {
                    p[0].Image = p[1].Image;
                    p[1].Image = image;
                    p[0].Visible = false;
                    p[1].Visible = true;
                    count++;
                }
                else if (p[3].Visible == false)
                {
                    p[0].Image = p[3].Image;
                    p[3].Image = image;
                    p[3].Visible = true;
                    p[0].Visible = false;
                    count++;
                }
            }

            else if (button == p[1])
            {
                image = p[1].Image;
                if (p[0].Visible == false)
                {
                    p[1].Image = p[0].Image;
                    p[0].Image = image;
                    p[0].Visible = true;
                    p[1].Visible = false;
                    count++;
                }
                else if (p[2].Visible == false)
                {
                    p[1].Image = p[2].Image;
                    p[2].Image = image;
                    p[2].Visible = true;
                    p[1].Visible = false;
                    count++;
                }
                else if (p[4].Visible == false)
                {
                    p[1].Image = p[4].Image;
                    p[4].Image = image;
                    p[4].Visible = true;
                    p[1].Visible = false;
                    count++;
                }
            }

            else if (button == p[2])
            {
                image = p[2].Image;
                if (p[1].Visible == false)
                {
                    p[2].Image = p[1].Image;
                    p[1].Image = image;
                    p[1].Visible = true;
                    p[2].Visible = false;
                    count++;
                }
                else if (p[5].Visible == false)
                {
                    p[2].Image = p[5].Image;
                    p[5].Image = image;
                    p[5].Visible = true;
                    p[2].Visible = false;
                    count++;
                }
            }

            else if (button == p[3])
            {
                image = p[3].Image;
                if (p[0].Visible == false)
                {
                    p[3].Image = p[0].Image;
                    p[0].Image = image;
                    p[0].Visible = true;
                    p[3].Visible = false;
                    count++;
                }
                else if (p[4].Visible == false)
                {
                    p[3].Image = p[4].Image;
                    p[4].Image = image;
                    p[4].Visible = true;
                    p[3].Visible = false;
                    count++;
                }
                else if (p[6].Visible == false)
                {
                    p[3].Image = p[6].Image;
                    p[6].Image = image;
                    p[6].Visible = true;
                    p[3].Visible = false;
                    count++;
                }
            }
            else if (button == p[4])
            {
                image = p[4].Image;
                if (p[1].Visible == false)
                {
                    p[4].Image = p[1].Image;
                    p[1].Image = image;
                    p[1].Visible = true;
                    p[4].Visible = false;
                    count++;
                }
                else if (p[3].Visible == false)
                {
                    p[4].Image = p[3].Image;
                    p[3].Image = image;
                    p[3].Visible = true;
                    p[4].Visible = false;
                    count++;
                }
                else if (p[5].Visible == false)
                {
                    p[4].Image = p[5].Image;
                    p[5].Image = image;
                    p[5].Visible = true;
                    p[4].Visible = false;
                    count++;
                }
                else if (p[7].Visible == false)
                {
                    p[4].Image = p[7].Image;
                    p[7].Image = image;
                    p[7].Visible = true;
                    p[4].Visible = false;
                    count++;
                }
            }
            else if (button == p[5])
            {
                image = p[5].Image;
                if (p[2].Visible == false)
                {
                    p[5].Image = p[2].Image;
                    p[2].Image = image;
                    p[2].Visible = true;
                    p[5].Visible = false;
                    count++;
                }
                else if (p[4].Visible == false)
                {
                    p[5].Image = p[4].Image;
                    p[4].Image = image;
                    p[4].Visible = true;
                    p[5].Visible = false;
                    count++;
                }
                else if (p[8].Visible == false)
                {
                    p[5].Image = p[8].Image;
                    p[8].Image = image;
                    p[8].Visible = true;
                    p[5].Visible = false;
                    count++;
                }
            }

            else if (button == p[6])
            {
                image = p[6].Image;
                if (p[3].Visible == false)
                {
                    p[6].Image = p[3].Image;
                    p[3].Image = image;
                    p[3].Visible = true;
                    p[6].Visible = false;
                    count++;
                }
                else if (p[7].Visible == false)
                {
                    p[6].Image = p[7].Image;
                    p[7].Image = image;
                    p[7].Visible = true;
                    p[6].Visible = false;
                    count++;
                }
            }

            else if (button == p[7])
            {
                image = p[7].Image;
                if (p[4].Visible == false)
                {
                    p[7].Image = p[4].Image;
                    p[4].Image = image;
                    p[4].Visible = true;
                    p[7].Visible = false;
                    count++;
                }
                else if (p[6].Visible == false)
                {
                    p[7].Image = p[6].Image;
                    p[6].Image = image;
                    p[6].Visible = true;
                    p[7].Visible = false;
                    count++;
                }
                else if (p[8].Visible == false)
                {
                    p[7].Image = p[8].Image;
                    p[8].Image = image;
                    p[8].Visible = true;
                    p[7].Visible = false;
                    count++;
                }
            }
            else if (button == p[8])
            {
                image = p[8].Image;
                if (p[5].Visible == false)
                {
                    p[8].Image = p[5].Image;
                    p[5].Image = image;
                    p[5].Visible = true;
                    p[8].Visible = false;
                    count++;
                }
                else if (p[7].Visible == false)
                {
                    p[8].Image = p[7].Image;
                    p[7].Image = image;
                    p[7].Visible = true;
                    p[8].Visible = false;
                    count++;
                }
             
            }

            label4.Text = $"移動步數:{count}";
            int end_state = 0;
            for(int i = 0; i < 9; i++)
            {
                if (p[i].Image == bit[i])
                {
                    end_state++;
                }
            }
            if( end_state == 9)
            {
                timer1.Enabled = false;
                if (min < 10)
                {
                    str_time = "時間:0" + min.ToString();
                }
                else
                {
                    str_time = "時間:" + min.ToString();
                }
                if (time % 60 < 10)
                {
                    str_time = str_time + ":0" + ((time) % 60).ToString();
                }
                else
                {
                    str_time = str_time + ":" + ((time) % 60).ToString();
                }
                DialogResult result;
                result =  MessageBox.Show($"你獲勝了\n完成{str_time}\n移動步數:{count}", "win", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    label3.Text = "時間:00:00";
                    label4.Text = "移動步數:0";
                }
                for (int i = 0; i < 9; i++)
                {
                    p[i].Enabled = false;
                }
            }
        }

        int min;
        string str_time;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            min = time / 60;
            if (min < 10)
            {
                str_time = "時間:0" + min.ToString();
            }
            else
            {
                str_time = "時間:" + min.ToString();
            }
            if(time % 60 < 10)
            {
                str_time = str_time + ":0" + (time % 60).ToString();
            }
            else
            {
                str_time = str_time + ":" + (time%60).ToString();
            }
            label3.Text = str_time;
        }
    }
}
