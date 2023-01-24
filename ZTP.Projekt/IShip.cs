using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public interface IShip
    {
        public string[] changeShip();
        public int getAmmunition();
        public int getHp();
        public int getAttack();
    }
}
