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

        /// <summary>
        /// This method willl check if given string is a palindrome or not - using buffer. - with buffer
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool Problem6_v1(Node head)
        {
            if (head == null)
                return false;

            if (head.next == null)
                return true;

            int[] buffer = new int[10];
            int counter = 0;
            while (head != null)
            {
                buffer[head.data]++;
                if (buffer[head.data] % 2 == 0)
                    counter--;
                else
                    counter++;

                head = head.next;
            }
            return counter <= 1 ;
        }


        /// <summary>
        /// This method willl check if given string is a palindrome or not - using buffer. - with out buffer, just with int
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool Problem6_v2(Node head)
        {
            if (head == null)
                return false;

            if (head.next == null)
                return true;

            int checker = 0;
            while (head != null)
            {
                int temp = 1 << head.data;

                if ((checker & temp) == 0)
                {
                    checker |= temp;
                }
                else
                {
                    checker &= ~temp;
                }
                head = head.next;
            }
            return (checker & (checker - 1))==0;
        }

        #endregion

        #region Problem 8

        /// <summary>
        /// This method will check if given Linked list contains loops are not
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Problem8_v1(Node head)
        {
            if (head == null)
                return null;
            Node p1 = head;
            Node p2 = head;

            while(p1!=null && p2 != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;

                if (p1 == p2)
                    break;
            }

            if (p1 == null || p2 == null)
                return null;

            p1 = head;
            while (p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p1;
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

        public void Testcases_P6()
        {
            int[] arr = new int[] {1,2,3,3,2,1 };
            int[] arr1 = new int[] {1,2,3,4,3,2,1 };
            int[] arr2 = new int[] { 1, 2, 3, 4 };
            int[] arr3 = new int[] { 1, 1};
            int[] arr4 = new int[] { 1, 1,1,3,4,5,2,2,5,1,4};
            int[] arr5 = new int[] { 1, 1,1,3,4,5,2,2,5,1};

            Node head = Utilities.CreateLinkedList(arr);
            Node head1 = Utilities.CreateLinkedList(arr1);
            Node head2 = Utilities.CreateLinkedList(arr2);
            Node head3 = Utilities.CreateLinkedList(arr3);
            Node head4 = Utilities.CreateLinkedList(arr4);
            Node head5 = Utilities.CreateLinkedList(arr5);

            Console.WriteLine(Problem6_v1(head) +" - "+Problem6_v2(head));
            Console.WriteLine(Problem6_v1(head1)+" - "+Problem6_v2(head1));
            Console.WriteLine(Problem6_v1(head2)+" - "+Problem6_v2(head2));
            Console.WriteLine(Problem6_v1(head3)+" - "+Problem6_v2(head3));
            Console.WriteLine(Problem6_v1(head4)+" - "+Problem6_v2(head4));
            Console.WriteLine(Problem6_v1(head5)+" - "+Problem6_v2(head5));
        }

        public void Testcases_P7()
        {
            int[] arr = new int[] { 1, 2, 3, 3, 2, 1 };
            Node head = Utilities.CreateLinkedList(arr);

            head.next.next.next.next.next.next = head.next.next;
            var res = Problem8_v1(head);
        }


        #endregion

    }

    
}
