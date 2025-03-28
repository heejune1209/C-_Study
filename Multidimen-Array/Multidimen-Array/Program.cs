namespace Multidimen_Array
{
    // 다차원 배열

    class Map
    {
        int[,] tiles =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
        };

        public void Render()
        {
            var defaultColor = Console.ForegroundColor;
            for (int y = 0; y < tiles.GetLength(1); y++) 
            {
                for (int x = 0; x < tiles.GetLength(0); x++) 
                {
                    // 다차원 배열에선 GetLength로 쓰자.
                    // arr.Length() 👉 배열의 전체 원소 개수. 2 * 3 = 6
                    // arr.GetLength(0) 👉 행의 개수. 2
                    // arr.GetLength(1) 👉 열의 개수. 3
                    if(tiles[y, x] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('\u25cf');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = defaultColor;
        }
    }   

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5] { 10, 20, 30, 40, 50 }; // 배열

            // 다차원 배열 초기화 방법
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } }; 
            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // 접근 방법
            arr[0, 0] = 1;
            arr[1, 2] = 6;
            // C# 에선 arr[a, b] 이런식으로도 표현할 수 있다.
            // 물론 arr[a][b] 표현도 가능하다.

            // map 렌더
            Map map = new Map();
            map.Render();

            int[][] a = new int[3][];
            a[0] = new int[3];
            a[1] = new int[6];
            a[2] = new int[2];

            a[0][0] = 1;
            // 위와 같이 열의 크기를 나중에 정할 수도 있다. 행마다 배열의 크기가 다르게도 할 수 있다.
        }
    }
}
