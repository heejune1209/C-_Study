using static System.Net.Mime.MediaTypeNames;

namespace Polymorphism
{
    // 클래스 형식 변환
    class Player
    {
        protected int hp;
        protected int attack;
        public virtual void Move() { Console.WriteLine("Player Move"); }
    }
    class Knight : Player
    {
        public override void Move()
        {
            // 여기서 만약 부모의 Move함수를 호출하고 싶다면 base를 써서 호출하면 된다
            base.Move();
            Console.WriteLine("Knight Move");
        }
        //public sealed override void Move()
        //{
        //    // sealed는 오버라이딩 할 때 같이 사용된다. 손자, 증손자 클래스들에서 더 이상 오버라이딩 하지 못하게, 딱 나까지만 오버라이딩이 가능하도록 강제한다.
        //    // C++엔 없고 C#에만 있는 문법이며 그리 자주 쓰이진 않는다.
        //
        //    // Knight에서 Move()를 오버라이딩할 때 sealed 키워드를 통해 봉인해 두었기 때문에 손자 클래스인 SuperKnight에선 Move()를 오버라이딩 할 수 없다. 상속 받은 것을 그대로 써야 한다.
        //
        //    base.Move();
        //    Console.WriteLine("Knight Move");
        //}
        
        public void Attack() { Console.WriteLine("Knight Attack"); }
    }

    class SuperKnight : Knight
    {
        public override void Move() { Console.WriteLine("SuperKnight Move"); } // sealed을 사용했을 경우 컴파일 에러 !
    }

    class Mage : Player
    {
        public int mp;
        public override void Move() { Console.WriteLine("Mage Move"); }
        // public new void Move() { Console.WriteLine("Mage Move"); }
        // 부모 클래스로부터 상속 받은 함수와 이름은 동일하지만 이와 상관없는 완전히 다른 새로운 함수로서 재정의하고 싶다면 new 키워드를 사용하면 된다.
        // 상속 받은 함수와 동일한 이름이긴 하지만 새로운 함수를 만드는 것을 의미한다. 그래서 Player의 Move()와 Knight의 Move()는 완전히 다른 함수다.
        // new는 꼭 붙이지 않아도 된다. new 붙이지 않아도 new가 있는 것처럼 작동해주기 때문에 그냥 Knight 클래스 안에서 new붙이지 않고
        // public void Move()라고 정의하기만 해도 완전히 새로운 함수라고 정의된다. 그러나 new를 붙여주면 개발자 입장에선 의미를 알기 쉽기 때문에 붙이는 것을 권고하는 것 같다!
        public void Attack() { Console.WriteLine("Mage Attack"); }
    }

    internal class Program
    {
        // 다운 캐스팅시 런타임 에러 방지 문법
        // is
        // A is B 👉 A 변수가 B 타입의 객체를 참조하고 있다면 True 리턴, 아니면 False 리턴.

        // as
        // A as B 👉 A 변수를 B 타입으로 형변환 하는 것이 가능하다면 형변환을 진행하고 그 결과를 리턴한다. 불가능하다면 null을 리턴한다.
        static void EnterGame(Player player)
        {
            player.Move(); // player move 호출, 하지만 virtual을 쓰면 EnterGame(mage1); 이 코드에 의해 mage move가 호출된다
            // bool isMage = (player is Mage); // is
            Mage mage = (player as Mage);
            if (mage != null)
            {
                mage = (Mage)player;
                mage.Move();
            }
            // player가 Mage 타입의 객체를 참조하고 있다면, Mage로 형변환이 가능하다. 따라서 mage엔 player가 참조하고 있던 객체가 리턴되고
            // mage와 player는 힙메모리에 있는 동일한 객체를 가리키게 된다. mage는 player가 Mage로 형변환된 결과다.
            // 따라서 Mage mage = (Mage)player; 이 부분이 실행된다. 형변환이 불가능 했다면 이 부분은 실행되지 않았을 것이다. 안전함.

            //if(isMage)
            //{
            //    Mage mage = (Mage)player;
            //    mage.mp = 10;
            //    // player는 Knight 타입의 객체를 참조하고 있기 때문에 (player is Mage)의 결과는 False 이다.
            //    // 따라서 Mage mage = (Mage)player; 이 부분이 실행되지 않기 때문에 런타임 에러를 방지할 수 있다.

            //}
            //Mage mage = (Mage)player;
            //mage.mp = 10; // 이상태에서 EnterGame(knight); 라고 함수를 호출해서 knight를 넣어주고 넣어준걸 mage로 또 바꿔주고 mage의 멤버 변수를 건드리면 크래시가 난다.
            Knight knight = (player as Knight);
            if (knight != null)
            {
                knight = (Knight)player;
                knight.Move();
            }

        }

