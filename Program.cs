using System.Data;
using System.Reflection;

namespace L250218
{
  
    public class Program
    {

        static void Main(string[] args)
        {
       
            Engine engine = Engine.Instance; //유일한 Engine을 가져옴
            engine.Init(); //하드웨어 초기화
            engine.GameLoad();  //준비하고
            engine.GamePlay();  //진행시키고
            engine.Quit();

        }
    }
}
