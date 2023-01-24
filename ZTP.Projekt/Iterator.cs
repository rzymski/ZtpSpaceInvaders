using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public interface IIterator<T> where T : class
    {
        public T next();
        public bool hasNext();
    }
}
