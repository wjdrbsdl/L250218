using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CharactorCollider2D : Collider2D
{
    public bool IsCollider(int _addX, int _addY)
    {
        int futrueX = _addX + transform.X;
        int futrueY = _addY + transform.Y;
        foreach (var go in Engine.Instance.GameObjectList)
        {
            if(go.GetComponet<Collider2D>() != null)
            {
                if(go.transform.X == futrueX && go.transform.Y == futrueY)
                {
                    return true;
                }
            }
        } 
        return false;
    }

    public void Move(int _addX, int _addY)
    {
        int futrueX = _addX + transform.X;
        int futrueY = _addY + transform.Y;
        foreach (var go in Engine.Instance.GameObjectList)
        {
            if (go.GetComponet<Collider2D>() != null)
            {
                if (go.transform.X == futrueX && go.transform.Y == futrueY)
                {
                    return;
                }
            }
        }
        transform.X = futrueX;
        transform.Y = futrueY;
    }
}

