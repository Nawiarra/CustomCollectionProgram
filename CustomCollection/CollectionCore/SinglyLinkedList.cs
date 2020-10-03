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

        public override string ToString()
        {
            string result = "";
            Node<T> copyOfHeadNode = head;

            while (copyOfHeadNode != null)
            {
                result += copyOfHeadNode.Value.ToString() + '\n';
                copyOfHeadNode = copyOfHeadNode.NextValue;
            }
            return result;

        }
        public void DeleteItem(T item)
        {
            Node<T> copyOfHeadNode = head;
            Node<T> previousValue = null;

            while (copyOfHeadNode != null)
            {
                if (head.NextValue == null)
                {
                    head = null;
                }
                if (copyOfHeadNode.Value.Equals(item))
                {
                    if (previousValue != null)
                    {
                        previousValue.NextValue = copyOfHeadNode.NextValue;
                    }

                    Size--;
                }

                previousValue = copyOfHeadNode;
                copyOfHeadNode = copyOfHeadNode.NextValue;
            }
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

        public T this[int index]
        {
            get
            {
                if (index > Size)
                    return default(T);

                int curIndex = 0;
                Node<T> copyOfHeadNode = head;

                while (curIndex != index)
                {
                    copyOfHeadNode = copyOfHeadNode.NextValue;
                    curIndex++;
                }
                return copyOfHeadNode.Value;
            }
            set
            {
                if (index > Size)
                    return;

                int curIndex = 0;
                Node<T> copyOfHeadNode = head;

                while (curIndex != index)
                {
                    copyOfHeadNode = copyOfHeadNode.NextValue;
                    curIndex++;
                }
                copyOfHeadNode.Value = value;
            }
        }

        public void Except(SinglyLinkedList<T> secondList) 
        {
            Node<T> copyOfHeadNode = head;

            bool isntInCustList = false;

            while (copyOfHeadNode != null)
            {
                foreach (T item in secondList)
                {
                    if(copyOfHeadNode.Value.Equals(item))
                    {
                        isntInCustList = true;
                        break;
                    }
                }

                if (isntInCustList)
                {
                    isntInCustList = false;
                    if (this.Contains(copyOfHeadNode.Value))
                    {
                        DeleteItem(copyOfHeadNode.Value);
                    }
                }

                copyOfHeadNode = copyOfHeadNode.NextValue;
            }

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
