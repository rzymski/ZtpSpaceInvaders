using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Hard : IDifficultLevel
    {
        public string name { get => "Hard"; }

        public void setDifficultyLevel(Board board)
        {
            board.probabilityAppearanceAlien = 70;
            board.probabilityMutationAlien = 70;
            board.probalityBonusAppearance = 10;
            board.timeBetweenNextWave = 1000;
        }
        public int chooseIterator()
        {
            return 1;
        }
    }
}
