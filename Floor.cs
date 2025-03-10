

namespace L250218
{
    public class Floor : GameObject
    {
        public Floor(int _posX, int _posY, char _shape, int _orderLayer, string _filename) : base(_posX, _posY, _shape, _orderLayer, _filename)
        {
            color = new SDL2.SDL.SDL_Color { r =0, g= 0,b= 0, a= 0};


        }
                
    }
}
