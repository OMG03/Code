namespace LinkedListDemo
{
    using System;

    public class StartUp
    {   
        public static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddLast(0);
            list.AddFirst(4);

            list.InsertAt(0, 100);

            var currentNode = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                Console.WriteLine("OK!");
            }
        }
    }
}
