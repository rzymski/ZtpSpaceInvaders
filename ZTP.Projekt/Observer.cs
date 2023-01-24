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

        public void updateAlienStatus()
        {
            if(alien.Hp <= 1 )
            {
                alien.isDead = true;
                alien.setStatusToDelete();
                alien.ClearAlien();
                //Console.WriteLine("IF "+alien.Hp.ToString()+"\n");
            }
            else
            {
                //Console.WriteLine("ELSE " + alien.Hp.ToString() + "\n");
                alien.Hp--;
            }
            //Console.WriteLine(alien.Hp.ToString() + "\n");
            //Console.ReadKey();

            Board b = Board.getInstance();
            b.Score += alien.pointsForKill;
        }
    }
}
