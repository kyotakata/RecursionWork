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
            if (x%y == 0)
            {
                return y;
            }

            return CalcGCD(y, x%y);
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
    }
}
