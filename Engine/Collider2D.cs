using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Collider2D : Component
{
    public bool isTrigger = false;
    public override void Update()
    {

    }

    public bool IsCollide(int _posX , int _posY)
    {
        foreach (var go in Engine.Instance.GameObjectList)
        {
            if (go.GetComponet<Collider2D>() != null)
            {
                if (go.transform.X == _posX && go.transform.Y == _posY)
                {
                    //충돌체에 트리거가 온이라면
                    if (go.GetComponet<Collider2D>().isTrigger == true)
                    {
                        object[] goParm = { go };
                        gameObject.ExcuteMethod("OnTriggerEnter", goParm);
                        object[] selfParm = { gameObject };
                        go.ExcuteMethod("OnTriggerEnter", selfParm);
                    }
                    else
                    {
                        //온 아니면 멈춤
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
    }
}

