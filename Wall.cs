

namespace L250218
{
    public class Wall : GameObject
    {
        public Wall(int _posX, int _posY, char _shape, int _orderLayer, string _filename) : base(_posX, _posY, _shape, _orderLayer, _filename)
        {
            isCollide = true;
        }
    }
}
