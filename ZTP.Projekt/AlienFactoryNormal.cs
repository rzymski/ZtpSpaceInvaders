using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class AlienFactoryNormal : IAlienFactory
    {
        private string alienType;
        public AlienFactoryNormal()
        {
            alienType = "Normal Alien";
        }
        public IAlien createAlien()
        {
            var alien = new Alien(alienType);
            alien.Sprite = Sprites.enemy1String;
            alien.ColorValue = 2; //ConsoleColor.DarkGreen
            alien.Hp = 1;
            alien.pointsForKill = 1;
            Observer ob = new Observer(alien);
            alien.attach(ob);
            return alien;
        }
    }
}
