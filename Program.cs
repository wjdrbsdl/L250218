/*
 * 
 * 오브젝트 - 
 * 공간좌표와 모양이 있고
 * 플레이어, 몬스터, 골
 * 벽과 바닥
 * 
 * 프로그램에서
 * - 준비로는 맵핑 - 각자 오브젝트들을 각자 위치에 세우기 
 * - 1. 입력 2. 각자 적용할거 적용하고, 3. 화면 표시하고
 * 입력받고, 연산하고, 출력하고
 */

using System.Data;

namespace L250218
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Engine engine = Engine.Instance; //유일한 Engine을 가져옴
            engine.GameLoad();  //준비하고
            engine.GamePlay();  //진행시키고
        }

    }
}
