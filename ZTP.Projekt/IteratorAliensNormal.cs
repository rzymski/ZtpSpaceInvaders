using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class IteratorAliensNormal : IIterator<Alien>
    {
        private List<Alien> aliens;
        private int pos = 0;
        MoveDirection move;
        int boardWidth;
        int boardHeight;
        public IteratorAliensNormal(List<Alien> aliens, MoveDirection move, int boardWidth, int boardHeight)
        {
            this.aliens = aliens;
            this.move = move;
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
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
                    aliens[pos].moveAlien(move, boardWidth, boardHeight);
                }
                return true;
              
                
            }
        }
    }
}
