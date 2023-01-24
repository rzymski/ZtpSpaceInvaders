using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class BonusHp : Bonus
    {
        public int HpValue { get; set; }
        public BonusHp(IShip ship) : base(ship)
        {
            HpValue = 1;
        }

        public override int getHp()
        {
            if(base.getHp() == 3)
                return base.getHp();
            else return base.getHp() + HpValue;

        }
    }
}
