using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Monster : GameObject
    {
        public Monster(int _posX, int _posY, char _shape) : base(_posX, _posY, _shape)
        {

        }

        Random randomMove = new Random();
        public override void Update()
        {
            Move();
        }

        private void Move()
        {
            int move = randomMove.Next() % 4;

            int preX = posX;
            int preY = posY;

            if (move == 0)
            {
                posY--;
            }
            if (move == 1)
            {
                posY++;
            }
            if (move == 2)
            {
                posX--;
            }
            if (move == 3)
            {
                posX++;
            }
            char shape = Engine.Instance.CheckCollideObject(posX, posY);
            if (shape == '*')
            {
                //이동하려는곳이 벽이면 이동불가
                posX = preX;
                posY = preY;
                return;
            }
            if (shape == 'P')
            {
                //플레이어면 게임오버
                Engine.Instance.GameOver();
                return;
            }
            //이동 했으면 맵 갱신 
            Engine.Instance.RewnewMap(preX, preY, posX, posY);
        }
    }
}
