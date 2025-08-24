namespace Flow_Control
{
    internal class Program
    {
        enum Choice
        {
            Rock = 1,
            PAPER = 2,
            SCISSORS = 0
            // 위와 같이 직접 값을 명시해줄 수도 있다.
        }
        // enum 열거형을 사용하는 이유
        // 상수이므로 의미를 알기 쉽다.
        // 연관된 것들을 하나의 enum 으로 묶기 때문에 그룹화를 할 수 있다.
        // 상수나 변수가 굉장히 많아지면 이름이 중복될 우려도 있는데 서로 다른 enum에 속하면 이름이 동일해도 전혀 다른 것으로 간주되기 때문에 이름 중복 우려를 방지할 수 있다.
        // 열거형 선언은 클래스처럼 함수 밖에서 선언되야 한다.
        // 내부적으론 정수가 저장된다.
        // 값이 입력 안되면 디폴트 값 0 에서 출발하여 0, 1, 2, 3, 이런식으로 저장된다.이전 값에서 +1 한 값으로 설정된다.

        static void Main(string[] args)
        {
            // if-else if 
            // switch-case 스위치 케이스 문은 if else문의 축소판같은 느낌
            // while
            // for/foreach
            // do-while

            // 삼항 연산자
            // 조건식 ? 참일때 값 : 거짓일때 값
            //int num = 25;
            //bool isPair;
            //isPair = num % 2 == 0 ? true : false;

            // 가위바위보 게임

            // 상수와 열거형
            //const int Rock = 1;
            //const int PAPER = 2;
            //const int SCISSORS = 0;

            Random random = new Random();
            int aiChoice = random.Next(0, 3); // 0~2 사이의 랜덤값

            int choice = Convert.ToInt32(Console.ReadLine());

            // 현재 switch 조건문의 choice가 int형이니까 int형으로 캐스팅
            switch (choice)
            {
                case (int)Choice.SCISSORS:
                    Console.WriteLine("당신의 선택은 가위입니다");
                    break;
                case (int)Choice.Rock:
                    Console.WriteLine("당신의 선택은 바위입니다");
                    break;
                case (int)Choice.PAPER:
                    Console.WriteLine("당신의 선택은 보입니다");
                    break;
            }

            switch(aiChoice)
            {
                case (int)Choice.SCISSORS:
                    Console.WriteLine("AI의 선택은 가위입니다");
                    break;
                case (int)Choice.Rock:
                    Console.WriteLine("AI의 선택은 바위입니다");
                    break;
                case (int)Choice.PAPER:
                    Console.WriteLine("AI의 선택은 보입니다");
                    break;
            }

            // 승리, 무승부, 패배 판정
            if(choice == aiChoice)
            {
                Console.WriteLine("무승부입니다");
            }
            else if (choice == (int)Choice.SCISSORS && aiChoice == (int)Choice.PAPER || choice == (int)Choice.Rock && aiChoice == (int)Choice.SCISSORS || choice == (int)Choice.PAPER && aiChoice == (int)Choice.Rock)
            {
                Console.WriteLine("당신이 이겼습니다");
            }
            else
            {
                Console.WriteLine("당신이 졌습니다");
            }
            
            

        }
    }
}
