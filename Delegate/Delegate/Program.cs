using System.Collections.Generic;
namespace Delegate
{
    // Delegate (대리자)
    // delegate는 C#의 꽃이다!


    internal class Program
    {
        // delegate 를 사용하는 이유
        // 버튼이 눌리면 아바타에 옷을 입힌다 👉 무기를 들게 한다. 👉 랜덤 메세지를 출력한다.
        // 이런 과정들이 순차적으로 실행되게 하고 싶다면 버튼 눌리는 함수 내부에 각각의 기능들을 함수로 직접 실행시키면 되겠다.
        // 즉 ButtonPressed() 함수 내부에서 직접 여러 함수들에게 인수를 넘겨 호출하는 방식이다.
        // 그러나 이런 구현 방식의 문제점은 ButtonPressed() 함수 내부에서 함수들을 실행시키면서 일일이 매개 변수에게 인수를 넘겨야 하기 때문에 개발자가 실수를 할 확률도 커지고,
        // 예를 들어 게임 로직 함수와 UI 관련 함수가 섞여 있으니 설계적으로 보기도 좋지 않은 등등.. 여러모로 아쉬운 부분들이 있다.
        // 유니티의 경우 ButtonPressed() 이런 버튼 클릭시 실행시킬 함수는 유니티에서 제공되는 이벤트 함수이기 때문에 함수 내부에다가 버튼 클릭시 내가 원하는 함수들 직접 추가할 수도 없다.
        // 유니티 제공 시스템 함수라서 수정 불가능.

        // 만약 ButtonPressed() 함수에 위 과정의 각각의 기능을 실행하는 함수들 자체를 인자로 넘기고 ButtonPressed() 내에선 이게 어떤 함수인지 몰라도 되며
        // 그저 실행만 시키면 될 뿐이라면 위와 같은 문제들이 해결될 것이다. 마치 실행 해야할 함수 포인터들만 ButtonPressed()에게 인자로 넘겨주고 ‘대신 실행 부탁드려요~’ 하는 것과 같다.
        // 일일이 실행될 함수들을 나열하여 직접 호출하고 그 함수들에게 인자 직접 명시하여 넘기고.. 그런 과정이 필요가 없다.
        // 델리게이트 딱 하나만 실행하면 되기 때문에! (등록은 다른데서 필요할 때마다 해두고)
        // 이처럼 A 라는 함수를 호출할 때 B 라는 함수 자체를(B 함수 포인터) 인수로 넘겨주고 A 함수 안에서 B 함수를 호출하는 상황에서 A 함수를 콜백 함수라고 한다.
        // 이처럼 실행시킬 함수들을 그 자체로(함수 포인터로) delegate에게 넘겨주면 delegate는 이 함수들의 내용은 모르지만 그저 받은 함수 포인터들을 대신 실행시켜줄 뿐이다. (그래서 이름이 대리자)
        
        // delegate 선언
        delegate int OnClicked();
        // delegate -> 형식은 형식인데, 함수 자체를 인자로 언겨주는 그런 형식
        // 반환 : int , 입력:void, 형식 이름 : OnClicked
        // delegate의 이름과 함께 등록할 수 있는 함수의 형식을 선언하는 것이다.
        // 이땐 delegate가 어떠한 메모리도 차지하지 않으며 단순히 매개 변수 없고 + int를 리턴 타입으로 가지는 함수들만을 등록할 수 있는,
        // OnClicked라는 이름을 가진 delegate 형식을 선언해준 것 뿐이다.

        static void ButtonPressed(OnClicked clicked) // 버튼이 눌렸을 때 실행, 함수 자체를 인자로 넘겨준다.
        {
            // 버튼이 눌렸을 때 실행할 여러가지 함수들 나열 및 실행
            // 함수를 호출
            clicked(); // 대신 실행
        }

        static int Test()
        {
            Console.WriteLine("Hello Delegate ");
            return 0;
        }

        static int Test2()
        {
            Console.WriteLine("Hello Delegate 2");
            return 0;
        }

        static void AscendingSort() { /* 오름차순 정렬시키는 내용*/ }
        static void DescendingSort() { /* 내림차순 정렬시키는 내용*/ }

        delegate void SortMethod();

        static void Sort(SortMethod sortMethod)
        {
            sortMethod();
        }
        // 예를 들어 정렬 함수를 구현한다고 할 때 이런식으로 오름 차순 정렬을 시키고 싶으면 Sort 함수에 AscendingSort 함수를 인수로 넘기면 되고,
        // 내림 차순 정렬을 시키고 싶으면 Sort 함수에 DescendingSort 함수를 인수로 넘기면 된다. 정렬 방식에 따라 Sort 함수 내용이 달라지는건 없다.
        // 어떤 함수들이 등록됐느냐에 따라 sortMethod();는 다르게 실행된다.

        // 그 이외의 delegate에 관한 사실
        // 델리게이트도 일반화(Generic) 시킬 수 있다.델리게이트를 일반화하면 어떤 타입의 함수라도 등록할 수 있다.;
        delegate T SortMethod2<T>(T[] arr); 

