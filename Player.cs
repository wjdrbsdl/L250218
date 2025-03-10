using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace L250218
{
    public class Player : GameObject
    {
        public Player(int _posX, int _posY, char _shape, int _orderLayer, string _filename) : base(_posX, _posY, _shape, _orderLayer, _filename)
        {
            collider = new ColliderComponent();
            color = new SDL2.SDL.SDL_Color { r = 0, g = 255, b = 0, a = 0 };
   
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

            if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_w) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                posY--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_s) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                posY++;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_a) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                posX--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_d) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
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
          
            //무사히 이동했으면 맵 갱신
           // Engine.Instance.RewnewMap(preX, preY, posX, posY);
        }
    }
}
