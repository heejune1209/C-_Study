namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                game.Process();
                // 디자인 패턴중에 State패턴과 유사함
            }
        }
    }
}
