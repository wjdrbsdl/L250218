

namespace L250218
{
    public class AIController : Component
    {
        Random randomMove = new Random();
        CharactorCollider2D charCollider2D;

        public override void Awake()
        {
            charCollider2D = GetComponet<CharactorCollider2D>();
        }

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
    
            int preX = transform.X;
            int preY = transform.Y;

            if (move == 0)
            {
                charCollider2D.Move(0, -1);
            }
            if (move == 1)
            {
                charCollider2D.Move(0, 1);
            }
            if (move == 2)
            {
                charCollider2D.Move(-1, 0);
            }
            if (move == 3)
            {
                charCollider2D.Move(1, 0);
            }
      
        }

        public void OnTriggerEnter(GameObject _other)
        {
            Console.WriteLine("몬스터도 부딪혔음" + _other.Name);
        }
    }
}
