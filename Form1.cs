using System;
using System.Collections;
using System.Collections.Generic; // スタックを扱うために必要
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks; // 非同期処理で処理を待機するために必要
using System.Threading;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;
using System.Drawing.Text;
using static System.Threading.Timer;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Controls;
using System.Reflection.Emit;
using System.Windows;
//using System.Windows.Controls;

namespace _240810_calc
{
    public partial class Form1 : Form
    {
        // 変数宣言
        string input = "";  // 入力された数式そのまま
        int bracket_depth = 0;  // 括弧が閉じられているか否か　閉じていればtrue
        int period_phase = 0;   // 小数点を入力できるかの判定（最後の文字はまだ見ない大前提の条件として）
                                // 　0→可能「3」
                                // 　1→小数点記号が入力され、小数点以下が一つ以上入力されるのを待っている状況「3.」
                                // 　2→小数点以下が1つ以上入力され、数値と小数点以下以外 が入力されるのを待つ状況「3.2」「3.24」
                                // 分類〇の直前に存在してはいけない文字（禁止文字）
        string[] symbol_typeA = { "+", "-", "x", "/", ".", "(" };       // 分類A「 + - * / 」
        string[] symbol_typeMinus = { "+", "-", "x", "/", "." };        // 分類Aの中のマイナス記号
        string[] symbol_typeB = { "+", "-", "x", "/", ".", "(", ")" };  // 分類B「 . 」
        string[] symbol_typeC = { "." };                                // 分類C「 ( 」
        string[] symbol_typeD = { "+", "-", "x", "/", ".", "(" };       // 分類D「 ) 」

        // 計算可能かどうかを判別するための、最後に来てはいけない文字
        // これはsymbol_typeDと同じなのでこれを流用する

        // input → input_list → input_word に変換する関数（ConvertToInputWord()関数）で、文字種類の判定に使う
        string[] group_num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] group_cal = { "+", "-", "x", "/" };

        // 計算式を格納する諸変数
        string[] input_word = new string[] { };  // 入力文字列を数値と記号毎に、配列に分解したもの
        string[] input_wordx = new string[] { }; // ↑で省略されていたx記号を補ったもの
        string[] rev_poland = new string[] { }; // ↑を並べ替え、逆ポーランド記法にしたもの
        float? answer; // 計算結果Calcrate()の結果をこれに入れる ★float?にすることでnullを許容（計算過程でfloatの範囲外になった時はnullで返す）
        bool isOutOfFloat = false;

        /**
         * 表示モードについて
         * - isShowCalcProcess == false のとき 計算ボタンで即結果を表示「即時計算」
         * - isShowCalcProcess == true  のとき 計算ボタンで input_wordx → rev_poland → answer までの計算過程を順々に表示
         * input, input_word, input_wordx はinputに連動して都度表示させておく
         */

        // 過程表示モード切替
        int freq = 5;               // 過程の表示更新の周波数
        bool isShowCalcProcess = true;  // 計算過程を表示するか否か input_wordx → rev_poland → answer

        // ログ表示画面
        bool isShowLogPage = false;
        string[] log_array = new string[]
            {
                "■ 240810_calc",
                "      □ 機能",
                "            - 入力した数式を後置記法に変換して解を求めます。（小数点のバグあり）",
                "      □ モード",
                "            - 「PROCESS」: 入力数式 → 後置記法 → 解 への 変換・演算 過程を表示します。",
                "            - 「INSTANT」: 入力した数式は即座に計算されます。（ログは残りません）",
                "      □ 制作期間",
                "            -  240810～240907",
                "      □ 制作",
                "            -  @kah221",
                "      □ 開発環境",
                "            - 開発環境   : Visual Studio 2022",
                "            - ﾌﾚｰﾑﾜｰｸ    : .NET Framework 4.8",
                "            - 言語       : C#",
                "--------------------------------------------------------------   Press Enter to close.   ----------------",
            };

        /// <summary>
        /// アプリが開かれたとき、コンポーネントの初期化、画面サイズの指定等を行う
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(900, 500); // (横, 縦)
            this.MinimumSize = new System.Drawing.Size(900, 500); // 横, 縦
            this.MaximumSize = new System.Drawing.Size(1900, 500);

            // 位置調整用の変数
            int _window_w = this.ClientSize.Width;  // 画面全体の幅
            int _window_h = this.ClientSize.Height; // 画面全体の高さ





            panel_input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_input.Size = new System.Drawing.Size(_window_w, 99);

            panel_numpad.Anchor = AnchorStyles.Right;
            //panel_numpad.Dock = DockStyle.Right;
            panel_numpad.Location = new System.Drawing.Point(654, 100);



