//Julian Blair 14/09/10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1
{
    /// <summary>
    /// Adds and removes values to/from nodes
    /// </summary>
    class Stack
    {
        private ListNode head = null; //list head
        private int count = 0; //number of new nodes
        private object temp; //previous head value is stored here after pointers moved to next

        /// <summary>
        /// Gets the number of nodes.
        /// </summary>
        /// <value>
        /// The return count.
        /// </value>
        public int ReturnCount {get { return count; } }
        
        /// <summary>
        /// Gets the value of the previous head.
        /// </summary>
        /// <value>
        /// The return temporary.
        /// </value>
        public object ReturnTemp { get { return temp; } }
        
        /// <summary>
        /// Gets the value of the current head.
        /// </summary>
        /// <value>
        /// The returnhead.
        /// </value>
        public object Returnhead { get { return head; } }


        /// <summary>
        /// Pushes the specified data value to new node.
        /// Also prints the value of the top most element.
        /// </summary>
        /// <param name="dataValue">The data value.</param>
        public void push(object dataValue)
        {
            if (head == null)
            {
                head = new ListNode(dataValue, null);
            }
            
            else
            {
                head = new ListNode(dataValue, head);
            }

            Console.WriteLine("Topmost element in stack: " + head.my_Data.ToString() );
            count = count + 1;
            Console.WriteLine("Element count: " + count);
        }


        /// <summary>
        /// Pops this instance.
        /// </summary>
        /// <returns></returns>
        public object pop()
        {
            if (head == null)
            {
                return null;
            }

            else
            {
                temp = head.my_Data; //This saves the data of the topmost node before the pointer is changed 
                
                head = head.next_Node; //This changes the head pointer to point to the next element in list

                count = count - 1; //This has to be placed before the return call otherwise the number will be wrong
                                
                return temp; //This returns the data from before the head pointer was changed.
            }
        }


        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        public object peek()
        {
            if (head == null)
            {
                return null;
            }

            else
            {
                return head.my_Data; //ändrade från att returnera bara head
            }
        }


    }
}
