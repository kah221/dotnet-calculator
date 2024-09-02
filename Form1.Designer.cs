namespace _240810_calc
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.action = new System.Windows.Forms.Button();
            this.label01 = new System.Windows.Forms.Label();
            this.bt_1 = new System.Windows.Forms.Button();
            this.bt_9 = new System.Windows.Forms.Button();
            this.bt_8 = new System.Windows.Forms.Button();
            this.bt_7 = new System.Windows.Forms.Button();
            this.bt_6 = new System.Windows.Forms.Button();
            this.bt_5 = new System.Windows.Forms.Button();
            this.bt_4 = new System.Windows.Forms.Button();
            this.bt_3 = new System.Windows.Forms.Button();
            this.tb_2 = new System.Windows.Forms.Button();
            this.bt_0 = new System.Windows.Forms.Button();
            this.bt_dot = new System.Windows.Forms.Button();
            this.bt_brackets_close = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_sub = new System.Windows.Forms.Button();
            this.bt_multi = new System.Windows.Forms.Button();
            this.bt_divide = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_brackets_open = new System.Windows.Forms.Button();
            this.bracket_depth_display = new System.Windows.Forms.Label();
            this.poland_display = new System.Windows.Forms.Label();
            this.answer_display = new System.Windows.Forms.Label();
            this.word_display = new System.Windows.Forms.Label();
            this.wordx_display = new System.Windows.Forms.Label();
            this.stack_torev_display = new System.Windows.Forms.Label();
            this.current_torev_display = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // action
            // 
            this.action.Font = new System.Drawing.Font("ＭＳ ゴシック", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.action.Location = new System.Drawing.Point(702, 572);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(170, 77);
            this.action.TabIndex = 0;
            this.action.Text = "計算";
            this.action.UseVisualStyleBackColor = true;
            this.action.Click += new System.EventHandler(this.action_Click);
            // 
            // label01
            // 
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label01.Location = new System.Drawing.Point(12, 9);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(0, 34);
            this.label01.TabIndex = 1;
            this.label01.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_1
            // 
            this.bt_1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_1.Location = new System.Drawing.Point(652, 349);
            this.bt_1.Name = "bt_1";
            this.bt_1.Size = new System.Drawing.Size(50, 50);
            this.bt_1.TabIndex = 2;
            this.bt_1.Text = "1";
            this.bt_1.UseVisualStyleBackColor = true;
            this.bt_1.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_9
            // 
            this.bt_9.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_9.Location = new System.Drawing.Point(764, 461);
            this.bt_9.Name = "bt_9";
            this.bt_9.Size = new System.Drawing.Size(50, 50);
            this.bt_9.TabIndex = 3;
            this.bt_9.Text = "9";
            this.bt_9.UseVisualStyleBackColor = true;
            this.bt_9.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_8
            // 
            this.bt_8.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_8.Location = new System.Drawing.Point(708, 461);
            this.bt_8.Name = "bt_8";
            this.bt_8.Size = new System.Drawing.Size(50, 50);
            this.bt_8.TabIndex = 4;
            this.bt_8.Text = "8";
            this.bt_8.UseVisualStyleBackColor = true;
            this.bt_8.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_7
            // 
            this.bt_7.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_7.Location = new System.Drawing.Point(652, 461);
            this.bt_7.Name = "bt_7";
            this.bt_7.Size = new System.Drawing.Size(50, 50);
            this.bt_7.TabIndex = 5;
            this.bt_7.Text = "7";
            this.bt_7.UseVisualStyleBackColor = true;
            this.bt_7.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_6
            // 
            this.bt_6.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_6.Location = new System.Drawing.Point(764, 405);
            this.bt_6.Name = "bt_6";
            this.bt_6.Size = new System.Drawing.Size(50, 50);
            this.bt_6.TabIndex = 6;
            this.bt_6.Text = "6";
            this.bt_6.UseVisualStyleBackColor = true;
            this.bt_6.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_5
            // 
            this.bt_5.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_5.Location = new System.Drawing.Point(708, 405);
            this.bt_5.Name = "bt_5";
            this.bt_5.Size = new System.Drawing.Size(50, 50);
            this.bt_5.TabIndex = 7;
            this.bt_5.Text = "5";
            this.bt_5.UseVisualStyleBackColor = true;
            this.bt_5.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_4
            // 
            this.bt_4.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_4.Location = new System.Drawing.Point(652, 405);
            this.bt_4.Name = "bt_4";
            this.bt_4.Size = new System.Drawing.Size(50, 50);
            this.bt_4.TabIndex = 8;
            this.bt_4.Text = "4";
            this.bt_4.UseVisualStyleBackColor = true;
            this.bt_4.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_3
            // 
            this.bt_3.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_3.Location = new System.Drawing.Point(764, 349);
            this.bt_3.Name = "bt_3";
            this.bt_3.Size = new System.Drawing.Size(50, 50);
            this.bt_3.TabIndex = 9;
            this.bt_3.Text = "3";
            this.bt_3.UseVisualStyleBackColor = true;
            this.bt_3.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // tb_2
            // 
            this.tb_2.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_2.Location = new System.Drawing.Point(708, 349);
            this.tb_2.Name = "tb_2";
            this.tb_2.Size = new System.Drawing.Size(50, 50);
            this.tb_2.TabIndex = 10;
            this.tb_2.Text = "2";
            this.tb_2.UseVisualStyleBackColor = true;
            this.tb_2.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_0
            // 
            this.bt_0.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_0.Location = new System.Drawing.Point(652, 517);
            this.bt_0.Name = "bt_0";
            this.bt_0.Size = new System.Drawing.Size(50, 50);
            this.bt_0.TabIndex = 11;
            this.bt_0.Text = "0";
            this.bt_0.UseVisualStyleBackColor = true;
            this.bt_0.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_dot
            // 
            this.bt_dot.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_dot.Location = new System.Drawing.Point(708, 517);
            this.bt_dot.Name = "bt_dot";
            this.bt_dot.Size = new System.Drawing.Size(50, 50);
            this.bt_dot.TabIndex = 12;
            this.bt_dot.Text = ".";
            this.bt_dot.UseVisualStyleBackColor = true;
            this.bt_dot.Click += new System.EventHandler(this.btSymbol_typeB_Click);
            // 
            // bt_brackets_close
            // 
            this.bt_brackets_close.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_brackets_close.Location = new System.Drawing.Point(708, 293);
            this.bt_brackets_close.Name = "bt_brackets_close";
            this.bt_brackets_close.Size = new System.Drawing.Size(50, 50);
            this.bt_brackets_close.TabIndex = 13;
            this.bt_brackets_close.Text = ")";
            this.bt_brackets_close.UseVisualStyleBackColor = true;
            this.bt_brackets_close.Click += new System.EventHandler(this.btSymbol_typeD_Click);
            // 
            // bt_add
            // 
            this.bt_add.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_add.Location = new System.Drawing.Point(820, 349);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(50, 50);
            this.bt_add.TabIndex = 14;
            this.bt_add.Text = "+";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.btSymbol_typeA_Click);
            // 
            // bt_sub
            // 
            this.bt_sub.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_sub.Location = new System.Drawing.Point(820, 405);
            this.bt_sub.Name = "bt_sub";
            this.bt_sub.Size = new System.Drawing.Size(50, 50);
            this.bt_sub.TabIndex = 15;
            this.bt_sub.Text = "-";
            this.bt_sub.UseVisualStyleBackColor = true;
            this.bt_sub.Click += new System.EventHandler(this.btSymbol_typeA_Click);
            // 
            // bt_multi
            // 
            this.bt_multi.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_multi.Location = new System.Drawing.Point(820, 461);
            this.bt_multi.Name = "bt_multi";
            this.bt_multi.Size = new System.Drawing.Size(50, 50);
            this.bt_multi.TabIndex = 16;
            this.bt_multi.Text = "*";
            this.bt_multi.UseVisualStyleBackColor = true;
            this.bt_multi.Click += new System.EventHandler(this.btSymbol_typeA_Click);
            // 
            // bt_divide
            // 
            this.bt_divide.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_divide.Location = new System.Drawing.Point(820, 517);
            this.bt_divide.Name = "bt_divide";
            this.bt_divide.Size = new System.Drawing.Size(50, 50);
            this.bt_divide.TabIndex = 17;
            this.bt_divide.Text = "/";
            this.bt_divide.UseVisualStyleBackColor = true;
            this.bt_divide.Click += new System.EventHandler(this.btSymbol_typeA_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_delete.Location = new System.Drawing.Point(822, 293);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(50, 50);
            this.bt_delete.TabIndex = 18;
            this.bt_delete.Text = "<x";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_clear.Location = new System.Drawing.Point(764, 293);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(50, 50);
            this.bt_clear.TabIndex = 19;
            this.bt_clear.Text = "C";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_brackets_open
            // 
            this.bt_brackets_open.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_brackets_open.Location = new System.Drawing.Point(652, 293);
            this.bt_brackets_open.Name = "bt_brackets_open";
            this.bt_brackets_open.Size = new System.Drawing.Size(50, 50);
            this.bt_brackets_open.TabIndex = 20;
            this.bt_brackets_open.Text = "(";
            this.bt_brackets_open.UseVisualStyleBackColor = true;
            this.bt_brackets_open.Click += new System.EventHandler(this.btSymbol_typeC_Click);
            // 
            // bracket_depth_display
            // 
            this.bracket_depth_display.AutoSize = true;
            this.bracket_depth_display.Location = new System.Drawing.Point(691, 278);
            this.bracket_depth_display.Name = "bracket_depth_display";
            this.bracket_depth_display.Size = new System.Drawing.Size(0, 12);
            this.bracket_depth_display.TabIndex = 21;
            // 
            // poland_display
            // 
            this.poland_display.AutoSize = true;
            this.poland_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.poland_display.Location = new System.Drawing.Point(12, 278);
            this.poland_display.Name = "poland_display";
            this.poland_display.Size = new System.Drawing.Size(0, 34);
            this.poland_display.TabIndex = 22;
            // 
            // answer_display
            // 
            this.answer_display.AutoSize = true;
            this.answer_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.answer_display.Location = new System.Drawing.Point(12, 362);
            this.answer_display.Name = "answer_display";
            this.answer_display.Size = new System.Drawing.Size(0, 34);
            this.answer_display.TabIndex = 23;
            // 
            // word_display
            // 
            this.word_display.AutoSize = true;
            this.word_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.word_display.Location = new System.Drawing.Point(22, 63);
            this.word_display.Name = "word_display";
            this.word_display.Size = new System.Drawing.Size(0, 34);
            this.word_display.TabIndex = 24;
            // 
            // wordx_display
            // 
            this.wordx_display.AutoSize = true;
            this.wordx_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wordx_display.Location = new System.Drawing.Point(22, 123);
            this.wordx_display.Name = "wordx_display";
            this.wordx_display.Size = new System.Drawing.Size(0, 34);
            this.wordx_display.TabIndex = 25;
            // 
            // stack_torev_display
            // 
            this.stack_torev_display.AutoSize = true;
            this.stack_torev_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stack_torev_display.Location = new System.Drawing.Point(12, 235);
            this.stack_torev_display.Name = "stack_torev_display";
            this.stack_torev_display.Size = new System.Drawing.Size(0, 34);
            this.stack_torev_display.TabIndex = 26;
            // 
            // current_torev_display
            // 
            this.current_torev_display.AutoSize = true;
            this.current_torev_display.Font = new System.Drawing.Font("07やさしさゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.current_torev_display.Location = new System.Drawing.Point(12, 192);
            this.current_torev_display.Name = "current_torev_display";
            this.current_torev_display.Size = new System.Drawing.Size(0, 34);
            this.current_torev_display.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.current_torev_display);
            this.Controls.Add(this.stack_torev_display);
            this.Controls.Add(this.wordx_display);
            this.Controls.Add(this.word_display);
            this.Controls.Add(this.answer_display);
            this.Controls.Add(this.poland_display);
            this.Controls.Add(this.bracket_depth_display);
            this.Controls.Add(this.bt_brackets_open);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_divide);
            this.Controls.Add(this.bt_multi);
            this.Controls.Add(this.bt_sub);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.bt_brackets_close);
            this.Controls.Add(this.bt_dot);
            this.Controls.Add(this.bt_0);
            this.Controls.Add(this.tb_2);
            this.Controls.Add(this.bt_3);
            this.Controls.Add(this.bt_4);
            this.Controls.Add(this.bt_5);
            this.Controls.Add(this.bt_6);
            this.Controls.Add(this.bt_7);
            this.Controls.Add(this.bt_8);
            this.Controls.Add(this.bt_9);
            this.Controls.Add(this.bt_1);
            this.Controls.Add(this.label01);
            this.Controls.Add(this.action);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button action;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Button bt_1;
        private System.Windows.Forms.Button bt_9;
        private System.Windows.Forms.Button bt_8;
        private System.Windows.Forms.Button bt_7;
        private System.Windows.Forms.Button bt_6;
        private System.Windows.Forms.Button bt_5;
        private System.Windows.Forms.Button bt_4;
        private System.Windows.Forms.Button bt_3;
        private System.Windows.Forms.Button tb_2;
        private System.Windows.Forms.Button bt_0;
        private System.Windows.Forms.Button bt_dot;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_sub;
        private System.Windows.Forms.Button bt_multi;
        private System.Windows.Forms.Button bt_divide;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_brackets_open;
        private System.Windows.Forms.Button bt_brackets_close;
        private System.Windows.Forms.Label bracket_depth_display;
        private System.Windows.Forms.Label poland_display;
        private System.Windows.Forms.Label answer_display;
        private System.Windows.Forms.Label word_display;
        private System.Windows.Forms.Label wordx_display;
        private System.Windows.Forms.Label stack_torev_display;
        private System.Windows.Forms.Label current_torev_display;
    }
}

