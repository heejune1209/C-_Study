using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace OOP
{
    
    // class는 ref 참조를 해서 변수를 넘긴다.
    class Knight
    {
        public int hp;
        public int attack;
        // public을 안쓰면 외부 클래스에서 데이터에 접근을 못한다

        public Knight Clone()
        {
            Knight Knight = new Knight();
            Knight.hp = hp; // 본인값의 hp를 넣어줌
            Knight.attack = attack; // 본인값의 attack을 넣어줌
            return Knight;
        }
        // 새로운 별개의 객체를 생성하여 자기 자신의 속성 값들을 복사하고 이를 리턴하는 함수 Clone()을 만든다.직접 Call by Value를 구현하는 방식.

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }

        public void Attack()
        {
            Console.WriteLine("Knight Attack");
        }
    }

    // 구조체는 기본적으로 복사를 해서 넘긴다
    struct Mage
    {
        public int hp;
        public int attack;
    }
    
    internal class Program
    {
        // OOP
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }
        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }

        static void Main(string[] args)
        {
            //Knight knight = new Knight(); // 새로 객체를 만들때 쓰는 문법은 new이다.
            ////Knight knight1 = null; // null인 상태로 knight1을 쓰면 크래시가 난다.

            //knight.hp = 100;
            //knight.attack = 10;

            //knight.Move();
            //knight.Attack();

            // 복사와 참조
            // 얕은 복사, 깊은 복사
            Mage mage = new Mage(); // 복사본
            mage.hp = 100;
            mage.attack = 50;
            //KillMage(mage); // 복사본이어서 mage의 hp를 0으로 해도 진퉁을 안건드렸기 때문에 변화가 없음

            Mage mage2 = mage; // 이렇게 해도 mage2는 영향을 안받는다
            mage2.hp = 0; 

            Knight knight = new Knight(); // 참조값(진퉁)
            knight.hp = 100;
            knight.attack = 10;
            //KillKnight(knight); // 얘는 진퉁을 건드려서 hp가 0.

            //Knight knight2 = knight; // 이렇게 하면 knight2의 원본 데이터값도 knight1이랑 똑같아짐 
            Knight knight2 = knight.Clone();  // knight을 깊은 복사하여 knight2을 만든다. 두 객체는 별개의 객체이다
            knight2.hp = 0;
            // 이렇게 하면 class인 knight2는 0인데 knight는 100인걸 볼수 있다.

            // 만약에 knight2의 초기값만 knight1의 hp와 attack으로 동일하게 하고 싶다고 한다면
            //Knight knight2 = new Knight();
            //knight2.hp = knight.hp;
            //knight2.attack = knight.attack; 이렇게 하는 방법이 있다
            // 이렇게 하면 knight와 knight2는 완전히 독립된 객체가 된다

            // 근데 매번 이렇게 new를 해서 새로운 객체를 만들어서 하나씩 대입하는게 마음에 안들면 또다른 방법이 있는데,
            // 깊은 복사라는게 있다.

            // 구조체와 클래스의 차이
            // 구조체 👉 Call by Value 방식으로 작업한다. (복사)
            // - 예를 들어 이름이 mage인 Mage타입의 구조체(Struct)가 있다면 Mage mage2 = mage 하여도 mage와 mage2는 별개의 메모리다.mage2는 mage의 값들을 깊은 복사해 온 사본일 뿐이다.
            // - 객체와 달리 구조체는 Mage mage; 만 해도 메모리가 할당이 된다.
            // - 구조체(값 타입)의 경우에는 new를 사용해도 로컬 변수로 선언되면 스택(stack)에 할당될 수 있으며, 참조 타입의 멤버로 포함되면 힙에 포함되어 할당된다.

            // ----------------------------
            // ex) 참조 타입의 멤버로 포함되면 힙에 포함되어 할당되는 경우
            //public class MyClass
            //{
            //    public int number;  // 값 타입 멤버
            //    public MyStruct data;  // 구조체 타입 멤버
            //}

            //public struct MyStruct
            //{
            //    public float x;
            //    public float y;
            //}

            // MyClass의 인스턴스 생성
            // MyClass obj = new MyClass();

            // 예를 들어, 아래와 같이 클래스의 멤버로 값 타입(예: int 또는 구조체)이 선언된 경우, 해당 클래스 객체는 힙에 할당되며,
            // 멤버 변수들도 그 객체의 일부로 힙에 저장됩니다.
            // ----------------------------

            // 클래스 👉 Call by Reference 방식으로 작업한다. (참조)
            // - 예를 들어 이름이 knight인 Knight 클래스 타입의 객체가 있다면 Knight knight2 = knight 하면 knight2와 knight는 동일한 메모리를 참조하게 된다. 즉 이 둘은 동일한 객체를 접근한다.
            // 데이터를 복사해준 것이 아닌 얕은 복사하여 동일한 객체에 대한 주소를 내부적으로 복사해준 것 뿐이다.
            // - C++로 따지면 두 변수가 동일한 메모리에 소유권을 모두 가지도록 shared_ptr를 만들고 리턴해준 상황과 같다.
            // - C#에선 Knight knight;만으로는 메모리 할당이 되지 않는다. new를 사용하여야 메모리가 할당이 된다.(= 실존하게 된다.)
            // - new를 사용하여 할당했다는 것은 힙 메모리에 동적으로 할당 받았다는 것이다. C# 에서 클래스 객체는 C++과 달리 무조건 힙 메모리에 올라간다.
            // - C++은 구조체나 클래스 객체나 다 스택, 힙 양쪽 다 사용이 가능하다.
            // - 힙과 다르게 스택 메모리는 유효 범위가 계속 달라지므로 스택의 주소를 참조하는건 좀 위험한 일이다.
            // "C#의 클래스는 참조 타입이기 때문에 변수는 주소를 저장하지만, 실제 객체는 new를 통해 힙 메모리에 만들어줘야 쓸 수 있다. 그렇지 않으면 참조가 null이고, 사용할 수 없다."

            // 스택과 힙
            // 스택 메모리
            // - 불완전하고 일시적으로 사용하는 메모리
            // - 메모장 같은 존재.
            // - 함수 내부에서만 살아 있다가 함수 끝나면 사라지는 지역 변수, 연쇄적인 함수들의 호출 위치 등등 잠깐 있다 사라질 것들은 스택 메모리에 올라온다.
            // - 스택 자료구조처럼 쌓이는 구조고 가장 나중에 쌓인게 가장 먼저 빠진다.
            // - 반면에 객체와 같은 Call by Reference 는 스택 메모리에 그 데이터 자체가 아닌 그 데이터가 있는 주소가 올라간다.
            // - 실제 데이터는 힙 메모리에 있다. 즉 스택 메모리에 저장되는건 본체 데이터가 위치한 힙 메모리의 주소다.

            // 힙 메모리
            // - new 등등 프로그램 실행 中 실시간으로 할당 된 것들이 올라간다.
            // - 실행 전부터 메모리를 잡고 실행하는 것이 아니라 프로그램 실행 중에 그때 그때 필요한 메모리를 할당할 땐 힙 메모리에서 가져다 쓴다.
            // - 특별히 해제해주는 작업이 없다면 프로그램 내내 힙 메모리에 안정적으로 남아있게 된다.
            // - C++ 에선 개발자가 반드시 직접 delete 로 일일이 해제 해주어 힙 메모리 누수를 막아야 했었다.
            // - C# 에선 아무도 참조하지 않고 자리만 차지하는 힙 메모리는 C# 시스템 자체의 가비지 콜렉터가 알아서 해제해준다.
            // - Call by Reference 를 실현하는 ref 변수가 참조하는 데이터는 스택 메모리일 수도 있다.
            // - ref int a 에서 참조하는 메모리는 스택 메모리 일 수도 있는 것. a엔 참조 중인 스택 메모리의 주소가 스택 메모리에 속한 a에 올라가게 된다.
            // - Call by Reference 라고 해서 무조건 힙에 저장되는건 아니라는 것이다. 착각하지 말기!

            // 따라서 Call by Reference는 메모리의 위치(스택/힙)와는 별개로, 값의 복사가 아닌 주소 전달을 통해 원본에 접근하는 방식임을 기억하면 된다.
        }
    }
}
