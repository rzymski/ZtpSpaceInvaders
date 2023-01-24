using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public interface IDifficultLevel
    {
        string name { get;}
        public void setDifficultyLevel(Board board);
        //public void setDifficultyLevel(int probabilityMutationAlien, int probabilityAppearanceAlien, int probalityBonusAppearance, int timeBetweenNewWave);
        public int chooseIterator();
    }
}
