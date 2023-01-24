using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Bullet
    {
        public Position position { get; set; } = new Position();
        public char bullerChar { get; set; } = '█';
        public int penetrationValue { get; set; } = 1;
        public Bullet(int x, int y, int penetrationValue)
        {
            position.x = x;
            position.y = y;
            this.penetrationValue = penetrationValue;
        }

        public void moveBullet()
        {
            //uproszczona tymczasowa wersja
            //trzeba zrobic z tego wątek          
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(bullerChar);
           
        }

    }
}
