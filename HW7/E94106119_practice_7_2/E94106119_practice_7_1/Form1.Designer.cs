namespace E94106119_practice_7_1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file_menustrip = new System.Windows.Forms.ToolStripMenuItem();
            this.new_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openold_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.store_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storenew_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byebye_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.work_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newword_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.search_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.單字測驗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.see_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordweight_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.只顯示標記單字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除標記ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text_main = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtb_word = new System.Windows.Forms.TextBox();
            this.txtb_chinese = new System.Windows.Forms.TextBox();
            this.label_word = new System.Windows.Forms.Label();
            this.label_chinese = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.comboBox_state = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_menustrip,
            this.work_MenuItem,
            this.see_MenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1179, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file_menustrip
            // 
            this.file_menustrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_MenuItem,
            this.openold_MenuItem,
            this.store_MenuItem,
            this.storenew_MenuItem,
            this.byebye_MenuItem});
            this.file_menustrip.Name = "file_menustrip";
            this.file_menustrip.Size = new System.Drawing.Size(53, 24);
            this.file_menustrip.Text = "檔案";
            // 
            // new_MenuItem
            // 
            this.new_MenuItem.Name = "new_MenuItem";
            this.new_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.new_MenuItem.Text = "新增";
            this.new_MenuItem.Click += new System.EventHandler(this.new_MenuItem_Click);
            // 
            // openold_MenuItem
            // 
            this.openold_MenuItem.Name = "openold_MenuItem";
            this.openold_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.openold_MenuItem.Text = "開啟舊檔";
            this.openold_MenuItem.Click += new System.EventHandler(this.openold_MenuItem_Click);
            // 
            // store_MenuItem
            // 
            this.store_MenuItem.Name = "store_MenuItem";
            this.store_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.store_MenuItem.Text = "儲存";
            this.store_MenuItem.Click += new System.EventHandler(this.store_MenuItem_Click);
            // 
            // storenew_MenuItem
            // 
            this.storenew_MenuItem.Name = "storenew_MenuItem";
            this.storenew_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.storenew_MenuItem.Text = "另存新檔";
            this.storenew_MenuItem.Click += new System.EventHandler(this.storenew_MenuItem_Click);
            // 
            // byebye_MenuItem
            // 
            this.byebye_MenuItem.Name = "byebye_MenuItem";
            this.byebye_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.byebye_MenuItem.Text = "離開";
            this.byebye_MenuItem.Click += new System.EventHandler(this.byebye_MenuItem_Click);
            // 
            // work_MenuItem
            // 
            this.work_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newword_MenuItem,
            this.search_MenuItem,
            this.單字測驗ToolStripMenuItem});
            this.work_MenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.work_MenuItem.Name = "work_MenuItem";
            this.work_MenuItem.Size = new System.Drawing.Size(53, 24);
            this.work_MenuItem.Text = "功能";
            // 
            // newword_MenuItem
            // 
            this.newword_MenuItem.Name = "newword_MenuItem";
            this.newword_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.newword_MenuItem.Text = "新增單字";
            this.newword_MenuItem.Click += new System.EventHandler(this.newword_MenuItem_Click);
            // 
            // search_MenuItem
            // 
            this.search_MenuItem.Name = "search_MenuItem";
            this.search_MenuItem.Size = new System.Drawing.Size(152, 26);
            this.search_MenuItem.Text = "搜尋單字";
            this.search_MenuItem.Click += new System.EventHandler(this.search_MenuItem_Click);
            // 
            // 單字測驗ToolStripMenuItem
            // 
            this.單字測驗ToolStripMenuItem.Name = "單字測驗ToolStripMenuItem";
            this.單字測驗ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.單字測驗ToolStripMenuItem.Text = "單字測驗";
            this.單字測驗ToolStripMenuItem.Click += new System.EventHandler(this.單字測驗ToolStripMenuItem_Click);
            // 
            // see_MenuItem
            // 
            this.see_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordweight_MenuItem,
            this.只顯示標記單字ToolStripMenuItem,
            this.清除標記ToolStripMenuItem});
            this.see_MenuItem.Name = "see_MenuItem";
            this.see_MenuItem.Size = new System.Drawing.Size(53, 24);
            this.see_MenuItem.Text = "檢視";
            // 
            // wordweight_MenuItem
            // 
            this.wordweight_MenuItem.Name = "wordweight_MenuItem";
            this.wordweight_MenuItem.Size = new System.Drawing.Size(224, 26);
            this.wordweight_MenuItem.Text = "字型大小";
            this.wordweight_MenuItem.Click += new System.EventHandler(this.wordweight_MenuItem_Click);
            // 
            // 只顯示標記單字ToolStripMenuItem
            // 
            this.只顯示標記單字ToolStripMenuItem.Name = "只顯示標記單字ToolStripMenuItem";
            this.只顯示標記單字ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.只顯示標記單字ToolStripMenuItem.Text = "只顯示標記單字";
            this.只顯示標記單字ToolStripMenuItem.Click += new System.EventHandler(this.只顯示標記單字ToolStripMenuItem_Click);
            // 
            // 清除標記ToolStripMenuItem
            // 
            this.清除標記ToolStripMenuItem.Name = "清除標記ToolStripMenuItem";
            this.清除標記ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.清除標記ToolStripMenuItem.Text = "清除標記";
            this.清除標記ToolStripMenuItem.Click += new System.EventHandler(this.清除標記ToolStripMenuItem_Click);
            // 
            // text_main
            // 
            this.text_main.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_main.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.text_main.Location = new System.Drawing.Point(16, 36);
            this.text_main.Margin = new System.Windows.Forms.Padding(4);
            this.text_main.Multiline = true;
            this.text_main.Name = "text_main";
            this.text_main.ReadOnly = true;
            this.text_main.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.text_main.Size = new System.Drawing.Size(840, 590);
            this.text_main.TabIndex = 1;
            this.text_main.WordWrap = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtb_word
            // 
            this.txtb_word.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtb_word.Location = new System.Drawing.Point(72, 206);
            this.txtb_word.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_word.Name = "txtb_word";
            this.txtb_word.Size = new System.Drawing.Size(169, 31);
            this.txtb_word.TabIndex = 2;
            // 
            // txtb_chinese
            // 
            this.txtb_chinese.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtb_chinese.Location = new System.Drawing.Point(72, 304);
            this.txtb_chinese.Margin = new System.Windows.Forms.Padding(4);
            this.txtb_chinese.Name = "txtb_chinese";
            this.txtb_chinese.Size = new System.Drawing.Size(169, 31);
            this.txtb_chinese.TabIndex = 3;
            // 
            // label_word
            // 
            this.label_word.AutoSize = true;
            this.label_word.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_word.Location = new System.Drawing.Point(68, 182);
            this.label_word.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_word.Name = "label_word";
            this.label_word.Size = new System.Drawing.Size(49, 20);
            this.label_word.TabIndex = 5;
            this.label_word.Text = "單字";
            // 
            // label_chinese
            // 
            this.label_chinese.AutoSize = true;
            this.label_chinese.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_chinese.Location = new System.Drawing.Point(68, 280);
            this.label_chinese.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_chinese.Name = "label_chinese";
            this.label_chinese.Size = new System.Drawing.Size(49, 20);
            this.label_chinese.TabIndex = 6;
            this.label_chinese.Text = "中文";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_state.Location = new System.Drawing.Point(68, 374);
            this.label_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(49, 20);
            this.label_state.TabIndex = 7;
            this.label_state.Text = "詞性";
            // 
            // comboBox_state
            // 
            this.comboBox_state.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_state.FormattingEnabled = true;
            this.comboBox_state.Items.AddRange(new object[] {
            "adv",
            "adj",
            "v",
            "n",
            "prep",
            "conj",
            "phr",
            "abbr",
            "pron",
            "other"});
            this.comboBox_state.Location = new System.Drawing.Point(72, 398);
            this.comboBox_state.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_state.Name = "comboBox_state";
            this.comboBox_state.Size = new System.Drawing.Size(169, 28);
            this.comboBox_state.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(91, 499);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox_state);
            this.panel1.Controls.Add(this.label_state);
            this.panel1.Controls.Add(this.label_chinese);
            this.panel1.Controls.Add(this.label_word);
            this.panel1.Controls.Add(this.txtb_chinese);
            this.panel1.Controls.Add(this.txtb_word);
            this.panel1.Location = new System.Drawing.Point(877, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 598);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(877, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 598);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(93, 499);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "搜尋";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(43, 405);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(43, 311);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(43, 212);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "adv",
            "adj",
            "v",
            "n",
            "prep",
            "conj",
            "phr",
            "abbr",
            "pron",
            "other"});
            this.comboBox1.Location = new System.Drawing.Point(76, 398);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 28);
            this.comboBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(72, 374);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "詞性";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(72, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "中文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(72, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "單字";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(76, 304);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 31);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(76, 208);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 31);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.text_main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file_menustrip;
        private System.Windows.Forms.ToolStripMenuItem work_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem new_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem openold_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem store_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem storenew_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem byebye_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem newword_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem search_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem see_MenuItem;
        private System.Windows.Forms.TextBox text_main;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtb_word;
        private System.Windows.Forms.TextBox txtb_chinese;
        private System.Windows.Forms.Label label_word;
        private System.Windows.Forms.Label label_chinese;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.ComboBox comboBox_state;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem wordweight_MenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 單字測驗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 只顯示標記單字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除標記ToolStripMenuItem;
    }
}

