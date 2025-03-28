namespace Array_Ex
{
    internal class Program
    {
        // 가장 높은 숫자 반환
        static int GetHighestScore(int[] scores)
        {
            int best = 0;
            foreach (var item in scores)
            {
                if (item > best)
                {
                    best = item;
                }
            }
            return best;
        }
        // 배열중 평균값을 반환
        static int GetAverageScore(int[] scores)
        {
            int sum = 0;
            foreach (var score in scores)
            {
                sum += score;
            }
            if(sum == 0)
                return 0;

            return sum / scores.Length; // Length를 써서 배열의 길이를 구할수 있다.
        }

        // 배열에서 내가 원하는 값이 있는지 찾는 함수
        // 있으면 인덱스 번호를 반환, 없으면 -1을 반환
        static int GetIndexof(int[] scores, int index)
        {
            for (int i = 0; i < scores.Length; i++) 
            {
                if (scores[i] == index)
                    return i;
            }
            return -1;
        }

        static void Sort(int[] scores)
        {
            for(int i = 0; i < scores.Length; i++)
            {
                // [i~ 배열 길이 -1] 제일 작은 숫자가 있는 index를 찾는다.
                int minindex = i;
                for(int j = i;  j < scores.Length; j++)
                {
                    if(scores[j] < scores[minindex])
                        minindex = j;
                }

                // swap
                int temp = scores[i];
                scores[i] = scores[minindex];
                scores[minindex] = temp;

            }
        }

        static void Main(string[] args)
        {
            // 배열
            int[] scores = new int[5] { 10, 30, 20, 50, 40 };
            int value = GetHighestScore(scores);
            Console.WriteLine(value);

            Console.WriteLine(GetAverageScore(scores));
            Console.WriteLine(GetIndexof(scores, 30));

            Sort(scores);

            foreach (var score in scores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
