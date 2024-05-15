using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_6_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        string file_sound;
        PictureBox[,,] pic = new PictureBox[6, 7, 5];
        int button_state;
        SoundPlayer player = new SoundPlayer();
        char[] clock = new char[6];
        string[] upordown = new string[3];

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            button_state = 0;
            for(int x  = 0; x < 6; x++)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        pic[x,i,k] = new PictureBox();
                        pic[x, i, k].SetBounds(50+20 * k + 130 * x, 30 + 20 * i, 20 ,20);
                        Controls.Add(pic[x, i , k]);
                        pic[x,i,k].BorderStyle = BorderStyle.Fixed3D;
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "音樂檔案(*.wav, *.mp3)|*.wav;*.mp3";
            openFileDialog.FileName = null;
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_sound = openFileDialog.FileName;
                label1.Text = file_sound;
                if(textBox1.Text == "")
                {
                    textBox1.Text = $"{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 已設定鬧鈴";
                }
                else
                {
                    textBox1.Text = textBox1.Text + "\r\n" + $"{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 已設定鬧鈴";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文件檔案(*.txt)|*.txt";
            saveFileDialog.FileName = null;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog.FileName;
                FileStream fist = new FileStream(file, FileMode.Create);
                StreamWriter sw = new StreamWriter(fist);
                sw.Write(textBox1.Text);
                sw.Flush();
                sw.Close();
                textBox1.Text = textBox1.Text + "\r\n" + $"{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 已匯出記錄檔";
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if(button_state == 0)
            {
                if(file_sound == null)
                {
                    if(textBox1.Text == "")
                    {
                        textBox1.Text = $"{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute/10}{minute%10}:{second/10}{second%10} : 錯誤訊息! ";
                    }
                    else
                    {
                        textBox1.Text = textBox1.Text + $"\r\n{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 錯誤訊息! ";
                    }
                    MessageBox.Show("請先設定鬧鈴", "", MessageBoxButtons.OK);
                }
                else
                {
                    button_state = 1;
                    button2.Text = "停止";
                    player.SoundLocation = file_sound;
                    upordown = domainUpDown1.Text.Split(' ');
                    clock = upordown[1].ToCharArray();
                    textBox1.Text += $"\r\n{year}/{month/10}{month%10}/{day/10}{day%10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 已設定鬧鐘 ";
                    domainUpDown1.Enabled = false;
                }

                
            }
            else
            {
                button_state = 0;
                button2.Text = "啟動";
                textBox1.Text += $"\r\n{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 已關閉鬧鐘 ";
                domainUpDown1.Enabled = true;
                Array.Clear(clock, 0, clock.Length);
                Array.Clear(upordown,0, upordown.Length);
            }
        }

        int year;
        int month;
        int day;
        int hour;
        int minute;
        int second;
        int hour1;
        int hour2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
           
            

            if(DateTime.Now.Hour >= 12)
            {
                if(DateTime.Now.Hour == 12)
                {
                    hour1 = hour % 10;
                    hour2 = hour / 10;
                }
                else
                {
                    hour1 = (hour-12) % 10;
                    hour2 = (hour-12) / 10;
                }
                label3.Text = "下午";
            }
            else
            {
                hour1 = hour % 10;
                hour2 = hour / 10;
                label3.Text = "上午";
            }
            
            time_blue(second%10, 5);
            time_blue(second/10, 4);
            time_blue(minute%10, 3);
            time_blue(minute/10, 2);
            time_blue(hour1, 1);
            time_blue(hour2, 0);

            if(button_state == 1)
            {
                if (upordown[0] == label3.Text)
                {
                    if ((int.Parse(clock[0].ToString()) == hour2) && (int.Parse(clock[1].ToString()) == hour1))
                    {
                        if ((int.Parse(clock[3].ToString()) == minute/10) && (int.Parse(clock[4].ToString()) == minute % 10))
                        {
                            if(second == 0)
                            {
                                player.PlayLooping();
                                textBox1.Text += $"\r\n{year}/{month / 10}{month % 10}/{day / 10}{day % 10} {label3.Text} {hour2}{hour1}:{minute / 10}{minute % 10}:{second / 10}{second % 10} : 鬧鐘響鈴!";
                                MessageBox.Show("時間到! 該起床囉~~", "", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }

            if((button_state == 0) && (file_sound != null))
            {
                FileStream fIn = new FileStream(file_sound, FileMode.Open);
                player.Stop();                          
                fIn.Close();　　                                
            }

        }

        private void time_blue(int time, int picbox)
        {
            for(int i = 0; i < 7; i++)
            {
                for(int  j = 0; j < 5; j++)
                {
                    pic[picbox, i , j].BackColor = SystemColors.Control;
                }
            }
            switch (time)
            {
                case 0:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 2 ,4].BackColor = Color.Blue;
                    pic[picbox, 4, 0].BackColor= Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 0].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor= Color.Blue;
                    pic[picbox, 6, 1].BackColor= Color.Blue;
                    pic[picbox, 6, 2].BackColor= Color.Blue;
                    pic[picbox, 6, 3].BackColor= Color.Blue;
                    break;

                case 1:
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    break;

                case 2:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor =Color.Blue;
                    pic[picbox, 3 ,2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    pic[picbox, 4, 0].BackColor = Color.Blue;
                    pic[picbox, 5, 0].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    break;

                case 3:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    break;

                case 4:
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    break;

                case 5:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    break;

                case 6:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    pic[picbox, 4, 0].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 0].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    break;

                case 7:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    break;

                case 8:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 4, 0].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 0].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    break;

                case 9:
                    pic[picbox, 0, 1].BackColor = Color.Blue;
                    pic[picbox, 0, 2].BackColor = Color.Blue;
                    pic[picbox, 0, 3].BackColor = Color.Blue;
                    pic[picbox, 1, 0].BackColor = Color.Blue;
                    pic[picbox, 1, 4].BackColor = Color.Blue;
                    pic[picbox, 2, 0].BackColor = Color.Blue;
                    pic[picbox, 2, 4].BackColor = Color.Blue;
                    pic[picbox, 4, 4].BackColor = Color.Blue;
                    pic[picbox, 5, 4].BackColor = Color.Blue;
                    pic[picbox, 6, 1].BackColor = Color.Blue;
                    pic[picbox, 6, 2].BackColor = Color.Blue;
                    pic[picbox, 6, 3].BackColor = Color.Blue;
                    pic[picbox, 3, 1].BackColor = Color.Blue;
                    pic[picbox, 3, 2].BackColor = Color.Blue;
                    pic[picbox, 3, 3].BackColor = Color.Blue;
                    break;

            }
        }

        
    }
}
