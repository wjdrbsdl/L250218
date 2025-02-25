using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ColliderComponent
{
    public bool CheckCollideObject(int _posX, int _posY)
    {
        //위치에 벽이 있냐 
        //Go[]배열에 해당 x, y가 *인지 만 알 수 있으면 좋은데 
        //for (int i = 0; i < gameObjecets.Length; i++)
        //{
        //    if (gameObjecets[i].posX == _posX && gameObjecets[i].posY == _posY && gameObjecets[i].shape == '*')
        //    {
        //        return true;
        //    }
        //}
        List<GameObject> objList = Engine.Instance.GameObjectList;
        for (int i = 0; i < Engine.Instance.GameObjectList.Count; i++)
        {
            if (objList[i].posX == _posX && objList[i].posY == _posY)
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
