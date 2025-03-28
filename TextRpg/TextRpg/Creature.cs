using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        CreatureType type;  // private
        protected int hp = 0;
        protected int attack = 0;

        protected Creature(CreatureType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHP() { return hp; }
        public int GetAttack() { return attack; }

        public bool IsDead() { return hp <= 0; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
