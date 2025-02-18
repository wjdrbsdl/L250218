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

        public GameObject(int _posX, int _posY, char _shape)
        {
            posX = _posX;
            posY = _posY;
            shape = _shape;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Render()
        {
            //자기 위치에 자기 모양으로 표기하기 
            Console.SetCursorPosition(posX, posY);
            Console.Write(shape);
        }

    }
}
