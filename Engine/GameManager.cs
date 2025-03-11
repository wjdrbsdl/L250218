using L250218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameManager : Component
{
    public bool isGameOver = false;
    public bool isFinish = false;

    public bool isFailShow = false;
    public bool isSucShow = false;

    public override void Update()
    {
        if (isGameOver)
        {
            if(isFailShow == false)
            {
                Console.WriteLine("Failed");
                GameObject failGo = new GameObject();
                failGo.Name = "failObject";
                TextRenderer textR = failGo.AddComponent(new TextRenderer());

                textR.color.r = 255;
                textR.color.g = 0;
                textR.color.b = 0;
                textR.SetText("실패");
                Engine.Instance.GameObjectList.Add(failGo);
                isFailShow = true;
            }
 
   
        }

        if (isFinish)
        {
            if(isSucShow == false)
            {
                Console.WriteLine("Success");
                GameObject failGo = new GameObject();
                failGo.Name = "sucObject";
                TextRenderer textR = failGo.AddComponent(new TextRenderer());

                textR.color.g = 255;
                textR.color.r = 0;
                textR.color.b = 0;
                textR.SetText("성공");
                Engine.Instance.GameObjectList.Add(failGo);
                isSucShow = true;
            }
  
    
        }
    }


}
