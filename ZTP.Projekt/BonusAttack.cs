using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class BonusAttack : Bonus
    {
        public int AttackValue { get; set; }
        public BonusAttack(IShip ship) : base(ship)
        {
            AttackValue = 1;
        }
        public override string[] changeShip()
        {;
            return Sprites.shipUgradedAttackString;
        }

        public override int getAttack()
        {
            return base.getAttack() + AttackValue;
        }
    }
}
