using System.Collections.Generic;
namespace Dictionary
{
    // Dictionary
    // dic[Key] = Value 👉 Key를 통하여 접근하여 그에 대응하는 Value를 불러올 수 있다.
    // using System.Collections.Generic;을 해주어야 사용이 가능하다.
    // 얘도 클래스이기 때문에 Dictionary 타입의 객체를 생성하면 참조를 하게 된다는 의미가 된다.
    // new를 사용하여 생성해야 함.
    // 해시 테이블을 사용하기 때문에 검색이 매우 빠르다. O(1) (리스트, 배열처럼 순차 검색(O(n)) 안 해도 됨)
    // 공간을 미리 많이 차지하고 있기 때문에 공간 면에선 비효율적일 수 있다.
    // 메모리를 내주고 성능을 취한다.

    class Monster
    {
        public Monster(int id) { this.id = id; }
        public int id;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            // Dictionary
            // key -> value
            // Dictionary<TKey, TValue>

            // 추가
            // dic.Add(1, new Monster(2));
            // dic[2] = new Monster(3); // key 2가 새롭게 생김. dic[Key] = Value
            // 추가 방법
            // 1. Add 사용
            // - Add(Key, Value)
            // 2. [] 사용
            // - 기존에 없는 Key에 Value 를 대입해도 추가가 된다.

            // 값 가져오기
            for (int i = 0; i < 10000; i++)
            {
                dic.Add(i, new Monster(i));
            }

            Monster mon = dic[5000];
            Monster mon2 = dic[10001]; // error. 10001는 없는 Key이기 때문에 리턴 값이 없다. 따라서 런타임 에러 발생.
            Monster mon3;
            bool found = dic.TryGetValue(154, out mon3); // ⭕ mon3에 154 키에 해당하는 값이 저장된다.
            // Value 가져오는 방법
            // 1. [] 사용
            // - 없는 Key로 접근하여 Value를 받아오려 할 경우 런타임 에러가 발생할 수 있다.
            // 2. TryGetValue(Key, out)
            // - 해당 Key가 Dictionary에 존재한다면 Value를 out 키워드 붙은 변수에 저장하고 (원본 저장, 참조) True를 리턴한다.
            // - 해당 Key가 Dictionary에 존재하지 않는다면 False를 리턴하고 mon 변수는 null 상태로 남을 것이다.

            // 삭제
            dic.Remove(7);  // 해당 key에 해당하는 정보 삭제.
            // dic.Clear(); // 전부 클리어.

            // 검색
            if (dic.ContainsKey(3))
                Console.WriteLine("3 Key가 존재합니다");
            // ContainsKey(Key)
            // 해당 키가 Dictionary 안에 있다면 True, 없다면 False.
        }
    }
}
