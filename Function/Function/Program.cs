namespace Function
{
    internal class Program
    {

        // 반환형식 함수이름(매개변수 목록)
        //{

        //}

        //static void hello()
        //{
        //    Console.WriteLine("Hello");
        //}

        //static void Swap(ref int a, ref int b)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp;
        //}

        //static void Add(ref int number)
        //{
        //    number = number + 1;

        //}

        //static int Add2(int number)
        //{
        //    return number + 1;
        //}

        //static void Divide(int a, int b, out int res1, out int res2)
        //{
        //    res1 = a / b;
        //    res2 = a % b;
        //}
        // out이 붙은 매개 변수에 아무런 값도 저장하지 않는다면 이렇게 컴파일 오류가 뜬다.
        // out 매개변수에 저장을 강제함! ref였으면 아무런 문제가 없다. 아래와 같이 out 매개 변수에 값을 저장하면 오류가 사라진다.

        //static int Add(int a, int b, int c = 0, float d = 1.0f, double e = 3.0)
        //{
        //    Console.WriteLine("Add int 호출");
        //    return a + b;
        //}

        //// 오버로딩
        //static float Add(float a, float b)
        //{
        //    Console.WriteLine("Add float 호출");
        //    return a + b;
        //}

        static int Factorial(int n)
        {
            //int temp = 1;
            //for (int num = 1; num <= n; num++) 
            //{
            //    temp *= num;
            //}
            //return temp;
            
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1); // 재귀함수로 구현
        }
        static void Main(string[] args)
        {
            //int a = 0;

            // 메소드
            // 복사(짝퉁), 참조(진짜)
            // ref
            // 개 변수는 & 타입이라도 인수에까지 &을 붙일 필요는 없었던 C++ 문법과는 다르게 C# 에선 넘겨주는 인수까지 꼭 ref를 붙여주어야 한다.
            // 매개 변수가 ref int number로 선언되어 있다면 인수도 마찬가지로 꼭 ref a로 넘겨주어야 한다.

            //Console.WriteLine("Hello, World!");
            //Program.hello();
            //Program.Add(ref a); // ref : reference로 참조값으로 실제 a의 값에 데이터를 변화시킬수 있음
            //Console.WriteLine(a); // a의 값이 변하지 않았음(복사값으로 했기때문) 1로 바뀔거면 ref를 써야함

            //// 진퉁을 안바꾸고 다른데다 저장을 하는 용도로 사용할수 있다
            //int b = Add2(a);
            //a = b;
            //Console.WriteLine(a);

            //int num1 = 1;
            //int num2 = 2;
            //Swap(ref num1, ref num2); // 참조를 사용하여 진퉁을 건드려서 숫자 스왑
            //Console.WriteLine(num1);
            //Console.WriteLine(num2);

            // out
            // ref랑 똑같다. Call by Reference. 매개 변수에 저장을 강제하는 ref라고 생각하면 된다.

            // 매개 변수가 ref인 경우
            // - 매개 변수에 값을 저장(write)하지 않고 그저 읽기(read)만 하더라도 문법적 오류 전혀 없다.
            // - 즉 매개변수를 call by reference 로 인수의 메모리를 참조하기로 해놓고는 아무런 사용도 안해도 문제가 전혀 없다.
            // - [함수 외부] <-> [함수 내부] 양방향으로 통신하기 위해서 데이터 참조를 주고 받기 위한 개념
            // - 읽기 + 쓰기 가능. 사용하지 않아도 됨.
            // - 함수 내부/외부 사이에 데이터를 빠르게 넘겨주기 위해 사용.
            // - 반드시 초기화가 되어 있는, 메모리가 비어 있지 않은 변수에만 ref를 사용할 수 있다. 초기화 되지 않은 변수에 ref 붙이며 컴파일 오류가 난다.
            // - 함수 내부에서 그냥 읽기만 할 수도 있기 때문에 런타임 에러의 위험이 생길 수 있음.

            // 매개 변수에 어떤 값을 저장(write)하는 활동이 전혀 없다면 컴파일 오류를 발생시킨다. 반드시 참조 매개변수를 함수 내부에서 write 시켜야 한다. 단순 읽기만 해서는 안된다.
            // - call by reference 매개 변수가 참조 중인 메모리의 사용을 강제하기 때문에 ref와 달리 초기화를 전혀 하지 않은 변수를 인수로서 out 매개 변수에 넘기는 것이 가능하다.
            // - 함수가 끝나면 넘겨준 인수에도 Call by Reference를 통해 어떤 값이 반드시 저장될 것이라는게 보장되기 때문이다.out이 이를 강제해서!
            // - [함수 내부]에서 작업한 최종 결과물을[함수 외부] 쪽으로 넘겨주는 일방적 통행(out 이름 답게!)
            // - 함수 내부에서 값을 바꿔서 외부에 전달. 참조 중인 외부 메모리에도 영향을 끼침.
            // - 반드시 쓰기 과정이 필요
            // - 함수 내에서의 로직으로 매개 변수 write을 진행한 최종 데이터를 함수 외부로 넘겨주기 위한 용도로 사용.



            //int num1 = 10;
            //int num2 = 3;

            //int res1;
            //int res2;
            //Divide(10, 3, out res1, out res2);
            // ref와 마찬가지로 인수에도 모두 out을 붙여주어야 한다.

            //Console.WriteLine(res1);
            //Console.WriteLine(res2);
            // 만약에 값을 여러 개를 반환해야 될 경우에는 이런 식으로 out 키워드를 이용해서 넘길수 있다는것을 참고.
            // out도 ref와 마찬가지로 진통으로 작업을 하는 것이다

            //-----------------------------
            // 오버로딩
            // 함수 이름의 재사용
            // 오버로딩을 사용하려면 매개변수 타입과 개수가 정확하게 일치하면 안된다
            // 근데 반환형식만 다른것은 오버로딩을 사용하지 못한다.

            //int ret = Add(2, 3, d: 2.0f); // Add 함수는 받는 인자가 되게 많은데 매개변수에 초기값 설정이 되어있는 경우에 그중 하나만 이렇게 따로 재정의해줄수 있다. 
            //float ret2 = Add(2.3f, 3.3f);

            //Console.WriteLine(ret);

            // ----------------------
            // 연습문제
            // 구구단

            for (int i = 2; i < 10; i++) 
            {
                for(int j =1; j < 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}" );
                }
            }

            // 별찍기
            for (int i = 0; i<5; i++)
            {
                for (int j = 1; j <= i; j++) 
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // !(팩토리얼)
            int ret = Factorial(5);
            Console.WriteLine(ret);
            // 팩토리얼 함수 구현은 재귀함수로도 구할수 있다
        }
    }
}
