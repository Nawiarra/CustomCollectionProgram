using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionCore
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        Node<T> head;

        private T[] ListArray = new T[arraySize];


        private int size;
        private int arraySize = 50;
        public int Size
        {
            get
            {
                return size;
            }
        }

        public void AddItem(T item)
        {
            if (head == null)
            {
                head.Value = item;
                head.NextValue = null;
            }
            else
            {
                while (head.NextValue.Value != null)
                {
                    head = head.NextValue;
                }
                head.NextValue.Value = item;
            }
        }

        private void ResizeArray()
        {
            Array.Resize<T>(ref ListArray, arraySize * 2);
            arraySize *= 2;

        }

        public T[] ToArray()
        {
            if (size > arraySize)
            {
                ResizeArray();
            }

            int index = 0;
            while (head.NextValue.Value != null)
            {
                ListArray[index] = head.Value;
                head = head.NextValue;
            }
            return ListArray;
        }

        public Node<T> this[int index]
        {
            get
            {
                int curIndex = 0;
                while (curIndex != index)
                {
                    head = head.NextValue;
                    curIndex++;
                }
                return head;
            }
            set { }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.NextValue;
            }
        }
    }
}
