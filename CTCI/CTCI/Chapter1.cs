using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI
{
    /// <summary>
    /// Problems on Strings and Arrays
    /// 
    /// 1. Given a string,check if it contains all unique Characters.
    /// 2. Given two strings, check if one is permutation of other.
    /// 3. Given a string, replace all the spaces with '%20'
    /// 4. Given a string, check if it is a permutation of palindrome
    /// 5. Given two strings, check one strig is formed by replacing a character,deletion of a character, addation of a character in other string
    /// 6. Given a string, perform string compression Eg: aaabbbccc->a3b3c3
    /// 7. Given a N* N matrix, rotate it by 90 degrees
    /// 8. Given a N* M matrix, replace a roiw/coulmn with zeros if any position contain zero
    /// 9. given two strings, check if one string is rotation of othe
    /// </summary>
    class Chapter1
    {
        /// <summary>
        /// This Method will check if given string contain all unique characters - Using buffer - List
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem1_v1(string str)
        {
            if (str.Length == 0)
                return false;
            if (str.Length == 1 || (str.Length==2 && str[0] == str[1]))
                return true;

            List<char> list = new List<char>();

            foreach(char c in str)
            {
                if (list.Contains(c))
                    return false;
                else
                    list.Add(c);
            }

            return true;
        }


        /// <summary>
        /// This Method will check if given string contain all unique characters - Using buffer - Array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem1_v2(string str)
        {
            if (str.Length == 0)
                return false;
            if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return true;

            bool[] arr = new bool[256];

            foreach (char c in str)
            {
                if (arr[c])
                    return false;
                else
                    arr[c] = true;
            }

            return true;
        }


        /// <summary>
        /// This Method will check if given string contain all unique characters - No buffer, Optimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem1_v3(string str)
        {
            if (str.Length == 0)
                return false;
            if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return true;

            int checker = 0;

            for(int i=0;i<str.Length;i++)
            {
                int val = str[i] - 'a';
                if ((checker & (1 << val)) > 0)
                    return false;
                else
                    checker |= (1 << val);
                 
            }

            return true;
        }


        /// <summary>
        /// This method will check various problems with different text cases
        /// </summary>
        public void Testcases()
        {
            // Problem-1
            Console.WriteLine("V1:");
            Console.WriteLine(Problem1_v1("abc"));
            Console.WriteLine(Problem1_v1("abca"));
            Console.WriteLine(Problem1_v1("aaaaaa"));
            Console.WriteLine(Problem1_v1("q"));
            Console.WriteLine(Problem1_v1(""));

            Console.WriteLine("V2:");
            Console.WriteLine(Problem1_v2("abc"));
            Console.WriteLine(Problem1_v2("abca"));
            Console.WriteLine(Problem1_v2("aaaaaa"));
            Console.WriteLine(Problem1_v2("q"));
            Console.WriteLine(Problem1_v2(""));

            Console.WriteLine("V3:");
            Console.WriteLine(Problem1_v3("abc"));
            Console.WriteLine(Problem1_v3("abca"));
            Console.WriteLine(Problem1_v3("aaaaaa"));
            Console.WriteLine(Problem1_v3("q"));
            Console.WriteLine(Problem1_v3(""));
        }
    }
}

