using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Observer : IObserver
    {
        private Alien alien;

        public Observer(Alien alien)
        {
            this.alien = alien;
        }

        public void updateAlienStatus(int howMuchHpAllienLost)
        {
            alien.Hp -= howMuchHpAllienLost;

            if (alien.Hp <= 0 )
            {
                alien.isDead = true;
                alien.setStatusToDelete();
                alien.ClearAlien();
            }

            Board b = Board.getInstance();
            b.Score += alien.pointsForKill;
        }
    }
}
