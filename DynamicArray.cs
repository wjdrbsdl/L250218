using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
  
    class DynamicArray<T>
    {
        
         public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(T inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            T[] newObject = new T[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(T removObject)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (removObject .Equals( objects[i]))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        //[][][][][][]
        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }

                count--;
                return true;
            }

            return false;
        }

        //[1][2][3]
        //Insert(2, 5);
        //[1][2][3][4]
        public void Insert(int insertIndex, T value)
        {
            //3 == 3  + 1 -> [1][2][3] - >[1][2][3][][][]
            //1. object.length == count
            //확장
            //추가 
            //3 == 2 + 1     [1][2][3][][][]
            //2. object.length < count
            //확장 X
            //추가
            if (objects.Length == count)
            {
                ExtendSpace();
            }


            for (int i = count; i > insertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[insertIndex + 1] = value;
            count++;
        }

     

        protected T[] objects = new T[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }
}
