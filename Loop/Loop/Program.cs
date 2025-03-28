namespace Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Loop
            // while, for, foreach, do-while

            int count = 5;
            while (count > 0)
            {
                Console.WriteLine("heejune");
                count--;
            }

            //do
            //{

            //} while (count > 0);
            // do -while은 조건이 false여도 최소 한번은 실행된다.

            // for
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("heejune");
            }

            //-------------------------
            int num = 97; // 1, 97 로만 나뉘는 숫자, 소수를 만들자! (Break문 활용)

            bool isPrime = true;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine(num + " is a prime number");
            }
            else
            {
                Console.WriteLine(num + " is not a prime number");
            }

            // -------------------------
            // continue문 활용
            //for (int i = 0; i <= 100; i++)
            //{
            //    if (i % 3 == 0)
            //    {
            //        Console.WriteLine($"3으로 나뉘는 숫자 발견 : {i}");
            //    }               
            //}
            // continue문을 사용하면 코드가 더 가독성이 좋다.
            // continue문은 아래 코드를 실행하지 않고 다음 루프로 넘어간다.
            for (int i = 0; i <= 100; i++)
            {
                if (i % 3 != 0)
                {
                    continue;
                }
                Console.WriteLine($"3으로 나뉘는 숫자 발견 : {i}");
            }

        }
    }
}
