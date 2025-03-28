using System.Collections.Generic;

namespace List
{
    // List(동적 배열 = 가변적 크기의 배열)
    // C#에서의 List 👉 동적 배열! 크기가 고정적이지 않으며 가변적이다. C++에서 vector같은 존재.

    // using System.Collections.Generic;을 해주어야 사용이 가능하다.
    // 얘도 클래스이기 때문에 List 타입의 객체를 생성하면 참조를 하게 된다는 의미가 된다.
    // 그래서 new를 사용하여 생성해야 함.
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(); // 빈 상태
            // 빈 상태일 때 없는 인덱스에 접근하면 런타임 에러 예외가 발생한다.
            // 이건 정적배열도 마찬가지.
            // 중간 삽입, 중간 삭제가 효율적이지 않다.
            // 뒤에 있는 원소들이 전부 다 한 칸씩 밀리거나 앞으로 땡겨야 하기 때문이다. 그 과정에서 사본을 생성해야 하는 일도 발생.
            // 대신 임의 접근은 굉장히 빠르다. 인덱스로 접근하기 때문에! 배열의 특징.
            // 하지만 검색은 느림 (O(n))

            // Count : 크기 리턴 (리스트 길이)
            // 함수 아니고 프로퍼티다.
            for (int i = 0; i < list.Count; i++)
            {
                list.Add(i); // 0 1 2 3 4
            }
            // 삽입 삭제
            // Add : 맨 끝에 삽입
            list.Add(3); // 0 1 2 3 4 3
            // Insert : 중간에 삽입
            list.Insert(2, 999); // 인덱스2 자리에 원소 999 추가 👉 0 1 999 2 3 4 3

            // Remove : 원소로 search 하여 삭제
            list.Remove(3);  // 0 1 999 4 3 
            // 인수로 넘긴 값과 동일한 값들이 있을 수 있지만 가장 처음 만난 값을 삭제한다.
            // 그리고 삭제에 성공하면 True 리턴, 해당 원소를 찾지 못했다면 False 리턴. bool타입을 리턴한다.

            // RemoveAt : 인덱스로 삭제
            list.RemoveAt(0);  // 1 999 3 4
            // 인수로 넘긴 인덱스에 해당하는 원소를 삭제한다.

            // Clear : 원소 전부 삭제하여 리스트 비우기
            //list.Clear();  // 리스트 내의 모든 원소를 싸그리 지운다.
            for (int i = 0;i < 5; i++)
                Console.WriteLine(list[i]);            
        }
    }
}
