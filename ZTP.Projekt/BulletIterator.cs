using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class BulletIterator : IIterator<Bullet>
    {
        private List<Bullet> _bullets;

        int pos = 0;

        public BulletIterator(List<Bullet> bullets)
        {
            _bullets = bullets;
        }

        public bool hasNext()
        {
            if (pos < _bullets.Count || _bullets[pos] == null) return false;
            else return true;
        }

        public Bullet next()
        {
            Bullet bullet = _bullets[pos];
            pos++;
            return bullet;
        }
    }
}
