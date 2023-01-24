using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class AlienCollection
    {
        private List<Alien> list;

        public AlienCollection()
        {
            list = new List<Alien>();
        }

        public List<Alien> getList() { return list; }

        public void Add(Alien alien)
        {
            list.Add(alien);
        }

        public void Delete(Alien alien)
        {
            list.Remove(alien);
        }

        public int getSize()
        {
            return list.Count;
        }

        public IteratorAliensNormal createIteratorNormal(MoveDirection move, int boardWidth, int boardHeight)
        {
            return new IteratorAliensNormal(list, move, boardWidth, boardHeight);
        }

        public IteratorAliensHalfAliensDoubleSpeed createIteratorHalfAliensDoubleSpeed(MoveDirection move, int boardWidth, int boardHeight)
        {
            return new IteratorAliensHalfAliensDoubleSpeed(list, move, boardWidth, boardHeight);
        }
        public IteratorAliensMoveRight createIteratorMoveRight(MoveDirection move, int boardWidth, int boardHeight)
        {
            return new IteratorAliensMoveRight(list, move, boardWidth, boardHeight);
        }
    }
}
