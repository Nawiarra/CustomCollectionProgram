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

        private int size;
        private static int arraySize = 2;

        private T[] ListArray = new T[arraySize];

        public int Size
        {
            get
            {
                return size;
            }
            private set { size = value; }
        }

        public void AddItem(T item)
        {

            if (head == null)
            {
                head = new Node<T>();

                head.Value = item;
            }
            else
            {
                Node<T> copyOfHeadNode = head;

                while (copyOfHeadNode.NextValue != null)
                {
                    copyOfHeadNode = copyOfHeadNode.NextValue;
                }

                copyOfHeadNode.NextValue = new Node<T>();

                copyOfHeadNode.NextValue.Value = item;

            }

            Size++;
        }

        private void ResizeArray()
        {
            Array.Resize<T>(ref ListArray, arraySize * 2);
            arraySize *= 2;

        }

        public T[] ToArray()
        {

            int index = 0;
            Node<T> copyOfHeadNode = head;

            if (size > arraySize)
            {
                ResizeArray();
            }


            while (copyOfHeadNode != null)
            {
                ListArray[index] = copyOfHeadNode.Value;
                copyOfHeadNode = copyOfHeadNode.NextValue;
                index++;
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
