using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class BonusAmmunition : Bonus
    {
        public int AmmunitionValue { get; set; }
        public BonusAmmunition(IShip ship) : base(ship)
        {
            AmmunitionValue = 10;
        }
        public override int getAmmunition()
        {
            return base.getAmmunition() + AmmunitionValue;
        }
    }
}
