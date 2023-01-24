using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public abstract class Bonus : IShip
    {
        protected IShip ship;
        public Position Position { get; set; } = new Position();
        public string[] Sprite { get; set; }
        public int ColorValue { get; set; }

        public Bonus(IShip ship)
        {
            this.ship = ship;
        }
        public virtual string[] changeShip()
        {
            return ship.changeShip();
        }
        public virtual int getAmmunition()
        {
            return ship.getAmmunition();
        }

        public virtual int getHp()
        {
            return ship.getHp();
        }

        public virtual int getAttack()
        {
            return ship.getAttack();
        }
    }
}
