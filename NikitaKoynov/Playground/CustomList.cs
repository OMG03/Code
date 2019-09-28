namespace Playground
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private const int ResizeMultipyer = 2;

        private T[] array;

        public CustomList()
        {
            this.array = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public int Capacity
            => this.array.Length;

        public T this[int i]
        {
            get
            {
                this.IsValidPosition(i);

                return this.array[i];
            }

            set
            {
                this.IsValidPosition(i);

                this.array[i] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            this.array[this.Count] = element;
            this.Count++;
        }

        public void AddRange(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.array = new T[InitialCapacity];
        }

        public bool Remove(T element)
        {
            int targetPosition = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    targetPosition = i;
                    break;
                }
            }

            if (targetPosition == -1)
            {
                return false;
            }

            this.RemoveAt(targetPosition);
            return true;
        }

        public void RemoveAt(int position)
        {
            this.IsValidPosition(position);

            for (int i = position; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.Count--;
        }

        private void Resize()
        {
            var newArray = new T[this.Capacity * ResizeMultipyer];

            for (int i = 0; i < this.Capacity; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void IsValidPosition(int position)
        {
            if (position < 0 || position >= this.Count)
            {
                throw new ArgumentException("Invalid position!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
