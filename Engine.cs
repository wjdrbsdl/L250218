using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Engine
    {
        #region 변수
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
        List<GameObject> gameObjecets = new List<GameObject>();

        public List<GameObject> GameObjectList
        {
            get
            {
                return gameObjecets;
            }
        }

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
        #endregion

        #region Load
        private string[] LoadMap(string _fileName)
        {
            string[] loadMap = null;

            byte[] buffer = new byte[1024];//읽어들일 공간?
            FileStream fs = new FileStream(_fileName, FileMode.Open);

            
            fs.Seek(0, SeekOrigin.End); //파일을 열고 커서를 파일 끝으로 갖다놓는다.
            int fileSize = (int)fs.Position; //커서 끝 부분 위치가 해당 파일 사이즈
            fs.Seek(0, SeekOrigin.Begin); //커서 위치를 처음으로 조정 
            fs.Read(buffer, 0, fileSize); //커서 위치 처음 부터, 파악한 파일 사이즈 만큼 읽기
            fs.Close();
            string loadStr = Encoding.UTF8.GetString(buffer); //바이트로 읽은걸 string으로 전환
            loadStr = loadStr.Replace("\0", ""); //공백을 제거

            loadMap = loadStr.Split("\r\n"); //엔터로 잘라서 배열에 담기

            return loadMap;
        }

        public void GameLoad()
        {
            //맵을 보고 오브젝트들을 생성, 위치와 모양을 입력
            Console.WriteLine(map[0].Length);
            map = LoadMap("level01.map");
            gameObjecets = new();
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    char shape = map[y][x];

                    //바닥 무조건 추가 
                    GameObject floorObj = new Floor(x, y, ' ', 0);
                    gameObjecets.Add(floorObj);

                    GameObject gameObject = null;
                    if (shape == 'P')
                    {
                        gameObject = new Player(x, y, shape, 4);
                    }
                    else if (shape == '*')
                    {
                        gameObject = new Wall(x, y, shape, 1);
                    }
                    //else if (shape == ' ')
                    //{
                    //    gameObject = new Floor(x, y, shape);
                    //}
                    else if (shape == 'M')
                    {
                        gameObject = new Monster(x, y, shape,3);
                    }
                    else if (shape == 'G')
                    {
                        gameObject = new GameObject(x, y, shape, 2);
                    }
                    if(gameObject != null)
                    {
                        gameObjecets.Add(gameObject);
                    }
                    
          

                   
                }
            }
            gameObjecets.Sort((a, b) => a.orderLayer.CompareTo(b.orderLayer));
        }
        #endregion 


        public DateTime lastTime;
        public void GamePlay()
        {
            float actTime = 1000.0f / 1.0f;
            float curTime = 0.0f;
            Console.CursorVisible = false;
            isPlaying = true;
            Render(); //맵핑 먼저 하고 
            while (isPlaying)
            {
                Time.Update(); //시간 변화시키기
                if(curTime >= actTime)
                {
                    Input();
                    Update();
                    Render();
                    keyInfo = new ConsoleKeyInfo();
                    curTime = 0;
                }
                else {
                    curTime += Time.deltaTime;
                }
                
            }
        }


        private void Input()
        {
            //입력받은거 저장해놓기
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
            }
        }

        public bool GetKeyDown(ConsoleKey _key)
        {
            return _key == keyInfo.Key;
        }


        private void Update()
        {
            for (int i = 0; i < gameObjecets.Count; i++)
            {
                if (isPlaying == false)
                {
                    break;
                }

                gameObjecets[i].Update();
            }
        }

        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];
        private void Render()
        {
            //Console.Clear(); //이전거 지우고
            for (int i = 0; i < gameObjecets.Count; i++)
            {
                //개별적인 오브젝트들의 렌더링
                //1. 하나씩 그리는거에서
                //2. 버퍼에 기록하는걸로 수정 ?? 
                gameObjecets[i].Render();
            }
            
            //back <-> frotn (flip)
            
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    if (frontBuffer[y, x] == backBuffer[y, x])
                    {
                        continue;
                    }
                    frontBuffer[y, x] = backBuffer[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(backBuffer[y,x]);
                }
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

