using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace RecursionWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(recursiveIsPrime(3));
        }
        private static bool recursiveIsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            return recursiveIsPrimeHelper(n, 2) == 1;
        }

        private static int recursiveIsPrimeHelper(int n, int i)
        {
            if (i > n)
            {
                return 0;
            }

            if (n % i == 0)
            {
                return 1 + recursiveIsPrimeHelper(n, i + 1);
            }

            return recursiveIsPrimeHelper(n, i + 1); ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = 1029;
            var y = 1071;
            var gcd = countSquare(x, y);
            Console.WriteLine($"最大公約数{gcd}");
            var u = (x / gcd) * (y / gcd);
            Console.WriteLine($"長方形に入る正方形の数{u}");
        }

        public static int countSquare(int x, int y)
        {
            return CalcGCD(x, y);
        }

        /// <summary>
        /// 最大公約数を求める(再帰)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CalcGCD(int x, int y)
        {
            if (x % y == 0)
            {
                return y;
            }

            return CalcGCD(y, x % y);
        }

        /// <summary>
        /// 最大公約数を求める(非再帰)
        /// スタックオーバーフローを防止
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CalcGCD2(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(splitAndAdd(546125));
        }

        public static decimal splitAndAdd(decimal number)
        {
            if (number < 0) throw new ArgumentException("正の数を入力してください。");

            return splitAndAddHelper(number);

        }

        public static decimal splitAndAddHelper(decimal digits)
        {
            // 値が10以下になった時がベースケース
            if (digits < 10) return digits;

            return digits % 10 + splitAndAddHelper(Math.Floor(digits / 10));

        }

        //public static int splitAndAddHelper(int number, int digits, int count, int sum)
        //{
        //    if (count <= 0)
        //    {
        //        return sum;
        //    }
        //    else if(count == 1)
        //    {
        //        sum += number;
        //    }
        //    else
        //    {
        //        var quo = number / (int)Math.Pow(10, count - 1);
        //        sum += quo;
        //        number -= quo * (int)Math.Pow(10, count - 1);
        //    }
        //    count--;
        //    return splitAndAddHelper(number, digits, count, sum);
        //}

        /// <summary>
        /// 正の数の桁数を取得する(対数(log10))
        /// 負数や浮動小数点は未対応
        /// </summary>
        /// <param name="number">正の数</param>
        /// <returns>桁数</returns>
        public static int GetNumberOfDigits(int number)
        {
            // Math.Log10(0)はNegativeInfinityを返すため、別途処理する。
            return (number == 0) ? 1 : ((int)Math.Log10(number) + 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(multipleOfTwoTotal(3));
        }

        public static int multipleOfTwoTotal(int n)
        {
            return multipleOfTwoTotalHelper(3);
        }

        private static int multipleOfTwoTotalHelper(int n)
        {
            if (n < 1) return 0;

            var i = n;
            var sum = 0;

            while (i > 0)
            {
                sum += i * 2;
                i--;
            }

            return sum + multipleOfTwoTotalHelper(n - 1);
        }
    }
}
