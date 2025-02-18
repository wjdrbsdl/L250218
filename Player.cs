using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Player : GameObject
    {
        public Player(int _posX, int _posY, char _shape) : base(_posX,_posY,_shape)
        {

        }

        public override void Update()
        {
            //엔진에서 현재 입력된 키가 뭔지 물어보고 이동 
            //엔진은 하나여야하고, 그 키 값도 하나여야함 
            Move();
            
        }

        private void Move()
        {
            int preX = posX;
            int preY = posY;

            if (Engine.Instance.GetKeyDown(ConsoleKey.W) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                posY--;
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.S) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                posY++;
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.A ) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                posX--;
            }
            else if (Engine.Instance.GetKeyDown(ConsoleKey.D) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            {
                posX++;
            }

            char shape = Engine.Instance.CheckCollideObject(posX, posY);
            if (shape == '*')
            {
                //충돌했으면 이동 못함
                posX = preX;
                posY = preY;
                return;
            }
            if( shape == 'M')
            {
                Engine.Instance.GameOver();
                return;
            }
            if (shape == 'G')
            {
                Engine.Instance.NextGame();
                return;
            }
            //무사히 이동했으면 맵 갱신
            Engine.Instance.RewnewMap(preX, preY, posX, posY);
        }
    }
}
