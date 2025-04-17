

using static System.Formats.Asn1.AsnWriter;

namespace _25._04._15_과제
{
    public abstract class SceneManager
    {
        public abstract void SScene(); //추상 메서드

        private Dictionary<string, int> Scene = new Dictionary<string, int>();

       
        //씬 추가 메서드
        public void AddScene(string placeName, int num)
        {
            if(Scene.ContainsKey(placeName))
            {
                Scene[placeName] += num;
            }
            else
            {
                Scene[placeName] = num;
            }
        }
        //씬 삭제 메서드
        public void RemoveScene(string placeName)
        {
            if (Scene[placeName]==0)
            {
                Scene.Remove(placeName);
            }
        }

              

    }
    class MainScreen : SceneManager
    {
        public override void SScene()
        {
            Console.WriteLine("[메인 화면]");
            Console.WriteLine("(1. 마을 2. 던전 3. 집)어디로 가시겠습니까?");
        }


        public class Viliage : MainScreen
        {
            public override void SScene()
            {
                
                Console.WriteLine("[마을]에 도착했습니다.");
                Console.WriteLine("(1. 상점 2. 식당 3. 여관) 어디로 가시겠습니까?");
                string input = Console.ReadLine();
                int inputNum;
                int.TryParse(input, out inputNum);
                if(inputNum == 1)
                {
                    Console.WriteLine("[상점]에 들어왔습니다.");
                }
                else if(inputNum == 2)
                {
                    Console.WriteLine("[식당]에 들어왔습니다.");
                }
                else if(inputNum == 3)
                {
                    Console.WriteLine("[여관]에 들어왔습니다.");
                }
                else
                {
                    Console.WriteLine("올바른 숫자를 입력하세요");
                    return;
                }

            }
        }
        public class Dungeon : MainScreen
        {
            public override void SScene()
            {
                
                Console.WriteLine("[던전]에 입장했습니다.");                
                Console.WriteLine("(1. 사냥 2. 채집) 무엇을 하시겠습니까?");
                string input = Console.ReadLine();
                int inputNum;
                int.TryParse(input, out inputNum);
                if (inputNum == 1)
                {
                    Console.WriteLine("사냥을 시작합니다.");
                }
                else if (inputNum == 2)
                {
                    Console.WriteLine("채집을 합니다.");
                }
                else
                {
                    Console.WriteLine("올바른 숫자를 입력하세요");
                    return;
                }
                
            }
        }
        public class House : MainScreen
        {
            public override void SScene()
            {
                
                Console.WriteLine("[집]으로 돌아왔습니다.");
                Console.WriteLine("(1. 잠들기 2. 게임하기) 무엇을 하시겠습니까?");
                string input = Console.ReadLine();
                int inputNum;
                int.TryParse(input, out inputNum);
                if (inputNum == 1)
                {
                    Console.WriteLine("잠에 들었습니다.");
                }
                else if (inputNum == 2)
                {
                    Console.WriteLine("게임을 합니다.");
                }
                else
                {
                    Console.WriteLine("올바른 숫자를 입력하세요");
                    return;
                }
            }
        }


        public void ChangeScene()
        {   //씬 바꾸는(전환) 메서드

            Viliage vilScene = new Viliage();
            Dungeon dunScene = new Dungeon();
            House houseScene = new House();

            string input = Console.ReadLine();
            int inputNum;
            int.TryParse(input, out inputNum);

            if (inputNum == 1)
            {
                AddScene("마을", 1);
                vilScene.SScene();
            }
            else if (inputNum == 2)
            {
                AddScene("던전", 1);
                dunScene.SScene();
            }
            else if (inputNum == 3)
            {
                AddScene("집", 1);
                houseScene.SScene();
            }
            else
            {
                Console.WriteLine("올바른 숫자를 입력하세요");
                return;
            }
        }
    }
    
    

    internal class FileName
    {
        static void Main()
        {
            MainScreen scene = new MainScreen();
            scene.SScene();
            scene.ChangeScene();


        }

    }
}
