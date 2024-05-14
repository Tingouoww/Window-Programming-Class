using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_3_1
{
    public partial class Form1 : Form
    {
        int a = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label6.Visible = false;
            label7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(a != 5)
            {
                a = 0;
                //判斷是否五個textBox皆輸入正確
                //a初始值為0
                //a = 5 表示5個textBox皆輸入正確
                if (textBox_name.Text == "")
                {
                    label1.Text = "此欄未填寫";
                }
                else
                {
                    label1.Text = "";
                    a++;
                }

                if (textBox_sex.Text == "")
                {
                    label2.Text = "此欄未填寫";
                }
                else if ((textBox_sex.Text != "女") && (textBox_sex.Text != "男"))
                {
                    label2.Text = "輸入應為男or女";
                }
                else
                {
                    label2.Text = "";
                    a++;
                }

                if (textBox_born.Text == "")
                {
                    label3.Text = "此欄未填寫";
                }
                else
                {
                    label3.Text = "";
                    a++;
                }

                if (textBox_today.Text == "")
                {
                    label4.Text = "此欄未填寫";
                }
                else
                {
                    label4.Text = "";
                    a++;
                }

                if (textBox_catdog.Text == "")
                {
                    label5.Text = "此欄未填寫";
                }
                else if ((textBox_catdog.Text != "貓") && (textBox_catdog.Text != "狗"))
                {
                    label5.Text = "輸入應為貓or狗";
                }
                else
                {
                    label5.Text = "";
                    a++;
                }

                //若五個textBox皆輸入正確，則進入神諭時刻
                if(a == 5)
                {
                    button1.Text = "來，下面一位~";

                    //textBox看不見
                    textBox_name.Visible = false;
                    textBox_sex.Visible = false;
                    textBox_born.Visible = false;
                    textBox_today.Visible = false;
                    textBox_catdog.Visible = false;

                    //label調整
                    label_input.Text = "神諭時刻";
                    label_name.Location = new Point(220,60);
                    label_sex.Location = new Point(510, 60);
                    label_born.Location = new Point(70, 120);
                    label_today.Location = new Point(370, 120);
                    label_catdog.Location = new Point(640, 120);
                    label1.Location = new Point(220, 90);
                    label2.Location = new Point(510, 90);
                    label3.Location = new Point(70, 150);
                    label4.Location = new Point(370, 150);
                    label5.Location = new Point(640, 150);
                    label1.Text = textBox_name.Text;
                    label2.Text = textBox_sex.Text;
                    label3.Text = textBox_born.Text;
                    label4.Text = textBox_today.Text;
                    label5.Text = textBox_catdog.Text;
                    //運勢&建議
                    label6.Visible = true;
                    label7.Visible = true;
                    label6.Location = new Point(100, 260);
                    label7.Location = new Point(100, 320);

                    String[] analysis = { "桃花運大漲", "家庭遭逢變故", "事業平步青雲，有升官可能", "事業起伏大", "親人病情好轉", "被財神眷顧", "近期一帆風順" };
                    String[] suggest = { "少做壞事，夜路走多了總匯三明治",
                     "保持謙虛，一山還有一山高，雞蛋還有雞蛋糕",
                     "善待他人，不要任意嘲笑別人，除非你忍不住",
                     "早點睡覺，不要仗著自己長得醜，就任意熬夜",
                     "小心小人，可謂浮雲能蔽日，輕舟已過萬重山",
                     "不要偷懶，你在睡覺的時候，美國人還在上班阿",
                     "健康第一，定期身體檢查並謹記醫生怎麼說，doctor!",
                     "穩定情緒，今天不開心沒關係，反正明天也不會開心"};
                    int x, y;
                    Random rand = new Random();
                    x = rand.Next(analysis.Length);
                    y = rand.Next(suggest.Length);

                    label6.Text = $"運勢:{analysis[x]}";
                    label7.Text = $"建議:{suggest[y]}";

                }
                //若有不正確的，則讓a歸零，等待新的輸入click
                else
                {
                    a = 0;
                }
            }

            else
            {
                button1.Text = "AI大神請告訴我答案吧";
                //textBox調整
                textBox_name.Visible = true;
                textBox_sex.Visible = true;
                textBox_born.Visible = true;
                textBox_today.Visible = true;
                textBox_catdog.Visible = true;
                textBox_name.Text = "";
                textBox_sex.Text = "";
                textBox_born.Text = "";
                textBox_today.Text = "";
                textBox_catdog.Text = "";
                //label調整
                label_input.Text = "資料輸入";
                label_name.Location = new Point(120, 80);
                label_sex.Location = new Point(120, 140);
                label_born.Location = new Point(120, 200);
                label_today.Location = new Point(120, 260);
                label_catdog.Location = new Point(120, 320);
                label1.Location = new Point(580, 80);
                label2.Location = new Point(580, 140);
                label3.Location = new Point(580, 200);
                label4.Location = new Point(580, 260);
                label5.Location = new Point(580, 320);
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label6.Visible = false;
                label7.Visible = false;
                //a回到初始值
                a = 0;
            }
            
        }
    }
}
