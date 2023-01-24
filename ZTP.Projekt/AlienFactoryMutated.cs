using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class AlienFactoryMutated : IAlienFactory
    {
        private string alienType;
        public AlienFactoryMutated()
        {
            alienType = "Mutated Alien";
        }
        public IAlien createAlien()
        {
            var alien = new Alien(alienType);
            alien.Sprite = Sprites.enemy2String;
            alien.ColorValue = 4; //ConsoleColor.DarkRed
            alien.Hp = 3;
            alien.pointsForKill = 5;
            Observer ob = new Observer(alien);
            alien.attach(ob);
            return alien;
        }
    }
}
