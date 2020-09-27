using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionCore
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> NextValue { get; set; }
        public Node()
        {

        }
        public Node(T value)
        {
            Value = value;
        }
 
    }
}
