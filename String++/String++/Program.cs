namespace String__
{
    // 문자열 둘러보기
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                // 1. Contains
                string name = "Harry Potter";

                if (name.Contains("Harry"))
                    Console.WriteLine("True");
                // Conains(string) 👉 호출한 문자열에 인수로 넘긴 문자열이 부분 문자열로 존재한다면 True, 아니면 False 리턴.
                // 인수로 넘긴 “Harry”는 name 문자열에 부분 문자열로 존재하기 때문에 True 리턴.
            }
            {
                // 2. IndexOf
                string name = "Harry Potter";

                Console.WriteLine(name.IndexOf('P'));
                Console.WriteLine(name.IndexOf('Z'));
                // IndexOf(char) 👉 호출한 문자열에 인수로 넘긴 문자가 부분 문자열로 존재 한다면,
                // 해당 문자가 있는 위치인 인덱스를 리턴하고 존재 하지 않는다면 -1를 리턴한다.
            }
            {
                // 3. 덧붙이기 : + 연산자
                string name = "Harry Potter";
                name = name + " Junior";

                Console.WriteLine(name);
            }
            {
                // 4. 소문자, 대문자로 변형 : ToLower, ToUpper
                string name = "Harry Potter";

                Console.WriteLine(name.ToLower());
                Console.WriteLine(name.ToUpper());
            }
            {
                // 5. 특정 문자 바꾸기 : Replace
                string name = "Harry Potter";
                string newName = name.Replace('r', 'l'); // Replace(char, char) 👉 호출한 문자열에 첫 번째 인수 문자에 해당하는 부분들을 전부 두 번째 인수로 바꾼다.
                // name 문자열의 모든 r부분이 l로 바뀌었다.
                Console.WriteLine(newName);
            }
            {
                // 6. Split
                string name = "Harry Potter";
                string[] names = name.Split(new char[] { ' ' }); // 배열의 원소인 ' ' 공백 문자를 기준으로 분할한 문자열들을 string [] 배열로 리턴한다.

                for (int i = 0; i < names.Length; i++)
                    Console.WriteLine(names[i]);
                // Split 👉 인수로 넘긴 구분자를 기준으로, 호출한 문자열을 분할하여 이를 string [] 배열로 리턴한다.
                string name2 = "Harry Potter";
                string[] names2 = name2.Split(' ');

                for (int i = 0; i < names2.Length; i++)
                    Console.WriteLine(names2[i]);

                // Split(char 배열) : 인수로 넘긴 char 배열의 원소들을 기준으로 구분하고 분할하여 string [] 배열로 리턴한다.
                string text = "one\ttwo three:four,five six seven";
                string[] words = text.Split(new char[] { ' ', ',', '.', ':', '\t' });

                for (int i = 0; i < words.Length; i++)
                    Console.WriteLine(words[i]);
                // Split(string) : 인수로 넘긴 string 문자열을 기준으로 구분하고 분할하여 string [] 배열로 리턴한다
                string text2 = "Harry Potter";

                string[] words2 = text2.Split("rry");

                for (int i = 0; i < words2.Length; i++)
                    Console.WriteLine(words2[i]);

                // Split(string 배열, StringSplitOptions) : 인수로 넘긴 string 문자열 배열의 원소들을 기준으로 구분하고 구분하여 string [] 배열로 리턴한다.
                // ✔ 단, string 배열을 인수로 넘길 때는 두번째 인수가 꼭 필요하다. 두 번째 인수를 포함하지 않으면 컴파일 에러가 발생한다.
                // 두 번째 인수
                // StringSplitOptions.None
                // - 리턴 값에 빈 문자열이 포함됨
                // StringSplitOptions.RemoveEmptyEntries
                // - 리턴 값에 빈 문자열이 포함되지 않음
                string text3 = "one<<two......three<four";
                string[] words3 = text3.Split(new string[] { "<<", "..." }, System.StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words3.Length; i++)
                    Console.WriteLine(words3[i]);
            }
            {
                // 7.Substring
                // Substring(int) 👉 호출한 문자열의 인수에 해당하는 인덱스부터 문자열 끝까지를 리턴한다.
                string name = "Harry Potter";
                Console.WriteLine(name.Substring(5));
               
                // Substring(int, int) 👉 호출한 문자열의 첫 번째 인수에 해당하는 인덱스부터 두 번째 인수 길이만큼 리턴한다.
                string name1 = "Harry Potter";
                Console.WriteLine(name1.Substring(5, 4));
            }
            {
                // 8. 문자열 포맷
                // string.Format
                // C# 에서는 형식 문자열을 간단하게 인수의 순서에 따라 {0}, {1}, {2}… 으로 지정해주면 된다.
                // 첫 번째 인수가 {0}이 되고 두 번째 인수가 {1}이 되고 이런 식!
                int a = 10;
                int b = 5;
                string str = string.Format("{0} + {1} = {2}", a, b, a + b);
                Console.WriteLine(str);  // "10 + 5 = 15" 출력
                // 표준 숫자 서식 문자열
                // C, D, E, F 등등..
                // 사용자 지정 숫자 형식 문자열
                // 0, #, . , % 등등..
            }
            {
                // IsNullOrEmpty
                // string의 static 함수로, 인수로 넘긴 문자열이 null이거나 비어있으면 true 리턴!
                string name = null;
                string.IsNullOrEmpty(name); // true 리턴
            }
        }
    }
}
