using SDL2;
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
        List<GameObject> gameObjects = new List<GameObject>();

        public List<GameObject> GameObjectList
        {
            get
            {
                return gameObjects;
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

        public IntPtr myWindowAddress;
        public IntPtr myBrush;
        public SDL.SDL_Event myEvent;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init");
                return false;
            }

            //아래 창 정보를 담은 메모리 의 C# 포인터형태로 인트 포인트라는걸 씀
            myWindowAddress = SDL.SDL_CreateWindow(
                "TileName",
                100, 100,//시작점?
                640, 480,//크기
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN //윈도우 보여달라
            ); //그리고나면 어딘가의 메모리에 들어간거고, 그 메모리 주소값을 반환함. 

            myBrush = SDL.SDL_CreateRenderer(myWindowAddress,
                -1, //그릴 순서
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | // 그래픽 카드 쓰겠다.
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC | //주사율 맞추겟다.
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE //일단 메모리에 넣어놓겠다.
             );

            return true;
        }

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
            gameObjects = new();
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    char shape = map[y][x];

                    //바닥 무조건 추가 
                    GameObject floorObj = new GameObject(x, y);
                    floorObj.Name = "Floor";
                    SpriteRenderer renderF = floorObj.AddComponent(new SpriteRenderer());
                    renderF.colorKey.r = 255;
                    renderF.colorKey.g = 255;
                    renderF.colorKey.b = 255;
                    renderF.orderLayer = 0;
                    renderF.LoadBmp("floor.bmp");
                    renderF.shape = ' ';
                    gameObjects.Add(floorObj);

                    GameObject gameObject = new GameObject(x, y);
                    SpriteRenderer render = gameObject.AddComponent(new SpriteRenderer());
                    if (shape == 'P')
                    {
                        gameObject.AddComponent(new PlayerController());
                        gameObject.Name = "Player";
                        render.colorKey.r = 255;
                        render.colorKey.g = 0;
                        render.colorKey.b = 255;
                        render.orderLayer = 2;
                        render.LoadBmp("player.bmp", true);
                        render.shape = 'P';

                        gameObject.AddComponent(new CharactorCollider2D());
                    }
                    else if (shape == '*')
                    {
                        gameObject.Name = "Wall";
                        gameObject.isCollide = true;
                        render.colorKey.r = 255;
                        render.colorKey.g = 255;
                        render.colorKey.b = 255;
                        render.LoadBmp("wall.bmp");
                        render.orderLayer = 1;
                        render.shape = '*';

                        gameObject.AddComponent(new BoxCollider2D());
                    }
                    else if (shape == 'M')
                    {
                        gameObject.Name = "Monster";
                        gameObject.AddComponent(new AIController());
                        render.colorKey.r = 255;
                        render.colorKey.g = 255;
                        render.colorKey.b = 255;
                        render.LoadBmp("monster.bmp");
                        render.orderLayer = 3;
                        render.shape = 'M';
                        CharactorCollider2D col = gameObject.AddComponent(new CharactorCollider2D());
                        col.isTrigger = true;
                    }
                    else if (shape == 'G')
                    {
                        GoalCollider2D goalCollider = gameObject.AddComponent(new GoalCollider2D());
                        goalCollider.isTrigger = true;
                        gameObject.Name = "Goal";
                        render.colorKey.r = 255;
                        render.colorKey.g = 255;
                        render.colorKey.b = 255;
                        render.orderLayer = 3;
                        render.LoadBmp("goal.bmp");
                        render.shape = 'G';
                    }
                    else if (shape == ' ')
                    {
                        continue;
                    }
                    if(gameObject != null)
                    {
                        gameObjects.Add(gameObject);
                    }
                }
            }

            GameObject gameManager = new GameObject();
            gameManager.AddComponent(new GameManager());
            gameObjects.Add(gameManager);
            gameManager.Name = "GameManager";
            //오브젝트들 정렬
            sortCompare = Compare;
            Sort();

            //오브젝트들 Awake
            Awake();
        }
       
        private void Awake()
        {
            foreach (var item in gameObjects)
            {
                foreach (Component component in item.componentList)
                {
                    component.Awake();
                }
            }
        }

        private void Sort()
        {
            for (int i = 0; i < gameObjects.Count-1; i++)
            {
                for (int j = i+1; j < gameObjects.Count; j++)
                {
                   if(sortCompare(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
              
            }
            
        }

        private int Compare(GameObject first, GameObject second)
        {
            SpriteRenderer firstRender = first.GetComponet<SpriteRenderer>();
            SpriteRenderer secondRender = second.GetComponet<SpriteRenderer>();
            if(firstRender == null || secondRender == null)
            {
                return 0;
            }
            return firstRender.orderLayer - secondRender.orderLayer;
        }

        public delegate int SortCompare(GameObject first, GameObject second);
        public SortCompare sortCompare;
        #endregion

        public DateTime lastTime;

        public void GamePlay()
        {
            Console.CursorVisible = false;
            isPlaying = true;
            while (isPlaying)
            {
                SDL.SDL_PollEvent(out myEvent);
                Time.Update(); //시간 변화시키기
                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isPlaying = false;
                        break;
                }
                Update();
                Render();
              
            }
        }

        #region 콘솔 인풋
        private void Input()
        {
            //입력받은거 저장해놓기
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
            }
        }
        #endregion

        public bool GetKeyDown(SDL.SDL_Keycode _key)
        {
            if (myEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                return Engine.Instance.myEvent.key.keysym.sym == _key;
            }
            return false;
        }

        public bool GetKeyDown(ConsoleKey _key)
        {
         
                return _key == keyInfo.Key;
    
        }


        private void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int x = 0; x < gameObjects[i].componentList.Count; x++)
                {
                    gameObjects[i].componentList[x].Update();
                }
                
            }
        }

        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];
        private void Render()
        {
            //화면지우기
            SDL.SDL_SetRenderDrawColor(myBrush, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myBrush);
            
            for (int i = 0; i < gameObjects.Count; i++)
            {
                //개별적인 오브젝트들의 렌더링
                //1. 하나씩 그리는거에서
                //2. 버퍼에 기록하는걸로 수정 ?? 
               SpriteRenderer spriteRender = gameObjects[i].GetComponet<SpriteRenderer>();
                if(spriteRender != null)
                {
                    spriteRender.Render();
                }
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

            SDL.SDL_RenderPresent(myBrush);
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


        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myBrush);
            SDL.SDL_DestroyWindow(myWindowAddress);

            SDL.SDL_Quit();
            //sdl를 닫았다.

            return true;
        }
    }
}

