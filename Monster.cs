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
            if (Engine.Instance.IsCollisionWall(posX, posY))
            {
                posX = preX;
                posY = preY;
            }
        }
    }
}
