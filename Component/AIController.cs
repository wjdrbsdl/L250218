

namespace L250218
{
    public class AIController : Component
    {
     
        public AIController()
        {

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
            if (moveTime < 3f)
            {
                return;
            }
            moveTime = 0; 
            int move = randomMove.Next() % 4;
            Transform transform = GetComponet<Transform>();
            int preX = transform.X;
            int preY = transform.Y;

            if (move == 0)
            {
                transform.Y--;
            }
            if (move == 1)
            {
                transform.Y++;
            }
            if (move == 2)
            {
                transform.X--;
            }
            if (move == 3)
            {
                transform.X++;
            }
            ColliderComponent isCollide = GetComponet<ColliderComponent>();
            if (isCollide.CheckCollideObject(transform.X, transform.Y))
            {
                //충돌했으면 이동 못함
                transform.X = preX;
                transform.Y = preY;
                return;
            }

        }
    }
}
