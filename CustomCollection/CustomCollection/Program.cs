using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionCore;

namespace CustomCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> TestList = new SinglyLinkedList<int>();
            SinglyLinkedList<int> TestList2 = new SinglyLinkedList<int>();

            TestList.AddItem(5);
            TestList.AddItem(6);
            TestList.AddItem(7);
            TestList.AddItem(71);

            for (int i = 0; i < 10; i++)
            {
                TestList2.AddItem(i);
            }

            TestList2.Except(TestList);

            int A = TestList[1];

            TestList[2] = 10;

            TestList.DeleteItem(6);

            int [] array = TestList.ToArray();


            string result = TestList.ToString();
            Console.WriteLine(result);

            Console.ReadLine();

        }
    }
}
