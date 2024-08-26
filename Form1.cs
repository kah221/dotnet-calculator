﻿using System;
using System.Collections.Generic; // スタックを扱うために必要
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _240810_calc
{
    public partial class Form1 : Form
    {
        // 変数宣言
        string input = "";  // 入力された数式そのまま
        int bracket_depth = 0;  // 括弧が閉じられているか否か　閉じていればtrue
        int period_phase = 0;  // 小数点を入力できるかの判定（最後の文字はまだ見ない大前提の条件として）
                               // 　0→可能「3」
                               // 　1→小数点記号が入力され、小数点以下が一つ以上入力されるのを待っている状況「3.」
                               // 　2→小数点以下が1つ以上入力され、数値と小数点以下以外 が入力されるのを待つ状況「3.2」「3.24」
        string[] symbol_typeA = { "+", "-", "x", "/", ".", "(" };  // 分類Aの直前に存在してはいけない文字
        string[] symbol_typeMinus = { "+", "-", "x", "/", "." };  // マイナス記号
        string[] symbol_typeB = { "+", "-", "x", "/", ".", "(", ")" };  // ピリオド
        string[] symbol_typeC = { "." };  // 括弧開き記号
        string[] symbol_typeD = { "+", "-", "x", "/", ".", "(" };  // 括弧閉じ記号

        // input → input_list → input_word に変換する関数で、文字種類の判定に使う
        string[] group_num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] group_cal = { "+", "-", "x", "/" };
        string[] input_word = new string[] { };  // 入力計算式を、数値と記号に区切って、配列にしたもの
        string[] input_wordx = new string[] { }; // ↑で省略されていたx記号を補ったもの
        string[] rev_poland = new string[] { }; // ↑を並べ替え、逆ポーランド記法にしたもの
        float answer; // 計算結果Calcrate()の結果をこれに入れる

        string[] poland = new string[] { };     // inputを逆ポーランド記法に直したもの











        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(900, 700); // (横, 縦)
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更不可にする
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // 計算開始ボタンが押されたときの処理
        private void action_Click(object sender, EventArgs e)
        {
            //this.label01.Text = "ボタンがクリックされた";
            this.input_word   = ConvertToInputWord(input); // input → input_list → input_word
            this.input_wordx  = ConvertToInputWordx(input_word); // input_word → input_wordx
            this.rev_poland = ConvertToRevPoland(input_wordx); // input_wordx → rev_poland
            this.answer = Calculate(rev_poland);
            string rev_po_txt = "";
            foreach (string rp in rev_poland){rev_po_txt += rp;}
            this.poland_display.Text = rev_po_txt;
            // Console.WriteLine("answer: " + answer);
            this.answer_display.Text = answer.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // 数字が押されたとき
        private void btNumber_Click(object sender, EventArgs e)
        {
            input += ((Button)sender).Text;
            // 小数点の状態「period_phase」が 1 だったとき、小数点以下入力待ちフェーズなので
            if(period_phase == 1)
            {
                period_phase = 2; // 2：小数点と数値以外の入力待ち状態へ 
            }
            this.label01.Text = input;
        }

        // 記号が押されたとき
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

                    }
                }
                // マイナス記号の時だけ特別
                if ((!symbol_typeMinus.Any(c => c == lastChar)))
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
            this.label01.Text = input; // 最後に画面表示を更新
        }

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
            this.label01.Text = input; // 最後に画面表示を更新
        }
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
            this.label01.Text = input; // 最後に画面表示を更新
        }

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
            this.label01.Text = input; // 最後に画面表示を更新
        }

        // input → input_list → input_word　に変換する
        private string[] ConvertToInputWord(string input)
        {
            // 
            Console.WriteLine("入力された文字列 input: " + input);
            // 文字列を配列に変換
            char[] input_list = input.ToCharArray(); // 入力文字列を配列に分解する（1文字ずつ）input → input_list
            string mem_num = ""; // 数値が連続で続いたときにここに保存
            string pre_type = ""; // 一つ前の文字の種類（number, dot, calc, bracket)
            string[] word = new string[] { }; // 戻り値

            for (int i = 0; i < input_list.Length; i++)
            {
                Console.WriteLine("i= " + i + " の対象文字: " + input_list[i]);
                Console.WriteLine("処理前");
                Console.WriteLine("pre_type: " + pre_type);
                Console.WriteLine("mem_num : " + mem_num);

                // まず今回の文字の種類を判別（前回の種類pre_typeとの組み合わせで合計12通りの場合分けになる
                // 今回 calc
                if (group_cal.Any(c => c == input_list[i].ToString()))
                {
                    // 前回を確認（number→calc, bracket→calc の2択のうち、前者のみ追加で処理がある）
                    if (pre_type == "number") // number→calc mem_numに数値がある状態なのでそれを入れる
                    {
                        // 配列に要素を追加するテンプレ
                        // string[] word に mem_num を追加する
                        string[] newArray = new string[word.Length + 1]; // 新しい配列を複製
                        Array.Copy(word, newArray, word.Length);
                        newArray[newArray.Length - 1] = mem_num; // 最後尾に要素を追加
                        word = newArray; // newArrayが新しい配列となる
                        mem_num = ""; // 初期化
                    }

                    // （負の値対応）計算記号のうち、マイナス記号が来た時無条件でmem_numに追加
                    if (input_list[i].ToString() == "-")
                    {
                        mem_num += "-";
                        // もし、前回が数値ならプラス記号をinput_wordに追加
                        if (pre_type == "number")
                        {
                            // string[] word に "+" を追加
                            string[] newArray2 = new string[word.Length + 1]; // 新しい配列を複製
                            Array.Copy(word, newArray2, word.Length);
                            newArray2[newArray2.Length - 1] = "+"; // 最後尾に要素を追加
                            word = newArray2; // newArray2が新しい配列となる
                        }
                    }
                    else
                    {
                        // 今回分の文字を追加する
                        // 配列に要素を追加するテンプレ
                        // string[] word に input_list[i] を追加
                        string[] newArray2 = new string[word.Length + 1]; // 新しい配列を複製
                        Array.Copy(word, newArray2, word.Length);
                        newArray2[newArray2.Length - 1] = input_list[i].ToString(); // 最後尾に要素を追加
                        word = newArray2; // newArray2が新しい配列となる


                    }
                    pre_type = "calc"; // 前回の文字種を更新
                }

                // 今回 bracket
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

                    pre_type = "bracket"; // 前回の文字種を更新
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
            // 配列に要素を追加するテンプレ
            // string[] word に mem_num を追加する
            string[] newArray3 = new string[word.Length + 1]; // 新しい配列を複製
            Array.Copy(word, newArray3, word.Length);
            newArray3[newArray3.Length - 1] = mem_num; // 最後尾に要素を追加
            word = newArray3; // newArrayが新しい配列となる
            mem_num = ""; // 初期化

            // 確認用
            Console.WriteLine("input_word");
            foreach (string w in word)
            {
                Console.WriteLine("  " + w);
            }

            return word;
        }

        private string[] ConvertToInputWordx(string[] word)
        {
            string[] wordx = new string[] { }; // 戻り値
            string pre_type = "";
            string now_type = "";

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

                pre_type = now_type; // 更新
            }

            // 確認用
            Console.WriteLine("input_wordx");
            foreach (string wx in wordx)
            {
                Console.WriteLine(wx);
                //Console.Write(wx + " ");
            }

            return wordx;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            input = "";
            bracket_depth = 0;
            period_phase = 0; // 小数点状態リセット
            this.bracket_depth_display.Text = bracket_depth.ToString();
            this.label01.Text = input;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if(input.Length != 0)
            {
                string deleteTarget = input.Last().ToString();
                if (deleteTarget == ")")
                {
                    bracket_depth++;
                    this.bracket_depth_display.Text = bracket_depth.ToString();
                }
                else if(deleteTarget == "(")
                {
                    bracket_depth--;
                    this.bracket_depth_display.Text = bracket_depth.ToString();
                }
                input = input.Substring(0, input.Length - 1);
                this.label01.Text = input;
            }
        }




        // 逆ポーランド記法に変換する
        private string[] ConvertToRevPoland(string[] wordx)
        {
            Stack<string> stack1 = new Stack<string>();
            string[] rev_po = new string[] { }; // 戻り値
            // 演算子の優先順位定義
            string[] strong = { "x", "/", ")" };
            string[] weak = { "+", "-" };

            foreach(string x in wordx)
            {
                // 種類を判定 0~9, +-), x/(, 
                float xf;
                if (float.TryParse(x, out xf)) // float型に変換できた時 数値であるから → rev_poに追加
                {
                    string[] newArray = new string[rev_po.Length + 1];
                    Array.Copy(rev_po, newArray, rev_po.Length);
                    newArray[newArray.Length - 1] = x;
                    rev_po = newArray;
                }
                else // 演算子のとき
                {
                    // 直ぐにStackにpushするのではなくstackの中身を確認
                    //if(stack1.Pop())
                    if( stack1.Count > 0 && weak.Any(c => c == x) && strong.Any(c => c == stack1.Peek())) // 優先順位が 今回の演算子 < Stackの演算子
                    {
                        while(stack1.Count > 0) // stackの中身をすべて取り出す
                        {
                            string pop = stack1.Pop();
                            if (pop == "+" || pop == "-" || pop == "x" || pop == "/") // (, ) は無視
                            {
                                // rev_poにstack1からpopした内容を追加
                                string[] newArray = new string[rev_po.Length + 1];
                                Array.Copy(rev_po, newArray, rev_po.Length);
                                newArray[newArray.Length - 1] = pop;
                                rev_po = newArray;
                            } 
                        }
                        // stackが空になってから、今回の演算子を追加↓if文の外
                    }
                    // 演算子だが、優先順位が 今回 <= Stack のとき → 普通にstackへpush
                    stack1.Push(x);
                    Console.WriteLine("stack1に " + x + " を追加");
                }
            }

            // 最後にstackの中身をすべてrev_polandへ
            while (stack1.Count > 0) // stackの中身をすべて取り出す
            {
                string pop = stack1.Pop();
                if (pop == "+" || pop == "-" || pop == "x" || pop == "/") // (, ) は無視
                {
                    // rev_poにstack1からpopした内容を追加
                    string[] newArray = new string[rev_po.Length + 1];
                    Array.Copy(rev_po, newArray, rev_po.Length);
                    newArray[newArray.Length - 1] = pop;
                    rev_po = newArray;
                }
            }


            return rev_po;
        }


        // 計算する部分
        private float Calculate(string[] poland)
        {
            Stack<float> stack = new Stack<float>(); // 計算用スタック 
                // https://kiironomidori.hatenablog.com/entry/csharp_stack
                // stack.Push("aaa"); で値の格納
                // char x = stack.Pop(); で値の取り出し
                // stack.Clear(); で空にする
                // Console.WriteLine(stack.Peek()); で値を参照するだけ（取り除かない

            int i = 0;
            foreach (string x in poland) { // 配列の要素分だけ動かす
                // xの種類を判定
                // 数値, (, ), +-x/ の4通り
                float xf;
                if(float.TryParse(x, out xf)) // float型に変換できたとき → 数値なのでスタックに積み上げる
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

                i++;
            }


            return stack.Pop();
        }

    }
}