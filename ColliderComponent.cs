using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ColliderComponent : Component
{
    public override void Update()
    {
     
    }

    public bool CheckCollideObject(int _posX, int _posY)
    {
        List<GameObject> objList = Engine.Instance.GameObjectList;
        for (int i = 0; i < Engine.Instance.GameObjectList.Count; i++)
        {
            if (objList[i].transform.X == _posX && objList[i].transform.Y == _posY)
            {
                if (objList[i].isCollide)
                {
                    return true;
                }

            }
        }
        return false;
    }
}
