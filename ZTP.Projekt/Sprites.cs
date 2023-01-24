using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Sprites
    {
        public static readonly string[] shipString = new string[3] {
            "   ▄   ",
            "  ▄█▄  ",
            " ▀█▀█▀ ",
        };

        public static readonly string[] shipUgradedAttackString = new string[3] {
            "   ▄   ",
            "█ ▄█▄ █",
            "█▀█▀█▀█",
        };

        public static readonly string[] enemy1String = new string[3] {
            " ▀▄ ▄▀ ",
            " █▀█▀█ ",
            " ▐▀▀▀▌ "
        };

        public static readonly string[] enemy2String = new string[3] {
            "  ▐ ▌  ",
            " █▀█▀█ ",
            " ▀▀▀▀▀ "
        };

        public static readonly string[] enemy3String = new string[3] {
            "  ▄█▄  ",
            " █▄█▄█ ",
            " ║╚ ╝║ "
        };

        public static readonly string[] enemy4String = new string[3] {
            "  ▄█▄  ",
            " █▄█▄█ ",
            " ╝║ ║╚ "
        };

        public static readonly string[] enemy5String = new string[3] {
            "  ║ ║  ",
            " ▄▀█▀▄ ",
            " ▀▀█▀▀ "
        };

        public static readonly string[] enemy6String = new string[3] {
            "  ╔ ╗  ",
            " ▄▀█▀▄ ",
            " ▀█▀█▀ "
        };

        public static readonly string[] bonusHealthString = new string[3] {
            " BONUS ",
            " HEALTH",
            "       ",
        };

        public static readonly string[] bonusAmmoString = new string[3] {
            " BONUS ",
            "  AMMO ",
            "       ",
        };

        public static readonly string[] bonusAttackString = new string[3] {
            " BONUS ",
            " Attack",
            "       ",
        };

        public static readonly string[] bonusHealthAttackString = new string[3] {
            " BONUS ",
            " HEALTH",
            " ATTACK",
        };

        public static readonly string[] bonusHealthAmmoString = new string[3] {
            " BONUS ",
            " HEALTH",
            "  AMMO ",
        };

        public static readonly string[] bonusDoubleAmmoString = new string[3] {
            " BONUS ",
            "AMMO x2",
            "       ",
        };

        public static readonly string[] bonusNothingString = new string[3] {
            "  USE- ",
            "  LESS ",
            "  BONUS",
        };

        //public static readonly string[] healthString = new string[6] {
        //    " ♥♥ ♥♥ ",
        //    "♥ ♥ ♥ ♥",
        //    "♥  ♥  ♥",
        //    " ♥   ♥ ",
        //    "  ♥ ♥  ",
        //    "   ♥   "
        //};
    }
}
