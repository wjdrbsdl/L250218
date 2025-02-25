using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L250218
{
    public class Wall : GameObject
    {
        public Wall(int _posX, int _posY, char _shape, int _orderLayer) : base(_posX, _posY, _shape, _orderLayer)
        {
            isCollide = true;
        }
    }
}
