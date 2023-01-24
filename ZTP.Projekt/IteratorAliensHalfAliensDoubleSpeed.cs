using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class IteratorAliensHalfAliensDoubleSpeed : IIterator<Alien>
    {
        private List<Alien> aliens;
        private int pos = 0;
        MoveDirection move;
        int boardWidth;
        int boardHeighth;
        public IteratorAliensHalfAliensDoubleSpeed(List<Alien> aliens, MoveDirection move, int boardWidth, int boardHeight)
        {
            this.aliens = aliens;
            this.move = move;
            this.boardWidth = boardWidth;
            this.boardHeighth = boardHeight;
        }
        public Alien next()
        {
            Alien a = aliens[pos];
            pos++;
            return a;
        }
        public bool hasNext()
        {
            if (pos >= aliens.Count || aliens[pos] == null) 
                return false;
            else
            {
                if (aliens[pos].getStatusToDelete() || aliens[pos].isDead)
                {
                    aliens.Remove(aliens[pos]);
                }
                else
                {
                    if (pos % 2 == 0)
                    {
                        aliens[pos].moveAlien(move, boardWidth, boardHeighth);
                    }
                    else
                    {
                        aliens[pos].moveAlien(move, boardWidth, boardHeighth);
                        aliens[pos].ClearAlien();
                        aliens[pos].moveAlien(move, boardWidth, boardHeighth);
                    }
                }
                return true;
            }
        }
    }
}
