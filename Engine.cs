using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Engine
    {
        //싱글톤 - 엔진은 하나여야함
        private Engine()
        {

        }

        private static Engine instance;

        public static Engine Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Engine();
                    return instance;
                }
                return instance;
            }
        }

        bool isPlaying = false;
        GameObject[] gameObjecets;
        ConsoleKeyInfo keyInfo; //인풋에서 받아놓을것
        string[] map =
        {
            "**********",
            "*P       *",
            "*        *",
            "*        *",
            "*  M     *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*        *",
            "*    G   *",
            "**********"
        };


        public void GameLoad()
        {
            //맵을 보고 오브젝트들을 생성, 위치와 모양을 입력
            Console.WriteLine(map[0].Length);
            gameObjecets = new GameObject[map.Length * map[0].Length];
            int objectIndex = 0;
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    char shape = map[y][x];
                    GameObject gameObject = new GameObject(x, y, shape);
                    if (shape == 'P')
                    {
                        gameObject = new Player(x, y, shape);
                    }
                    else if(shape == '*')
                    {
                        gameObject = new Wall(x, y, shape);
                    }
                    else if (shape == ' ')
                    {
                        gameObject = new Floor(x, y, shape);
                    }
                    else if (shape == 'M')
                    {
                        gameObject = new Monster(x, y, shape);
                    }

                    gameObjecets[objectIndex] = gameObject;
                    objectIndex++;
                }
            }
        }

        public void GamePlay()
        {
            isPlaying = true;
            Render(); //맵핑 먼저 하고 
            while (isPlaying)
            {
                Input();
                Update();
                Render();
            }
        }


        private void Input()
        {
            //입력받은거 저장해놓기
            keyInfo = Console.ReadKey();
        }

        public bool GetKeyDown(ConsoleKey _key)
        {
            return _key == keyInfo.Key;
        }


        private void Update()
        {
            for (int i = 0; i < gameObjecets.Length; i++)
            {
                if (isPlaying == false)
                {
                    break;
                }

                gameObjecets[i].Update();
            }
        }

        public char CheckCollideObject(int _posX, int _posY)
        {
            //위치에 벽이 있냐 
            //Go[]배열에 해당 x, y가 *인지 만 알 수 있으면 좋은데 
            //for (int i = 0; i < gameObjecets.Length; i++)
            //{
            //    if (gameObjecets[i].posX == _posX && gameObjecets[i].posY == _posY && gameObjecets[i].shape == '*')
            //    {
            //        return true;
            //    }
            //}

            return map[_posY][_posX];
        }

        public void RewnewMap(int _preX, int _preY, int _newX, int _newY)
        {
            char preChar = map[_preY][_preX];
            char nextChar = map[_newY][_newX];

            char keep = map[_preY][_preX];

            StringBuilder sb = new StringBuilder(map[_preY]);
            sb[_preX] = map[_newY][_newX];
            map[_preY] = sb.ToString();

             sb = new StringBuilder(map[_newY]);
            sb[_newX] = keep;
            map[_newY] = sb.ToString();
        }

        private void Render()
        {
            Console.Clear(); //이전거 지우고
            for (int i = 0; i < gameObjecets.Length; i++)
            {
                gameObjecets[i].Render();
            }
        }

        public void GameOver()
        {
            isPlaying = false;
            Console.WriteLine("게임 오버");
            Console.ReadKey();
        }

        public void NextGame()
        {
            isPlaying = false;
            Console.WriteLine("다음판");
            Console.ReadKey();
        }
    }
}
