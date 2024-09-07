using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            this.input_display = new System.Windows.Forms.Label();
            this.panel_input = new System.Windows.Forms.Panel();
            this.wordx_display = new System.Windows.Forms.Label();
            this.bt_1 = new System.Windows.Forms.Button();
            this.bt_2 = new System.Windows.Forms.Button();
            this.bt_3 = new System.Windows.Forms.Button();
            this.bt_4 = new System.Windows.Forms.Button();
            this.bt_5 = new System.Windows.Forms.Button();
            this.bt_6 = new System.Windows.Forms.Button();
            this.bt_7 = new System.Windows.Forms.Button();
            this.bt_8 = new System.Windows.Forms.Button();
            this.bt_9 = new System.Windows.Forms.Button();
            this.bt_0 = new System.Windows.Forms.Button();
            this.bt_dot = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_sub = new System.Windows.Forms.Button();
            this.bt_multi = new System.Windows.Forms.Button();
            this.bt_divide = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_brackets_open = new System.Windows.Forms.Button();
            this.bt_brackets_close = new System.Windows.Forms.Button();
            this.bracket_depth_display = new System.Windows.Forms.Label();
            this.word_display = new System.Windows.Forms.Label();
            this.label_row3_stack = new System.Windows.Forms.Label();
            this.label_row2_token = new System.Windows.Forms.Label();
            this.label_row1_input = new System.Windows.Forms.Label();
            this.label_row4_RPN = new System.Windows.Forms.Label();
            this.panel_numpad = new System.Windows.Forms.Panel();
            this.bt_kilo = new System.Windows.Forms.Button();
            this.panel_row9_value = new System.Windows.Forms.Panel();
            this.label_row9_log = new System.Windows.Forms.Label();
            this.label_row5_RPN = new System.Windows.Forms.Label();
            this.label_row8_stack = new System.Windows.Forms.Label();
            this.panel_row1 = new System.Windows.Forms.Panel();
            this.label_row1 = new System.Windows.Forms.Label();
            this.panel_row2 = new System.Windows.Forms.Panel();
            this.label_row2 = new System.Windows.Forms.Label();
            this.panel_row3 = new System.Windows.Forms.Panel();
            this.label_row3 = new System.Windows.Forms.Label();
            this.panel_row4 = new System.Windows.Forms.Panel();
            this.label_row4 = new System.Windows.Forms.Label();
            this.panel_row5 = new System.Windows.Forms.Panel();
            this.label_row5 = new System.Windows.Forms.Label();
            this.panel_row6 = new System.Windows.Forms.Panel();
            this.label_row6 = new System.Windows.Forms.Label();
            this.panel_row7 = new System.Windows.Forms.Panel();
            this.label_row7 = new System.Windows.Forms.Label();
            this.panel_row8 = new System.Windows.Forms.Panel();
            this.label_row8 = new System.Windows.Forms.Label();
            this.panel_row1_value = new System.Windows.Forms.Panel();
            this.panel_row2_value = new System.Windows.Forms.Panel();
            this.panel_row3_value = new System.Windows.Forms.Panel();
            this.panel_row4_value = new System.Windows.Forms.Panel();
            this.panel_row5_value = new System.Windows.Forms.Panel();
            this.panel_row6_value = new System.Windows.Forms.Panel();
            this.label_row6_token = new System.Windows.Forms.Label();
            this.panel_row7_value = new System.Windows.Forms.Panel();
            this.label_row7_LR = new System.Windows.Forms.Label();
            this.panel_row8_value = new System.Windows.Forms.Panel();
            this.bt_action = new System.Windows.Forms.Button();
            this.bt_change = new System.Windows.Forms.Button();
            this.label_mode = new System.Windows.Forms.Label();
            this.trackBar_freq = new System.Windows.Forms.TrackBar();
            this.label_freq = new System.Windows.Forms.Label();
            this.panel_modecolor = new System.Windows.Forms.Panel();
            this.panel_row9 = new System.Windows.Forms.Panel();
            this.label_row9 = new System.Windows.Forms.Label();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.panel_input.SuspendLayout();
            this.panel_row9_value.SuspendLayout();
            this.panel_row1.SuspendLayout();
            this.panel_row2.SuspendLayout();
            this.panel_row3.SuspendLayout();
            this.panel_row4.SuspendLayout();
            this.panel_row5.SuspendLayout();
            this.panel_row6.SuspendLayout();
            this.panel_row7.SuspendLayout();
            this.panel_row8.SuspendLayout();
            this.panel_row1_value.SuspendLayout();
            this.panel_row2_value.SuspendLayout();
            this.panel_row3_value.SuspendLayout();
            this.panel_row4_value.SuspendLayout();
            this.panel_row5_value.SuspendLayout();
            this.panel_row6_value.SuspendLayout();
            this.panel_row7_value.SuspendLayout();
            this.panel_row8_value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_freq)).BeginInit();
            this.panel_row9.SuspendLayout();
            this.SuspendLayout();
            // 
            // input_display
            // 
            this.input_display.Font = new System.Drawing.Font("ＭＳ ゴシック", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.input_display.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.input_display.Location = new System.Drawing.Point(226, 29);
            this.input_display.Name = "input_display";
            this.input_display.Size = new System.Drawing.Size(208, 37);
            this.input_display.TabIndex = 1;
            this.input_display.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_input
            // 
            this.panel_input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_input.Controls.Add(this.wordx_display);
            this.panel_input.Controls.Add(this.input_display);
            this.panel_input.Location = new System.Drawing.Point(0, 0);
            this.panel_input.Margin = new System.Windows.Forms.Padding(0);
            this.panel_input.Name = "panel_input";
            this.panel_input.Size = new System.Drawing.Size(618, 99);
            this.panel_input.TabIndex = 31;
            // 
            // wordx_display
            // 
            this.wordx_display.AutoSize = true;
            this.wordx_display.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wordx_display.Location = new System.Drawing.Point(12, 9);
            this.wordx_display.Name = "wordx_display";
            this.wordx_display.Size = new System.Drawing.Size(0, 27);
            this.wordx_display.TabIndex = 25;
            // 
            // bt_1
            // 
            this.bt_1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_1.Location = new System.Drawing.Point(653, 236);
            this.bt_1.Name = "bt_1";
            this.bt_1.Size = new System.Drawing.Size(50, 50);
            this.bt_1.TabIndex = 2;
            this.bt_1.Text = "1";
            this.bt_1.UseVisualStyleBackColor = true;
            this.bt_1.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_2
            // 
            this.bt_2.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_2.Location = new System.Drawing.Point(709, 236);
            this.bt_2.Name = "bt_2";
            this.bt_2.Size = new System.Drawing.Size(50, 50);
            this.bt_2.TabIndex = 10;
            this.bt_2.Text = "2";
            this.bt_2.UseVisualStyleBackColor = true;
            this.bt_2.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_3
            // 
            this.bt_3.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_3.Location = new System.Drawing.Point(765, 236);
            this.bt_3.Name = "bt_3";
            this.bt_3.Size = new System.Drawing.Size(50, 50);
            this.bt_3.TabIndex = 9;
            this.bt_3.Text = "3";
            this.bt_3.UseVisualStyleBackColor = true;
            this.bt_3.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_4
            // 
            this.bt_4.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_4.Location = new System.Drawing.Point(653, 292);
            this.bt_4.Name = "bt_4";
            this.bt_4.Size = new System.Drawing.Size(50, 50);
            this.bt_4.TabIndex = 8;
            this.bt_4.Text = "4";
            this.bt_4.UseVisualStyleBackColor = true;
            this.bt_4.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_5
            // 
            this.bt_5.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_5.Location = new System.Drawing.Point(709, 292);
            this.bt_5.Name = "bt_5";
            this.bt_5.Size = new System.Drawing.Size(50, 50);
            this.bt_5.TabIndex = 7;
            this.bt_5.Text = "5";
            this.bt_5.UseVisualStyleBackColor = true;
            this.bt_5.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_6
            // 
            this.bt_6.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_6.Location = new System.Drawing.Point(765, 292);
            this.bt_6.Name = "bt_6";
            this.bt_6.Size = new System.Drawing.Size(50, 50);
            this.bt_6.TabIndex = 6;
            this.bt_6.Text = "6";
            this.bt_6.UseVisualStyleBackColor = true;
            this.bt_6.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_7
            // 
            this.bt_7.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_7.Location = new System.Drawing.Point(653, 348);
            this.bt_7.Name = "bt_7";
            this.bt_7.Size = new System.Drawing.Size(50, 50);
            this.bt_7.TabIndex = 5;
            this.bt_7.Text = "7";
            this.bt_7.UseVisualStyleBackColor = true;
            this.bt_7.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_8
            // 
            this.bt_8.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_8.Location = new System.Drawing.Point(709, 348);
            this.bt_8.Name = "bt_8";
            this.bt_8.Size = new System.Drawing.Size(50, 50);
            this.bt_8.TabIndex = 4;
            this.bt_8.Text = "8";
            this.bt_8.UseVisualStyleBackColor = true;
            this.bt_8.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_9
            // 
            this.bt_9.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_9.Location = new System.Drawing.Point(765, 348);
            this.bt_9.Name = "bt_9";
            this.bt_9.Size = new System.Drawing.Size(50, 50);
            this.bt_9.TabIndex = 3;
            this.bt_9.Text = "9";
            this.bt_9.UseVisualStyleBackColor = true;
            this.bt_9.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // bt_0
            // 
            this.bt_0.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_0.Location = new System.Drawing.Point(653, 404);
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
            this.bt_dot.Location = new System.Drawing.Point(765, 404);
            this.bt_dot.Name = "bt_dot";
            this.bt_dot.Size = new System.Drawing.Size(50, 50);
            this.bt_dot.TabIndex = 12;
            this.bt_dot.Text = ".";
            this.bt_dot.UseVisualStyleBackColor = true;
            this.bt_dot.Click += new System.EventHandler(this.btSymbol_typeB_Click);
            // 
            // bt_add
            // 
            this.bt_add.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_add.Location = new System.Drawing.Point(821, 236);
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
            this.bt_sub.Location = new System.Drawing.Point(821, 292);
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
            this.bt_multi.Location = new System.Drawing.Point(821, 348);
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
            this.bt_divide.Location = new System.Drawing.Point(821, 404);
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
            this.bt_delete.Location = new System.Drawing.Point(821, 180);
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
            this.bt_clear.Location = new System.Drawing.Point(765, 180);
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
            this.bt_brackets_open.Location = new System.Drawing.Point(653, 180);
            this.bt_brackets_open.Name = "bt_brackets_open";
            this.bt_brackets_open.Size = new System.Drawing.Size(50, 50);
            this.bt_brackets_open.TabIndex = 20;
            this.bt_brackets_open.Text = "(";
            this.bt_brackets_open.UseVisualStyleBackColor = true;
            this.bt_brackets_open.Click += new System.EventHandler(this.btSymbol_typeC_Click);
            // 
            // bt_brackets_close
            // 
            this.bt_brackets_close.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_brackets_close.Location = new System.Drawing.Point(709, 180);
            this.bt_brackets_close.Name = "bt_brackets_close";
            this.bt_brackets_close.Size = new System.Drawing.Size(50, 50);
            this.bt_brackets_close.TabIndex = 13;
            this.bt_brackets_close.Text = ")";
            this.bt_brackets_close.UseVisualStyleBackColor = true;
            this.bt_brackets_close.Click += new System.EventHandler(this.btSymbol_typeD_Click);
            // 
            // bracket_depth_display
            // 
            this.bracket_depth_display.AutoSize = true;
            this.bracket_depth_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bracket_depth_display.Location = new System.Drawing.Point(703, 140);
            this.bracket_depth_display.Name = "bracket_depth_display";
            this.bracket_depth_display.Size = new System.Drawing.Size(0, 12);
            this.bracket_depth_display.TabIndex = 21;
            // 
            // word_display
            // 
            this.word_display.AutoSize = true;
            this.word_display.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.word_display.Location = new System.Drawing.Point(22, 63);
            this.word_display.Name = "word_display";
            this.word_display.Size = new System.Drawing.Size(0, 27);
            this.word_display.TabIndex = 24;
            // 
            // label_row3_stack
            // 
            this.label_row3_stack.AutoSize = true;
            this.label_row3_stack.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row3_stack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row3_stack.Location = new System.Drawing.Point(2, 6);
            this.label_row3_stack.Name = "label_row3_stack";
            this.label_row3_stack.Size = new System.Drawing.Size(0, 27);
            this.label_row3_stack.TabIndex = 26;
            // 
            // label_row2_token
            // 
            this.label_row2_token.AutoSize = true;
            this.label_row2_token.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row2_token.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row2_token.Location = new System.Drawing.Point(2, 7);
            this.label_row2_token.Name = "label_row2_token";
            this.label_row2_token.Size = new System.Drawing.Size(0, 27);
            this.label_row2_token.TabIndex = 27;
            // 
            // label_row1_input
            // 
            this.label_row1_input.AutoSize = true;
            this.label_row1_input.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row1_input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row1_input.Location = new System.Drawing.Point(2, 7);
            this.label_row1_input.Name = "label_row1_input";
            this.label_row1_input.Size = new System.Drawing.Size(0, 27);
            this.label_row1_input.TabIndex = 28;
            // 
            // label_row4_RPN
            // 
            this.label_row4_RPN.AutoSize = true;
            this.label_row4_RPN.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row4_RPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row4_RPN.Location = new System.Drawing.Point(2, 6);
            this.label_row4_RPN.Name = "label_row4_RPN";
            this.label_row4_RPN.Size = new System.Drawing.Size(0, 27);
            this.label_row4_RPN.TabIndex = 36;
            // 
            // panel_numpad
            // 
            this.panel_numpad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_numpad.Location = new System.Drawing.Point(883, 106);
            this.panel_numpad.Margin = new System.Windows.Forms.Padding(0);
            this.panel_numpad.Name = "panel_numpad";
            this.panel_numpad.Size = new System.Drawing.Size(232, 389);
            this.panel_numpad.TabIndex = 32;
            // 
            // bt_kilo
            // 
            this.bt_kilo.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.bt_kilo.Location = new System.Drawing.Point(709, 404);
            this.bt_kilo.Name = "bt_kilo";
            this.bt_kilo.Size = new System.Drawing.Size(50, 50);
            this.bt_kilo.TabIndex = 33;
            this.bt_kilo.Text = "000";
            this.bt_kilo.UseVisualStyleBackColor = true;
            this.bt_kilo.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // panel_row9_value
            // 
            this.panel_row9_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row9_value.Controls.Add(this.label_row9_log);
            this.panel_row9_value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel_row9_value.Location = new System.Drawing.Point(56, 422);
            this.panel_row9_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row9_value.Name = "panel_row9_value";
            this.panel_row9_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row9_value.TabIndex = 34;
            this.panel_row9_value.Click += new System.EventHandler(this.textBox_log_Toggle);
            // 
            // label_row9_log
            // 
            this.label_row9_log.AutoSize = true;
            this.label_row9_log.Font = new System.Drawing.Font("ＭＳ ゴシック", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row9_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label_row9_log.Location = new System.Drawing.Point(5, 12);
            this.label_row9_log.Name = "label_row9_log";
            this.label_row9_log.Size = new System.Drawing.Size(0, 19);
            this.label_row9_log.TabIndex = 39;
            // 
            // label_row5_RPN
            // 
            this.label_row5_RPN.AutoSize = true;
            this.label_row5_RPN.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row5_RPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row5_RPN.Location = new System.Drawing.Point(2, 12);
            this.label_row5_RPN.Name = "label_row5_RPN";
            this.label_row5_RPN.Size = new System.Drawing.Size(0, 27);
            this.label_row5_RPN.TabIndex = 39;
            // 
            // label_row8_stack
            // 
            this.label_row8_stack.AutoSize = true;
            this.label_row8_stack.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row8_stack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row8_stack.Location = new System.Drawing.Point(2, 6);
            this.label_row8_stack.Name = "label_row8_stack";
            this.label_row8_stack.Size = new System.Drawing.Size(0, 27);
            this.label_row8_stack.TabIndex = 38;
            // 
            // panel_row1
            // 
            this.panel_row1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row1.Controls.Add(this.label_row1);
            this.panel_row1.Location = new System.Drawing.Point(0, 100);
            this.panel_row1.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row1.Name = "panel_row1";
            this.panel_row1.Size = new System.Drawing.Size(55, 40);
            this.panel_row1.TabIndex = 38;
            // 
            // label_row1
            // 
            this.label_row1.AutoSize = true;
            this.label_row1.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row1.Location = new System.Drawing.Point(7, 13);
            this.label_row1.Name = "label_row1";
            this.label_row1.Size = new System.Drawing.Size(45, 18);
            this.label_row1.TabIndex = 0;
            this.label_row1.Text = "input";
            // 
            // panel_row2
            // 
            this.panel_row2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_row2.Controls.Add(this.label_row2);
            this.panel_row2.Location = new System.Drawing.Point(0, 140);
            this.panel_row2.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row2.Name = "panel_row2";
            this.panel_row2.Size = new System.Drawing.Size(55, 40);
            this.panel_row2.TabIndex = 39;
            // 
            // label_row2
            // 
            this.label_row2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_row2.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row2.Location = new System.Drawing.Point(0, 0);
            this.label_row2.Name = "label_row2";
            this.label_row2.Size = new System.Drawing.Size(55, 40);
            this.label_row2.TabIndex = 1;
            this.label_row2.Text = "token";
            this.label_row2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row3
            // 
            this.panel_row3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_row3.Controls.Add(this.label_row3);
            this.panel_row3.Location = new System.Drawing.Point(0, 180);
            this.panel_row3.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row3.Name = "panel_row3";
            this.panel_row3.Size = new System.Drawing.Size(55, 40);
            this.panel_row3.TabIndex = 40;
            // 
            // label_row3
            // 
            this.label_row3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_row3.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row3.Location = new System.Drawing.Point(0, 0);
            this.label_row3.Name = "label_row3";
            this.label_row3.Size = new System.Drawing.Size(55, 40);
            this.label_row3.TabIndex = 2;
            this.label_row3.Text = "stack";
            this.label_row3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row4
            // 
            this.panel_row4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_row4.Controls.Add(this.label_row4);
            this.panel_row4.Location = new System.Drawing.Point(0, 220);
            this.panel_row4.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row4.Name = "panel_row4";
            this.panel_row4.Size = new System.Drawing.Size(55, 40);
            this.panel_row4.TabIndex = 41;
            // 
            // label_row4
            // 
            this.label_row4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(201)))), ((int)(((byte)(214)))));
            this.label_row4.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(215)))));
            this.label_row4.Location = new System.Drawing.Point(0, 0);
            this.label_row4.Name = "label_row4";
            this.label_row4.Size = new System.Drawing.Size(55, 40);
            this.label_row4.TabIndex = 3;
            this.label_row4.Text = "RPN";
            this.label_row4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row5
            // 
            this.panel_row5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_row5.Controls.Add(this.label_row5);
            this.panel_row5.Location = new System.Drawing.Point(0, 261);
            this.panel_row5.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row5.Name = "panel_row5";
            this.panel_row5.Size = new System.Drawing.Size(55, 40);
            this.panel_row5.TabIndex = 42;
            // 
            // label_row5
            // 
            this.label_row5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_row5.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row5.Location = new System.Drawing.Point(0, 0);
            this.label_row5.Name = "label_row5";
            this.label_row5.Size = new System.Drawing.Size(55, 40);
            this.label_row5.TabIndex = 4;
            this.label_row5.Text = "RPN";
            this.label_row5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row6
            // 
            this.panel_row6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_row6.Controls.Add(this.label_row6);
            this.panel_row6.Location = new System.Drawing.Point(0, 301);
            this.panel_row6.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row6.Name = "panel_row6";
            this.panel_row6.Size = new System.Drawing.Size(55, 40);
            this.panel_row6.TabIndex = 43;
            // 
            // label_row6
            // 
            this.label_row6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_row6.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row6.Location = new System.Drawing.Point(0, 0);
            this.label_row6.Name = "label_row6";
            this.label_row6.Size = new System.Drawing.Size(55, 40);
            this.label_row6.TabIndex = 5;
            this.label_row6.Text = "token";
            this.label_row6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row7
            // 
            this.panel_row7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_row7.Controls.Add(this.label_row7);
            this.panel_row7.Location = new System.Drawing.Point(0, 341);
            this.panel_row7.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row7.Name = "panel_row7";
            this.panel_row7.Size = new System.Drawing.Size(55, 40);
            this.panel_row7.TabIndex = 44;
            // 
            // label_row7
            // 
            this.label_row7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_row7.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row7.Location = new System.Drawing.Point(0, 0);
            this.label_row7.Name = "label_row7";
            this.label_row7.Size = new System.Drawing.Size(55, 40);
            this.label_row7.TabIndex = 5;
            this.label_row7.Text = "LR";
            this.label_row7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row8
            // 
            this.panel_row8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_row8.Controls.Add(this.label_row8);
            this.panel_row8.Location = new System.Drawing.Point(0, 381);
            this.panel_row8.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row8.Name = "panel_row8";
            this.panel_row8.Size = new System.Drawing.Size(55, 40);
            this.panel_row8.TabIndex = 44;
            // 
            // label_row8
            // 
            this.label_row8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(182)))), ((int)(((byte)(191)))));
            this.label_row8.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.label_row8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row8.Location = new System.Drawing.Point(0, 0);
            this.label_row8.Name = "label_row8";
            this.label_row8.Size = new System.Drawing.Size(55, 40);
            this.label_row8.TabIndex = 5;
            this.label_row8.Text = "stack";
            this.label_row8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_row1_value
            // 
            this.panel_row1_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row1_value.Controls.Add(this.label_row1_input);
            this.panel_row1_value.Location = new System.Drawing.Point(56, 100);
            this.panel_row1_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row1_value.Name = "panel_row1_value";
            this.panel_row1_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row1_value.TabIndex = 35;
            // 
            // panel_row2_value
            // 
            this.panel_row2_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row2_value.Controls.Add(this.label_row2_token);
            this.panel_row2_value.Location = new System.Drawing.Point(56, 140);
            this.panel_row2_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row2_value.Name = "panel_row2_value";
            this.panel_row2_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row2_value.TabIndex = 36;
            // 
            // panel_row3_value
            // 
            this.panel_row3_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row3_value.Controls.Add(this.label_row3_stack);
            this.panel_row3_value.Location = new System.Drawing.Point(56, 180);
            this.panel_row3_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row3_value.Name = "panel_row3_value";
            this.panel_row3_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row3_value.TabIndex = 37;
            // 
            // panel_row4_value
            // 
            this.panel_row4_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(201)))), ((int)(((byte)(214)))));
            this.panel_row4_value.Controls.Add(this.label_row4_RPN);
            this.panel_row4_value.Location = new System.Drawing.Point(56, 220);
            this.panel_row4_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row4_value.Name = "panel_row4_value";
            this.panel_row4_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row4_value.TabIndex = 37;
            // 
            // panel_row5_value
            // 
            this.panel_row5_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row5_value.Controls.Add(this.label_row5_RPN);
            this.panel_row5_value.Location = new System.Drawing.Point(56, 261);
            this.panel_row5_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row5_value.Name = "panel_row5_value";
            this.panel_row5_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row5_value.TabIndex = 37;
            // 
            // panel_row6_value
            // 
            this.panel_row6_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row6_value.Controls.Add(this.label_row6_token);
            this.panel_row6_value.Location = new System.Drawing.Point(56, 301);
            this.panel_row6_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row6_value.Name = "panel_row6_value";
            this.panel_row6_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row6_value.TabIndex = 40;
            // 
            // label_row6_token
            // 
            this.label_row6_token.AutoSize = true;
            this.label_row6_token.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row6_token.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row6_token.Location = new System.Drawing.Point(2, 6);
            this.label_row6_token.Name = "label_row6_token";
            this.label_row6_token.Size = new System.Drawing.Size(0, 27);
            this.label_row6_token.TabIndex = 40;
            // 
            // panel_row7_value
            // 
            this.panel_row7_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row7_value.Controls.Add(this.label_row7_LR);
            this.panel_row7_value.Location = new System.Drawing.Point(56, 341);
            this.panel_row7_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row7_value.Name = "panel_row7_value";
            this.panel_row7_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row7_value.TabIndex = 41;
            // 
            // label_row7_LR
            // 
            this.label_row7_LR.AutoSize = true;
            this.label_row7_LR.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row7_LR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))));
            this.label_row7_LR.Location = new System.Drawing.Point(2, 6);
            this.label_row7_LR.Name = "label_row7_LR";
            this.label_row7_LR.Size = new System.Drawing.Size(0, 27);
            this.label_row7_LR.TabIndex = 41;
            // 
            // panel_row8_value
            // 
            this.panel_row8_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(182)))), ((int)(((byte)(191)))));
            this.panel_row8_value.Controls.Add(this.label_row8_stack);
            this.panel_row8_value.Location = new System.Drawing.Point(56, 381);
            this.panel_row8_value.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row8_value.Name = "panel_row8_value";
            this.panel_row8_value.Size = new System.Drawing.Size(587, 40);
            this.panel_row8_value.TabIndex = 41;
            // 
            // bt_action
            // 
            this.bt_action.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.bt_action.ForeColor = System.Drawing.Color.Black;
            this.bt_action.Location = new System.Drawing.Point(765, 134);
            this.bt_action.Name = "bt_action";
            this.bt_action.Size = new System.Drawing.Size(106, 40);
            this.bt_action.TabIndex = 45;
            this.bt_action.Text = "Calcurate";
            this.bt_action.UseVisualStyleBackColor = true;
            this.bt_action.Click += new System.EventHandler(this.action_Click);
            // 
            // bt_change
            // 
            this.bt_change.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_change.Location = new System.Drawing.Point(765, 107);
            this.bt_change.Name = "bt_change";
            this.bt_change.Size = new System.Drawing.Size(106, 21);
            this.bt_change.TabIndex = 46;
            this.bt_change.Text = "mode";
            this.bt_change.UseVisualStyleBackColor = true;
            this.bt_change.Click += new System.EventHandler(this.modeChange);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_mode.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_mode.Location = new System.Drawing.Point(685, 111);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(63, 16);
            this.label_mode.TabIndex = 47;
            this.label_mode.Text = "PROCESS";
            // 
            // trackBar_freq
            // 
            this.trackBar_freq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.trackBar_freq.LargeChange = 1;
            this.trackBar_freq.Location = new System.Drawing.Point(653, 134);
            this.trackBar_freq.Maximum = 22;
            this.trackBar_freq.MaximumSize = new System.Drawing.Size(218, 40);
            this.trackBar_freq.Minimum = 1;
            this.trackBar_freq.MinimumSize = new System.Drawing.Size(106, 40);
            this.trackBar_freq.Name = "trackBar_freq";
            this.trackBar_freq.Size = new System.Drawing.Size(106, 45);
            this.trackBar_freq.TabIndex = 38;
            this.trackBar_freq.Value = 5;
            // 
            // label_freq
            // 
            this.label_freq.AutoSize = true;
            this.label_freq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_freq.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_freq.ForeColor = System.Drawing.Color.Black;
            this.label_freq.Location = new System.Drawing.Point(650, 158);
            this.label_freq.Name = "label_freq";
            this.label_freq.Size = new System.Drawing.Size(49, 14);
            this.label_freq.TabIndex = 48;
            this.label_freq.Text = " 5[Hz]";
            // 
            // panel_modecolor
            // 
            this.panel_modecolor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panel_modecolor.Location = new System.Drawing.Point(653, 107);
            this.panel_modecolor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_modecolor.Name = "panel_modecolor";
            this.panel_modecolor.Size = new System.Drawing.Size(21, 21);
            this.panel_modecolor.TabIndex = 49;
            // 
            // panel_row9
            // 
            this.panel_row9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_row9.Controls.Add(this.label_row9);
            this.panel_row9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel_row9.Location = new System.Drawing.Point(0, 422);
            this.panel_row9.Margin = new System.Windows.Forms.Padding(0);
            this.panel_row9.Name = "panel_row9";
            this.panel_row9.Size = new System.Drawing.Size(55, 40);
            this.panel_row9.TabIndex = 40;
            // 
            // label_row9
            // 
            this.label_row9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_row9.Font = new System.Drawing.Font("ＭＳ ゴシック", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_row9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label_row9.Location = new System.Drawing.Point(0, 0);
            this.label_row9.Name = "label_row9";
            this.label_row9.Size = new System.Drawing.Size(55, 40);
            this.label_row9.TabIndex = 51;
            this.label_row9.Text = "log";
            this.label_row9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_row9.Click += new System.EventHandler(this.textBox_log_Toggle);
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox_log.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_log.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox_log.Location = new System.Drawing.Point(688, 634);
            this.textBox_log.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(478, 276);
            this.textBox_log.TabIndex = 50;
            this.textBox_log.Visible = false;
            this.textBox_log.DoubleClick += new System.EventHandler(this.textBox_log_Toggle);
            this.textBox_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_log_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1318, 960);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.panel_row9);
            this.Controls.Add(this.panel_modecolor);
            this.Controls.Add(this.label_freq);
            this.Controls.Add(this.trackBar_freq);
            this.Controls.Add(this.label_mode);
            this.Controls.Add(this.bt_change);
            this.Controls.Add(this.bt_action);
            this.Controls.Add(this.panel_row8_value);
            this.Controls.Add(this.panel_row7_value);
            this.Controls.Add(this.panel_row6_value);
            this.Controls.Add(this.panel_row4_value);
            this.Controls.Add(this.panel_row3_value);
            this.Controls.Add(this.panel_row2_value);
            this.Controls.Add(this.panel_row9_value);
            this.Controls.Add(this.panel_row8);
            this.Controls.Add(this.panel_row5_value);
            this.Controls.Add(this.panel_row7);
            this.Controls.Add(this.panel_row6);
            this.Controls.Add(this.panel_row5);
            this.Controls.Add(this.panel_row4);
            this.Controls.Add(this.panel_row3);
            this.Controls.Add(this.panel_row2);
            this.Controls.Add(this.panel_row1);
            this.Controls.Add(this.bracket_depth_display);
            this.Controls.Add(this.bt_kilo);
            this.Controls.Add(this.bt_0);
            this.Controls.Add(this.word_display);
            this.Controls.Add(this.panel_input);
            this.Controls.Add(this.bt_brackets_open);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_divide);
            this.Controls.Add(this.bt_multi);
            this.Controls.Add(this.bt_sub);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.bt_brackets_close);
            this.Controls.Add(this.bt_dot);
            this.Controls.Add(this.bt_2);
            this.Controls.Add(this.bt_3);
            this.Controls.Add(this.bt_4);
            this.Controls.Add(this.bt_5);
            this.Controls.Add(this.bt_6);
            this.Controls.Add(this.bt_7);
            this.Controls.Add(this.bt_8);
            this.Controls.Add(this.bt_9);
            this.Controls.Add(this.bt_1);
            this.Controls.Add(this.panel_row1_value);
            this.Controls.Add(this.panel_numpad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_input.ResumeLayout(false);
            this.panel_input.PerformLayout();
            this.panel_row9_value.ResumeLayout(false);
            this.panel_row9_value.PerformLayout();
            this.panel_row1.ResumeLayout(false);
            this.panel_row1.PerformLayout();
            this.panel_row2.ResumeLayout(false);
            this.panel_row3.ResumeLayout(false);
            this.panel_row4.ResumeLayout(false);
            this.panel_row5.ResumeLayout(false);
            this.panel_row6.ResumeLayout(false);
            this.panel_row7.ResumeLayout(false);
            this.panel_row8.ResumeLayout(false);
            this.panel_row1_value.ResumeLayout(false);
            this.panel_row1_value.PerformLayout();
            this.panel_row2_value.ResumeLayout(false);
            this.panel_row2_value.PerformLayout();
            this.panel_row3_value.ResumeLayout(false);
            this.panel_row3_value.PerformLayout();
            this.panel_row4_value.ResumeLayout(false);
            this.panel_row4_value.PerformLayout();
            this.panel_row5_value.ResumeLayout(false);
            this.panel_row5_value.PerformLayout();
            this.panel_row6_value.ResumeLayout(false);
            this.panel_row6_value.PerformLayout();
            this.panel_row7_value.ResumeLayout(false);
            this.panel_row7_value.PerformLayout();
            this.panel_row8_value.ResumeLayout(false);
            this.panel_row8_value.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_freq)).EndInit();
            this.panel_row9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label input_display;
        private System.Windows.Forms.Button bt_1;
        private System.Windows.Forms.Button bt_9;
        private System.Windows.Forms.Button bt_8;
        private System.Windows.Forms.Button bt_7;
        private System.Windows.Forms.Button bt_6;
        private System.Windows.Forms.Button bt_5;
        private System.Windows.Forms.Button bt_4;
        private System.Windows.Forms.Button bt_3;
        private System.Windows.Forms.Button bt_2;
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
        private System.Windows.Forms.Label word_display;
        private System.Windows.Forms.Label wordx_display;
        private System.Windows.Forms.Label label_row3_stack;
        private System.Windows.Forms.Label label_row2_token;
        private System.Windows.Forms.Label label_row1_input;
        private System.Windows.Forms.Panel panel_input;
        private System.Windows.Forms.Panel panel_numpad;
        private System.Windows.Forms.Button bt_kilo;
        private System.Windows.Forms.Panel panel_row9_value;
        private System.Windows.Forms.Panel panel_row1_value;
        private System.Windows.Forms.Label label_row5_RPN;
        private System.Windows.Forms.Label label_row8_stack;
        private System.Windows.Forms.Label label_row4_RPN;
        private System.Windows.Forms.Panel panel_row1;
        private System.Windows.Forms.Panel panel_row2;
        private System.Windows.Forms.Panel panel_row3;
        private System.Windows.Forms.Panel panel_row4;
        private System.Windows.Forms.Panel panel_row5;
        private System.Windows.Forms.Panel panel_row6;
        private System.Windows.Forms.Label label_row1;
        private System.Windows.Forms.Label label_row2;
        private System.Windows.Forms.Label label_row3;
        private System.Windows.Forms.Label label_row4;
        private System.Windows.Forms.Label label_row5;
        private System.Windows.Forms.Label label_row6;
        private System.Windows.Forms.Panel panel_row7;
        private System.Windows.Forms.Label label_row7;
        private System.Windows.Forms.Panel panel_row5_value;
        private System.Windows.Forms.Panel panel_row8;
        private System.Windows.Forms.Label label_row8;
        private System.Windows.Forms.Panel panel_row2_value;
        private System.Windows.Forms.Panel panel_row3_value;
        private System.Windows.Forms.Panel panel_row4_value;
        private System.Windows.Forms.Panel panel_row6_value;
        private System.Windows.Forms.Panel panel_row7_value;
        private System.Windows.Forms.Panel panel_row8_value;
        private Button bt_action;
        private Button bt_change;
        private Label label_mode;
        private Label label_row6_token;
        private Label label_row7_LR;
        private Label label_row9_log;
        private TrackBar trackBar_freq;
        private Label label_freq;
        private Panel panel_modecolor;
        private Panel panel_row9;
        private Label label_row9;
        private TextBox textBox_log;
    }
}

