namespace Data_Format
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int   정수 123
            // float 실수 3.14
            // string 문자열 "heejune"
            // bool 참/거짓 true/false

            //char ch;
            //ch = 'A'; // 문자 'A' C#에선 2바이트, C++에선 1바이트

            //int a = 100;
            ////short b = a; // short는 2바이트 , 암시적으로는 캐스팅 불가 
            //short b = (short)a; // 명시적 캐스팅 변환

            //float c = a; // float는 4바이트, 암시적으로도 캐스팅 가능
            //int d = (int)c; // 명시적 캐스팅 변환

            // 즉 더 큰 데이터에서 작은 데이터 타입으로 넘어갈때는 안에 들어가있는 데이터가 너무 크면 일부 데이터가 잘려 들어간다. 암시적으론 x, 명시적으로는 가능
            // 근데 작은 데이터에서 큰 데이터 타입으로 넘어갈때는 아무런 문제가 없다. 암시적으로도 가능
            // --------------------------------------------
            int a = 100;
            //string b = (string)a; // 스트링은 단순하게 변환이 불가능. 명시적으로도 불가능 하다.

            // string -> int
            //string input = Console.ReadLine(); // Console.WriteLine의 반대 개념. 사용자로부터 입력을 받는다.
            // 여기서 Console.ReadLine()은 string을 반환하기 때문에 input은 string이다. 
            // 그래서 정수 숫자를 입력해도 문자열로 인식한다.
            //int number = int.Parse(input); // int.Parse()를 사용하여 string을 int로 변환한다.
            //Console.WriteLine(number); // 출력 기능

            // int -> string
            int hp = 100;
            int maxHp = 200;

            // 당신의 Hp는 ?? 입니다.
            //string message = string.Format("당신의 HP는 {0}/{1} 입니다 ", hp, maxHp); // string.Format()을 사용하여 문자열을 만든다.
            // 근데 스트링 포맷의 단점은 치환해야하는 값들이 늘어날때 써야하는게 많아서 번거롭다.
            // 그래서 C# 6.0부터는 $ 이라고 문자열 보간이라는 기능이 추가되었다.
            string message = $"당신의 HP는 {hp}/{maxHp} 입니다"; // 문자열 보간을 사용하여 문자열을 만든다.
            Console.WriteLine(message); 
        }
    }
}
