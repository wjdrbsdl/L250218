using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class CharactorCollider2D : Collider2D
{
    public void Move(int _addX, int _addY)
    {
        int futrueX = _addX + transform.X;
        int futrueY = _addY + transform.Y;
        if(IsCollide(futrueX, futrueY) == true)
        {
            return;
        }
        transform.X = futrueX;
        transform.Y = futrueY;
    }

    
}

