using L250218;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


public class TextRenderer : Renderer
{
    public string content;
    public IntPtr surface; //cpu에 올릴 먼저
    public IntPtr texture; //gpu에 전달할 텍스쳐
    public SDL.SDL_Color color;
    SDL.SDL_Rect destination;

    public void SetText(string _content)
    {
        content = _content;
        surface = SDL2.SDL_ttf.TTF_RenderUNICODE_Solid(Engine.Instance.myFont, content, color);
        texture =SDL.SDL_CreateTextureFromSurface(Engine.Instance.myBrush, surface);

     
        int w = 0;
        int h = 0;
        uint format = 0;
        SDL.SDL_QueryTexture(texture, out format, out int k, out w, out h);
        destination.x = 100;
        destination.y = 100;
        destination.w = w;
        destination.h = h;
    }

    public override void Render()
    {

        SDL.SDL_RenderCopy(Engine.Instance.myBrush, texture, 0, ref destination);
    }

    public override void Update()
    {
        
    }
}
