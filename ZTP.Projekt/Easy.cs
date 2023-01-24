using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Easy : IDifficultLevel
    {
        public string name { get => "Easy"; }

        public void setDifficultyLevel(Board board)
        {
            board.probabilityAppearanceAlien = 30;
            board.probabilityMutationAlien = 30;
            board.probalityBonusAppearance = 30;
            board.timeBetweenNextWave = 2000;          
        }

        public int chooseIterator()
        {
            return 0;
        }
    }
}