        static void Main(string[] args)
        {
            //Knight knight = new Knight();  
            //Mage mage = new Mage();
            //
            //// Mage => player O
            //// Player -> Mage x
            //Player magePlayer = mage;
            //// Mage mage1 = magePlayer; // error
            //Mage mage2 = (Mage)magePlayer;
            //
            //EnterGame(knight);
            //EnterGame(mage);

            // 요약하자면, 자식에서 부모로 업캐스팅을 하는것은 아무런 문제가 없지만,
            // 부모에서 자식으로 다운캐스팅을 하는것은 될수도 있고 안될수도 있다.

            // 업 캐스팅 : 자식 👉 부모 ⭕
            // 자식(Knight)타입의 객체(new Knight();)를 부모 타입의 변수(player)로 참조하는 것 가능하다.
            // 단 자식 타입의 전부를 호출할 순 없고, 부모로부터 상속 받은 멤버들만 호출이 가능하다.
            // 자식 객체를 참조하고 있더라도 부모 변수로 상속 받지 않은 자식만의 멤버를 호출하려 하면 컴파일 에러를 발생시킨다.
            // Knight knight = new Knight();
            // Player player = knight; // ⭕ 문제없다.

            // player.hp = 10; // ⭕ 문제없다.
            // player.Move();  // ❌ 컴파일 에러!

            // 다운 캐스팅 : 부모 👉 자식(경우에 따라 다름)
            // 암시적 형변환을 해주지 않는다. (컴파일 에러) ex) Mage mage1 = magePlayer; // error
            // 자식타입의 객체(new Knight();)를 참조하던 부모 타입 변수(player)를 다시 자식 타입으로 형변환 해주는 것이 가능하다. 즉, 자식 -> 부모 -> 자식. 이런상황이면 가능
            // 그러나 컴파일러는 이를 자동 형변환 해주지 않는다. 컴파일러 타임엔 부모 타입 변수인 player가 어떤 타입의 객체를 가리키고 있는지 알 수 없기 때문이다.
            // 객체가 메모리를 할당 받는 일은 해당 코드가 실행되는 런타임이기 때문에 컴파일 타임에선 player가 어떤 타입의 객체를 가리키고 있는지 알 수 없어서 자동적으로 형변환을 해주지 않는다.
            // 따라서 개발자가 직접 명시적으로 형변환을 해주어야 한다.
            // Player player = new Knight();
            // Knight knight = player;  // ❌ 컴파일 에러! 자동 형변환 해주지 않음.
            // Knight knight = (Knight)player;  // ⭕ 이렇게 명시적 형변환을 해주어야 한다. 

            // 명시적 형변환은 컴파일에선 문제 없으나 경우에 따라 런타임 에러가 발생할 수도 있다.
            // 실제로 형변환이 가능한지는 프로그램을 실행해 봐야 알 수 있다.객체가 메모리를 할당 받는 일은 해당 코드가 실행되는 런타임이기 때문이다.
            // ⭕ 아래의 경우엔 런타임 에러가 발생하지 않는다. 문제 없다.
            // 다시 원래 타입의 객체로 돌려주는 일이기 때문이다.부모 타입 변수 player는 자식 타입인 Knight 타입 객체를 참조하고 있었기 때문에
            // player 변수를 Knight 타입으로 형변환 해주는 것이 문제 되지 않는다. 안그래도 Knight 타입 객체를 참조있었기 때문에!
            // Player player = new Knight(); // 자식 -> 부모
            // Knight knight = (Knight)player;  // ⭕ 문제 없다. 부모 -> 자식

            // ❌ 아래의 경우엔 런타임 에러가 발생한다.
            // 부모 타입 변수 player는 자식 타입인 Knight 타입 객체를 참조하고 있었기 때문에 Mage타입으로 형변환 될 수 없다.
            // 이게 컴파일 타임에선 player가 어떤 객체를 가리키고 있는지 알 수 없고 런타임 때 해당 코드를 실행해 봐야 알 수 있는 부분인데,
            // Knight과 Mage는 둘 다 Player 자식이긴 하지만 Knight타입의 객체는 Mage에만 정의되어 있는 Mage의 멤버들을 담고 있지 않기 때문이다.
            // 따라서 Mage 타입의 변수 mage로 Knight타입의 객체를 참조할 수 없기 때문에, Knight타입의 객체를 가리키고 있는 player는 Mage로 형변환 될 수 없다.
            // Player player = new Knight(); 
            // Mage mage = (Mage)player;  // ❌ 런타임 에러 발생!
            // Unhandled Exception: System.InvalidCastException: Unable to cast object of type 'CSharp.Knight' to type 'CSharp.Mage'.


            // ---------------------------------
            // 다형성
            Knight knight1 = new Knight();
            Mage mage1 = new Mage();

            knight1.Move();
            mage1.Move();

            EnterGame(mage1);
        }
    }
}
