using System;
using System.Collections.Generic;
namespace Exception
{
    // Exception
    // 예외 처리
    // 게임에선 예외처리를 잘 하지 않는 편이다. 그냥 크래쉬 된 체로 냅두고 문제가 되는 코드 자체를 나중에 수정하는게 보통이다.
    // 예외처리가 큰 의미가 없기 때문이다. 그래도 게임이라도 네트워크 오류 같은 문제는 예외 처리가 필요함!
 
    // 예외가 발생하는 상황 예시
    // 1. 0 으로 나눌 때
    // 2. 잘못된 메모리를 참조할 때
    // 3. 오버플로우 등등…
    internal class Program
    {
        // 사용자 지정 예외 클래스와 throw
        // 예외 클래스 정의
        // Exception을 상속 받는 예외 클래스를 직접 만들 수도 있다
        //class TestException : Exception  // 사용자 정의 예외
        //{

        //}

        static void TestFunc()
        {
            // 이렇게 정의해둔 후, 어떤 상황에선 내가 만든 예외 클래스 타입의 객체가 던져지도록 할 수 있다. throw를 사용.
            // catch (TestException e) 혹은 catch (Exception e)에서 이를 처리할 수 있다.
            // 이렇게 함수 안에서도 던질 수 있다. 꼭 try문 안에서만 가능한 것은 아니다.
            //throw new TestException();  // 함수 안에서 던져도 잡아준다. 
        }
        static void Main(string[] args)
        {
            // 1. try-catch
            // try내부에서 예외가 발생하면 catch에게 예외 상황을 던져주고, 해당 예외 상황과 대응되는 catch가 이를 받아 예외 처리를 한다.
            try
            {
                int a = 10;
                int b = 0;
                int result = a / b;

                int c = 0; // 실행 X 
            }
            catch (DivideByZeroException e)
            {

            }
            //catch (Exception e)  // 실행 X 
            //{
            
            //}
            // try문 내에서는 예외가 발생하면 해당 예외를 자동으로 던져준다.
            // try문 내에서 0 으로 나누는 예외가 발생했기 때문에 DivideByZeroException 예외 객체가 생성되어 던져지고 catch (DivideByZeroException e) 에서 이를 받아 예외처리를 한다.
            // 위 catch에서 예외 처리를 했기 때문에 catch (Exception e)는 실행 되지 않는다.

            // Exception 클래스
            // Exception은 모든 종류의 예외 클래스들의 조상이다. 따라서 모든 예외를 다 받을 수 있다.
            // 위와 같이 순서를 바꾸면 모~~~든 예외를 catch (Exception e)에서 다 처리할 수 있기 때문에 catch (DivideByZeroException e)는 절대 쓰일일이 없다는 것을 컴파일 타임에도 알 수 있다.
            // 따라서 이렇게 순서를 바꾸면 catch (DivideByZeroException e)에 컴파일 오류가 발생한다.
            {
                try
                {
                    int a = 10;
                    int b = 0;
                    int result = a / b; // 예외 발생

                    int c = 0; // 실행 X 
                }
                //catch (Exception e)
                //{

                //}
                catch (DivideByZeroException e)  // ❌❌ 컴파일에러
                {

                }
            }
            // finally
            //try
            //{
            //    int a = 10;
            //    int b = 0;
            //    int result = a / b;

            //    int c = 0; // 실행 X 
            //}
            //catch (Exception e)
            //{

            //}
            // 예외가 int result = a / b;에서 발생하기 때문에 예외 객체가 던져져 catch (Exception e)을 실행하게 되고
            // 예외가 발생한 곳 아래에 있는 int c = 0;는 다시는 실행되지 않는다. 예외가 발생하면 예외 처리 후 다시 돌아와서 코드를 진행하는 것이 아니라
            // 그냥 예외 처리 후 프로그램이 종료가 되기 때문이다.

            // 그래서
            //try
            //{
            //    int a = 10;
            //    int b = 0;
            //    int result = a / b;

            //    int c = 0; // 실행 안 됨

            //    throw new TestException();
            //}
            //catch (Exception e)
            //{

            //}
            //finally  // 예외가 발생해도 무조건 실행되야 하는 코드
            //{

            //}
            // DB나 네트워크나 예외가 발생하더라도 무조건 실행이 되야 하는 부분은 finally문 안에 명시하면 된다.
            // finally문은 예외가 발생하여도 실행되는 부분이다. int c = 0;가 꼭 실행되야 하는 코드라면 finally 안에다가 쓰면 된다.

            
        }
    }
}
