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
    /// 3. Delete the i th Node in the Linkedlist given only access to it.
    /// 4. Write a program to partiation a linked list around a value x.
    /// 5. Given two Linkedlists, sum the values inside it.
    /// 6. Check if given linked list can form palindrome.
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

        #region  Problem 3

        /// <summary>
        /// This method wil delete the given node given only access to it.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public void Problem3_v1( Node head)
        {
            if(head != null)
            {
                head.data = head.next.data;
                head.next = head.next.next;
            }
        }

        #endregion

        #region Problem 5

        /// <summary>
        /// This Method will return the sum of two linked lists - assuming numbers are stores in reverse order, 123 is stored as  3->2->1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Node Problem5_v1(Node a, Node b)
        {
            Node res = null;

            if (a == null && b == null)
                return res;
            if (a == null)
                return b;
            if (b == null)
                return a;

            int carry = 0;
            Node runner = null;
            while(a!=null || b != null)
            {
                int x = a != null ? a.data : 0;
                int y = b != null ? b.data : 0;

                int sum = x + y + carry;
                carry = sum / 10;

                Node temp = new Node(sum % 10);
                if(res==null)
                {
                    res = temp;
                    runner = res;
                }
                else
                {
                    runner.next = temp;
                    runner = runner.next;
                }

                if (a != null)
                    a = a.next;
                if (b != null)
                    b = b.next;
            }
            
            if(carry == 1)
            {
                runner.next = new Node(1);
            }
                  
            return res;
        }

        #endregion

        #region Problem 6


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

        public void Testcases_P3()
        {
            int[] arr = new int[] { 1, 2, 22, 3, 4, 5, 4, 5, 6, 7, 2, 4 };
            Node head = Utilities.CreateLinkedList(arr);
            Problem3_v1(head.next);
        }

        public void Testcases_P5()
        {
            int[] x1 = new int[] {5,9,9 };
            int[] y1 = new int[] {5,9};

            Node x = Utilities.CreateLinkedList(x1);
            Node y = Utilities.CreateLinkedList(y1);

            Node result = Problem5_v1(x, y);
        }
        #endregion

    }

    
}
