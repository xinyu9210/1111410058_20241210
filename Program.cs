//1111410058_謝欣妤
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1210_1
{
    internal class Program
    {
        // 計算圓週率函式
        static double CountPi(int n)
        {
            if (n < 4 || n > 15)
            {
                return -1; // 回傳錯誤值
            }

            double pi = 0.0;
            for (int i = 0; i < n; i++)
            {
                pi += Math.Pow(-1, i) / (2 * i + 1);
            }
            return pi * 4; // Leibniz公式
        }

        // 計算圓週長函式
        static double GetCircumference(double r, int n)
        {
            double pi = CountPi(n);
            return pi == -1 ? -1 : pi * r; // 使用三元運算符簡化程式碼
        }

        // 計算圓面積函式
        static double GetCircleArea(double r, int n)
        {
            double pi = CountPi(n);
            return pi == -1 ? -1 : pi * r * r; // 使用三元運算符簡化程式碼
        }

        // 主程式
        static void Main(string[] args)
        {
            double radius;
            double rawPrecision;
            int precision;

            // 要求使用者輸入圓半徑
            while (true)
            {
                Console.Write("請輸入圓半徑 (正數): ");
                if (double.TryParse(Console.ReadLine(), out radius) && radius > 0)
                {
                    break;
                }
                Console.WriteLine("輸入的半徑無效，請重新輸入正數！");
            }

            // 要求使用者輸入精度，允許小數點，並轉換為整數
            while (true)
            {
                Console.Write("請輸入圓週率精度 (4~15，可包含小數): ");
                if (double.TryParse(Console.ReadLine(), out rawPrecision))
                {
                    precision = (int)Math.Round(rawPrecision); // 將小數點四捨五入為整數
                    if (precision >= 4 && precision <= 15)
                    {
                        break; // 輸入正確範圍內的精度，跳出迴圈
                    }
                }
                Console.WriteLine("輸入的精度無效，請重新輸入 4 到 15 之間的值！");
            }

            // 計算與顯示結果
            double pi = CountPi(precision);
            Console.WriteLine("\n設定精度為 {0}，計算出的圓週率為 {1:g}", precision, pi);

            double circumference = GetCircumference(radius, precision);
            Console.WriteLine("圓週長為: {0:g}", circumference);

            double area = GetCircleArea(radius, precision);
            Console.WriteLine("圓面積為: {0:g}", area);
        }
    }
}
