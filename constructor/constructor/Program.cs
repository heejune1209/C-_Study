using System.Runtime.CompilerServices;

namespace constructor
{
    class Knight
    {
        // 필드
        static public int counter; // 오로지 한개만 존재

        public int id;
        public int hp;
        public int attack;

        static public void Test()
        {
            // this.id = 23; // ❌ 에러! 특정 객체 멤버는 사용할 수 없음
            // hp = 100;     // ❌ 에러! 특정 객체 멤버는 사용할 수 없음
            // 공용 함수라는 거는 결국 각각 개개인의 고유한 그런 정보에는 접근을 한다는 게 사실 말이 안되는게,
            // 얘는 현재 id라는 값이 모든 나이트 객체마다 다 다를 수도 있는데 얘를 어떻게 알고 어떤 애의 객체를 참조해야 될지를 알고 접근을 하겠는가.
            // counter++; // static함수 안에선 static 변수만 연산을 할수 있다.
        }

        static public Knight CreateKnight()  // 문제 없음. 가능. ⭕
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 1;
            return knight;
        }
        // static 함수 내에선 일반 멤버는 사용할 수 없고 static 멤버 변수만 사용할 수 있다.
        // Console 클래스에 있는 static 함수인 WriteLine() 👉 Console.WriteLine("a")

        public Knight()
        {
            id = counter;
            counter++; // 스태틱 활용
            
            hp = 100;
            attack = 10;
            Console.WriteLine("생성자 호출");
        }

        public Knight(int hp) : this() 
        {
            //  : this() -> Knight() 이 기본 생성자를 호출해달라는 뜻
            // 따라서 this.hp = hp를 실행하기 전에 Knight()를 호출하여 hp = 100와 attack = 10 를 먼저 실행하게 된다.
            // 따라서 자연스럽게 Knight(int hp) 생성자에서 hp 값만 설정헀어도 attack은 10 으로 설정이 미리 된다.
            this.hp = hp;
            Console.WriteLine("int 생성자 호출");
        }

        public void Move()
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Knight knight = new Knight(); // 생성자 호출
            Knight knight = new Knight(50); // 생성자 호출

            Knight knight1 = Knight.CreateKnight(); // 객체에 종속적인게 아니라 클래스에 종속적, static
            // Knight.Move(); // x
            knight1.Move(); // O , 일반

            // static
            // static이 아닌 일반 멤버들
            // - 종속된 객체 인스턴스들 마다 메모리가 별개다.
            // - 같은 클래스 타입이라도 객체들은 서로 속성값도 다를 수 있으며 별개의 존재이다.
            // - static이 아닌 일반 멤버 변수, 함수들은 객체에 종속된다.
            // static 멤버 변수, 멤버 함수
            // - static인 멤버 메모리를 같은 타입의 모든 객체들이 공유 한다.
            // - 따라서 오직 해당 멤버가 전체 메모리 상에서 단 1 개만 존재한다.
            // - 객체에 종속되지 않는다.
            // - 따라서 객체 생성 후 객체 이름으로 호출하는 것이 아닌 클래스 이름으로 호출한다.(객체에 종속적인게 아니라 클래스에 종속적) ex) Knight knight1 = Knight.CreateKnight();
            // - 객체 생성할 필요가 없다.
            // - static 함수 내에선 특정 일반 객체 멤버를 사용할 수 없다.
            // - 공용 함수니까 애당초 어떤 객체의 멤버를 사용해야 하는지 알 수 없기 때문에
            // - 그렇다고 아예 못 쓴다는 것은 아니고 함수 바깥의 어떤 특정 일반 객체 멤버를 사용할 수 없다는 것 뿐이다!예를 들면 this같이…
            // 예를 들어 static함수 내부에서 아예 새롭게 객체를 만들고 이를 리턴하는 작업은 가능하다.
        }
    }
}