            panel_row1_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row1_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row2_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row2_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row3_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row3_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row4_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row4_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row5_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row5_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row6_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row6_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row7_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row7_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row8_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row8_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);
            panel_row9_value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_row9_value.Size = new System.Drawing.Size(_window_w - 232 - 55, 40);


            // input_display
            input_display.AutoSize = false; // falseにしないと右詰できない
            input_display.Parent = panel_input; // パネル領域を親要素に指定
            input_display.Dock = DockStyle.Fill; // 親要素のサイズいっぱいに広げる 親要素がAnchorのRightなので合わせて右詰
            input_display.TextAlign = ContentAlignment.MiddleRight; // ラベル内の文字列を右詰に

            // log
            //label_row9_log.AutoSize = false;
            //label_row9_log.Parent = panel_row9_value;
            //label_row9_log.Dock = DockStyle.Fill;
            //label_row9_log.TextAlign = ContentAlignment.MiddleLeft;

            // イベントハンドラ
            trackBar_freq.ValueChanged += TrackBarFreqChanged; // トラックバーがチェンジしたときの
            input_display.TextChanged += inputTextChanged; // 入力が更新した時フォントサイズをリサイズ
            

            // ボタン類の位置調整
            bt_action.Anchor = AnchorStyles.Right;
            trackBar_freq.Anchor = AnchorStyles.Right;
            label_freq.Anchor = AnchorStyles.Right;
            panel_modecolor.Anchor = AnchorStyles.Right;
            bt_change.Anchor = AnchorStyles.Right;
            label_mode.Anchor = AnchorStyles.Right;
            bt_0.Anchor = AnchorStyles.Right;
            bt_kilo.Anchor = AnchorStyles.Right;
            bt_1.Anchor = AnchorStyles.Right;
            bt_2.Anchor = AnchorStyles.Right;
            bt_3.Anchor = AnchorStyles.Right;
            bt_4.Anchor = AnchorStyles.Right;
            bt_5.Anchor = AnchorStyles.Right;
            bt_6.Anchor = AnchorStyles.Right;
            bt_7.Anchor = AnchorStyles.Right;
            bt_8.Anchor = AnchorStyles.Right;
            bt_9.Anchor = AnchorStyles.Right;
            bt_brackets_close.Anchor = AnchorStyles.Right;
            bt_brackets_open.Anchor = AnchorStyles.Right;
            bracket_depth_display.Anchor = AnchorStyles.Right;
            bt_clear.Anchor = AnchorStyles.Right;
            bt_delete.Anchor = AnchorStyles.Right;
            bt_dot.Anchor = AnchorStyles.Right;
            bt_sub.Anchor = AnchorStyles.Right;
            bt_add.Anchor = AnchorStyles.Right;
            bt_multi.Anchor = AnchorStyles.Right;
            bt_divide.Anchor = AnchorStyles.Right;

            bt_action.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 276);
            trackBar_freq.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 276);
            label_freq.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 250);
            panel_modecolor.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 304);
            bt_change.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 304);
            label_mode.Location = new System.Drawing.Point(_window_w - 50 - 174 + 21, _window_h - 50 - 300);
            bt_0.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 6);
            bt_kilo.Location = new System.Drawing.Point(_window_w - 50 - 118, _window_h - 50 - 6);
            bt_1.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 174);
            bt_2.Location = new System.Drawing.Point(_window_w - 50 - 118, _window_h - 50 - 174);
            bt_3.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 174);
            bt_4.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 118);
            bt_5.Location = new System.Drawing.Point(_window_w - 50 - 118, _window_h - 50 - 118);
            bt_6.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 118);
            bt_7.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 62);
            bt_8.Location = new System.Drawing.Point(_window_w - 50 - 118, _window_h - 50 - 62);
            bt_9.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 62);
            bt_brackets_close.Location = new System.Drawing.Point(_window_w - 50 - 118, _window_h - 50 - 230);
            bt_brackets_open.Location = new System.Drawing.Point(_window_w - 50 - 174, _window_h - 50 - 230);
            bracket_depth_display.Location = new System.Drawing.Point(_window_w - 194, _window_h - 50 - 227);
            bt_clear.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 230);
            bt_delete.Location = new System.Drawing.Point(_window_w - 50 - 6, _window_h - 50 - 230);
            bt_dot.Location = new System.Drawing.Point(_window_w - 50 - 62, _window_h - 50 - 6);
            bt_sub.Location = new System.Drawing.Point(_window_w - 50 - 6, _window_h - 50 - 118);
            bt_add.Location = new System.Drawing.Point(_window_w - 50 - 6, _window_h - 50 - 174);
            bt_multi.Location = new System.Drawing.Point(_window_w - 50 - 6, _window_h - 50 - 62);
            bt_divide.Location = new System.Drawing.Point(_window_w - 50 - 6, _window_h - 50 - 6);

            //this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更不可にする

            // log表示用画面を画面いっぱいに
            textBox_log.Dock = System.Windows.Forms.DockStyle.Fill;

        }

        // これ必要
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ------------------------------------------------------------------------------------------
        // ↑ アプリ全体の初期化処理
        // ↓ クリックイベントの処理
        // ------------------------------------------------------------------------------------------

        /// <summary>
        /// 数字・記号を押したときに表示する文字を更新する。「C」ボタンか否か、モードがどちらか、により処理を分岐
        /// この関数が呼ばれる前に、inputの更新は完了させておく
        /// </summary>
        private bool CallConvertCalcUpdate(string btnName = "") // boolを返すことにする（trueならfloatの範囲内で計算可能, falseならfloatの範囲外で計算不可）
        {
            // 前回のfloat範囲外エラーフラグをリセット
            isOutOfFloat = false;
            UpdateLabelRow9Log("", false);

            if (btnName == "C") // 「C」ボタンからこれが呼び出されたとき → 全てを空に
            {
                UpdateInput(input_wordx);
                // UpdateWord(input_word);
                //UpdateWordx(input_wordx);
                UpdateRevPoland(rev_poland);

                label_row1_input.Text = "";
                label_row2_token.Text = "";
                label_row3_stack.Text = "";
                label_row5_RPN.Text = "";
                label_row8_stack.Text = "";
                return true;
            }
            else // それ以外のボタンからこれが呼び出されたとき → inputをもとに順に処理を呼び出す
            {

                input_word = ConvertToInputWord(input);
                //UpdateWord(input_word);

                input_wordx = ConvertToInputWordx(input_word);
                //UpdateWordx(input_wordx);

                UpdateInput(input_wordx);

                if (isShowCalcProcess == false && JudgeFormulaCanSolve()) // 即時計算モード かつ 数式が解けるとき → 解まで表示
                {
                    rev_poland = ConvertToRevPoland(input_wordx);
                    // float範囲外の場合nullで返ってくる
                    if(rev_poland == null)
                    {
                        return false;
                    }

                    label_row4_RPN.Text = string.Join(" ", rev_poland);
                    answer = Calculate(rev_poland);
                    if(answer == null) // nullのときはfloatの範囲外
                    {
                        // 計算の過程でスタックの内容が残ったまま←このままにしておく

                        return false;
                    }
                    else
                    {
                        label_row8_stack.Text = answer.ToString(); // 解を表示
                    }
                }

                if (btnName == "delete" && JudgeFormulaCanSolve() == false)  // 一文字削除ボタン かつ 数式が解けないとき → モードにかかわらずrev_poとanswerを表示しない
                {
                    // 一時的に隠すだけなので、関数を介さずに行う
                    label_row4_RPN.Text = "";
                    label_row8_stack.Text = "";
                }
                return true;
            }
        }

        /// <summary>
        /// 計算可能かどうかを判断する
        /// </summary>
        /// <returns>計算可能か否か trueなら計算可能</returns>
        private bool JudgeFormulaCanSolve()
        {
            // 計算可能かを判断 
            if (input.Count() == 0)
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 数式が空です");
                UpdateLabelRow9Log("The equation is empty.", false, "red");
                return false;
            }
            else if (bracket_depth != 0) // 括弧の深さが0でないとき計算不可能
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 括弧が閉じていません");
                UpdateLabelRow9Log("The brackets aren't closed.", false, "red");
                return false;
            }
            else if (symbol_typeD.Any(c => c == input[input.Length - 1].ToString())) // 入力文字列が計算不可能な終わり方のとき（typeDを流用）
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 解けない数式です");
                UpdateLabelRow9Log("The equation cannot be solved.", false, "red");
                return false;
            }
            else
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 計算可能です（小数点のバリデーションは未実装）");
                // モードによって文字を変える
                if (isShowCalcProcess) // 即時計算
                {
                    UpdateLabelRow9Log("Ready.", false);
                }
                else // 過程表示
                {
                    UpdateLabelRow9Log("The equation can be solved.", false);
                }
                return true;
            }
        }



        /// <summary>
        /// 「計算」ボタンが押されたとき、入力文字列の変換・計算の各関数を順に呼び出す
        /// このボタンはisShowCalcProcess==trueのときに押せないようにする
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void action_Click(object sender, EventArgs e)
        {
            // 計算可能不可能にかかわらず表示をリセット 計算過程表示モードで再計算を行った時、label_row4_RPN と label_row8_stackが表示されたままなので
            // （多分他のやつはどこかで処理を書いてる。）
            label_row4_RPN.Text = "";
            label_row8_stack.Text = "";

            // 前回のfloat範囲外エラーフラグをリセット
            isOutOfFloat = false;

            // 配列を初期化
            log_array = new string[]
            {
                "■ 240810_calc",
                "      □ 機能",
                "            - 入力した数式を後置記法に変換して解を求めます。（小数点のバグあり）",
                "      □ モード",
                "            - 「PROCESS」: 入力数式 → 後置記法 → 解 への 変換・演算 過程を表示します。",
                "            - 「INSTANT」: 入力した数式は即座に計算されます。（ログは残りません）",
                "      □ 制作期間",
                "            -  240810～240907",
                "      □ 制作",
                "            -  @kah221",
                "      □ 開発環境",
                "            - 開発環境   : Visual Studio 2022",
                "            - ﾌﾚｰﾑﾜｰｸ    : .NET Framework 4.8",
                "            - 言語       : C#",
                "--------------------------------------------------------------   Press Enter to close.   ----------------",
            };

            if (JudgeFormulaCanSolve()) // 計算可能なら
            {
                input_word = ConvertToInputWord(input); // input → input_list → input_word
                input_wordx = ConvertToInputWordx(input_word); // input_word → input_wordx
                if (isShowCalcProcess) // 計算過程表示モード
                {
                    // 入力数式をlogに追加
                    string[] temp = new string[log_array.Length + 1];
                    Array.Copy(log_array, temp, log_array.Length);
                    temp[temp.Length - 1] = "★ input:  " + string.Join(" ", input_wordx);
                    log_array = temp;

                    // 変換の見出しをlogに追加
                    temp = new string[log_array.Length + 1];
                    Array.Copy(log_array, temp, log_array.Length);
                    temp[temp.Length - 1] = "---< Conversion  >---------";
                    log_array = temp;

                    EnableButton(); // 計算中はボタンを押せないようにする
                    ConvertAndCalculate(input_wordx);
                }
                else // 即時計算モード
                {

                    rev_poland = ConvertToRevPoland(input_wordx); // input_wordx → rev_poland
                    if(rev_poland == null)
                    {
                        return;
                    }
                    answer = Calculate(rev_poland);
                    if (answer == null)
                    {
                        return;
                    }
                    // 表示
                    UpdateInput(input_wordx);
                    //UpdateWord(input_word);
                    //UpdateWordx(input_wordx);
                    UpdateRevPoland(rev_poland);


                }
            }
            else
            {

            }
        }

        /// <summary>
        /// 「0~9」ボタンが押されたとき、表示を更新する。小数点の状態により処理を分岐
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btNumber_Click(object sender, EventArgs e)
        {
            input += ((System.Windows.Forms.Button)sender).Text; // ボタンに表示している文字を入力（半角にしている）
            // 小数点の状態「period_phase」が 1 だったとき、小数点以下入力待ちフェーズなので
            if (period_phase == 1)
            {
                period_phase = 2; // 2：小数点と数値以外の入力待ち状態へ 
            }
            // 都度更新------------------------------
            if (CallConvertCalcUpdate()) // ←CallConvertCalcUpdate()内で呼ばれる、2つの変換・計算の関数内でfloatの範囲外になった時falseでこれ以上judgeは行わない
            {
                JudgeFormulaCanSolve();
            }
            // ------------------------------
        }

        /// <summary>
        /// 分類Aの記号「 + - * / 」ボタンが押されたときの処理。この中で「 - 」記号のみ特殊な処理を行う
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btSymbol_typeA_Click(object sender, EventArgs e) // 分類 A 
        {
            if (input.Length != 0) // 入力文字が空出ない必要があり、
            {
                string lastChar = input[input.Length - 1].ToString(); // 最後の入力文字を取得
                if ((!symbol_typeA.Any(c => c == lastChar)))
                { // 最後の入力文字が、禁止文字ではないとき　入力実行
                    switch (((System.Windows.Forms.Button)sender).Text)
                    {
                        case "+":
                            input += "+";
                            // 小数点の状態「period_phase」が 2 だったとき、小数点と数値以外の入力待ち状態なので
                            if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                            break;
                        case "*":
                            input += "x";
                            if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                            break;
                        case "/":
                            input += "/";
                            if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                            break;
                            // マイナス記号の処理は書かない
                    }
                }
                // マイナス記号の時だけ特別
                if ((!symbol_typeMinus.Any(c => c == lastChar))) // マイナスの直前の禁止文字
                { // 最後の入力文字が、禁止文字ではないとき　入力実行
                    switch (((System.Windows.Forms.Button)sender).Text)
                    {
                        case "-":
                            input += "-";
                            if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                            break;
                    }
                }
            }
            else
            {
                switch (((System.Windows.Forms.Button)sender).Text)
                {
                    case "-":
                        input += "-";
                        if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                        break;
                }

            }
            // 都度更新------------------------------
            if (CallConvertCalcUpdate())
            {
                JudgeFormulaCanSolve();
            }
            // ------------------------------
        }

        /// <summary>
        /// 分類Bの記号「 . 」ボタンが押されたときの処理。
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btSymbol_typeB_Click(object sender, EventArgs e)
        {
            if (input.Length != 0) // 入力文字が空でない必要があり、
            {
                if (period_phase == 0) // 小数点が入力可能かを判別する①
                {
                    string lastChar = input[input.Length - 1].ToString(); // 最後の入力文字を取得
                    if ((!symbol_typeB.Any(c => c == lastChar)))
                    { // 最後の入力文字が、禁止文字ではないとき　入力実行
                        input += ".";
                        period_phase++;  // 小数点の状態を 0→1 に変更
                    }

                }
            }
            // 都度更新------------------------------
            if (CallConvertCalcUpdate())
            {
                JudgeFormulaCanSolve();
            }
            // ------------------------------
        }

        /// <summary>
        /// 分類Cの記号「 ( 」ボタンが押されたときの処理。
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btSymbol_typeC_Click(object sender, EventArgs e)
        {
            if (input.Length == 0) // 入力文字が空のとき 無条件で入力実行
            {
                input += "(";
                bracket_depth++;
                if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                this.bracket_depth_display.Text = bracket_depth.ToString();
            }
            else
            {
                string lastChar = input[input.Length - 1].ToString(); // 最後の入力文字を取得
                if ((!symbol_typeC.Any(c => c == lastChar)))
                { // 最後の入力文字が、禁止文字ではないとき　入力実行
                    input += "(";
                    bracket_depth++;
                    if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                    this.bracket_depth_display.Text = bracket_depth.ToString();
                }

            }
            // 都度更新------------------------------
            if (CallConvertCalcUpdate())
            {
                JudgeFormulaCanSolve();
            }
            // ------------------------------
        }

        /// <summary>
        /// 分類Dの記号「 ) 」ボタンが押されたときの処理。
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btSymbol_typeD_Click(object sender, EventArgs e)
        {
            if (input.Length != 0) // 入力文字が空のとき 無条件で入力実行
            {
                string lastChar = input[input.Length - 1].ToString(); // 最後の入力文字を取得
                if ((!symbol_typeD.Any(c => c == lastChar))) // 最後の入力文字が、禁止文字ではないとき
                {
                    if (bracket_depth > 0) // さらに括弧の深さが1より大きいとき　入力実行
                    {
                        input += ")";
                        bracket_depth--;
                        if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                        this.bracket_depth_display.Text = bracket_depth.ToString();
                    }
                }
            }
            // 都度更新------------------------------
            if (CallConvertCalcUpdate())
            {
                JudgeFormulaCanSolve();
            }
            // ------------------------------
        }

        /// <summary>
        /// 「C」ボタン（全削除）が押されたときの処理
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void bt_clear_Click(object sender, EventArgs e)
        {
            // リセット
            input = "";
            input_word = new string[] { };
            input_wordx = new string[] { };
            rev_poland = new string[] { };
            bracket_depth = 0; // 括弧の深さ
            period_phase = 0;  // 小数点状態

            // 都度更新------------------------------
            bracket_depth_display.Text = bracket_depth.ToString();
            CallConvertCalcUpdate("C"); // Cから呼び出されたよというフラグをつける
            JudgeFormulaCanSolve();
            // Cで全削除したので、数式が空　というログを表示させない
            UpdateLabelRow9Log("", false);
            // ------------------------------
        }

        /// <summary>
        /// 「<x」ボタン（1文字削除）が押されたときの処理
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (input.Length != 0)
            {
                string deleteTarget = input.Last().ToString();
                if (deleteTarget == ")")
                {
                    bracket_depth++;
                    this.bracket_depth_display.Text = bracket_depth.ToString();
                }
                else if (deleteTarget == "(")
                {
                    bracket_depth--;
                    this.bracket_depth_display.Text = bracket_depth.ToString();
                }
                input = input.Substring(0, input.Length - 1);

                // 都度更新------------------------------
                if (CallConvertCalcUpdate("delete"))
                {
                    JudgeFormulaCanSolve();
                }
                label_row1_input.Text = "";
                label_row2_token.Text = "";
                label_row3_stack.Text = "";
                label_row5_RPN.Text = "";
                label_row6_token.Text = "";
                label_row7_LR.Text = "";
                // ------------------------------
            }
        }

        
        private void modeChange(object sender, EventArgs e)
        {
            if (isShowCalcProcess) // 即時計算モードにする↓
            {
                isShowCalcProcess = false;
                // モード表示
                label_mode.Text = "INSTANT";
                panel_modecolor.BackColor = Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(96))))); // ピンク
                bt_action.Enabled = false;
                trackBar_freq.Enabled = false;
                label_freq.ForeColor = Color.Gray;


                label_row1_input.Text = "";
                label_row2_token.Text = "";
                label_row3_stack.Text = "";
                label_row4_RPN.Text   = "";
                label_row5_RPN.Text   = "";
                label_row6_token.Text = "";
                label_row7_LR.Text    = "";
                label_row8_stack.Text = "";
            }
            else // 過程表示モードにする↓
            {
                isShowCalcProcess = true;
                // モード表示
                label_mode.Text = "PROCESS";
                panel_modecolor.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215))))); // 青
                bt_action.Enabled = true;
                trackBar_freq.Enabled = true;
                label_freq.ForeColor = Color.Black;


                label_row1_input.Text = "";
                label_row2_token.Text = "";
                label_row3_stack.Text = "";
                label_row4_RPN.Text   = "";
                label_row5_RPN.Text   = "";
                label_row6_token.Text = "";
                label_row7_LR.Text    = "";
                label_row8_stack.Text = "";
            }
            // モードチェンジが起きた（双方）
            if (CallConvertCalcUpdate())
            {
                JudgeFormulaCanSolve();
            }
            // 入力が空の場合、label_row9_logには赤文字が表示されるので、空にしておく
            if (input == "") UpdateLabelRow9Log("", false);
        }

        // イベントハンドラ
        private void TrackBarFreqChanged(object sender, EventArgs e)
        {
            if (trackBar_freq.Value < 10)
            {
                label_freq.Text = " " + trackBar_freq.Value.ToString() + "[Hz]"; // 1桁なのでスペースで位置合わせ
            }
            else
            {
                label_freq.Text = trackBar_freq.Value.ToString() + "[Hz]";
            }
            freq = trackBar_freq.Value;
        }

        // inputのフォントサイズを動的に変更する
        private void inputTextChanged(object sender, EventArgs e)
        {
            // Graphicsオブジェクトの作成
            using (Graphics g = input_display.CreateGraphics())
            {
                SizeF _input_size = input_display.ClientSize;
                SizeF string_size = g.MeasureString(input_display.Text, input_display.Font);

                // 最適なフォントサイズを二分探索で求める ← 要確認
                int minFontSize = 20; // 最小フォントサイズ
                int maxFontSize = 42; // 最大フォントサイズ
                while (minFontSize <= maxFontSize)
                {
                    int midFontSize = (minFontSize + maxFontSize) / 2;
                    input_display.Font = new Font(input_display.Font.FontFamily, midFontSize);
                    string_size = g.MeasureString(input_display.Text, input_display.Font);

                    if (string_size.Width > _input_size.Width || string_size.Height > _input_size.Height)
                    {
                        maxFontSize = midFontSize - 1;
                    }
                    else
                    {
                        minFontSize = midFontSize + 1;
                    }
                }

                // 見つかった最適なフォントサイズを設定
                input_display.Font = new Font(input_display.Font.FontFamily, maxFontSize);
            }
        }

        private void EnableButton()
        {
            bt_0.Enabled = false;
            bt_1.Enabled = false;
            bt_2.Enabled = false;
            bt_3.Enabled = false;
            bt_4.Enabled = false;
            bt_5.Enabled = false;
            bt_6.Enabled = false;
            bt_7.Enabled = false;
            bt_8.Enabled = false;
            bt_9.Enabled = false;
            bt_action.Enabled = false;
            bt_delete.Enabled = false;
            bt_clear.Enabled = false;
            bt_brackets_open.Enabled = false;
            bt_brackets_close.Enabled = false;
            bt_add.Enabled = false;
            bt_sub.Enabled = false;
            bt_multi.Enabled = false;
            bt_divide.Enabled = false;
            bt_dot.Enabled = false;
            bt_kilo.Enabled = false;
            bt_change.Enabled = false;
            
        }

        private void AbleButton()
        {
            bt_0.Enabled = true;
            bt_1.Enabled = true;
            bt_2.Enabled = true;
            bt_3.Enabled = true;
            bt_4.Enabled = true;
            bt_5.Enabled = true;
            bt_6.Enabled = true;
            bt_7.Enabled = true;
            bt_8.Enabled = true;
            bt_9.Enabled = true;
            bt_action.Enabled = true;
            bt_delete.Enabled = true;
            bt_clear.Enabled = true;
            bt_brackets_open.Enabled = true;
            bt_brackets_close.Enabled = true;
            bt_add.Enabled = true;
            bt_sub.Enabled = true;
            bt_multi.Enabled = true;
            bt_divide.Enabled = true;
            bt_dot.Enabled = true;
            bt_kilo.Enabled = true;
            bt_change.Enabled = true;
        }

        // ------------------------------------------------------------------------------------------
        // ↑ クリックイベントの処理
        // ↓ 変換・計算の処理
        // ------------------------------------------------------------------------------------------


        /// <summary>
        /// 入力文字列「input」を負の値・演算子・小数を考慮し、単語毎の配列「input_word」に変換して返す
        /// 変換の流れ: input → input_list → input_word
        /// </summary>
        /// <param name="input">入力文字列</param>
        /// <returns name="word">単語毎の配列</returns>
        private string[] ConvertToInputWord(string input)
        {
            // 
            Console.WriteLine("入力された文字列 input: " + input);
            // 文字列を配列に変換
            char[] input_list = input.ToCharArray(); // 入力文字列を配列に分解する（1文字ずつ）input → input_list
            string mem_num = "";    // 数値が連続で続いたときにここに保存
            string pre_type = "";   // 一つ前の文字の種類（number, dot, calc, bracket_open, bracket_close)
            string[] word = new string[] { };  // 戻り値
            bool isFinishBracketClose = false; // 最後が括弧閉じだった時、mem_numを追加しないようにするフラグ

            // 入力文字列の長さだけループ
            for (int i = 0; i < input_list.Length; i++)
            {
                isFinishBracketClose = false; // 毎回for文内先頭で初期化

                Console.WriteLine("i= " + i + " の対象文字: " + input_list[i]);
                Console.WriteLine("処理前");
                Console.WriteLine("pre_type: " + pre_type);
                Console.WriteLine("mem_num : " + mem_num);

                // 先に"今回"、続いて"前回"の順に場合分けを行い処理を分岐
                // 今回 calc
                /**
                 * ↓マイナス記号のときの場合分けのメモ
                 * 数値→演算子（マイナス記号）　　　　→→　マイナス記号は演算子　→→　mem_numを初期化して演算子をwordに追加
                 * 数値→演算子（マイナス記号以外）　　→→　　　　　記号は演算子　→→　mem_numを初期化して演算子をwordに追加
                 * 括弧閉じ→演算子（マイナス記号）　　→→　マイナス記号は演算子　→→　mem_numを初期化して演算子をwordに追加
                 * 括弧閉じ→演算子（マイナス記号以外）→→　　　　　記号は演算子　→→　mem_numを初期化して演算子をwordに追加
                 * 括弧開き→演算子（マイナス記号）　　→→　マイナス記号は負値　　→→　mem_numにマイナス記号を追加
                 * 括弧開き→演算子（マイナス記号以外）←×　これは入力不可
                 * 空文字→演算子（マイナス記号）　　　→→　マイナス記号は負値　　→→　mem_numにマイナス記号を追加
                 * 空文字→演算子（マイナス記号以外）　←×　これは入力不可
                 */
                if (group_cal.Any(c => c == input_list[i].ToString()))
                {
                    // 更に演算子がマイナス記号か、それ以外かに分ける
                    if (input_list[i].ToString() == "-") // マイナス記号のとき
                    {
                        // マイナス記号の一つ前の文字の種類で判別
                        if (pre_type == "number" || pre_type == "bracket_close") // このときマイナス記号は演算子 → mem_numを初期化
                        {
                            // ★さらに、前回が括弧閉じだった時、mem_numの中身が空文字になっているため、空文字でないときにのみwordに追加するようにする
                            if (mem_num != "")
                            {
                                // 配列に要素を追加するテンプレ
                                // string[] word に mem_num を追加する
                                string[] newArray = new string[word.Length + 1]; // 新しい配列を複製
                                Array.Copy(word, newArray, word.Length);
                                newArray[newArray.Length - 1] = mem_num; // 最後尾に要素を追加
                                word = newArray; // newArrayが新しい配列となる
                                mem_num = ""; // 初期化
                            }
                            // 続けて、マイナス記号を演算子として追加
                            string[] newArray2 = new string[word.Length + 1]; // 新しい配列を複製
                            Array.Copy(word, newArray2, word.Length);
                            newArray2[newArray2.Length - 1] = "-"; // マイナス記号確定なので文字列で指定
                            word = newArray2; // newArrayが新しい配列となる
                        }
                        if (pre_type == "" || pre_type == "bracket_open") // このときマイナス記号は演算子でない
                        {
                            mem_num += "-";
                        }
                    }
                    else // マイナス記号以外の演算子のとき → 必ずmem_numを初期化
                    {
                        // ★さらに、前回が括弧閉じだった時、mem_numの中身が空文字になっているため、空文字でないときにのみwordに追加するようにする
                        if (mem_num != "")
                        {
                            // 配列に要素を追加するテンプレ
                            // string[] word に mem_num を追加する
                            string[] newArray = new string[word.Length + 1]; // 新しい配列を複製
                            Array.Copy(word, newArray, word.Length);
                            newArray[newArray.Length - 1] = mem_num; // 最後尾に要素を追加
                            word = newArray; // newArrayが新しい配列となる
                            mem_num = ""; // 初期化
                        }

                        // 続けて、記号を演算子として追加
                        string[] newArray2 = new string[word.Length + 1]; // 新しい配列を複製
                        Array.Copy(word, newArray2, word.Length);
                        newArray2[newArray2.Length - 1] = input_list[i].ToString(); // 最後尾に要素を追加
                        word = newArray2; // newArray2が新しい配列となる
                    }

                    pre_type = "calc"; // 前回の文字種を更新
                }

                // 今回 bracket（bracket_open, bracket_close）
                if (input_list[i].ToString() == "(" || input_list[i].ToString() == ")")
                {
                    // 前回を確認（number, calc, bracket, 空 →bracket　の4択のうちnumber→bracketのときのみ追加で処理がある）
                    if (pre_type == "number") // number→bracket mem_numに数値がある状態なのでそれを入れる
                    {
                        // 配列に要素を追加するテンプレ
                        // string[] word に mem_num を追加する
                        string[] newArray = new string[word.Length + 1]; // 新しい配列を複製
                        Array.Copy(word, newArray, word.Length);
                        newArray[newArray.Length - 1] = mem_num; // 最後尾に要素を追加
                        word = newArray; // newArrayが新しい配列となる
                        mem_num = ""; // 初期化
                    }
                    // 今回分の文字を追加する
                    // 配列に要素を追加するテンプレ
                    // string[] word に input_list[i] を追加
                    string[] newArray2 = new string[word.Length + 1]; // 新しい配列を複製
                    Array.Copy(word, newArray2, word.Length);
                    newArray2[newArray2.Length - 1] = input_list[i].ToString(); // 最後尾に要素を追加
                    word = newArray2; // newArray2が新しい配列となる

                    // 前回の文字種を更新
                    if (input_list[i].ToString() == "(") pre_type = "bracket_open";
                    if (input_list[i].ToString() == ")") pre_type = "bracket_close";
                    if (input_list[i].ToString() == ")") isFinishBracketClose = true;
                }

                // 今回 dot
                if (input_list[i].ToString() == ".")
                {
                    // 前回は必ずnumberなので場合分け無し
                    // string mem_num に . を追加する
                    mem_num += "."; // 一時保存

                    pre_type = "dot";
                }

                // 今回 number
                if (group_num.Any(c => c == input_list[i].ToString()))
                {
                    // 前回の文字種は空含め5通りあるが、いずれも処理は同じ
                    // string mem_num に 数値 を追加する
                    mem_num += input_list[i].ToString(); // 一時保存

                    pre_type = "number";
                }

                Console.WriteLine("処理後");
                Console.WriteLine("pre_type: " + pre_type);
                Console.WriteLine("mem_num : " + mem_num);
                Console.WriteLine("");
            }

            // 最後が数値で終わった時、mem_numの中に存在したまま、wordの方には追加されないので、ここで追加する
            // ↓ここで、数値以外の文字（つまり括弧閉じ）で終わった時、空文字が追加されてしまうためフラグを参照
            // string[] word に mem_num を追加する
            if (!isFinishBracketClose) // 最後が閉じ括弧だった時以外、mem_numを追記
            {
                string[] newArray3 = new string[word.Length + 1]; // 新しい配列を複製
                Array.Copy(word, newArray3, word.Length);
                newArray3[newArray3.Length - 1] = mem_num; // 最後尾に要素を追加
                word = newArray3; // newArrayが新しい配列となる
                mem_num = ""; // 初期化
            }

            // 確認用
            // Console.WriteLine("input_word");
            // foreach (string w in word)
            // {
            // Console.WriteLine("  " + w);
            // }

            return word;
        }

        /// <summary>
        /// 単語毎の配列「input_word」に掛け算記号を挿入して返す「input_wordx」
        /// </summary>
        /// <param name="word">単語毎の配列「input_word」</param>
        /// <returns name="wordx">x挿入済み単語毎の配列「」</returns>
        private string[] ConvertToInputWordx(string[] word)
        {
            string[] wordx = new string[] { }; // 戻り値
            string pre_type = ""; // ループ初回参照時は空文字のため""にしておく
            string now_type;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == "(")
                {
                    now_type = "bracket_open";
                }
                else if (word[i] == ")")
                {
                    now_type = "bracket_close";
                }
                else if (float.TryParse(word[i], out float num))
                {
                    now_type = "number";
                }
                else
                {
                    now_type = "";
                }

                if ((pre_type == "bracket_close" && now_type == "number") ||
                    (pre_type == "number" && now_type == "bracket_open") ||
                    (pre_type == "bracket_close" && now_type == "bracket_open"))// この時、数値と括弧の間に掛け算記号を追加する
                {
                    // wordx末尾にx追加する
                    Console.WriteLine("x記号追加");
                    string[] newArray = new string[wordx.Length + 1]; // 現在のwordxの要素数+1の配列を用意
                    Array.Copy(wordx, newArray, wordx.Length);
                    newArray[newArray.Length - 1] = "x";
                    wordx = newArray;
                }
                // wordxにwordの要素をに追加する
                string[] newArray2 = new string[wordx.Length + 1]; // 現在のwordxの要素数+1の配列を用意
                Array.Copy(wordx, newArray2, wordx.Length);
                newArray2[newArray2.Length - 1] = word[i];
                wordx = newArray2;

                pre_type = now_type; // 文字の種類を更新
            }

            // 確認用
            // Console.WriteLine("input_wordx");
            // foreach (string wx in wordx)
            // {
            // Console.WriteLine(wx);
            //Console.Write(wx + " ");
            //  }

            return wordx;
        }

        /// <summary>
        /// x挿入済み単語毎の配列「input_wordx」を後置記法（配列）に変換する「rev_poland」
        /// </summary>
        /// <param name="wordx">x挿入済み単語毎の配列「input_wordx」</param>
        /// <returns name="_array">後置記法（配列）</returns>
        private string[] ConvertToRevPoland(string[] wordx)
        {
            Console.WriteLine("ConvertToRevPolandが呼び出された");
            Console.WriteLine("wordxの長さ" + wordx.Length);
            // 変換用
            Stack<string> _stack = new Stack<string>();    // 計算用スタック
            string[] _array = new string[] { };      // 変換済み配列（戻り値）
            Dictionary<string, int> priority = new Dictionary<string, int> // 演算子の優先順位付け 大きいほど優先順位高
            {
                {"(", 0 }, // ←0！！！
                {"x", 2 },
                {"/", 2 },
                {"+", 1 },
                {"-", 1 }
            };

            /**
             * ①数値はスタックに積まない
             * ②演算子はスタックに積む
             * ③スタックに計算の優先順位が高い演算子があるときは、スタックの全ての演算子を取り出す
             * 　↑優先順位が高い　とは、
             * 　    - 演算子が読み込まれる順番のうち、早く読み込まれたもの←これは必ず満たす（左から読むため）
             * 　    - スタックの一番上が、括弧閉じ、x, / 記号であるとき？
             * ④最後に演算子をスタックからすべて取り出す
             * 
             */

            int i = 0;
            foreach (string x in wordx)
            {
                // デバッグ用文字列
                Console.WriteLine(i + " 回目----------------------------");

                // 桁数が範囲外
                if (x.Count() > 30)
                {
                    Console.WriteLine("桁数が範囲外★★");
                    UpdateLabelRow9Log("Out of range for a float.  (input → RPN)", true, "red"); // これ以降inputの更新が無い限りlog更新しないように
                    return null;
                }


                // 種類を判定 0~9, +-), x/(, 
                float xf;
                if (float.TryParse(x, out xf)) // float型に変換できた時 数値
                {
                    Console.WriteLine(x + " ←数値");
                    // x→converted
                    string[] temp = new string[_array.Length + 1];
                    Array.Copy(_array, temp, _array.Length);
                    temp[temp.Length - 1] = x;
                    _array = temp;
                }
                else if (x == "(")
                {
                    Console.WriteLine(x + " ←開き括弧");
                    _stack.Push(x);
                }
                else if (x == ")")
                {
                    Console.WriteLine(x + " ←閉じ括弧");
                    // スタックから左括弧が出るまでstack→converted
                    while (_stack.Count() > 0 && _stack.Peek() != "(")
                    {

                        string[] temp = new string[_array.Length + 1];
                        Array.Copy(_array, temp, _array.Length);
                        temp[temp.Length - 1] = _stack.Pop();
                        _array = temp;

                    }
                    // ↑までで、スタックの最後に括弧開き　が入った状態になるので、最後にそいつを取り出す
                    if (_stack.Count() > 0 && _stack.Peek() == "(") _stack.Pop();
                }
                else // 演算子
                {
                    Console.WriteLine(x + " ←演算子");
                    while ((_stack.Count() > 0) && (priority[x] <= priority[_stack.Peek()]))
                    {
                        // 優先順位確認
                        Console.WriteLine("今回の演算子の優先順位　: " + priority[x]);
                        Console.WriteLine("スタックの先頭の優先順位: " + priority[_stack.Peek()]);
                        string[] temp = new string[_array.Length + 1];
                        Array.Copy(_array, temp, _array.Length);
                        temp[temp.Length - 1] = _stack.Pop();
                        _array = temp;
                    }
                    _stack.Push(x);
                }


                //------------------------------用意↓
                i++;
                string wordx_txt = ""; // 変換前
                string target = x;
                string _stack_txt = string.Join(" ", _stack);
                string _array_txt = string.Join(" ", _array);
                Stack<string> _stack_copy = new Stack<string>();
                // 変換前の配列　→　文字列
                for (int j = i; j < wordx.Length - 1; j++)
                {
                    wordx_txt += wordx[j];
                }


                //------------------------------用意↑
                //------------------------------表示↓
                Console.WriteLine("wordx_txt:  " + wordx_txt);
                Console.WriteLine("target:     " + target);
                Console.WriteLine("_stack_txt: " + _stack_txt);
                Console.WriteLine("_array_txt: " + _array_txt + "\n\n");
                label_row4_RPN.Text = string.Join(" ", _array);
                //------------------------------表示↑

                //------------------------------遅延
            }





            // 最後にstackに残ったものを取り出す
            Console.WriteLine("最後stackに残ったものを取り出す");
            while (_stack.Count > 0)
            {
                //------------------------------変換
                //string[] n = new string[_array.Length + 1];
                //Array.Copy(_array, n, _array.Length);
                //n[n.Length - 1] = _stack.Pop(); // popして直接入れる
                //_array = n;
                _array = _array.Concat(new[] { _stack.Pop() }).ToArray();

                //------------------------------用意
                string _stack_txt = string.Join(" ", _stack);
                string _array_txt = string.Join(" ", _array);

                //------------------------------表示
                Console.WriteLine("_stack_txt: " + _stack_txt);
                Console.WriteLine("_array_txt: " + _array_txt + "\n\n");
                label_row4_RPN.Text = string.Join(" ", _array);

                //------------------------------遅延\
            }

            // 確認用
            Console.WriteLine("スタック: " + string.Join(", ", _stack));
            Console.WriteLine("後置記法: " + string.Join(", ", _array));
            return _array;
        }



        // 計算する部分
        /// <summary>
        /// 後置記法（配列）「rev_poland」を受け取り解を求める「answer」
        /// </summary>
        /// <param name="poland">後置記法（配列）「rev_poland」</param>
        /// <returns>解（最終的なstackの中身）</returns>
        private float? Calculate(string[] poland)
        {
            Console.WriteLine("Caluculateが呼び出された");
            Stack<float> stack = new Stack<float>(); // 計算用スタック 演算終了時Popで取り出した値が解←戻り値
            // int i = 0;
            foreach (string x in poland)
            { // 配列の要素分だけ動かす

                if(x.Count() > 30)
                {
                    Console.WriteLine("桁数が範囲外★★");
                    UpdateLabelRow9Log("Out of range for a float.  (RPN → Answer)", true, "red"); // inputの更新があるまでlog更新しないように
                    return null; // nullを返す
                }

                // xの種類を判定 数値, (, ), +-x/ の4通り
                if (float.TryParse(x, out float xf)) // float型に変換できたとき → 数値なのでスタックに積み上げる
                {
                    stack.Push(xf);
                }
                else // float型に変換できなかったとき → 演算子
                {
                    float r = stack.Pop(); // right
                    float l = stack.Pop(); // left
                    switch (x) // 演算子による計算を行い、スタックへ積み上げる
                    {
                        case "+":
                            stack.Push(l + r); break;
                        case "-":
                            stack.Push(l - r); break;
                        case "x":
                            stack.Push(l * r); break;
                        case "/":
                            stack.Push(l / r); break;
                    }
                }
                // i++;
            }
            label_row8_stack.Text = stack.Peek().ToString(); // 表示
            return stack.Pop(); // 解を返す
        }

        // ------------------------------------------------------------計算過程表示モードの関数
        private void ConvertAndCalculate(string[] wordx)
        {
            Console.WriteLine("ConvertToRevPolandが呼び出された");
            Console.WriteLine("wordxの長さ" + wordx.Length);
            // 変換用
            Stack<string> _stack = new Stack<string>();    // 計算用スタック
            string[] _array = new string[] { };      // 変換済み配列（戻り値）
            Dictionary<string, int> priority = new Dictionary<string, int> // 演算子の優先順位付け 大きいほど優先順位高
            {
                {"(", 0 }, // ←0！！！
                {"x", 2 },
                {"/", 2 },
                {"+", 1 },
                {"-", 1 }
            };

            // 計算用
            Stack<float> _stackCalc = new Stack<float>();

            Console.WriteLine("isShowCalcProcessがtrue");
            async void DelayTimeAsync()
            {
                Console.WriteLine("DelayTimeAsync()内部");

                label_row1_input.Text = string.Join("", wordx); // 最初にinput_wordxを全部表示（1文字目が欠けてしまうため）
                await Task.Delay(1000 / freq);
                int i = 0;
                foreach (string x in wordx)
                {
                    // デバッグ用文字列
                    Console.WriteLine(i + " 回目----------------------------");

                    // floatの範囲外かを判定
                    if (x.Count() > 30)
                    {
                        Console.WriteLine("桁数が範囲外★★Async");
                        UpdateLabelRow9Log("Out of range for a float.  (input → RPN)", true, "red"); // inputの更新があるまでlog更新しないように
                        isOutOfFloat = true;
                        break;
                    }

                    // 種類を判定 0~9, +-), x/(, 
                    float xf;
                    if (float.TryParse(x, out xf)) // float型に変換できた時 数値
                    {
                        Console.WriteLine(x + " ←数値");
                        // x→converted
                        string[] temp = new string[_array.Length + 1];
                        Array.Copy(_array, temp, _array.Length);
                        temp[temp.Length - 1] = x;
                        _array = temp;
                        UpdateLabelRow9Log("operand        >>>   stack → RPN", true);
                    }
                    else if (x == "(")
                    {
                        Console.WriteLine(x + " ←開き括弧");
                        _stack.Push(x);
                        UpdateLabelRow9Log("bracket-open   >>>   input → stack", true);
                    }
                    else if (x == ")")
                    {
                        Console.WriteLine(x + " ←閉じ括弧");
                        // スタックから左括弧が出るまでstack→converted
                        while (_stack.Count() > 0 && _stack.Peek() != "(")
                        {
                            string[] temp = new string[_array.Length + 1];
                            Array.Copy(_array, temp, _array.Length);
                            temp[temp.Length - 1] = _stack.Pop();
                            _array = temp;

                        }
                        // ↑までで、スタックの最後に括弧開き　が入った状態になるので、最後にそいつを取り出す
                        if (_stack.Count() > 0 && _stack.Peek() == "(") _stack.Pop();
                        UpdateLabelRow9Log("bracket-close  >>>   stack → RPN   (Until the bracket-open appears)", true);
                    }
                    else // 演算子
                    {
                        Console.WriteLine(x + " ←演算子");
                        while ((_stack.Count() > 0) && (priority[x] <= priority[_stack.Peek()]))
                        {
                            // 優先順位確認
                            Console.WriteLine("今回の演算子の優先順位　: " + priority[x]);
                            Console.WriteLine("スタックの先頭の優先順位: " + priority[_stack.Peek()]);
                            string[] temp = new string[_array.Length + 1];
                            Array.Copy(_array, temp, _array.Length);
                            temp[temp.Length - 1] = _stack.Pop();
                            _array = temp;
                        }
                        _stack.Push(x);
                        UpdateLabelRow9Log("operator       >>>   stack → RPN   (Until a higher-priority operator appears)", true);
                    }


                    //------------------------------用意↓
                    i++;
                    string wordx_txt = ""; // 変換前
                    for (int j = i; j < wordx.Length; j++)
                    {
                        wordx_txt += wordx[j];
                    }
                    //------------------------------用意↑
                    //------------------------------表示↓ label_row9_logだけは処理毎に表示する者が違うので上で表示


                    label_row1_input.Text = wordx_txt;
                    label_row2_token.Text = x;
                    label_row3_stack.Text = string.Join(" ", _stack);
                    label_row4_RPN.Text   = string.Join(" ", _array);
                    //------------------------------表示↑

                    //------------------------------遅延
                    await Task.Delay(1000 / freq); // for文内でこれを書く
                }

                // 最後にstackに残ったものを取り出す
                async void DelayTimeAsync2()
                {
                    Console.WriteLine("最後stackに残ったものを取り出す");
                    label_row2_token.Text = "";  // これはリセットしてOK
                    while (_stack.Count > 0)
                    {
                        //------------------------------変換
                        //string[] n = new string[_array.Length + 1];
                        //Array.Copy(_array, n, _array.Length);
                        //n[n.Length - 1] = _stack.Pop(); // popして直接入れる
                        //_array = n;
                        _array = _array.Concat(new[] { _stack.Pop() }).ToArray();

                        //------------------------------用意

                        //------------------------------表示
                        label_row3_stack.Text = string.Join(" ", _stack);
                        label_row4_RPN.Text = string.Join(" ", _array);
                        UpdateLabelRow9Log("empty          >>>   stack → RPN", true);
                        //------------------------------遅延\
                        await Task.Delay(1000 / freq); // while内に書く
                    }
                    // 写し終わった後に、row5を表示
                    label_row5_RPN.Text = string.Join(" ", _array);
                    await Task.Delay(1000 / freq);

                    async void DelayTimeAsync3()
                    {
                        // 変換の見出しをlogに追加
                        string[] temp = new string[log_array.Length + 1];
                        Array.Copy(log_array, temp, log_array.Length);
                        temp[temp.Length - 1] = "---< Calculation >---------";
                        log_array = temp;

                        Console.WriteLine("Caluculateが呼び出された");
                        int k = 1;
                        foreach (string x in _array)
                        { // 配列の要素分だけ動かす
                          // xの種類を判定 数値, (, ), +-x/ の4通り

                            // floatの範囲外かを判定
                            if (x.Count() > 30)
                            {
                                Console.WriteLine("桁数が範囲外★★Async");
                                UpdateLabelRow9Log("Out of range for a float.  (RPN → Answer)", true, "red"); // inputの更新があるまでlog更新しないように
                                isOutOfFloat = true;
                                break;
                            }

                            string _array_txt = "";
                            for (int l = k; l < _array.Length; l++)
                            {
                                _array_txt += _array[l] + " ";
                            }

                            if (float.TryParse(x, out float xf)) // float型に変換できたとき → 数値なのでスタックに積み上げる
                            {
                                //------------------------------変化↓
                                _stackCalc.Push(xf);
                                //------------------------------変化↑
                                //------------------------------表示↓
                                label_row5_RPN.Text = _array_txt;
                                label_row6_token.Text = x;
                                label_row7_LR.Text = "";
                                label_row8_stack.Text = string.Join(" ", _stackCalc);
                                UpdateLabelRow9Log("operand        >>>   RPN   → stack", true);
                                //------------------------------表示↑

                                // 待機
                                await Task.Delay(1000 / freq);
                            }
                            else // float型に変換できなかったとき → 演算子
                            {
                                //------------------------------変化↓
                                float r = _stackCalc.Pop(); // right
                                float l = _stackCalc.Pop(); // left
                                    
                                switch (x) // 演算子による計算を行い、スタックへ積み上げる
                                {
                                    case "+":
                                        _stackCalc.Push(l + r); break;
                                    case "-":
                                        _stackCalc.Push(l - r); break;
                                    case "x":
                                        _stackCalc.Push(l * r); break;
                                    case "/":
                                        _stackCalc.Push(l / r); break;
                                }
                                //------------------------------変化↑
                                //------------------------------表示↓
                                label_row5_RPN.Text = _array_txt;
                                label_row6_token.Text = x;
                                label_row7_LR.Text = l.ToString() + " " + x + " " + r.ToString();
                                label_row8_stack.Text = string.Join(" ", _stackCalc);
                                UpdateLabelRow9Log("operator       >>>   2Pop Calc", true);
                                //------------------------------表示↑

                                // 待機
                                await Task.Delay(1000 / freq);
                            }
                            k++;
                        }
                        if (!isOutOfFloat) // float範囲外エラーなしの場合終了
                        {
                            label_row5_RPN.Text = ""; //row5_RPNに1文字残るので消す
                            label_row6_token.Text = "";
                            label_row7_LR.Text = "";
                            UpdateLabelRow9Log("", false);
                        }
                        AbleButton(); // 計算が終わったのでボタンを押せるようにする ------------------------------←出口
                        // 解をlogに追加
                        string[] temp1 = new string[log_array.Length + 1];
                        Array.Copy(log_array, temp1, log_array.Length);
                        temp1[temp1.Length - 1] = "☆ output:  " + string.Join(" ", _stackCalc);
                        log_array = temp1;
                    }
                    DelayTimeAsync3();
                }
                // DelayTimeAsync()内のforeach内でfloat範囲外エラーが無い場合
                if (!isOutOfFloat)
                {
                    DelayTimeAsync2(); // 続きの処理へ
                }
                else // float範囲外エラーの場合終了
                {
                    AbleButton(); // 計算が終わったのでボタンを押せるようにする

                }
            }
            DelayTimeAsync();
        }




        // ------------------------------------------------------------------------------------------
        // ↑ 変換・計算の処理
        // ↓ 計算式の画面表示 計算過程の表示のため
        // ------------------------------------------------------------------------------------------


        /// <summary>
        /// 入力文字の表示を更新する関数
        /// </summary>
        /// <param name="input"></param>
        private void UpdateInput(string[] list_wx)
        {
            // input_display.Text = input;
            // モードにかかわらずwordxまで表示させるので、input領域にはwordxを表示する
            string text = "";
            foreach (string lwx in list_wx) { text += lwx; }
            input_display.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_rp"></param>
        private void UpdateRevPoland(string[] list_rp)
        {
            Console.WriteLine("UpdateRevPolandが呼び出された");
            string text = "";
            foreach (string lrp in list_rp) { text += lrp + " "; }
            label_row4_RPN.Text = text;
        }

        private void UpdateLabelRow9Log(string log, bool add, string color="black")
        {
            // 文字色を更新
            if(color == "red")
            {
                label_row9_log.ForeColor = Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(96))))); // ピンク
            }
            else
            {
                label_row9_log.ForeColor = Color.Black; // 黒
            }
            // 文字表示
            label_row9_log.Text = log;

            // ログを蓄積
            if (add)
            {
                string[] temp = new string[log_array.Length + 1];
                Array.Copy(log_array, temp, log_array.Length);
                temp[temp.Length - 1] = log;
                log_array = temp;
            }
        }

        // ------------------------------------------------------------------------------------------
        // ↑ 計算式の画面表示 計算過程の表示のため
        // ↓ log画面関連
        // ------------------------------------------------------------------------------------------
        

        private void textBox_log_Toggle(object sender, EventArgs e)
        {
            textBox_log.Visible = true;

            // logを改行して表示
            textBox_log.Text = string.Join(Environment.NewLine, log_array);
        }

        private void textBox_log_KeyDown(object sender, KeyEventArgs e)
        {
            textBox_log.Visible = false;
        }
    }
}