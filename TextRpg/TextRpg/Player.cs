using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType type = PlayerType.None;

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }

        public PlayerType GetPlayerType() { return type; }
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(50, 15);
        }
    }
    // C# 에서는 헤더 파일을 인클루딩할 필요가 없다.
    // C++과 달리 C#에서는 동일한 namespace를 가진 파일들을 알아서 같은 프로젝트 내에서 찾아준다.
    // 따라서 #include "Player.cs" 할 필요가 없다.
    // 부모인 Player 클래스는 단지 여러 직업의 공통적인 요소들을 모아두는 용도로 사용할 것이기 때문에
    // Player 타입의 객체는 외부에서 생성하지 못 하도록(쓸모 없으니까) 생성자는 protected로 접근 제한해두었다.
    // 반면 자식 클래스들은 직접 외부에서 객체로 생성할 것이기 때문에 생성자를 public으로 해둔다.
}
