using System.Reflection;

namespace L250218
{
    public class Program
    {
        class Data
        {
            public void Count()
            {
                Console.WriteLine( "퍼블 카운트");
            }

            private void PrivateSum()
            {
                Console.WriteLine( "프라빗 섬");
            }

            protected void ProSum()
            {

            }

            static void Add(int a, int b)
            {
                Console.WriteLine( a+" 더하기 "+b);
            }
        }

        static void Main(string[] args)
        {

            Data d = new();
            Type dType = d.GetType();
            MethodInfo[] methods = dType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            for (int i = 0; i < methods.Length; i++)
            {
                //Console.WriteLine(methods[i].Name);
                if (methods[i].Name == ("Add") )
                {
                    object[] param = { 3, 5 };
                    methods[i].Invoke(d, param);
                }
            }

            FieldInfo[] fileds = dType.GetFields(BindingFlags.Default);
            while (true)
            {

            }

            return;
            Engine engine = Engine.Instance; //유일한 Engine을 가져옴
            engine.Init(); //하드웨어 초기화
            engine.GameLoad();  //준비하고
            engine.GamePlay();  //진행시키고
            engine.Quit();

        }
    }
}
