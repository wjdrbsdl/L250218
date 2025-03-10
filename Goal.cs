using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Goal : GameObject
{
    public Goal(int _posX, int _posY, char _shape, int _orderLayer, string _filename) : base(_posX, _posY, _shape, _orderLayer, _filename)
    {
        color = new SDL2.SDL.SDL_Color { r = 255, g = 0, b = 0, a = 0 };
     
    }
}

