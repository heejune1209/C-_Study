namespace Lambda
{
    // Lambda
    // 익명 함수
    // 익명의 일회용 함수를 만드는데 사용하는 문법

    // 익명 함수가 필요한 이유
    enum ItemType // 아이템 타입
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }

    enum Rarity // 레어한 정도
    {
        Normal,
        Uncommon,
        Rare,
    }

    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }
    internal class Program
    {
        //static Item FindWeapon()
        //{
        //    foreach (Item item in _items)
        //    {
        //        if (item.ItemType == ItemType.Weapon)
        //            return item;
        //    }
        //    return null;
        //}

        //static Item FindRareItem()
        //{
        //    foreach (Item item in _items)
        //    {
        //        if (item.Rarity == Rarity.Rare)
        //            return item;
        //    }
        //    return null;
        //}
        delegate bool ItemSelector(Item item);
        // 델리게이트 일반화
        delegate Return MyFunc<T, Return>(T item); // 형식 일반화
        // Return으로 반환타입을 일반화하고, Generic으로 매개변수 타입을 일반화.
        // 델리게이트만의 제네릭 방식인듯        
        // 이러면 대신 실행시켜줄 함수들의 반환타입과 매개변수 타입을 일일이 델리게이트를 만들 필요가 없고, 하나로 일반화 시켜서 만들어줄수 있다.
        // 근데 인수의 개수까지 일반화 시켜줄순 없는듯

        //static bool IsWeapon(Item item)
        //{
        //    return item.ItemType == ItemType.Weapon;
        //}
        
        // 델리게이트 일반화
        static Item FindItem(MyFunc<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }
        static Item FindItem(Func<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }

        //static Item FindItem(ItemSelector selector) 
        //{
        //    foreach (Item item in _items)
        //    {
        //        if (selector(item))
        //            return item;
        //    }
        //    return null;
        //}
        // 리턴타입은 bool, 매개 변수는 Item인 함수들을 등록할 수 있는 ItemSelector 델리게이트를 만든다.
        // ItemSelector 델리게이트를 인수로 받는 함수 FindItem를 정의한다.
        // ItemSelector 델리게이트에 어떤 함수가 등록되느냐에 따라 if (selector(item)) 이 한 줄이 다르게 기능한다.
        // 아이템이 무기 타입이라면 true를 리턴하는 IsWeapon 함수를 FindItem 함수의 매개 변수(델리게이트)에게 넘기면 FindItem 무기인 아이템을 리턴하는 기능으로 동작하게 되서 편하다.
        // 그러나 여전히 불편한 점이 있다. 만약 FindItem 아이템 찾는 행동을 한 두번밖에 안할거라면 이 한두번을 위해서 IsWeapon, IsArmor 같은 여러가지 함수를 또 만들어야 한다.
        // FindItem 함수에 필요한 델리게이트에 등록해야하기 때문이다. 한 두번 밖에 안쓸건데 이 한번 때문에 여러가지 함수를 정의해놔야 하는게 비효율적이다.
        // 함수를 정의해두지 않고 그냥 익명 함수로서 인수로 넘기면, 즉 일회용으로 잠깐 쓰고 버릴 함수로서 인수에서만 정의해서 넘기면 더 편할 것이다. 함수를 일일이 정의할 필요가 없기 때문이다.
        // 이때 람다를 사용.


        static List<Item> _items = new List<Item>();


        static void Main(string[] args)
        {
            // 아이템 생성
            // 아래와 같이 익명 객체를 만들어 리스트 원소들로서 넣어줄 수 있다.
            // 익명 객체를 생성함과 동시에 new Item(), 중괄호 {}로 객체의 멤버 변수들을 초기화 시켜줄 수도 있다. C#에서 가능한 문법인듯 하다. (중괄호 초기화)
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal }); 
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            /*
            Item item1 = new Item();                    // 객체 생성
            item1.ItemType = ItemType.Weapon;           // 멤버 변수 초기화
            item1.Rarity = Rarity.Normal;
            _items.Add(item1);                          // 리스트에 추가

            Item item2 = new Item();
            item2.ItemType = ItemType.Armor;
            item2.Rarity = Rarity.Uncommon;
            _items.Add(item2);

            Item item3 = new Item();
            item3.ItemType = ItemType.Ring;
            item3.Rarity = Rarity.Rare;
            _items.Add(item3);
            */
            // 위에 3줄을 이렇게 나눠서 선언 및 초기화하면 이렇다

            // 특정 타입의 아이템을 찾기 위해선
            // FindWeapon(), FindRareItem() 등등 이런 함수들을 아이템 종류별로 여러개 정의해야 한다.
            // for문을 돌려 해당 타입의 아이템을 찾으면 리턴해주는 내용도 다 비슷하다.
            // 아이템 종류가 수십가지 백가지라면 아이템 종류마다 이런 함수들을 다 만들어 주어야 하므로 너무 비효율적이다.

            //Item item = FindItem(IsWeapon); 
            // delegate를 이용, 하지만 FindItem 아이템 찾는 행동을 한 두번밖에 안할거라면 이 한두번을 위해서 IsWeapon, IsArmor 같은 여러가지 함수를 또 만들어야 한다.
            //Item item = FindWeapon();
            //Item item2 = FindRareItem();

            // 익명 함수(람다식 x)의 사용
            // Anonymous Function

            // 일단 익명함수 선언 문법
            // 이 자리에 "그때그때 쓸 함수"를 정의
            // delegate (매개변수) { 함수내용 }
            // ex) delegate (Item i) { return i.ItemType == ItemType.Weapon; }

            // 1. delegate를 변수로 선언하고 그 변수로 익명 함수 참조하게 하기
            // 인수로 전달
            //Item item = FindItem(delegate (Item i) { return i.ItemType == ItemType.Weapon; });  // 익명함수 문법, 델리게이트 타입에 맞는 "익명 함수"를 바로 인자로 넘기고 있는 거야.
            // 인수로 전달 X (위의 한줄을 아래로 쪼개기)
            ItemSelector itemSelector = delegate (Item i)
            {
                return i.ItemType == ItemType.Weapon;
            };
            // 당연히 전달하려는 델리게이트의 형식과 익명 함수의 형식은 같아야 한다. 델리게이트 ItemSelector 형식은 Item타입의 인수를 받고 bool 타입을 리턴하는 함수다.
            // 익명 함수도 이와 같은 형식이어야 한다. 익명 함수를 델리게이트에 전달할 때는 delegate (익명 함수의 매개 변수 선언) { 익명 함수 내용 } 형태로 넘기면 된다.
            // 위 코드에선 무기 타입의 아이템이면 True 를 리턴하는 기존 IsWeapon와 동일한 내용을 가지는 익명 함수를 만들었다.
            // FindItem() 함수는 ItemSelector 타입을 인자로 받기 때문에 익명 함수가 "자동으로" ItemSelector로 변환돼서 전달되는 거야!

            // 2. 람다식 사용 (람다는 익명 함수의 간결한 문법)
            //Item item2 = FindItem((Item i) => { return i.ItemType == ItemType.Weapon; }); // lambda
            ItemSelector itemSelector2 = (Item i) => { return i.ItemType == ItemType.Weapon; };
            // 혹은 ItemSelector selector = new ItemSelector((Item i) => { return i.ItemType == ItemType.Weapon; }); // 델리게이트 객체를 만들고 람다식을 대입
            // Item item3 = FindItem(selector); // 아이템을 찾는다면 델리게이트 객체를 넣어준다
            // 익명 함수를 람다식으로 정의할 수도 있다.
            // (익명 함수의 매개변수 선언) => { 익명함수 내용 } 으로 만들 수 있다. 이게 람다식이다!
            // 마찬가지로 익명함수는 전달하려는 델리게이트와 형식이 동일해야 한다.

            // 델리게이트 일반화
            MyFunc<Item, bool> selector = new MyFunc<Item, bool>((Item i) => { return i.ItemType == ItemType.Weapon; });
            Item item4 = FindItem(selector);
            // delegate도 일반화(Generic) 할 수 있다. 델리게이트 MyFunc는 리턴 타입 Return도 일반화 하였고 매개 변수의 타입 T도 일반화 한 델리게이트라고 볼 수 있다.
            // selector 델리게이트를 생성함과 동시에 (Item i) => { return i.ItemType == ItemType.Weapon; } 를 수행하는 익명 함수를 람다식으로 등록하였다.
            // 이러면 대신 실행시켜줄 함수들의 반환타입과 매개변수 타입을 일일이 델리게이트를 만들 필요가 없고, 하나로 일반화 시켜서 만들어줄수 있다.

            // Func
            // 미리 C# 내에서 선언이 되어 있는 델리케이트로, 리턴 타입이 존재하는 함수만을 등록할 수 있는 제네릭 델리게이트이다.
            // C# 에서 지원하는 델리게이트기 떄문에 직접 제네릭 델리게이트를 선언할 필요가 없다. 무조건 리턴 타입이 존재하는 함수만 등록할 수 있다. 익명 함수 뿐만 아니라 일반 함수도 등록할 수 있다.
            Func<Item, bool> selector1 = (Item i) => { return i.ItemType == ItemType.Weapon; };
            Item item5 = FindItem(selector1);
            // Func<매개변수1의타입, 매개변수2의타입, ...> 으로 구체화하면 된다.

            // Action
            // 미리 C# 내에서 선언이 되어 있는 델리케이트로, 리턴 타입이 없는 함수만을 등록할 수 있는 제네릭 델리게이트이다.
            // 리턴 타입이 없는 함수만 등록할 수 있다는 것 말고는 Func와 동일하다.
            Action<Item> selector2 = (Item i) => { Console.WriteLine(i.ItemType == ItemType.Weapon); };
            //Action < 매개변수1의타입, 매개변수2의타입, ...> 으로 구체화하면 된다.

            // delegate를 직접 선언하지 않아도, 이미 만들어진 애들이 존재한다.
            // -> 반환타입이 있을경우 Func
            // -> 반환타입이 없을경우 Action

            //public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
            //{
            //    UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

            //    switch (type)
            //    {
            //        case Define.UIEvent.Click:
            //            evt.OnClickHandler -= action; // 혹시나 이미 있을까봐 빼줌
            //            evt.OnClickHandler += action;
            //            break;
            //        case Define.UIEvent.Drag:
            //            evt.OnDragHandler -= action; // 혹시나 이미 있을까봐 빼줌
            //            evt.OnDragHandler += action;
            //            break;
            //    }
            //}
            // 1. 액션(이벤트)에 액션(이벤트)을 더하는 것도 가능하다.
            // 2. 만약 이벤트에 해당 함수가 없는데도 빼려하는건 에러 안난다. 그냥 무시될 뿐!
            // - OnClickHandler에 action이 없더라도 빼는게 에러가 안난다. 그냥 무시된다.
            // - 만약 action이 OnClickHandler에 이미 등록되어 있다면 제거될 것이다.

        }
    }
}
