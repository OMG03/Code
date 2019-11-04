namespace LinkedListDemo
{
    using System;

    public class LinkedList<T>
    {
        public LinkedList()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty 
            => this.Count == 0;
        
        public T this[int index] 
        {
            get
            {
                IsInRange(index);

                var currentNode = GetNodeAt(index);

                return currentNode.Value;
            }
            set 
            {
                IsInRange(index); 

                var currentNode = GetNodeAt(index);

                currentNode.Value = value;
            }
        }

        private Node<T> GetNodeAt(int index)
        {
            var currentNode = this.First;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        private void IsInRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddFirst(T value)
        {
            if (this.IsEmpty)
            {
                this.First = this.Last = new Node<T>(value, null, null);
            }
            else
            {
                var nextFirstNode = new Node<T>(value, prev: null, next: this.First);
                this.First.Prev = nextFirstNode;
                this.First = nextFirstNode;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            if (this.IsEmpty)
            {
                this.First = this.Last = new Node<T>(value, null, null);
            }
            else
            {
                var newLastNode = new Node<T>(value, prev: this.Last, next: null);
                this.Last.Next = newLastNode;
                this.Last = newLastNode;
            }

            this.Count++;
        }

        public void InsertAt(int position, T value)
        {
            this.IsInRange(position);

            var nodeAtPosition = this.GetNodeAt(position);

            var newNode = new Node<T>(value, prev: nodeAtPosition.Prev, next: nodeAtPosition);

            if (nodeAtPosition.Prev == null)
            {
                this.First = newNode;
            }
            else
            {
                nodeAtPosition.Prev.Next = newNode;
            }

            nodeAtPosition.Prev = newNode;

            this.Count++;
        }

        public int IndexOf(T value)
        {
            var currentNode = this.First;
            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(value))
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public bool Contains(T value)
            => this.IndexOf(value) != -1;

        public bool Remove(T value)
        {
            var currentNode = this.First;
            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(value))
                {
                    RemoveNode(currentNode);

                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        private void RemoveNode(Node<T> node)
        {
            var prevNode = node.Prev;
            var nextNode = node.Next;

            if (prevNode != null)
            {
                prevNode.Next = nextNode;
            }
            else
            {
                this.First = nextNode;
            }

            if (nextNode != null)
            {
                nextNode.Prev = prevNode;
            }
            else
            {
                this.Last = prevNode;
            }

            this.Count--;
        }

        public void RemoveAt(int index)
        {
            this.IsInRange(index);

            var nodeAtPosition = this.GetNodeAt(index);

            this.RemoveNode(nodeAtPosition);
        }

        public void Clear()
        {
            this.First = null;
            this.Last = null;
            this.Count = 0;
        }
    }
}
