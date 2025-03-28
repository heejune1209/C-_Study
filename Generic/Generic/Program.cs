using System.Collections.Generic;
using System.Threading;

namespace Generic
{
    // Generic
    // 클래스 정의시 여러가지 자료형에 대해 일반화.

    internal class Program
    {
        //class MyintList
        //{
        //    int[] arr = new int[10];

        //    public int GetItem(int i)
        //    {
        //        return arr[i];
        //    }
        //}

        //class MyfloatList
        //{
        //    float[] arr = new float[10];

        //    public float GetItem(int i)
        //    {
        //        return arr[i];
        //    }
        //}

        //class MyMonsterList
        //{
        //    Monster[] arr = new Monster[10];

        //    public Monster GetItem(int i)
        //    {
        //        return arr[i];
        //    }
        //}

        //class Monster
        //{

        //}

        //class MyList
        //{
        //    object[] arr = new object[10];
        //} // 좋지 않은 방법

        // Generic
        // 자료형들을 일반화하여 T 자리에 여러 자료형 타입이 올 수 있게 된다!
        class MyList<T> // 조커카드같은 느낌, c++에 템플릿 문법과 유사
        {
            T[] arr = new T[10];
            public T GetItem(int i)
            {
                return arr[i];
            }

        }
        // 인자 추가
        // 일반화 할 특정 인자가 더 필요하다면 <class MyList <T1, T2> 이런식으로 T말고 추가 문자를 더 써주면 된다. Dictionary 자료구조도 이렇게 Generic 인자를 2개 사용하는 경우다.
        // Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
        class MyList<T1, T2>
        {
            private Dictionary<T2, T1> dict = new Dictionary<T2, T1>();

            public void Add(T2 key, T1 value)
            {
                dict[key] = value;
            }

            public T1 GetItem(T2 key)
            {
                return dict[key];
            }
        }

        // where
        // C#에만 있는 문법으로 특수화를 할 때 사용한다. 구체화할 때 where T : type -> T를 type타입으로만 구체화하도록 제약을 둔다.
        class MyList2<T> where T : Monster // T는 해당 클래스와 해당 클래스의 자식 클래스 타입의 객체여야만 한다.
            // 즉, Monster와 Monster를 상속받는 Orc, Slime 등등의 클래스 타입의 객체로만 구체화될 수 있다.
        {
            // where T : struct 
            // T는 Call by Value 형식어야 한다. int, float, struct 등등..

            // where T : class
            // T는 Call by Reference 형식어야 한다. 모든 클래스, 인터페이스, 대리자 또는 배열 형식에도 적용된다. 따라서 기본 자료형은 들어올 수 없다.

            // where T : new()
            // T는 매개 변수 없는 디폴트 생성자를 반드시 가지고 있어야 한다.
            // where T : Monster, new () 는 Monster타입의 클래스로만 구체화될 수 있으며 구체화될 땐 디폴트 생성자를 호출해야 한다.

            // where T : 특정 클래스 이름
            // T는 해당 클래스와 해당 클래스의 자식 클래스 타입의 객체여야만 한다.

            // where T : 인터페이스 이름
            // T는 명시한 인터페이스를 반드시 구현해야 한다. 인터페이스를 여러개 명시해줄 수도 있다.	

            // where T : U
            // T는 또 다른 형식 매개 변수 U와 일치하거나 U로부터 상속 받은 클래스여야 한다.
        }
        // 함수도 만약에 int형으로도 만들고 싶고, float형으로도 만들고 싶고, 즉, 여기에 어떤 값을 넣더라도 그 타입에 맞게 돌아가는 걸 만들고 싶다면, 아래처럼 해주면 된다.
        static void Test<T>(T input)
        {
            // 이렇게 함수도 일반화할 수 있다.
            // 함수 이름 오른쪽에 <T>만 붙여주고 일반화 할 자료형 자리를 T로 대체해주면 된다. 함수를 호출할 때도 함수 이름 오른쪽에 <T>만 붙여주면 된다.
            // where로 제한도 할 수 있다.
        }

        class Monster
        {

        }

        static void Main(string[] args)
        {
            // Object 👉 int, float 같은 모든 자료형 및 모든 클래스의 조상. (사용자 지정 클래스의 조상도 Object이다.)
            /* 박싱 */
            // object 타입은 기본 자료형들을 비롯한 모든 클래스들의 조상이기 때문에 업 캐스팅 개념으로 int, string 같은 기본 자료형들을 object 하나로 참조할 수 있다.이 과정을 박싱 이라고 한다.
            object obj = 3;
            object obj2 = "Hello World";
            /* 언박싱 */
            int num = (int)obj;
            string str = (string)obj2;
            // 다시 원래 자료형으로 되돌릴 땐 다운 캐스팅 개념으로 형변환 해주면 된다. 이 과정을 언박싱 이라고 한다.

            // 그러면 자료형들을 일반화시킬 때 위와 같이 object를 사용하면 되지 않을까?
            // 그래도 되긴 하지만, 박싱/언박싱 과정은 성능상 느리다. 따라서 비효율적이다.
            // object는 언제나 데이터를 참조하는 방식으로 저장하기 때문이다. 즉, 진짜 데이터는 힙 메모리에 저장되고 변수 obj엔 그 주소가 저장된다.
            int n = 3;
            object obj3 = 3;  // 박싱
            int num2 = (int)obj3; // 언박싱
            // int인 n의 데이터 3은 스택 메모리의 n영역에 직접 저장된다.
            // object인 obj가 참조하는 데이터인 3은 힙 메모리에 저장되며, 스택 메모리의 obj영역엔 이 힙 메모리의 주소가 저장된다.
            // - 박싱 👉 힙 메모리를 할당받는 과정이 필요하므로 성능면에서 깎임.
            // 힙 메모리에 있는 obj가 참조중인 데이터 3을 복사해 가져와 스택 메모리의 num영역에 직접 저장한다.
            // - 언박싱 👉 힙 메모리에 있는 데이터를 빼내어 스택 영역으로 옮기는 과정이 필요하므로 이 역시 성능면에서 깎임.
            // 결론 : object는 박싱 언박싱 과정 때문에 성능이 좋지 않으므로 Generic을 통해 일반화를 한다. Generic은 컴파일 타임에 결정되기 때문에 더 빠르다.

            MyList<int> list = new MyList<int>();
            int item = list.GetItem(0);
            MyList<float> list3 = new MyList<float>();
            MyList<Monster> myList = new MyList<Monster>();

            // Test<int>(item);
        }
    }
}
