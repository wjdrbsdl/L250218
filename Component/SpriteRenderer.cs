using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class SpriteRenderer : Renderer
    {
        public char shape;
        private int size = 35;
        public SDL.SDL_Color color;

        public int orderLayer;
        public SDL.SDL_Color colorKey;
        IntPtr mySurface;
        IntPtr myTexture;

        public bool isAnimation = false;
        public int spriteIndexX = 0;
        public int spriteIndexY = 0;

        public string fileName;
        float renderDeltaTime = 0;

        private SDL.SDL_Rect sourceRect;
        private SDL.SDL_Rect destiRect;

        public SpriteRenderer()
        {

        }

        ~SpriteRenderer()
        {
            SDL.SDL_DestroyTexture(myTexture);
        }
        public SpriteRenderer(string _fileName, bool _isAnimation = false)
        {
          
        }

        public override void Update()
        {
            int posX = gameObject.transform.X;
            int posY = gameObject.transform.Y;
            destiRect = new SDL.SDL_Rect { x = posX * size, y = posY * size, w = size, h = size };
            unsafe
            {
                //C로 되어있는 함수 사용하기 위해서
                //unsafe - 내가 알아서 하겠다고 명시하고 
                //포인트 문법 사용
                //ssd에 있던 그림을 cpu Ram으로 올려놓은 상태
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                sourceRect = new SDL.SDL_Rect
                {
                    x = 0,
                    y = 0,
                    w = surface->w,
                    h = surface->h
                };
                if (isAnimation)
                {
                    renderDeltaTime += Time.deltaTime;
                    int sizeX = surface->w / 5;
                    int sizeY = surface->h / 5;
                    sourceRect.x = spriteIndexX * sizeX;
                    sourceRect.y = spriteIndexY * sizeY;
                    sourceRect.w = sizeX;
                    sourceRect.h = sizeY;
                    if (renderDeltaTime >= 1f)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % 5;
                        renderDeltaTime = 0;
                    }

                }


            }
        }

        public override void Render()
        {
            Engine.backBuffer[gameObject.transform.Y, gameObject.transform.X] = shape;
            SDL.SDL_RenderCopy(Engine.Instance.myBrush, myTexture, ref sourceRect, ref destiRect);
        }

        public void LoadBmp(string _fileName, bool isAnim = false)
        {
            //실행중에는 bin 파일
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; //현재 실행중인 디렉토리의 부모 파일 이름
            fileName = projectFolder + "/data/" + _fileName;
            isAnimation = isAnim;

            mySurface = SDL.SDL_LoadBMP(fileName);
            unsafe
            {
                //C로 되어있는 함수 사용하기 위해서
                //unsafe - 내가 알아서 하겠다고 명시하고 
                //포인트 문법 사용
                //ssd에 있던 그림을 cpu Ram으로 올려놓은 상태
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                //빼버릴 색깔을 지정하는 함수
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format,
                    colorKey.r, colorKey.g, colorKey.b));
                // 메모리에 올라가있는 그림 데이터에서 저 색깔값은 빼버린다. 
            }

            //cpu Ram에서 gpu Vram으로 옮긴상태 - 용어도 surface -> texture로 
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myBrush, mySurface);

        }

    }
}
