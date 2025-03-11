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

    public override void Update()
    {
        if (isGameOver)
        {
            Console.WriteLine( "Failed");
            Engine.Instance.Quit();
        }

        if (isFinish)
        {
            Console.WriteLine("Success");
            Engine.Instance.Quit();
        }
    }


}
