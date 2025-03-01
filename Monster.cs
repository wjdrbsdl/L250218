﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Monster : GameObject
    {
        public Monster(int _posX, int _posY, char _shape, int _orderLayer) : base(_posX, _posY, _shape,_orderLayer)
        {
            collider = new ColliderComponent();
        }

        Random randomMove = new Random();
        public override void Update()
        {
            Move();
        }

        private float moveTime = 0f;
        private void Move()
        {
            moveTime += Time.deltaTime;
            if (moveTime < 0.005f)
            {
                return;
            }
            moveTime += 0.005f;
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
            bool isCollide = collider.CheckCollideObject(posX, posY);
            if (isCollide)
            {
                //충돌했으면 이동 못함
                posX = preX;
                posY = preY;
                return;
            }
            //if (shape == 'P')
            //{
            //    //플레이어면 게임오버
            //    Engine.Instance.GameOver();
            //    return;
            //}
            //이동 했으면 맵 갱신 
           // Engine.Instance.RewnewMap(preX, preY, posX, posY);
        }
    }
}
