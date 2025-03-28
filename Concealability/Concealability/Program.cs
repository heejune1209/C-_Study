namespace Concealability
{
    // 은닉성
    // 접근 한정자
    // public
    // 외부에서 접근할 수 있음.
    
    // protected
    // 외부에선 안되지만 내 자식들은 접근 할 수 있음.
    
    // private 👉 디폴트
    // 나만 접근할 수 있음.자식들도 접근 못 함.
    
    // get, set 같은 public 접근 함수를 따로 만들어서 간접 접근함.
    // 이렇게 하는 이유! ✨ 외부에서 직접 접근하여 player.hp = 100 이러고 다니면..
    // 유지 보수시 hp 멤버에 언제 언제 접근했는지 일일이 다 알아내기가 힘들다.
    // 그러나 private으로 해두고 접근 함수를 사용하여 접근하면 그냥 setter 함수 내부에만 🔴 중단점을 걸어나오면 알아서 이 부분을 실행한 호출 스택 이 나오므로 매우 편하다.

    class Knight
    {
        private int hp;
        // private는 외부에서는 사용할 수 없고 클래스 내부에서 정의된 로직에서만 사용이 가능하다는 의미
        public void SetHp(int hp)
        {
            this.hp = hp;
        }
        public int GetHp() { return hp; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.SetHp(10); // set함수로 멤버변수에 접근
            Console.WriteLine(knight.GetHp());
        }
    }
}
