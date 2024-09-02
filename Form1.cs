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
        float answer; // 計算結果Calcrate()の結果をこれに入れる

        /**
         * 表示モードについて
         * - isShowCalcProcess == false のとき 計算ボタンで即結果を表示「即時計算」
         * - isShowCalcProcess == true  のとき 計算ボタンで input_wordx → rev_poland → answer までの計算過程を順々に表示
         * input, input_word, input_wordx はinputに連動して都度表示させておく
         */

        // 過程表示モード切替
        int freq = 5;               // 過程の表示更新の周波数
        bool isShowCalcProcess = true;  // 計算過程を表示するか否か input_wordx → rev_poland → answer

        /// <summary>
        /// アプリが開かれたとき、コンポーネントの初期化、画面サイズの指定等を行う
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1400, 700); // (横, 縦)
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更不可にする
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
        private void CallConvertCalcUpdate(string btnName = "")
        {
            if(btnName == "C") // 「C」ボタンからこれが呼び出されたとき → 全てを空に
            {
                UpdateInput(input);
                UpdateWord(input_word);
                UpdateWordx(input_wordx);
                UpdateRevPoland(rev_poland);
                // UpdateAnswer(answer.ToString());
                answer_display.Text = ""; // 「C」が2回連続で押されたときに前回の結果が表示される問題の応急処置
            }
            else // それ以外のボタンからこれが呼び出されたとき → inputをもとに順に処理を呼び出す
            {
                UpdateInput(input);

                input_word = ConvertToInputWord(input);
                UpdateWord(input_word);

                input_wordx = ConvertToInputWordx(input_word);
                UpdateWordx(input_wordx);

                if (isShowCalcProcess == false && JudgeFormulaCanSolve()) // 即時計算モード かつ 数式が解けるとき → 解まで表示
                {
                    rev_poland = ConvertToRevPoland(input_wordx);
                    UpdateRevPoland(rev_poland);

                    answer = Calculate(rev_poland);
                    UpdateAnswer(answer.ToString());
                }

                if (btnName == "delete" && JudgeFormulaCanSolve() == false)  // 一文字削除ボタン かつ 数式が解けないとき → モードにかかわらずrev_poとanswerを表示しない
                {
                    // 一時的に隠すだけなので、関数を介さずに行う
                    poland_display.Text = "";
                    answer_display.Text = "";
                }
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
                return false;
            }
            else if (bracket_depth != 0) // 括弧の深さが0でないとき計算不可能
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 括弧が閉じていません");
                return false;
            }
            else if (symbol_typeD.Any(c => c == input[input.Length - 1].ToString())) // 入力文字列が計算不可能な終わり方のとき（typeDを流用）
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 解けない数式です");
                return false;
            }
            else
            {
                Console.WriteLine("JudgeFormulaCanSolve >>> 計算可能です（小数点のバリデーションは未実装）");
                return true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 「計算」ボタンが押されたとき、入力文字列の変換・計算の各関数を順に呼び出す
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void action_Click(object sender, EventArgs e)
        {
            // 計算可能かを判断 
            if (JudgeFormulaCanSolve())
            {
                input_word = ConvertToInputWord(input); // input → input_list → input_word
                input_wordx = ConvertToInputWordx(input_word); // input_word → input_wordx
                rev_poland = ConvertToRevPoland(input_wordx); // input_wordx → rev_poland
                answer = Calculate(rev_poland);

                // 過程表示モードに関わらず結果を表示する 結果表示は後置記法と解のみ
                UpdateInput(input);
                UpdateWord(input_word);
                UpdateWordx(input_wordx);
                UpdateRevPoland(rev_poland);
                UpdateAnswer(answer.ToString());
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
            input += ((Button)sender).Text;
            // 小数点の状態「period_phase」が 1 だったとき、小数点以下入力待ちフェーズなので
            if(period_phase == 1)
            {
                period_phase = 2; // 2：小数点と数値以外の入力待ち状態へ 
            }
            // 都度更新------------------------------
            CallConvertCalcUpdate();
            // ------------------------------
        }

        /// <summary>
        /// 分類Aの記号「 + - * / 」ボタンが押されたときの処理。この中で「 - 」記号のみ特殊な処理を行う
        /// </summary>
        /// <param name="sender">ボタンオブジェクト</param>
        /// <param name="e">イベントの情報のインスタンス</param>
        private void btSymbol_typeA_Click(object sender, EventArgs e) // 分類 A 
        {
            if(input.Length != 0) // 入力文字が空出ない必要があり、
            {
                string lastChar = input[input.Length - 1].ToString(); // 最後の入力文字を取得
                if ((!symbol_typeA.Any(c => c == lastChar))){ // 最後の入力文字が、禁止文字ではないとき　入力実行
                    switch (((Button)sender).Text)
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
                    switch (((Button)sender).Text)
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
                switch (((Button)sender).Text)
                {
                    case "-":
                        input += "-";
                        if (period_phase == 2) period_phase = 0; // 小数点状態リセット
                        break;
                }

            }
            // 都度更新------------------------------
            CallConvertCalcUpdate();
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
                if(period_phase == 0) // 小数点が入力可能かを判別する①
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
            CallConvertCalcUpdate();
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
            CallConvertCalcUpdate();
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
            CallConvertCalcUpdate();
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
                CallConvertCalcUpdate("delete");
                // ------------------------------
            }
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
        /// <returns name="converted">後置記法（配列）</returns>
        private string[] ConvertToRevPoland(string[] wordx)
        {
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
            Console.WriteLine("wordxの長さ" + wordx.Length);

            
            Stack<string> stk = new Stack<string>(); // 計算用スタック
            string[] converted = new string[] { };      // 変換済み配列（戻り値）
            Dictionary<string, int> priority = new Dictionary<string, int> // 演算子の優先順位付け 大きいほど優先順位高
            {
                {"(", 0 }, // ←0！！！
                {"x", 2 },
                {"/", 2 },
                {"+", 1 },
                {"-", 1 }
            };

            int i = 1;
            foreach(string x in wordx)
            {
                // デバッグ用文字列
                string db_poland = "";
                string db_stack = "";
                Console.WriteLine(i + " 回目----------------------------");


                // 種類を判定 0~9, +-), x/(, 
                float xf;
                if (float.TryParse(x, out xf)) // float型に変換できた時 数値
                {
                    Console.WriteLine(x + " ←数値");
                    // x→converted
                    string[] temp = new string[converted.Length + 1];
                    Array.Copy(converted, temp, converted.Length);
                    temp[temp.Length - 1] = x;
                    converted = temp;
                }
                else if(x == "(")
                {
                    Console.WriteLine(x + " ←開き括弧");
                    stk.Push(x);
                }
                else if(x == ")")
                {
                    Console.WriteLine(x + " ←閉じ括弧");
                    // スタックから左括弧が出るまでstack→converted
                    while (stk.Count() > 0 && stk.Peek() != "(") // ←　境界が少し怪しい
                    {

                        string[] temp = new string[converted.Length + 1];
                        Array.Copy(converted, temp, converted.Length);
                        temp[temp.Length - 1] = stk.Pop();
                        converted = temp;

                    }
                    // ↑までで、スタックの最後に括弧開き　が入った状態になるので、最後にそいつを取り出す
                    if (stk.Count() > 0 && stk.Peek() == "(") stk.Pop();
                }
                else // 演算子
                {
                    Console.WriteLine(x + " ←演算子");
                    while ((stk.Count() > 0) && (priority[x] <= priority[stk.Peek()]))
                    {
                        // 優先順位確認
                        Console.WriteLine("今回の演算子の優先順位　: " + priority[x]);
                        Console.WriteLine("スタックの先頭の優先順位: " + priority[stk.Peek()]);
                        string[] temp = new string[converted.Length + 1];
                        Array.Copy(converted, temp, converted.Length);
                        temp[temp.Length - 1] = stk.Pop();
                        converted = temp;
                    }
                    stk.Push(x);
                }


                // ↑デバッグ用

                i++;
                // 1ループが終わった時の途中経過を表示
                if (isShowCalcProcess == true)
                {
                    // 画面に表示する関数を呼び出す
                    UpdateXToRev(stk, converted, x); // 引数(スタック, 変換後, 現在見ている文字)

                }
            }



            // 最後にstackの中身をすべてrev_polandへ
            while (stk.Count > 0)
            {
                string[] n = new string[converted.Length + 1];
                Array.Copy(converted, n, converted.Length);
                n[n.Length - 1] = stk.Pop(); // popして直接入れる
                converted = n;

                if (isShowCalcProcess == true)
                {
                    UpdateXToRev(stk, converted);
                }
            }

            return converted;
        }

        private Task StopTime()
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(1000 / freq);
            });
            return task;
        }

        private async Task StopTimeAsync()
        {
            await Task.Delay(1000 / freq);
        }

        // 計算する部分
        /// <summary>
        /// 後置記法（配列）「rev_poland」を受け取り解を求める「answer」
        /// </summary>
        /// <param name="poland">後置記法（配列）「rev_poland」</param>
        /// <returns>解（最終的なstackの中身）</returns>
        private float Calculate(string[] poland)
        {
            Stack<float> stack = new Stack<float>(); // 計算用スタック 演算終了時Popで取り出した値が解←戻り値
            // int i = 0;
            foreach (string x in poland) { // 配列の要素分だけ動かす
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

            return stack.Pop();
        }


        // ------------------------------------------------------------------------------------------
        // ↑ 変換・計算の処理
        // ↓ 計算式の画面表示 計算過程の表示のため
        // ------------------------------------------------------------------------------------------


        /// <summary>
        /// 入力文字の表示を更新する関数
        /// </summary>
        /// <param name="input"></param>
        private void UpdateInput(string input)
        {
            label01.Text = input;
        }

        /// <summary>
        /// 処理中のinput_wordを受け取り、中身を文字列に結合して表示を更新
        /// </summary>
        /// <param name="list_w"></param>
        private void UpdateWord(string[] list_w)
        {
            string text = "";
            foreach (string lw in list_w) { text += lw + " "; }
            word_display.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_wx"></param>
        private void UpdateWordx(string[] list_wx)
        {
            string text = "";
            foreach (string lwx in list_wx) { text += lwx + " "; }
            wordx_display.Text = text;
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
            poland_display.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"></param>
        private void UpdateAnswer(string answer)
        {
            answer_display.Text = answer;
        }

        /// <summary>
        /// input_wordxからrev_polandへの変換過程を表示する関数
        /// これはConvertToRevPoland()の中のfor文内で何回も呼び出される
        /// </summary>
        /// <param name="current"></param>
        /// <param name="stack"></param>
        /// <param name="rev_po"></param>
        private void UpdateXToRev(Stack<string> stack, string[] rev_po, string current = "")
        {
            // デバッグ用変数用意
            string stack_txt = "";
            string rev_po_txt = "";
            Stack<string> stack_copy = new Stack<string>(); // スタックをコピーする一時的なスタック

            foreach (string rp in rev_po) // 後置記法を配列→文字列に
            {
                rev_po_txt += rp + " ";
            }

            while (stack.Count > 0) // 一時的なスタックを介してスタックの中身を文字列に写す
            {
                string s = stack.Pop();
                stack_copy.Push(s);
                stack_txt += s + " ";
            }
            while (stack_copy.Count > 0) // スタックを復元
            {
                stack.Push(stack_copy.Pop());
            }
            
            Console.WriteLine("current:  " + current);
            Console.WriteLine("stack:    " + stack_txt);
            Console.WriteLine("poland:   " + rev_po_txt + "\n\n");
            current_torev_display.Text = current;
            stack_torev_display.Text = stack_txt;
            poland_display.Text = rev_po_txt;



            var task = StopTime(); // 指定時間待つスレッドを起動
            task.Wait(); // 待機
            //await StopTimeAsync();
        }

        /// <summary>
        /// rev_polandからanswerへの演算過程を表示する関数
        /// これはCalculate()の中のfor文内で何回も呼び出される
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="rev_po"></param>
        /// <param name="ans"></param>
        private async void UpdateRevToAns(Stack<string> stack, string[] rev_po, float ans)
        {
            // var task = StopTime(); // 指定時間待つスレッドを起動
            // task.Wait(); // 待機
            await StopTimeAsync();
        }
    }
}