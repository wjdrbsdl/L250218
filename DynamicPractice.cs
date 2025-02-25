using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class DynamicPractice<T>
    {
        //동적 할당 어레이 만들기
        T[] objects= new T[3]; //초기 수량 3
        private int count = 0; //현재 사용중인 공간

        private void Expand()
        {
            //영역 확장하기
            T[] newArrays = new T[objects.Length * 2];
            for (int i = 0; i < count; i++)
            {
                //확장된 곳으로 이사
                newArrays[i] = objects[i];
            }
            objects = newArrays;//확장된걸로 가르킴
        }

        //기능
        public void Add(T _object)
        {
            if(count == objects.Length)
            {
                //현재 용량이 다 찼으면
                Expand(); //확장
            }
            objects[count] = _object; //추가
            count++; //사용량 조절
        }

        public void RemoveAt(int _index)
        {
            //해당 인덱스를 제거 하려면 해당 칸의 뒤부터 당기면됨
            if(_index<0 || count <= _index)
            {
                return;
            }

            //당길꺼니까 현재 활용된거 앞까지
            for (int i = _index; i < count-1; i++)
            {
                objects[i] = objects[i + 1]; //다음껄로 넣음
            }
            count--; //사용중인 공간 감소
        }

        //해당 인덱스에 넣고 그뒤로 미루기 
        public void Insert(int _insertIndex, T _object)
        {
            if(_insertIndex >= count)
            {
                //넣으려는곳이 맨끝 이상이면 방지
                return;
            }
            //다 찼으면 미루기
            if(count == objects.Length)
            {
                Expand();
            }
            //뒤로 미룬다 생각하고 미뤄진 맨 뒤부터 앞에껄 땡김 - 미뤄질 칸 까지 진행
            for (int i = count; i > _insertIndex; i--)
            {
                objects[i] = objects[i - 1]; //바로 앞에껄로 넣음
            }
            objects[_insertIndex] = _object; //넣어야할자리에 벨류 넣음
            count++; //사용공간 1칸 상승
        }

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
                if(index>=0 && index < count)
                {
                    return objects[index];
                }
                return default(T);
            }
            set
            {
                if(index>=0 && index < count)
                {
                    objects[index] = value;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(objects[i] + ", ");
            }
        }

    }
}
