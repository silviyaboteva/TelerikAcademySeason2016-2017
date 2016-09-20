using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5to7
{
    public class GenericList<T> where T: IComparable<T>
    {
        //Task 5
        private const int InitialCapacity = 5;
        private int count;
        private int capacity;

        private T[] elements;

        //constructors
        public GenericList()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.elements = new T[InitialCapacity];
        }

        public GenericList(int size)
        {
            this.Count = 0;
            this.Capacity = size;
            this.elements = new T[size];
        }

        //Propetries
        public int Count { 
            get
            {
                return this.count;
            }
            set
            { 
                if(value < 0)
                {
                    throw new ArgumentException("The count of the list can't be less than 0!");
                }

                this.count = value;
            }
        }
        public int Capacity {
            get
            {
                return this.capacity;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("The capacity of the list can't be less than 0!");
                }
            }
        }

        //Methods
        public T this[int index]
        {
            get
            {
                if(index <0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException("The index is outside of the boundries of the array!");
                }

                return this.elements[index];
            }

            set
            {
                 if(index <0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException("The index is outside of the boundries of the array!");
                }

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            //Task6
            if(this.Count == this.Capacity)
            {
                var oldElements = this.elements;
                this.Capacity *= 2;
                this.elements = new T[Capacity];
                Array.Copy(oldElements, this.elements, this.Count);
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void Clear()
        {
            this.elements = new T[this.Capacity];
            this.Count = 0;
        }

        public bool Contains(T element)
        {
            bool contains = false;
            foreach(var elem in this.elements)
            {
                if(elem.Equals(element))
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new NullReferenceException("The array cannot be copied to Not instanced one!");
            }

            Array.Copy(this.elements, array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var item = this.elements[i];
                yield return item;
            }
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (0 > index)
            {
                throw new IndexOutOfRangeException("The index is outisde of the boundries!");
            }

            if (index == this.elements.Length)
            {
                var oldElements = this.elements;
                this.Capacity *= 2;
                this.elements = new T[Capacity];
                Array.Copy(oldElements, this.elements, this.Count);
            }

            T temp = this.elements[index];
            this.elements[index] = item;

            for (int i = index + 1; i < this.elements.Length - 1; i++)
            {
                var temValue = this.elements[i];
                this.elements[i] = temp;
                temp = temValue;
            }
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;
            bool contsins = this.Contains(item);
            if (contsins)
            {
                var temp = this.elements;
                this.elements = new T[this.elements.Length - 1];
                this.Count = 0;
                var index = Array.IndexOf(temp, item);

                for (int i = 0; i < index; i++)
                {
                    this.Add(temp[i]);
                }

                for (int i = index; i < temp.Length - index; i++)
                {
                    this.Add(temp[i + 1]);
                }

                isRemoved = true;
            }

            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.elements.Length)
            {
                throw new IndexOutOfRangeException("The index is outside of the boundries of the array!");
            }

            var temp = this.elements;
            this.elements = new T[InitialCapacity];
            this.Capacity = InitialCapacity;
            this.Count = 0;

            for (int i = 0; i < index; i++)
            {
                this.Add(temp[i]);
            }

            for (int i = index; i < temp.Length - index; i++)
            {
                this.Add(temp[i + 1]);
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                result += this.elements[i];
                if(i < this.Count - 1)
                {
                    result += ", ";
                }
            }

            return result;
        }

        //Task 7
        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There are no elements in the GenericList");
            }

            T min = this.elements[0];

            for (int i = 0; i <= this.Count; i++)
            {
                T item = this[i];
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There are no elements in the GenericList");
            }

            T max = this.elements[0];

            foreach (T item in this.elements)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }
    }
}
