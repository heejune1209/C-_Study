namespace Inheritance
{
    // 상속성/은닉성/다형성

    // 상속성
    // 부모 클래스 👉 Player
    // - 직업에 상관없이 플레이어라면 모두 가지고 잇는 공통된 속성과 기능을 부모클래스로 묶는다.
    // 자식 클래스 👉 Mage, Aracher, Knight
    // - 이 클래스들은 Player를 상속받으므로 플레이어라면 모두 갖고 있는 공통 멤버들을 다시 필드에 명시해줄 필요가 없다.
    // - 이런 부분들은 Player 상속으로 해결하고 법사, 궁수, 전사들만의!!! 고유의 속성과 기능을 추가해주면 되는 식이다.
    // - 자식 클래스에서 멤버 필드에 직접 명시해주지 않더라도 상속만 하면 자동으로 부모의 멤버들도 가지게 된다. 👉 코드의 재사용성
    // - 상속을 받은 자식 클래스에서 부모클래스의 멤버 변수와 멤버 함수를 따로 정의를 안해도 자식 객체를 만들어서 상속받은 변수와 함수를 사용할 수 있다.

    // 부모 클래스에 생성자 정의가 아예 없거나(이 경우 컴파일러가 자동으로 만들어 줌) 혹은 디폴트 생성자 정의가 되어 있다면 문제가 되지 않지만
    // 부모 클래스에 매개 변수가 있는 생성자들은 있는데 디폴트 생성자 정의는 없는 경우에는 컴파일러가 자동으로 만들어 주지 않는다.
    // 따라서 이런 경우에는 다른 부모 생성자 호출을 직접 명시하지 않으면 컴파일 에러가 난다.부모 클래스의 디폴트 생성자를 정의해주거나,
    // 혹은 개발자가 매개 변수가 있는 특정 부모 생성자를 직접 호출시켜 주어야 한다.

    class Player // 부모 클래스, 기본 클래스
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int attack;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출");
        }
        public Player(int hp)
        {
            Console.WriteLine("Player hp 생성자 호출");
        }
    }
    class Mage : Player // 자식 클래스, 파생 클래스
    {
        //public Mage() // ❌ 컴파일 에러 발생 👉 부모인 Player에 디폴트 생성자가 없어 호출할 수 없다. 
        //{

        //}
    }
    class Archer : Player
    {

    }

    class Knight : Player
    {
        int c;
        public Knight() : base(100) // 개발자가 명시하지 않으면 부모 클래스의 디폴트 생성자가 호출되며, base(123) 이런식으로 base를 사용하여 원하는 종류의 부모 생성자를 직접 호출할 수도 있다.
            // 그리고 저번시간에 Knight() : this(100) 이라고 하면 나의 클래스에 다른 버전 생성자를 호출한다는 의미
        {
            this.c = 100; // this는 나의 클래스의 변수에 접근하는 기능
            base.hp = 100; // base는 부모의 변수에 접근. 즉, 부모의 hp에 접근
            Console.WriteLine("Knight 생성자 호출");
        }
        static public Knight CreateKnight()  // 문제 없음. 가능. ⭕
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 1;
            return knight;
        }
    }

    //--------------------------------------
    //class Player
    //{
    //    protected int hp = 0;
    //}

    //class Knight : Player
    //{
    //    public Knight() // ⭕ 문제 되지 않는다. 부모 생성자 딱히 정의된게 없기 때문에 디폴트 부모 생성자를 컴파일러가 자동으로 만들어 호출해주기 때문.
    //    {

    //    }
    //}

    //---------------------------------------


    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = Knight.CreateKnight(); // 부모 생성자가 먼저 호출 된다.
            // 당연히 생성자도 함수이므로 부모 생성자를 자식 클래스에서 상속을 받고, 언제나 부모 생성자를 먼저 호출한다.
            // 개발자가 명시하지 않으면 부모 클래스의 디폴트 생성자가 호출되며, base(123) 이런식으로 base를 사용하여 원하는 종류의 부모 생성자를 직접 호출할 수도 있다.

        }
    }
}