        static void Sort<T>(T[] arr, SortMethod2<T> sortMethod)
        {
            sortMethod(arr);
        }
        // 대부분 +를 통해 등록된 순서대로 실행되기는 하지만 이것이 반드시 등록된 순서대로 실행된다는 보장이 있는 것은 아니라고 한다.
        // 따라서 정말 순서 보장이 필요한 상황이라면
        // 직접 원하는 순서대로 함수들을 실행시키는 다른 함수를 정의하고 이 함수를 델리게이트에 등록하거나
        // 혹은 델리게이트를 여러개 만들어 리스트로 관리하는 방식으로 구현할 수 있겠다.

        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }

        static void Main(string[] args)
        {
            ButtonPressed(Test); // 함수 자체를 인자로 넘긴 느낌
            // 이렇게 함수의 매개 변수 자체가 delegate면 함수를 호출 할 때 인수로 함수 이름(함수 포인터)를 받을 수 있다.
            // 마치 다형성처럼 델리게이트 매개변수인 clickedFunction에 어떤 함수가 들어오느냐에 따라서 clickedFunction(); 이 한 줄이 다르게 실행될 수 있는 것이다!

            // delegate 객체 생성 및 함수 등록
            // delegate는 등록된 함수들을 캡슐화 하며 객체로서 생성된다.
            // delegate가 메모리를 할당 받아 객체로서 생성되는 순간은 첫 함수가 등록되는 순간부터다. (함수 이름 = 함수 포인터를 넘겨주는 것이나 마찬가지다.)
            // clicked 델리게이트 객체가 생성되고 Test() 함수가 등록되었다.
            // clicked 델리게이트 형식은 매개 변수가 없고 리턴 타입이 int인 함수만 등록될 수 있도록 선언했었기 때문에 delegate int OnClicked(); Test()를 등록하는 것이 가능하다.
            OnClicked clicked = new OnClicked(Test); // 이렇게 객체를 만들어서 쓸수도 있다
            // new 사용 없이 아래와 같이 생성할 수도 있다. (컴파일러가 알아서 new를 붙여 생성해준다.)
            // OnClicked clicked = Test;

            // delegate 객체에 추가로 함수들 등록하기. (함수 이름 = 함수 포인터를 넘겨주는 것이나 마찬가지다.)
            // +, += 더하기 연산자로 추가 등록할 수 있다.
            // 반대로 -, -= 빼기 연산자로 해당 함수를 델리게이트로부터 뺄 수도 있다.(체인 끊기)
            // 아래와 같이 추가로 Test2() 함수를 등록시켜 주었다. 따라서 clicked 델리게이트 객체를 실행시키면 Test1()이 실행된 이후 Test2()가 실행되게 된다.
            clicked += Test2; // chaining, Test2 함수를 추가로 등록하였다.
            // delegate 실행시키기 (대리로 직접 실행하다.)
            // Test1()이 실행된 후 Test2()가 실행되게 된다. 그러나 clicked 델리게이트는 자신에게 등록된 함수와 그 내용에 대해 알지 못한다.
            // 그저 넘겨받은 함수 포인터들을 차례대로 대신 실행시켜줄 뿐이다.
            
            clicked(); // Test1()이 실행된 후 Test2()가 실행되게 된다.
            // 매개 변수가 있는 형식의 델리게이트라면 clicked(1, 2, 3) 이런식으로 실행시키면 된다.
            // 필요한 인수는 델리게이트 실행할 때 넣으면 된다. 이때 clicekd에 등록된 모든 함수들이 인수가 (1, 2, 3)으로 동일하게 실행된다.

            // 즉, delegate를 사용하는 방법은 크게 두가지이다.
            // 1. ButtonPressed(Test); 이 코드처럼 매개변수 타입을 델리게이트로 만든 함수에 호출하고 싶은 함수를 대입.
            // 그대신 델리게이트를 선언할때 반환타입과 매개변수 타입이 같아야 함수를 넣어줄수 있음
            // 2. OnClicked clicked = new OnClicked(Test); 이렇게 델리게이트 객체를 만들어서 호출하고싶은 함수를 대입
            // 추가로, clicked += Test2; 이렇게 추가로 등록하고싶은 함수를 등록하고, clicked(); 이렇게 등록된 함수를 실행 시킬수 있다 

            // -----------------
            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest; // 이벤트에 OnInputTest() 함수를 등록한다.

            while (true)
            {
                inputManager.Update();
            }

            // inputManager.InputKey(); 이런식으로 하면 컴파일 에러! 외부에서 호출 불가능
            // 이벤트를 사용하기 위해 InputManager 타입의 객체를 만들어 inputManager에서 이를 참조한다.
            // 이벤트에 OnInputTest() 함수를 등록한다.
            // inputManager.InputKey += OnInputTest;
            // 여기는 InputManager 클래스의 외부라서 이벤트를 직접 호출하는 것은 불가능하므로(inputManager.InputKey();는 컴파일 에러)
            // 이 이벤트를 호출하는 InputManager의 멤버 함수 inputManager.Update();를 실행시키면 된다!
            // 직접 이 안에서 입력이 들어오면 실행시킬 함수들을 구구절절 나열하고 직접 호출해줄 필요가 없이 inputManager.Update();만 실행시켜주면 땡이다!
            // 결론! 델리게이트와 이벤트는 기능은 동일하나 차이점은 👉 델리게이트와 달리 이벤트는 클래스 외부에서는 이벤트를 호출할 수는 없다는 것이다.
        }
    }
}

