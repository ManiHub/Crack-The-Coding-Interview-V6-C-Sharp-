using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI
{
    /// <summary>
    /// This class contain some of leetcode problems
    /// 
    /// 1. Metge two sorted Linked lists
    /// </summary>
    class LeetCodeProblems
    {

        /// <summary>
        /// This Method will merge two sorted linked lists
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public ListNode Problem1_v1(ListNode a, ListNode b)
        {
            if (a == null && b == null)
                return null;

            if (a == null)
                return b;

            if (b == null)
                return a;

            ListNode n = null;

            if (a.val > b.val)
            {
                n = new ListNode(b.val);
                n.next = Problem1_v1(a, b.next);
            }
            else
            {
                n = new ListNode(a.val);
                n.next = Problem1_v1(a.next, b);
            }
                

            return n;
        }

        internal void Testcases_P1()
        {
            int[] a = new int[] {2 };
            int[] b = new int[] {1 };

            ListNode A = Utilities.CreateListNode(a);
            ListNode B = Utilities.CreateListNode(b);

            var ress = Problem1_v1(A, B);
        }
    }
}
