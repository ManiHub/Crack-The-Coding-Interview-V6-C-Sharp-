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
    /// 8. Given a N* M matrix, replace a row/column with zeros if respective row/column position contain zero
    /// 9. given two strings, check if one string is rotation of other
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

        #region Problem 3

        public char[] Problem3_v1(char[] str)
        {
            if (str == null || str.Length == 0 || (str.Length == 1 && str[0] != ' '))
                return str;
            int scount = 0;

            foreach (char c in str)
            {
                if (c == ' ')
                    scount++;
            }

            if (scount == 0)
                return str;

            int i = str.Length - 1;
            char[] str1 = new char[str.Length + (2 * scount)];
            int j = str1.Length - 1;
            while(i>=0)
            {
                if (str[i] == ' ')
                {
                    str1[j] = '0';
                    str1[j - 1] = '2';
                    str1[j - 2] = '%';
                    j -= 3;
                }
                else
                    str1[j--] = str[i];
                --i;
            }
            return str1;
        }

        #endregion

        #region Problem 4

        /// <summary>
        /// This method will check if given string is a permution of a palindrome - With Buffer - Dictionary - reduced loops
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem4_v1(string str)
        {
            if (str == null)
                return false;

            if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return true;

            Dictionary<char, int> list = new Dictionary<char, int>();
            bool flag = false;
            foreach(char c in str)
            {
                if (list.ContainsKey(c))
                    list[c] += 1;
                else
                    list[c] = 1;
            }

           foreach(var x in list)
            {
                if(x.Value%2!=0)
                {
                    if (flag)
                        return false;
                    else
                        flag = true;
                }
            }
            return true;
        }

        /// <summary>
        /// This method will check if given string is a permution of a palindrome - With Buffer - Dictionary 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem4_v2(string str)
        {
            if (str == null)
                return false;

            if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return true;

            Dictionary<char, int> list = new Dictionary<char, int>();
            int counter = 0;
            foreach (char c in str)
            {
                if (list.ContainsKey(c))
                {
                    list[c] += 1;

                    if (list[c] % 2 == 0)
                        counter--;
                }
                else
                {
                    list[c] = 1;
                    counter++;
                }
            }

            
            return counter <= 1;
        }

        /// <summary>
        /// This method will check if given string is a permution of a palindrome - With out Buffer - Optimal 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Problem4_v3(string str)
        {
            if (str == null)
                return false;

            if (str.Length == 1 || (str.Length == 2 && str[0] == str[1]))
                return true;

            int checker = 0;
            foreach (char c in str)
            {
                int value = c - 'a';
                int temp = 1<<value;

                // flip the bit at position temp
                if ((checker & temp) == 0)
                    checker |= temp;
                else
                    checker &= ~temp;

            }
            return (checker & (checker-1)) ==0;
        }




        #endregion

        #region Problem 5

        /// <summary>
        /// This method will find if two given strings are one edit away (replace, insert, remove) 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool Problem5_v1(string s1, string s2)
        {
            if (s1 == null || s2 == null)
                return false;
            if (s1.Length == 1 && s2.Length == 1)
                return true;
            if (s1.Length == s2.Length)
                return OneEditReplace(s1, s2);
            if (Math.Abs(s1.Length - s2.Length) == 1)
                return OnePlaceRemovInsert(s1, s2);

            return false;
        }

        private bool OnePlaceRemovInsert(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) != 1)
                return false;
            int i = 0, j = 0;

            while (i< s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (i!=j)
                        return false;
                    else
                        j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }
            return true;
        }

        private bool OneEditReplace(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            bool flag = false;
            for(int i = 0; i < s1.Length; i++)
            {
                if(s1[i]!=s2[i])
                {
                    if (flag)
                        return false;
                    else
                        flag = true;
                }
            }

            return true;
        }

        /// <summary>
        /// This method will find if two given strings are one edit away (replace, insert, remove) 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool Problem5_v2(string s1, string s2)
        {
            if (s1 == null || s2 == null)
                return false;
            if (s1.Length == 1 && s2.Length == 1)
                return true;
            if (s1.Length == s2.Length || Math.Abs(s1.Length - s2.Length) == 1)
                return OneEditAway(s1, s2);

            return false;
        }

        private bool OneEditAway(string str1, string str2)
        {
            if (Math.Abs(str1.Length - str2.Length) > 1)
                return false;
            string s1 = str1.Length > str2.Length ? str2 : str1;
            string s2 = str1.Length > str2.Length ? str1 : str2;
            int i = 0, j = 0;
            bool flag = false;
            while(i<s1.Length && j<s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (s1.Length == s2.Length)
                    {
                        if (flag)
                            return false;
                        flag = true;
                        i++;
                    }
                    else
                    {
                        if (i != j)
                            return false;
                    }
                }
                else
                {
                    i++;
                }
                j++;
            }
            return true;
        }
        #endregion

        #region Problem 6

        /// <summary>
        /// This method will return the compressed version of a give string eg: bbbbddddccc => b4d4c3
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Problem6_v1(string str)
        {
            if (str == null || str.Length == 1 || str.Length == 2 && str[0] != str[1])
                return str;
            string comp = "";
            int counter = 0;
            int i = 0;
            for(i = 0; i+1 < str.Length; i++)
            {
                counter++;
                if (str[i] != str[i + 1])
                {
                    comp += str[i]+"" + counter;
                    counter = 0;
                }
            }
            comp += str[i] + "" + counter;
            return comp.Length > str.Length ? str:comp;
        }

        #endregion

        #region Problem 7
        /// <summary>
        /// This method will rotate the given matrix by 90 degrees
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[,] Problem7_v1(int[,] mat)
        {
            int n = mat.GetLength(0);
            for(int layers = 0; layers < n/2; layers++)
            {
                int first = layers;
                int last = n - 1 - layers;
                
                for(int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int topelement = mat[first, i];
                    mat[first, i] = mat[last - offset,first];
                    mat[last - offset, first] = mat[last, last - offset];
                    mat[last, last - offset] = mat[i, last];
                    mat[i, last] = topelement;
                }
            }
            return mat;
        }
        #endregion

        #region Problem 8

        /// <summary>
        /// This method will make the respective row and column to zeros if an element at particular row and column is zero.
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[,] Problem8_v1(int[,] mat)
        {
            int n = mat.GetLength(0);
            bool[] row = new bool[n];
            bool[] col = new bool[n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mat[i, j] == 0)
                    {
                        row[i] = true;
                        col[j] = true;
                    }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (row[i] == true || col[j] == true)
                        mat[i,j] = 0;

            return mat;
        }

        #endregion

        #region Problem 9

        /// <summary>
        /// This method will check, Given a string str1, check if str2 is rotation of str1
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool Problem9_v1(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;
            str1 += str1;

            return str1.Contains(str2);
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
            //Console.WriteLine(Problem2_v1("apple", "apxls"));  -- Bug in the sort code

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

        public void Testcases_P3()
        {
            Console.WriteLine(Problem3_v1("a b c".ToCharArray()));
            Console.WriteLine(Problem3_v1("a bc".ToCharArray()));
            Console.WriteLine(Problem3_v1(" a b c".ToCharArray()));
            Console.WriteLine(Problem3_v1("a b c".ToCharArray()));
            Console.WriteLine(Problem3_v1(" ".ToCharArray()));
            Console.WriteLine(Problem3_v1("abc".ToCharArray()));
        }

        public void Testcases_P4()
        {
            string ip1 = "abcdcabd";
            string ip2 = "abc";
            string ip3 = "cccccccccccccccccccc";
            string ip4 = "tacktack";
            string ip5 = "maniiman";
            Console.WriteLine("Input : "+ip1+"; V1 : "+Problem4_v1(ip1)+"; V2 :"+Problem4_v2(ip1)+"; V3 : "+Problem4_v3(ip1));
            Console.WriteLine("Input : "+ip2+"; V1 : "+Problem4_v1(ip2)+"; V2 :"+Problem4_v2(ip2)+"; V3 : "+Problem4_v3(ip2));
            Console.WriteLine("Input : "+ip3+"; V1 : "+Problem4_v1(ip3)+"; V2 :"+Problem4_v2(ip3)+"; V3 : "+Problem4_v3(ip3));
            Console.WriteLine("Input : "+ip4+"; V1 : "+Problem4_v1(ip4)+"; V2 :"+Problem4_v2(ip4)+"; V3 : "+Problem4_v3(ip4));
            Console.WriteLine("Input : "+ip5+"; V1 : "+Problem4_v1(ip5)+"; V2 :"+Problem4_v2(ip5)+"; V3 : "+Problem4_v3(ip5));
        }

        public void Testcases_P5()
        {
            string s11 = "abcd", s21 = "abcd";
            string s12 = "abcd", s22= "abcx";
            string s13 = "xxxxxxx", s23 = "xxxxxx";
            string s14 = "pale", s24 = "sale";
            string s15 = "palex", s25 = "sale";
            string s16 = "palex", s26 = "saley";
            Console.WriteLine(s11+", "+s21+" - "+Problem5_v1(s11,s21)+" - "+Problem5_v2(s11,s21));
            Console.WriteLine(s12+", "+s22+" - "+Problem5_v1(s12,s22)+" - "+Problem5_v2(s12,s22));
            Console.WriteLine(s13+", "+s23+" - "+Problem5_v1(s13,s23)+" - "+Problem5_v2(s13,s23));
            Console.WriteLine(s14+", "+s24+" - "+Problem5_v1(s14,s24)+" - "+Problem5_v2(s14,s24));
            Console.WriteLine(s15+", "+s25+" - "+Problem5_v1(s15,s25)+" - "+Problem5_v2(s15,s25));
            Console.WriteLine(s16+", "+s26+" - "+Problem5_v1(s16,s26)+" - "+Problem5_v2(s16,s26));
        }

        public void Testcases_P6()
        {
            string ip1 = "abcd";
            string ip2 = "aabbccdd";
            string ip3 = "aaaaaaa";
            string ip4 = "abbbcdddd";
            string ip5 = null;
            Console.WriteLine(ip1 + " - " + Problem6_v1(ip1));
            Console.WriteLine(ip2 + " - " + Problem6_v1(ip2));
            Console.WriteLine(ip3 + " - " + Problem6_v1(ip3));
            Console.WriteLine(ip4 + " - " + Problem6_v1(ip4));
            Console.WriteLine(ip5 + " - " + Problem6_v1(ip5));
        }

        public void Testcases_P7()
        {
            int[,] mat1 = new int[,] { {1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16}};
            Console.WriteLine(Problem7_v1(mat1));
        }

        public void Testcases_P8()
        {
            int[,] mat1 = new int[,] { { 1, 2, 3, 0 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            Console.WriteLine(Problem8_v1(mat1));
           var  x = 10;
        }

        public void Testcases_P9()
        {
            Console.WriteLine("apple, leapp- "+Problem9_v1("apple","leapp"));
            Console.WriteLine("appl, eapp- "+Problem9_v1("appl", "eapp"));
            Console.WriteLine("aaa, aaa- " + Problem9_v1("aaa", "aaa"));
        }
        #endregion
    }
}

