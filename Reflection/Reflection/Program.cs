﻿using System;
using System.Collections.Generic;
using System.Reflection;
namespace Reflection
{
    // Reflection
    // 리플렉션을 사용하면 X-Ray 찍는 것과 같이 객체의 이름, 모든 멤버, 이벤트 목록 등등 객체의 세세한 정보들까지 객체의 모~~~~~든 정보를 런타임 중에 가져와 분석하고 사용할 수 있다.
    // C++엔 없고 C#에만 있는 기능이다. 그래서 C#을 사용하는 유니티에선 실행 중에도 멤버에 무엇이 있는지를 체크하고 이에 접근할 수 있는 UI를 열어 주는 등등 C#의 리플렉션 기능을 활용한다.
    // 언리얼은 리플렉션 기능이 없는 C++을 사용하기 때문에 리플렉션을 모방하는 방식으로
    // 리플렉션을 위한 매크로 함수를 멤버나 함수 등등에 붙이고 이 정보를 가지고 파싱하고 따로 기록하여 리플렉션 하는 방식을 취한다고 한다.
    //.NET Reflection은.NET 객체의 클래스 타입, 메서드, 프로퍼티 등의 메타 정보를 런타임 중에 알아내는 기능을 제공한다.
    // 또한, 이러한 메타 정보를 얻은 후, 직접 메서드를 호출하거나 프로퍼티를 변경하는 등의 작업도 가능하다.
    // 물론 객체에서 메서드를 직접 호출하는 경우가 더 빠르겠지만, 어떤 경우는 런타임중에 이런 메타 정보가 동적으로 알아낼 필요가 있다.
    // 예를 들어, 테스트 어셈블리에 있는 테스트 클래스들의 Public 메서드를 선별해서 이를 동적으로 호출하는 경우라든가,
    // 특정 클래스 안에 지정된 이름의 멤버가 있는지 판단하는 경우 등등에 .NET Reflection이 활용될 수 있다.
    class Program
    {
        // 사용자 지정 Attribute
        // 사용자 지정 Attribute 을 만드려면 System.Attribute을 상속받는 클래스를 만들면 된다. Important라는 이름의 Attribute를 만들었다.
        class Important : System.Attribute
        {
            string message;

            public Important(string message) { this.message = message; }
        }
        class Monster
        {
            [Important("Very Important")]
            public int hp;
            // hp멤버 변수에 Important Attribute를 붙여주었다.
            // hp에 추가적인 데이터를 덧붙여 주었고 이를 컴퓨터가 런타임에 알 수 있다!
            // hp 멤버 변수는 “Very Important”라는 문자열이 담긴 message를 추가적으로 담고 있다.

            protected int attack;
            private float speed;

            void Attack() { }
        }

        static void Main(string[] args)
        {
            Monster monster = new Monster();
            Type type = monster.GetType(); // 타입을 가져온다
            // 모~든 객체들은 Object 클래스를 상속받는다. 그래서 모든 객체들은 위 사진과 같은 Object에서 가지고 있는 함수들을 상속 받아 가지고 있다.
            // Object 클래스의 GetType() 함수
            // 👉 해당 객체의 정보를 담은 Type을 반환한다. 리턴 받은 이 Type을 통해 GetType()을 호출한 객체의 모든 세세한 정보들을 다 알 수 있다

            // GetType() 과 typeof 의 차이
            //typeof(Monster);
            //enum Temp { }
            //typeof(Temp);
            //typeof(int);
            
            // GetType()
            // 런타임 시점. Object를 상속받는 객체 인스턴스의 Type을 알려준다.
            // typeof
            // 컴파일 시점. 클래스 자체의 Type을 알려준다.

            // monster가 참조하는 객체에 대한 정보들을 보고싶어요
            FieldInfo[] fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);
            // Type 클래스의 GetFields 함수
            // 현재 type에는 monster가 참조하는 객체의 모든 정보가 들어있다.
            // type은 객체의 여러가지 정보를 열람할 수 있는 함수와 프로퍼티를 가지고 있다. 멤버 변수(=필드)들의 정보를 배열로 리턴하는 GetFields() 함수,
            // 객체의 생성자 목록을 배열로 리턴하는 GetConstructors() 함수, 멤버 함수들의 목록을 리턴하는 GetMethods() 함수 등등 정말 수~~~많은 함수들을 가지고 있다.
            // 👉 GetFields 함수는 해당 객체의 멤버 변수(=필드)들을 FieldInfo 타입의 배열로 리턴한다. FieldInfo타입은 해당 멤버 변수의 정보를 담은 클래스다.
            // 각각의 원소에는 멤버 변수 + 그의 정보가 각각 들어간다. (C# 문서에서 보니 원소의 순서는 꼭 멤버 변수가 선언된 순서와 일치하는 것은 아니라고 한다.)
            // GetFields() 👉 매개 변수 없다면 자동으로 모든 public 멤버 변수(=필드)들의 정보(FieldInfo타입 객체)를 FieldInfo 타입의 배열에 담아 리턴한다.
            // GetFields(BindingFlags 매개변수들) 👉 제약된 조건으로 검색한다. 매개 변수들은 BindingFlags으로 비트플래그로 추정된다.
            // | 혹은 & 비트연산자들을 통해 검색할 조건들을 종합적인 플래그로서 전달할 수 있다.
            // 아래의 코드 같은 경우, Public이거나 NonPublic이거나 Static이거나 Instance(메모리를 차지하는 인스턴스 멤버)인 조건에 해당하는 멤버 변수들의 정보(FieldInfo)를 fields 배열에 담는다.
            // BindingFlags 종류는 공식 문서 참고

            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";

                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
                // FieldInfo 타입의 객체 또한 해당 멤버 변수의 정보를 열람할 수 있는 여러 함수와 프로퍼티들을 가지고 있다.
                // IsPublic : 해당 멤버 변수가 public이면 True
                // IsPrivate : 해당 멤버 변수가 private이면 True
                // field.FieldType.Name : 해당 멤버 변수의 자료형 이름
                // field.Name : 해당 멤버 변수의 이름
            }
            // Attribute
            var attributes = fields[0].GetCustomAttributes(); // "Very Important"
            // Attribute 👉 특정 멤버나 클래스나 함수 등등에 추가적인 메타 데이터를 붙여 줌.
            // 어떤 Attributes 를 클래스나 멤버 혹은 함수 등등에 적용하려면 적용하려는 대상의 바로 윗줄에 [Attribute 이름]을 써주면 된다.
            // 주석은 개발자가 참고하기 위해 사용하는 것이며 런타임 때는 전혀 고려되지 않는다.
            // 이와 달리 Attribute는 컴퓨터가 런타임에 참고하기 위해 사용되는 주석과 같은 존재이며
            // 컴퓨터가 런타임에 중에도 Attribute가 붙은 대상을 체크하여 그에 관한 작업을 한다.
            // 유니티에서 주로 사용하는 Attribute 로는 [SerializedField]가 있는데,
            // 이 Attribute를 위에 써 준 멤버 변수는 private이더라도 유니티에서 UI를 열어주는 멤버 변수라고 유니티에게 추가 정보를 주는 것과 같다.
            // 특정 멤컴퓨터에게 하나 이상의 추가적인 메타 데이터(Attribute)를 알려주는식이다.
        }
    }
}
