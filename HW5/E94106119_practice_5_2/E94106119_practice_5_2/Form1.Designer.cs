namespace E94106119_practice_5_2
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
            this.components = new System.ComponentModel.Container();
            this.button_start = new System.Windows.Forms.Button();
            this.label_state = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label_player = new System.Windows.Forms.Label();
            this.label_you = new System.Windows.Forms.Label();
            this.label_beast = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_start.Location = new System.Drawing.Point(245, 250);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(400, 50);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "開始遊戲";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_state.Location = new System.Drawing.Point(400, 50);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(0, 27);
            this.label_state.TabIndex = 1;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_time.Location = new System.Drawing.Point(428, 85);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(0, 27);
            this.label_time.TabIndex = 2;
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label_player
            // 
            this.label_player.AutoSize = true;
            this.label_player.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_player.Location = new System.Drawing.Point(393, 396);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(0, 21);
            this.label_player.TabIndex = 3;
            this.label_player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_you
            // 
            this.label_you.AutoSize = true;
            this.label_you.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_you.Location = new System.Drawing.Point(68, 160);
            this.label_you.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_you.Name = "label_you";
            this.label_you.Size = new System.Drawing.Size(0, 24);
            this.label_you.TabIndex = 4;
            this.label_you.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_beast
            // 
            this.label_beast.AutoSize = true;
            this.label_beast.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_beast.Location = new System.Drawing.Point(705, 160);
            this.label_beast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_beast.Name = "label_beast";
            this.label_beast.Size = new System.Drawing.Size(0, 24);
            this.label_beast.TabIndex = 5;
            this.label_beast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label_beast);
            this.Controls.Add(this.label_you);
            this.Controls.Add(this.label_player);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.button_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.Label label_you;
        private System.Windows.Forms.Label label_beast;
    }
}

