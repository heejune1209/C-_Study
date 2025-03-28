namespace calculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int hp = 3 + 2 * 10;

            // 몫 ,나머지
            //int a = 10 / 3; // 3.3333 -> 3
            //int b = 10 % 3; // 1
            // 추가로 0으로 나누면 에러가 발생합니다.
            //int a = 10;
            //int b = a++; // a를 b에 대입 후 a를 증가
            //int c = ++a; // a를 증가 후 c에 대입
            // -----------------------------------
            // 비교연산
            // <, <=, >, >=, ==, !=
            // 논리연산
            // &&, ||, ! (and, or, not)

            // int , float, string, bool
            int hp = 100;
            var a = 10;
            var b = 3.14f;
            var c = "Hello, World!";
            var d = true;
            // var는 자동 추론을 해주는 기능.
            // c++의 auto와 비슷한 기능.
            // 타입이 길어질때는 사용하면 편리하지만, 가독성이 떨어질수 있어서 그냥 귀찮더라도 이 타입을 직접 명시하는 게 훨씬 더 좋다.

            Console.WriteLine("Hello, World!");
        }
    }
}
