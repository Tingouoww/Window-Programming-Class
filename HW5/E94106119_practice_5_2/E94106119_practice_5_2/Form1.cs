using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94106119_practice_5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int time;
        int player_num = 0;
        int turn = 0;
        int beast;
        int member1, member2;

        bool choose = false;
        bool game = true;

        Button[] b = new Button[3];

        string[] player = new string[2];
        Servant[] servants = new Servant[3];

        class Servant
        {
            public string character;
            public int hp;
            public int charge;
            public int atk;
            public int speed;
            public int cold;
            public bool survive;
            public virtual void Skill() {
                cold = 2;
            }

        }
        class Saber : Servant
        {
            public Saber()
            {
                character = "Saber";
                hp = 100;
                charge = 0;
                atk = 3;
                speed = 1;
                cold = 2;
                survive = true;
            }
            public override void Skill()
            {
                base.Skill();
                atk = atk * 2;
            }

        }
        class Caster : Servant
        {
            public Caster()
            {
                character = "Caster";
                hp = 100;
                charge = 0;
                atk = 2;
                speed = 2;
                cold = 2;
                survive = true;
            }

            public override void Skill()
            {
                base.Skill();
                hp = hp + (hp / 2);
            }
        }

        class Berserker : Servant
        {
            public Berserker()
            {
                character = "Berserker";
                hp = 100;
                charge = 0;
                atk = 4;
                speed = 4;
                cold = 2;
                survive = true;
            }
            public override void Skill()
            {
                base.Skill();
                atk = atk * 2;
                hp = hp - (hp / 2);
            }

        }
        class Beast : Servant
        {
            public Beast()
            {
                character = "Beast";
                hp = 500;
                charge = 0;
                atk = 2;
                speed = 3;
                cold = 3;
                survive = true;
            }
            public override void Skill()
            {
                cold = 3;
                atk = atk + 2;
            }
        }
        private void All_Reset()
        {
            Prepare_Time_Reset();
            player_num = 0;
            turn = 0;
            beast = -1;
            button_start.Enabled = true;
            button_start.Visible = true;
            label_state.Location = new Point(400, 50);
            label_player.Text = "";
            label_state.Text = "";
            label_you.Text = "";
            label_time.Text = "";
            label_beast.Text = "";
        }
        private void Prepare_Time_Reset()
        {
            time = 10;
            timer1.Interval = 1000;
            choose = true;
        }

        private void Fight_Time_Reset()
        {
            time = 0;
            timer2.Interval = 1000;
        }

        private void Fight_start()
        {
            label_beast.Visible = true;
            label_you.Visible = true;
            label_state.Text = "時間";
            label_state.Location = new Point(417, 50);
            for (int i = 0; i < 3; i++)
            {
                b[i].BackColor = Color.White;
                b[i].SetBounds(215 + 170 * i, 200, 120, 50);
                b[i].MouseClick -= Button_MouseClick;
            }
            b[0].Text = "普攻";
            b[1].Text = "技能";
            b[2].Text = "寶具";

            switch (player[0])
            {
                case "Berserker":
                    if (player[1] == "Saber")
                    {
                        servants[0] = new Saber();
                        servants[1] = new Beast();
                        servants[2] = new Berserker();
                        member1 = 0;
                        member2 = 2;
                        beast = 1;
                    }
                    else
                    {
                        servants[0] = new Caster();
                        servants[1] = new Beast();
                        servants[2] = new Berserker();
                        member1 = 0;
                        member2 = 2;
                        beast = 1;
                    }
                    break;

                case "Saber":
                    servants[0] = new Saber();
                    servants[1] = new Caster();
                    servants[2] = new Beast();
                    member1 = 0;
                    member2 = 1;
                    beast = 2;
                    break;
            }
            b[0].MouseClick += NormalAttack_MouseClick;
            b[1].MouseClick += SkillAttack_MouseClick;
            b[2].MouseClick += TreasureAttack_MouseClick;
            Fight_Change();
        }

        int end_time;
        private void Win_Lose()
        {
            if (servants[member1].survive == true)
            {
                if (servants[member1].hp <= 0)
                {
                    MessageBox.Show($"{servants[member1].character}倒下了!", "", MessageBoxButtons.OK);
                    servants[member1].survive = false;
                }
            }
            if (servants[member2].survive == true)
            {
                if (servants[member2].hp <= 0)
                {
                    MessageBox.Show($"{servants[member2].character}倒下了!", "", MessageBoxButtons.OK);
                    servants[member2].survive = false;
                }
            }

            if (servants[beast].hp <= 0)
            {
                servants[beast].survive = false;
                end_time = time;
                timer2.Enabled = false;
                DialogResult result;
                result = MessageBox.Show($"You Win!\n戰鬥時間:{end_time}", "", MessageBoxButtons.OK);
                if(result == DialogResult.OK)
                {
                    for(int i = 0; i <3; i++)
                    {
                        Controls.Remove(b[i]);
                        All_Reset();
                    }
                }
                game = false;
            }

            if ((!servants[member1].survive) && (!servants[member2].survive))
            {
                end_time = time;
                timer2.Enabled = false;
                DialogResult result;
                result = MessageBox.Show($"You Lose!\n戰鬥時間:{end_time}", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Controls.Remove(b[i]);
                        All_Reset();
                    }
                }
                game = false;
            }
        }


        bool beast_skill_now = false;
        private void Beast_attack()
        {
            if (servants[beast].cold == 0)
            {
                servants[beast].Skill();
                beast_skill_now=true;
                Fight_Change();
                MessageBox.Show($"Beast使用了技能\n當前ATK:{servants[beast].atk}","",MessageBoxButtons.OK);
            }
            else { }

            if (servants[beast].charge == 100)
            {
                for(int i = 0; i < 3; i++)
                {
                    if(i != beast)
                    {
                        servants[i].hp -= ((servants[beast].atk) * 2);
                    }
                }
                servants[beast].charge = 0;
                Fight_Change();
                MessageBox.Show($"Beast使用了寶具\n對全體隊友造成了{servants[beast].atk * 2}點傷害!","",MessageBoxButtons.OK);
                Win_Lose();
                if (game)
                {
                    if (beast_skill_now)
                    {
                        beast_skill_now = false;
                    }
                    else
                    {
                        servants[beast].cold--;
                    }
                    turn++;
                    if (!servants[turn % 3].survive)
                    {
                        turn++;
                        Fight_Change();
                    }
                    else
                    {
                        Fight_Change();
                    }
                }
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if(i != beast)
                    {
                        servants[i].hp -= servants[beast].atk;
                    }
                }
                servants[beast].charge += 20;
                Fight_Change();
                MessageBox.Show($"Beast對全體隊友造成{servants[beast].atk}點傷害!","",MessageBoxButtons.OK);
                Win_Lose();
                if (game)
                {
                    if (beast_skill_now)
                    {
                        beast_skill_now = false;
                    }
                    else
                    {
                        servants[beast].cold--;
                    }
                    turn++;
                    if (!servants[turn % 3].survive)
                    {
                        turn++;
                        Fight_Change();
                    }
                    else
                    {
                        Fight_Change();
                    }
                }
            }
        }

        private void Fight_Change()
        {
            if(turn%3 == beast)
            {
                if (servants[(turn-1)%3].survive == true)
                {
                    label_you.Text = $"{servants[(turn - 1) % 3].character}\nHP:{servants[(turn - 1) % 3].hp}\nCharge:{servants[(turn - 1) % 3].charge}%\nAttack:{servants[(turn - 1) % 3].atk}";
                }
                else
                {
                    if(beast == 1)
                    {
                        label_you.Text = $"{servants[(turn + 1) % 3].character}\nHP:{servants[(turn + 1) % 3].hp}\nCharge:{servants[(turn + 1) % 3].charge}%\nAttack:{servants[(turn + 1) % 3].atk}";
                    }
                    else
                    {
                        label_you.Text = $"{servants[(turn - 2) % 3].character}\nHP:{servants[(turn - 2) % 3].hp}\nCharge:{servants[(turn - 2) % 3].charge}%\nAttack:{servants[(turn - 2) % 3].atk}";
                    }
                }
                label_player.Text = "Beast turn";
                label_beast.Text = $"Beast\nHP:{servants[beast].hp}\nCharge:{servants[beast].charge}%\nAttack:{servants[beast].atk}";
            }
            else
            {
                label_player.Text = servants[(turn % 3)].character + " turn";
                label_beast.Text = $"Beast\nHP:{servants[beast].hp}\nCharge:{servants[beast].charge}%\nAttack:{servants[beast].atk}";
                label_you.Text = $"{servants[turn % 3].character}\nHP:{servants[turn % 3].hp}\nCharge:{servants[turn % 3].charge}%\nAttack:{servants[turn % 3].atk}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prepare_Time_Reset();
            timer1.Enabled = true;
            label_state.Text = "準備階段";
            button_start.Enabled = false;
            button_start.Visible = false;
            game = true;
            
            for(int i = 0; i < 3; i++)
            {
                b[i] = new Button();
                b[i].SetBounds(200 + 173 *i, 200, 150, 80);
                b[i].BackColor = Color.White;
                b[i].Font = new Font("Arial", 16, FontStyle.Regular);
                b[i].MouseClick += Button_MouseClick;
                Controls.Add(b[i]);
            }
            b[0].Text = "Berserker";
            b[1].Text = "Saber";
            b[2].Text = "Caster";
        }

       

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (choose)
            {
                if (button.BackColor == Color.LightGreen)
                {
                    button.BackColor = Color.White;
                    player_num--;
                }
                else
                {
                    if (player_num == 2)
                    {
                        MessageBox.Show("只能選兩個Servant!", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        button.BackColor = Color.LightGreen;
                        player_num++;
                    }
                }
            }
        }

        private void NormalAttack_MouseClick(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            int hit = random.Next(2);
            int chargee = random.Next(20,26);

            if (hit == 0)
            {
                servants[beast].hp -= servants[turn % 3].atk;
                servants[turn % 3].charge += chargee;
                Fight_Change();
                Win_Lose();
            }
            else
            {
                servants[beast].hp -= ((servants[turn % 3].atk) * 2);
                servants[turn % 3].charge += 30;
                Fight_Change();
                MessageBox.Show($"對Beast造成了{(servants[turn % 3].atk) * 2}點暴擊傷害", "", MessageBoxButtons.OK);
                Win_Lose();
            }

            if (game)
            {
                if (servants[turn % 3].cold != 0)
                {
                    if (!now)
                    {
                        servants[turn % 3].cold--;
                    }
                    else
                    {
                        now = false;
                    }
                }
                turn++;
                if (turn % 3 == beast)
                {
                    Fight_Change();
                    Beast_attack();
                }
                else if (servants[turn % 3].survive == false)
                {
                    turn++;
                    if(turn%3 == beast)
                    {
                        Fight_Change();
                        Beast_attack();
                    }
                }
                else
                {
                    Fight_Change();
                }
            }
           
        }

        bool now = false;
        private void SkillAttack_MouseClick(object sender, MouseEventArgs e)
        {
            if (servants[turn%3].cold != 0)
            {
                if (now)
                {
                    MessageBox.Show($"技能冷卻中(剩餘回合:3)");
                }
                else
                {
                    MessageBox.Show($"技能冷卻中(剩餘回合:{servants[turn % 3].cold})");
                }
            }
            else
            {
                servants[turn % 3].Skill();
                Fight_Change();
                MessageBox.Show($"{servants[turn % 3].character}使用了技能","",MessageBoxButtons.OK);
                now = true;
                Win_Lose();
            }
        }

        private void TreasureAttack_MouseClick(object sender, MouseEventArgs e)
        {
            if (servants[turn % 3].charge < 100)
            {
                MessageBox.Show("充能不足，無法施放寶具!", "", MessageBoxButtons.OK);
            }
            else
            {
                switch (servants[turn % 3].character)
                {
                    case "Saber":
                        servants[beast].hp -= (servants[turn % 3].atk + 25);
                        servants[turn % 3].hp += 5;
                        servants[turn % 3].charge -= 100;
                        Fight_Change();
                        MessageBox.Show($"Saber施放了寶具:\n對Beast造成了{servants[turn % 3].atk + 25}點傷害並回復5點血量", "", MessageBoxButtons.OK);
                        Win_Lose();
                        break;

                    case "Caster":
                        for (int i = 0; i < 3; i++)
                        {
                            if (i != beast)
                            {
                                servants[i].hp += 10;
                                servants[i].atk += 1;
                            }
                        }
                        servants[turn % 3].charge -= 100;
                        Fight_Change();
                        MessageBox.Show($"Caster施放了寶具:\n全體隊友增加1點攻擊、回復10點血量", "", MessageBoxButtons.OK);
                        Win_Lose();
                        break;

                    case "Berserker":
                        servants[beast].hp -= (50 + servants[turn % 3].atk);
                        servants[turn % 3].charge -= 100;
                        Fight_Change();
                        MessageBox.Show($"Berserker施放了寶具:\n對Beast造成了{50 + servants[turn % 3].atk}點傷害", "", MessageBoxButtons.OK);
                        Win_Lose();
                        break;
                }
                if (servants[turn % 3].cold != 0)
                {
                    if (!now)
                    {
                        servants[turn % 3].cold--;
                    }
                    else
                    {
                        now = false;
                    }
                }
                
                if (game)
                {
                    turn++;

                    if (turn % 3 == beast)
                    {
                        Fight_Change();
                        Beast_attack();
                    }
                    else if (servants[turn % 3].survive == false)
                    {
                        turn++;
                        if (turn % 3 == beast)
                        {
                            Fight_Change();
                            Beast_attack();
                        }
                    }
                    else
                    {
                        Fight_Change();
                    }
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_time.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                choose = false;
                int count = 0;
                if (player_num == 0)
                {
                    b[0].BackColor = Color.LightGreen;
                    b[1].BackColor = Color.LightGreen;
                }
                else if (player_num == 1)
                {
                    if (b[0].BackColor == Color.White)
                    {
                        b[0].BackColor = Color.LightGreen;
                    }
                    else if (b[1].BackColor == Color.White)
                    {
                        b[1].BackColor= Color.LightGreen;
                    }
                }
                for (int k = 0; k < 3; k++)
                {
                    if (b[k].BackColor == Color.LightGreen)
                    {
                        player[count] = b[k].Text;
                        count++;
                    }
                }
                Fight_start();
                Fight_Time_Reset();
                timer2.Enabled = true;
            }
            else
            {
                time--;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            label_time.Text = time.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_beast.Visible = false;
            label_you.Visible = false;
        }
    }
}
