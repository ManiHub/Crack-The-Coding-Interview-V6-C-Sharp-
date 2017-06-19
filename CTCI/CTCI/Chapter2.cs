using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CTCI
{
    /// <summary>
    /// Problems on Linked Lists
    /// 1. Remove duplicates in an unsorted Linkedlist
    /// 2. Return Kth to the last element in the linkedlist 
    /// 3. Return the i th Node in the Linkedlist given only access to it.
    /// 4. Write a program ro partiation a linked list around a value x.
    /// 5. Given two Linkedlists, sum the values inside it.
    /// 6. Check if given linked lsit can form palindrome.
    /// 7. Check if two given linkedlists intersects
    /// 8. Given a linked list, check if it has loops inside it.
    /// </summary>
    class Chapter2
    {

        #region Problem 1

        /// <summary>
        /// This Method will remove duplicates in a given linked list - using buffer.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        Node Problem1_v1(Node head)
        {
            if (head == null || head.next == null)
                return head;
            Node n = head;
            Node previous = head;
            HashSet<int> set = new HashSet<int>();
            while (n != null)
            {
                if (set.Contains(n.data))
                {
                    previous.next = n.next!=null?n.next:null;
                }
                else
                {
                    set.Add(n.data);
                    previous = n;
                }
                n = n.next;
                    
            }

            return head;
        }

        #endregion

        #region Problem 2

        public Node Problem2_v1(Node head, int k)
        {
            Node temp = null;
            Node p1 = head;
            Node p2 = head;
            int i = 0;
            while(p1 != null)
            {
                if (i == k)
                    break;

                p1 = p1.next;
                i++;
            }
            if (i != k)
                return null;
            while(p1!=null && p2 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            return p2;
        }

        #endregion

        #region Testcases

        public void Testcases_P1()
        {
            int[] arr = new int[] {1,2,2,3,4,5,4,5,6,7,2,4 };
            Node head = Utilities.CreateLinkedList(arr);
            var res = Problem1_v1(head);
        }

        public void Testcases_P2()
        {
            int[] arr = new int[] { 1, 2, 2, 3, 4, 5, 4, 5, 6, 7, 2, 4 };
            Node head = Utilities.CreateLinkedList(arr);
            var res = Problem2_v1(head,3);
        }

        #endregion

    }

    
}
