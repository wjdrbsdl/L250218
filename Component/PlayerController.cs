
using static SDL2.SDL;

namespace L250218
{
    public class PlayerController : Component
    {
        SpriteRenderer render;
        CharactorCollider2D charControl;
        public override void Awake()
        {
            render = GetComponet<SpriteRenderer>();
            charControl = GetComponet<CharactorCollider2D>();
        }
        public override void Update()
        {
            Move();
        }

        private void Move()
        {
                 
            int preX = transform.X;
            int preY = transform.Y;

            if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_w) || Engine.Instance.GetKeyDown(ConsoleKey.UpArrow))
            {
                render.spriteIndexY = 2;
                charControl.Move(0,-1);
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_s) || Engine.Instance.GetKeyDown(ConsoleKey.DownArrow))
            {
                render.spriteIndexY = 3;
       
                charControl.Move(0,1);
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_a) || Engine.Instance.GetKeyDown(ConsoleKey.LeftArrow))
            {
                render.spriteIndexY = 0;
      
                charControl.Move(-1, 0);
            }
            else if (Engine.Instance.GetKeyDown(SDL_Keycode.SDLK_d) || Engine.Instance.GetKeyDown(ConsoleKey.RightArrow))
            {
                render.spriteIndexY = 1;
        
                charControl.Move(1, 0);
            }

           
        }

        public void OnTriggerEnter(GameObject _other)
        {
            Console.WriteLine("충돌" + _other.Name);

            if (_other.Name == "Goal")
            {
                GameObject.Find("GameManager").GetComponet<GameManager>().isFinish = true;
            }
        }
    }

}
