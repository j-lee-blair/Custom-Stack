//Julian Blair 14/09/10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1
{
    /// <summary>
    /// Stores values of each new node
    /// </summary>
    class ListNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListNode"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="node">The node.</param>
        public ListNode(object data, ListNode node)
        {
            this.my_Data = data;
            this.next_Node = node;
        }

        /// <summary>
        /// Gets the my_ data.
        /// </summary>
        /// <value>
        /// The my_ data.
        /// </value>
        public object my_Data { get; private set; } //property

        /// <summary>
        /// Gets the next_ node.
        /// </summary>
        /// <value>
        /// The next_ node.
        /// </value>
        public ListNode next_Node { get; private set; } // These allow the variables to be set endast av denna klass
    }
}
