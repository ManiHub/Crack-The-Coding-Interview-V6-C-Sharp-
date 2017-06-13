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
        #region Problem 1
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

        #endregion


        #region Problem 2
        /// <summary>
        /// This Method will check if thwo given strings are permutations of each other -  sort and compare - O(n Logn)
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool Problem2_v1(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            str1 = Utilities.Sort(str1);
            str2 = Utilities.Sort(str2);

            return str1.Equals(str2);
        }

        /// <summary>
        /// This Method will check if thwo given strings are permutations of each other -  use buffer O(m+n)
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool Problem2_v2(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Dictionary<char, int> list = new Dictionary<char, int>();

            foreach(char c in str1)
            {
                if (list.ContainsKey(c))
                {
                    list[c] = list[c] + 1;
                }
                else
                    list[c] = 1;
            }

            foreach(char c in str2)
            {
                if (!list.ContainsKey(c) || ((list[c]-1)<0))
                    return false;
                list[c] = list[c] - 1;

                if (list[c] == 0)
                    list.Remove(c);
            }

                return list.Count==0;
        }

        /// <summary>
        /// This Method will check if thwo given strings are permutations of each other -  use buffer - Array O(m+n)
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool Problem2_v3(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            int[] list = new int[256];

            foreach (char c in str1)
            {
                list[c] += 1;
            }

            foreach (char c in str2)
            {
                list[c] -= 1;

                if (list[c] < 0)
                    return false;
            }

            return true;
        }


        #endregion


        #region Test cases
        /// <summary>
        /// This method will check various problems with different text cases
        /// </summary>
        public void Testcases_P1()
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

        public void Testcases_P2()
        {
            // Problem-2
            Console.WriteLine("V1");
            Console.WriteLine(Problem2_v1("213", "321"));
            Console.WriteLine(Problem2_v1("abc", "cba"));
            Console.WriteLine(Problem2_v1("abc1", "1cba"));
            Console.WriteLine(Problem2_v1("abc1x", "1cba"));
            //Console.WriteLine(Problem2_v1("apple", "apxls"));  -- looks has an issue

            Console.WriteLine("V2");
            Console.WriteLine(Problem2_v2("213", "321"));
            Console.WriteLine(Problem2_v2("abc", "cba"));
            Console.WriteLine(Problem2_v2("abc1", "1cba"));
            Console.WriteLine(Problem2_v2("abc1x", "1cba"));
            Console.WriteLine(Problem2_v2("apple", "apxls"));

            Console.WriteLine("V3");
            Console.WriteLine(Problem2_v3("213", "321"));
            Console.WriteLine(Problem2_v3("abc", "cba"));
            Console.WriteLine(Problem2_v3("abc1", "1cba"));
            Console.WriteLine(Problem2_v3("abc1x", "1cba"));
            Console.WriteLine(Problem2_v3("apple", "apxls"));
        }

        #endregion
    }
}

