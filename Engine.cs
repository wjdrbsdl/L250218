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
            Render(); //맵핑 먼저 하고 
            while (true)
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
                gameObjecets[i].Update();
            }
        }

        public bool IsCollisionWall(int _posX, int _posY)
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
            int index = 0;
            for(int i = 0; i < _posY; i++)
            {
                index += map[i].Length; //맵에서 줄수만큼 더하고
            }
            index += _posX; //해당 줄수에서 x만큼 진행한거
            char shape = gameObjecets[index].shape; //거기서 나온게 모양 
            if (shape == '*')
            {
                return true;
            }
                
            return false;
        }

        private void Render()
        {
            Console.Clear(); //이전거 지우고
            for (int i = 0; i < gameObjecets.Length; i++)
            {
                gameObjecets[i].Render();
            }
        }
    }
}
