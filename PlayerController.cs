
using static SDL2.SDL;

namespace L250218
{
    public class PlayerController : Component
    {
        public override void Update()
        {
            Move();
        }

        private void Move()
        {
            //int preX = posX;
            //int preY = posY;

            if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_w) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                //spriteIndexY = 2;
                //posY--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_s) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                //spriteIndexY = 3;
                //posY++;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_a) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                //spriteIndexY = 0;
                //posX--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_d) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            {
                //spriteIndexY = 1;
                //posX++;
            }

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
