using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public interface IAlienFactory
    {
        public IAlien createAlien();
    }
}