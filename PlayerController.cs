
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
            Transform transform = GetComponet<Transform>();
            SpriteRenderer render = GetComponet<SpriteRenderer>();
            int preX = transform.X;
            int preY = transform.Y;

            if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_w) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                render.spriteIndexY = 2;
                transform.Y--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_s) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                render.spriteIndexY = 3;
                transform.Y++;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_a) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                render.spriteIndexY = 0;
                transform.X--;
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_d) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            {
                render.spriteIndexY = 1;
                transform.X++;
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
