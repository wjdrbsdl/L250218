using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class SpriteRenderer : Component
    {
        public char shape;
        private int size = 35;
        public SDL.SDL_Color color;

        public int orderLayer;
        protected SDL.SDL_Color colorKey;
        IntPtr mySurface;
        IntPtr myTexture;

        public bool isAnimation = false;
        public int spriteIndexX = 0;
        public int spriteIndexY = 0;

        public string fileName;
        float renderDeltaTime = 0;
        public SpriteRenderer()
        {

        }

        public SpriteRenderer(string _fileName, bool _isAnimation = false)
        {
            LoadBmp(_fileName);
            isAnimation = _isAnimation;
        }

        public override void Update()
        {
        }

        public virtual void Render()
        {
            int posX = 0;
            int posY = 0;
            SDL.SDL_Rect rect = new SDL.SDL_Rect { x = posX * size, y = posY * size, w = size, h = size };
            unsafe
            {
                //C로 되어있는 함수 사용하기 위해서
                //unsafe - 내가 알아서 하겠다고 명시하고 
                //포인트 문법 사용
                //ssd에 있던 그림을 cpu Ram으로 올려놓은 상태
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                SDL.SDL_Rect sorceRect = new SDL.SDL_Rect
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
                    sorceRect.x = spriteIndexX * sizeX;
                    sorceRect.y = spriteIndexY * sizeY;
                    sorceRect.w = sizeX;
                    sorceRect.h = sizeY;
                    if (renderDeltaTime >= 1f)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % 5;
                        renderDeltaTime = 0;
                    }

                }

                SDL.SDL_RenderCopy(Engine.Instance.myBrush, myTexture, ref sorceRect, ref rect);
            }
        }

        public void LoadBmp(string _fileName)
        {
            mySurface = SDL.SDL_LoadBMP(_fileName);
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
