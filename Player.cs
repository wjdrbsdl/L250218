﻿
using static SDL2.SDL;

namespace L250218
{
    public class Player : GameObject
    {
        public Player(int _posX, int _posY, char _shape, int _orderLayer, string _filename) : base(_posX, _posY, _shape, _orderLayer, _filename)
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
            //int preX = posX;
            //int preY = posY;

            //if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_w) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            //{
            //    spriteIndexY = 2;
            //    posY--;
            //}
            //else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_s) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            //{
            //    spriteIndexY = 3;
            //    posY++;
            //}
            //else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_a) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            //{
            //    spriteIndexY = 0;
            //    posX--;
            //}
            //else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_d) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            //{
            //    spriteIndexY = 1;
            //    posX++;
            //}

            //bool isCollide = collider.CheckCollideObject(posX, posY);
            //if (isCollide)
            //{
            //    //충돌했으면 이동 못함
            //    posX = preX;
            //    posY = preY;
            //    return;
            //}
          
        }
    }
}
