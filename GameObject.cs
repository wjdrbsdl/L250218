using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class GameObject
    {
        public int posX;
        public int posY;
        public char shape;
        public int orderLayer;
        public bool isCollide;
        public bool isTrigger;
        public ColliderComponent? collider;
        private int size = 30;
        public SDL.SDL_Color color;
        IntPtr mySurface;
        IntPtr myTexture;

        public GameObject(int _posX, int _posY, char _shape, int _orderLayer, string _fileName)
        {
            posX = _posX;
            posY = _posY;
            shape = _shape;
            orderLayer = _orderLayer;
            LoadBmp("data/"+ _fileName+".bmp");
        }

        public virtual void Update()
        {
            
        }

        public virtual void Render()
        {

            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myBrush, color.r, color.g, color.b, color.a);
            SDL.SDL_Rect rect = new SDL.SDL_Rect { x = posX*size, y= posY*size, w = size, h = size };
            //  SDL.SDL_RenderFillRect(Engine.Instance.myBrush, ref rect);
            //Engine.backBuffer[posY, posX] = shape; //예전 text로 만들던 부분
    

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
            }

            //cpu Ram에서 gpu Vram으로 옮긴상태 - 용어도 surface -> texture로 
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myBrush, mySurface);

        }

    }
}
