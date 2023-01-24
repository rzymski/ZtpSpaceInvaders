using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Mid : IDifficultLevel
    {
        public string name { get => "Mid"; }

        public void setDifficultyLevel(Board board)
        {
            board.probabilityAppearanceAlien = 50;
            board.probabilityMutationAlien = 50;
            board.probalityBonusAppearance = 20;
            board.timeBetweenNextWave = 1500;
        }

        public int chooseIterator()
        {
            return 1;
        }
    }
}
