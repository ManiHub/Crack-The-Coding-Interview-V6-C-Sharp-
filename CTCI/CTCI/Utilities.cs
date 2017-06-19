using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI
{
    public static class Utilities
    {
        /// <summary>
        /// Sort the given alphabetically - ascending
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Sort(string str)
        {
            if (str == null || str.Length <= 1)
                return str;

            str = quicksort(str.ToCharArray(),0,str.Length-1);
            return str;
        }
        
        public static string quicksort(char[] str, int start,int end)
        {
            if (start < end)
            {
                int p = findpivot(str,start,end);
                quicksort(str, start, p);
                quicksort(str, p + 1, end);
            }
            return new string(str);
            
        }

        private static int findpivot(char[] str, int start, int end)
        {
            int p = start;
            int q = end;
            int pi = (start+end)/2;
            while (p < q)
            {
                while (str[p] < str[pi])
                    ++p;
                while (str[q] > str[pi])
                    --q;

                if (p <= q)
                {
                    char t = str[p];
                    str[p] = str[q];
                    str[q] = t;
                }
                

            }

            return pi;
        }

        internal static Node CreateLinkedList(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            Node head = null;
            Node runner = null;

            foreach(int x in arr){
                if(head == null)
                {
                    head = new Node(x);
                    runner = head;
                }
                else
                {
                    Node t = new Node(x);
                    runner.next = t;
                    runner = runner.next;
                }
            }

            return head;
        }
    }
}
