using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class GameObject
    {
        public int posX;
        public int posY;
        public char shape;
        public int orderLayer;
        public bool isCollide;
        public bool isTrigger;
        public ColliderComponent collider;
        public GameObject(int _posX, int _posY, char _shape, int _orderLayer)
        {
            posX = _posX;
            posY = _posY;
            shape = _shape;
            orderLayer = _orderLayer;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Render()
        {
            //자기 위치에 자기 모양으로 표기하기 
            //매오브젝트마다 렌더를 요청하는 방식
            //Console.SetCursorPosition(posX, posY);
            //Console.Write(shape);

            //매 오브젝트의 그림을 buffer라는 곳에 담기 
            Engine.backBuffer[posY, posX] = shape;
        }

    }
}
