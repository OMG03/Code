namespace LinkedListDemo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Node<T>
    {
        public Node(T value, Node<T> prev, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
            this.Prev = prev;
        }

        public Node<T> Next { get; set; }

        public Node<T> Prev { get; set; }

        public T Value { get; set; }
    }
}
