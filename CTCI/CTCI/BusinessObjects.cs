using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI
{
    public class Node
    {
        public int data;
        public Node next = null;

        public Node(int data)
        {
            this.data = data;
        }
    }


    public class ListNode
    {
        public int  val { get; set; }

        public ListNode next { get; set; }

        public ListNode(int val)
        {
            this.val = val;
        }
    }

}
