using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    // delegate의 한계
    // 아래 상황처럼 델리게이트 형식 OnClicked를 오직 ButtonPressed 함수 안에서만 실행시키기 위해 clickedFunction(); 만들었을 수도 있다.
    // 그러나 상관 없는, 그리고 외부인 메인 함수 안에서도 clicked(); 이렇게 델리게이트를 실행시킬 수 있다는 문제가 있다.

    // Event
    // event는 delegate와 달리 이벤트와 같은 클래스 안에서만 이벤트 호출이 가능하다.
    // 외부에선 오직 이벤트에 함수 등록만 해놓을 수 있으며 이벤트가 정의된 클래스 외부에서는 이벤트를 호출할 수는 없다. 이것이 델리게이트와의 차이점!

    //delegate int OnClicked();

    //static void ButtonPressed(OnClicked clickedFunction)
    //{
    //    clickedFunction();
    //}

    //static void Main(string[] args)
    //{
    //    OnClicked clicked = new OnClicked(Test);
    //    clicked += Test2; // chaining
    //    clicked();

    //    ButtonPressed(clicked);

    //    clicked();
    //}
    class InputManager
    {
        // 키보드 마우스 입력을 캐치해서 게임 로직에 이를 전달하는 역할로 정의한 클래스다.
        // 이벤트 정의하기
        // 1️. 먼저 delegate 형식부터 정의한다. (이벤트에 등록할 수 있는 함수 형식으로 쓸 것이다.)
        public delegate void OnInputKey(); // 매개 변수 없고 리턴 타입 없는 함수만 등록 가능한 형식
        // 2. 위에서 만든 delegate 형식을 가지는(= 타입이 해당 delegate인) 이벤트를 정의한다. 접근 한정자 + event + 델리게이트 이름 + 이벤트 이름
        public event OnInputKey InputKey;  // public 접근 한정자까지 똑같이 맞춰주어야 함, 이 이벤트의 타입은 OnInputKey 델리게이트
        // 델리게이트와 그 델리게이트를 타입으로 하여 정의한 이벤트는 둘 다 접근 한정자가 동일해야 한다. 둘 다 public으로 동일하여 문제 없음.
        // 사용자가 입력한 Key가 A라면 이벤트를 호출(실행)한다. 같은 클래스 내부에서 실행시키는 것이기 때문에 문제 없다.
        // InputManager 클래스 외부의 이곳 저곳에서 이 이벤트에 함수를 등록하고 이 이벤트에 등록된 함수가 무엇인지 알 필요 없이 그저 📜InputManager 클래스내에서 이를 실행만 하면 될 뿐이다.
        // 이와 같이 구독자(등록된 함수들)들에게 메세지를 뿌리는 디자인 패턴을 옵저버 패턴이라고 한다.

        public void Update()
        {
            if (Console.KeyAvailable == false) // Console.KeyAvailable 👉 Key를 누를 수 있는 상태라면 True 리턴, Key를 사용할 수 없으면 False 리턴.
                return;

            ConsoleKeyInfo info = Console.ReadKey(); // Console.ReadKey() 👉 사용자가 입력한 Key를 읽어들여 ConsoleKeyInfo 타입으로 리턴한다.
            if (info.Key == ConsoleKey.A)  // A 키가 눌리면 이벤트 호출
            {
                InputKey();  // 구독자들에게 메세지 뿌리기 👉 옵저버 패턴
            }
        }

        // 델리게이트와 이벤트의 차이점
        // 델리게이트
        // - 임의의 메서드를 가리키는 타입.
        // - 메서드를 참조·호출 가능한 변수형 타입
        // - 호출자는 Invoke() 또는 () 연산자로 직접 실행 가능.
        // - 외부에서도 재할당·호출 가능 → 책임 분리 미흡

        // 이벤트
        // - 델리게이트를 이벤트로 포장
        // - 외부는 구독/구독 해제만 가능하고, 직접 호출(() 실행)이나 = 재할당은 불가.
        // - 발행자만 Invoke() → 안전하게 콜백 관리, 캡슐화 보장.
        // 따라서, “단순 콜백” 용도라면 Action을 쓰고, **“외부 구독자에게 알림을 제공”**하는 패턴에는 event를 사용하는 것이 권장
    }
}
