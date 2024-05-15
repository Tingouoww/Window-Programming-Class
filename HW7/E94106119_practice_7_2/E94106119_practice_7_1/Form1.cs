using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace E94106119_practice_7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void byebye_MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public List<bool> icon = new List<bool>();
        public List<string> word = new List<string>();
        public List<string> Chinese = new List<string>();
        public List<string> speech = new List<string>();
        string filename;

        private void close_search()
        {
            search_MenuItem.Text = "搜尋單字";
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            panel2.Visible = false;
            panel2.Enabled = false;
            text_main.Text = null;
            for (int k = 0; k < word.Count; k++)
            {
                if (text_main.Text == "")
                {
                    text_main.Text = $"{word[k]} {Chinese[k]} {speech[k]}";
                }
                else
                {
                    text_main.Text += $"\r\n{word[k]} {Chinese[k]} {speech[k]}";
                }
            }
        }

        private void openold_MenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*|Word Files(*.docx*)|*.docx*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                word.Clear();
                Chinese.Clear();
                speech.Clear();
                text_main.Text = null;
                filename = openFileDialog1.FileName;
                FileStream fsIn = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(fsIn, Encoding.UTF8);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(' ');
                    word.Add(split[0]);
                    Chinese.Add(split[1]);
                    speech.Add(split[2]);
                    icon.Add(false);
                    if(text_main.Text == "")
                    {
                        text_main.Text = line;
                    }
                    else
                    {
                        text_main.Text += $"\r\n{line}";
                    }
                }
                sr.Close();
                fsIn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            state_origin();
            text_main.Text = null;
        }

        private void state_origin()
        {
            text_main.Size = new Size(850, 470);
            panel1.Visible = false;
            panel1.Enabled=false;
            panel2.Visible=false;
            panel2.Enabled=false;
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            txtb_chinese.Text = null;
            txtb_word.Text = null;
            comboBox_state.Text = null; 
        }

        bool newword_state = false;
        private void newword_MenuItem_Click(object sender, EventArgs e)
        {
            if (newword_state)
            {
                newword_state = false;
                panel1.Visible = false;
                panel1.Enabled=false;
                newword_MenuItem.Text = "新增單字";
                text_main.Size = new Size(850, 470);

            }
            else
            {
                newword_state = true;
                panel1.Visible = true;
                panel1.Enabled= true;
                search_state = false;
                search_MenuItem.Text = "搜尋單字";
                newword_MenuItem.Text = "新增單字(v)";
                text_main.Size = new Size(640, 470);
                close_search();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int state = 0;
            if(txtb_word.Text == "")
            {
                state = 1;
                MessageBox.Show("單字欄不可為空","給我注意喔",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(txtb_chinese.Text == "")
            {
                state = 1;
                MessageBox.Show("中文欄不可為空", "給我注意喔", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(comboBox_state.Text == "")
            {
                state = 1;
                MessageBox.Show("請選擇詞性", "給我注意喔", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(state == 0)
            {
                word.Add(txtb_word.Text);
                Chinese.Add(txtb_chinese.Text);
                speech.Add(comboBox_state.Text);
                icon.Add(false);
                if(text_main.Text == "")
                {
                    text_main.Text = $"{txtb_word.Text} {txtb_chinese.Text} {comboBox_state.Text}";
                }
                else
                {
                    text_main.Text += $"\r\n{txtb_word.Text} {txtb_chinese.Text} {comboBox_state.Text}";
                }
                txtb_word.Text = null;
                txtb_chinese.Text = null;
                comboBox_state.Text = null;
            }
        }

        private void wordweight_MenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = text_main.Font;
            
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {   
               text_main.Font = fontDialog1.Font;
               text_main.ForeColor = fontDialog1.Color;
            }
        }

        private void new_MenuItem_Click(object sender, EventArgs e)
        {
            state_origin();
            FontFamily fontFamily = new FontFamily("新細明體");
            text_main.Font= new Font(fontFamily,12,FontStyle.Regular);
            text_main.Text = null;
            filename = null;
            newword_MenuItem.Text = "新增單字";
            search_MenuItem.Text = "搜尋單字";
            word.Clear();
            Chinese.Clear();
            speech.Clear();
            icon.Clear();
        }
        
        private void store_MenuItem_Click(object sender, EventArgs e)
        {
            if(icon_state == true)
            {
                MessageBox.Show("目前僅會存取被標記的單字喔", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (filename != null)
            {
                FileStream fsOut = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fsOut);
                if (icon_state == true)
                {
                    string txt = text_main.Text;
                    sw.Write(txt);
                }
                else
                {
                    for (int i = 0; i < word.Count; i++)
                    {
                        string write = $"{word[i]} {Chinese[i]} {speech[i]}";
                        sw.WriteLine(write);
                    }
                }
                sw.Flush();
                sw.Close();
                fsOut.Close();
                state_origin();
                newword_MenuItem.Text = "新增單字";
                newword_state = false;
                search_MenuItem.Text = "搜尋單字";
                search_state = false;
            }
            else
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*|Word Files(*.docx*)|*.docx*";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    FileStream fsOut = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fsOut);
                    if (icon_state == true)
                    {
                        string txt = text_main.Text;
                        sw.Write(txt);
                    }
                    else
                    {
                        for (int i = 0; i < word.Count; i++)
                        {
                            string write = $"{word[i]} {Chinese[i]} {speech[i]}";
                            sw.WriteLine(write);
                        }
                    }
                    sw.Flush();
                    sw.Close();
                    fsOut.Close();
                    state_origin();
                    newword_MenuItem.Text = "新增單字";
                    newword_state = false;
                    search_MenuItem.Text = "搜尋單字";
                    search_state = false;
                }
            }
            text_main.Text = null;
            只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
            icon_state = false;
            for (int k = 0; k < word.Count; k++)
            {
               if(text_main.Text == "")
                {
                    text_main.Text = $"{word[k]} {Chinese[k]} {speech[k]}";
                }
                else
                {
                    text_main.Text += $"\r\n{word[k]} {Chinese[k]} {speech[k]}";
                }
            }
        }

        private void storenew_MenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*|Word Files(*.docx*)|*.docx*";
            if(icon_state == true)
            {
                MessageBox.Show("目前僅會存取被標記的單字喔", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string txt = text_main.Text;
                    filename = saveFileDialog1.FileName;
                    FileStream fsOut = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fsOut);
                    sw.Write(txt);
                    sw.Flush();
                    sw.Close();
                }
                text_main.Text = null;
                只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
                icon_state = false;
                for (int k = 0; k < word.Count; k++)
                {
                    if (text_main.Text == "")
                    {
                        text_main.Text = $"{word[k]} {Chinese[k]} {speech[k]}";
                    }
                    else
                    {
                        text_main.Text += $"\r\n{word[k]} {Chinese[k]} {speech[k]}";
                    }
                }
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    FileStream fsOut = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fsOut);
                    for (int i = 0; i < word.Count; i++)
                    {
                        string write = $"{word[i]} {Chinese[i]} {speech[i]}";
                        sw.WriteLine(write);
                    }
                    sw.Flush();
                    sw.Close();
                    fsOut.Close();
                    state_origin();
                    newword_MenuItem.Text = "新增單字";
                    newword_state = false;
                    search_MenuItem.Text = "搜尋單字";
                    search_state = false;

                    text_main.Text = null;
                    只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
                    icon_state = false;
                    for (int k = 0; k < word.Count; k++)
                    {
                        if (text_main.Text == "")
                        {
                            text_main.Text = $"{word[k]} {Chinese[k]} {speech[k]}";
                        }
                        else
                        {
                            text_main.Text += $"\r\n{word[k]} {Chinese[k]} {speech[k]}";
                        }
                    }
                }
            }
            
        }

        bool search_state = false;
        private void search_MenuItem_Click(object sender, EventArgs e)
        {
            if (search_state)
            {
                close_search();
                search_state = false;
                text_main.Size = new Size(850, 470);
                
                textBox1.Text = null;
                textBox2.Text = null;
                comboBox1.Text = null;
            }
            else
            {
                search_state = true;
                search_MenuItem.Text = "搜尋單字(v)";
                newword_MenuItem.Text = "新增單字";
                newword_state = false;
                panel2.Enabled = true;
                panel2.Visible = true;
                panel1.Visible = false;
                panel1.Enabled = false;
                text_main.Size = new Size(640, 470);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text_main.Text = null;
            bool is_check = false;
            List<int> list = new List<int>(); 
            if(icon_state == true)
            {
                if (checkBox1.Checked)
                {
                    is_check = true;
                    for (int i = 0; i < word.Count; i++)
                    {
                        if ((speech[i] == comboBox1.Text) && (icon[i] == true))
                        {
                            list.Add(i);
                        }
                    }
                }
                if (checkBox2.Checked)
                {
                    if (is_check)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (Chinese[list[k]] != textBox2.Text)
                            {
                                list.RemoveAt(k);
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < word.Count; k++)
                        {
                            if ((Chinese[k] == textBox2.Text) && (icon[k] == true))
                            {
                                list.Add(k);
                            }
                        }
                    }
                    is_check = true;
                }
                if (checkBox3.Checked)
                {
                    if (is_check)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (word[list[k]] != textBox1.Text)
                            {
                                list.RemoveAt(k);
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < word.Count; k++)
                        {
                            if ((word[k] == textBox1.Text) && (icon[k] == true))
                            {
                                list.Add(k);
                            }
                        }
                    }
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    is_check = true;
                    for (int i = 0; i < word.Count; i++)
                    {
                        if (speech[i] == comboBox1.Text)
                        {
                            list.Add(i);
                        }
                    }
                }
                if (checkBox2.Checked)
                {
                    if (is_check)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (Chinese[list[k]] != textBox2.Text)
                            {
                                list.RemoveAt(k);
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < word.Count; k++)
                        {
                            if (Chinese[k] == textBox2.Text)
                            {
                                list.Add(k);
                            }
                        }
                    }
                    is_check = true;
                }
                if (checkBox3.Checked)
                {
                    if (is_check)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (word[list[k]] != textBox1.Text)
                            {
                                list.RemoveAt(k);
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < word.Count; k++)
                        {
                            if (word[k] == textBox1.Text)
                            {
                                list.Add(k);
                            }
                        }
                    }
                }
            }
            

            for(int x = 0; x < list.Count; x++)
            {
                if(text_main.Text == "")
                {
                    text_main.Text = $"{word[list[x]]} {Chinese[list[x]]} {speech[list[x]]}";
                }
                else
                {
                    text_main.Text += $"\r\n{word[list[x]]} {Chinese[list[x]]} {speech[list[x]]}";
                }
            }
        }

        private void 單字測驗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font font = text_main.Font; 
            Form2 f2 = new Form2(word, Chinese, speech, icon, font, this);
            f2.Show();
            this.Hide();
        }


        bool icon_state = false;
        private void 只顯示標記單字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (icon_state)
            {
                icon_state = false;
                只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
                text_main.Text = "";
                for(int x = 0; x < word.Count; x++)
                {
                    if(text_main.Text == "")
                    {
                        text_main.Text = $"{word[x]} {Chinese[x]} {speech[x]}";
                    }
                    else
                    {
                        text_main.Text +=  $"\r\n{word[x]} {Chinese[x]} {speech[x]}";
                    }
                }
            }
            else
            {
                icon_state = true;
                只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字(v)";
                text_main.Text = "";
                for(int i = 0; i < icon.Count; i++)
                {
                    if(text_main.Text == "")
                    {
                        if (icon[i] == true)
                        {
                            text_main.Text = $"{word[i]} {Chinese[i]} {speech[i]}";
                        }    
                    }
                    else
                    {
                        if (icon[i] == true)
                        {
                            text_main.Text += $"\r\n{word[i]} {Chinese[i]} {speech[i]}";
                        }
                    }
                }
            }
        }

        private void 清除標記ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int x = 0;x < word.Count;x++)
            {
                icon[x] = false;
            }
            if (icon_state)
            {
                text_main.Text = "";
                icon_state = false;
                只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
                for (int x = 0; x < word.Count; x++)
                {
                    if (text_main.Text == "")
                    {
                        text_main.Text = $"{word[x]} {Chinese[x]} {speech[x]}";
                    }
                    else
                    {
                        text_main.Text += $"\r\n{word[x]} {Chinese[x]} {speech[x]}";
                    }
                }
            }
        }
    }
}
