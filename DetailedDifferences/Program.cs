using System;
using System.Collections.Generic;

namespace DetailedDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Detailed Differences 
            // https://open.kattis.com/problems/detaileddifferences 
            // simple string program

            var myCount = EnterCount();

            var myAnswers = GetAllResults(myCount);

            PrintList(myAnswers);
        }
        private static void PrintList(List<string> aaa)
        {
            foreach (var item in aaa)
            {
                Console.WriteLine(item);
            }
        }
        private static List<string> GetAllResults(int count)
        {
            var my2Lines = new string[2];
            var res = new List<string>();
            var answers = new List<string>();
            for (int i = 0; i < count; i++)
            {
                my2Lines = Enter2Lines();
                res = TwoStringsProcessing(my2Lines);
                answers.AddRange(res);
            }
            return answers;
        }
        private static List<string> TwoStringsProcessing(string[] lines)
        {
            string xtr = lines[0];
            string ytr = lines[1];

            // diff -> * // same -> .
            var answers = new List<string>();
            string result = "";
            for (int i = 0; i < xtr.Length; i++)
            {
                if (xtr[i] == ytr[i])
                    result = result + ".";
                else
                    result = result + "*";
            }
            answers.Add(xtr);
            answers.Add(ytr);
            answers.Add(result);
            answers.Add(" ");

            return answers;
        }
        private static string[] Enter2Lines()
        {
            var arr = new string[2];
            var xtr = "";
            var ytr = "";
            try
            {
                xtr = Console.ReadLine();
                ytr = Console.ReadLine();
                if (LinesCond(xtr, ytr) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter2Lines();
            }
            arr[0] = xtr;
            arr[1] = ytr;
            return arr;
        }
        private static bool LinesCond(string x, string y)
        {
            if (x.Length != y.Length)
                return false;
            else
            {
                if (x.Length < 1 || x.Length > 50 || y.Length < 1 || y.Length > 50)
                    return false;
                else
                    return true;
            }
        }
        private static int EnterCount()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 500)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterCount();
            }
            return a;
        }
    }
}
