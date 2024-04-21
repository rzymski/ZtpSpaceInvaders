using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public static class Menu
    {
        public static void setResolution(ref int resolutionWidth, ref int resolutionHeight)
        {
            resolutionWidth = Console.WindowWidth = Console.LargestWindowWidth;
            resolutionHeight = Console.WindowHeight = Console.LargestWindowHeight;
            if (resolutionWidth < 160 || resolutionHeight < 65)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 7, Console.LargestWindowHeight / 2 - 2);
                Console.WriteLine("-- Warning --");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 40, Console.LargestWindowHeight / 2 - 1);
                Console.WriteLine("Your screen isn't big enough to match the game's desired width and hight.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 45, Console.LargestWindowHeight / 2);
                Console.WriteLine("Things may not look quite right, unless you adjust the text size in your console window.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 33, Console.LargestWindowHeight / 2 + 1);
                Console.WriteLine($"Required min. resolution 160x65, your actual resolution is " + Console.LargestWindowWidth + "x" + Console.LargestWindowHeight);
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 14, Console.LargestWindowHeight / 2 + 2);
                waitForKey(ConsoleKey.Enter);
                Console.ForegroundColor = ConsoleColor.White;
            }

            int x = Console.LargestWindowHeight;
            while (!((x-3) % 5 == 0))
            {
                x--;
            }
            resolutionHeight = Console.WindowHeight = x;
            //Console.WriteLine(resolutionHeight);
            //Console.ReadKey();
        }

        public static void waitForKey(ConsoleKey expectedKey = ConsoleKey.Home)
        {
            if (expectedKey != ConsoleKey.Home)
            {
                Console.WriteLine($"Press {expectedKey} key to continue.");
                while (Console.ReadKey().Key != expectedKey) { }
            }
            else
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            Console.Clear();
        }

        public static int adjustToCenterText(int startRow, int endColumn, int length)
        {
            return ((endColumn + startRow - length) / 2 > 0) ? ((endColumn + startRow - length) / 2) : 0;
        }

//        public static void drawSubtitle(string text, int startColumn, int startRow, int colorText = 15, int colorBackground = 0)
//        {
//            text = text.ToLower();
//            if (text == "nowa gra")
//            {
//                text = @" _   _                         _____         
//| \ | |                       |  __ \            
//|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _ 
//| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |
//| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |
//|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|";
//            }
//            if (text == "sala chwaly")
//            {
//                text = @" _____         _          _____  _                     _        
///  ___|       | |        /  __ \| |                   | |       
//\ `--.   __ _ | |  __ _  | /  \/| |__ __      __ __ _ | | _   _ 
// `--. \ / _` || | / _` | | |    | '_ \\ \ /\ / // _` ||//| | | |
///\__/ /| (_| || || (_| | | \__/\| | | |\ V  V /| (_| |//|| |_| |
//\____/  \__,_||_| \__,_|  \____/|_| |_| \_/\_/  \__,_||_| \__, |
//                                                           __/ |
//                                                          |___/ ";
//            }
//            if (text == "wyjdz z gry")
//            {
//                text = @" _    _           _      _                                   
//| |  | |         (_)    | |    _                             
//| |  | | _   _    _   __| | _/_/   ____    __ _  _ __  _   _ 
//| |/\| || | | |  | | / _` ||_  /  |_  /   / _` || '__|| | | |
//\  /\  /| |_| |  | || (_| | / /_   / /   | (_| || |   | |_| |
// \/  \/  \__, |  | | \__,_|/___/  /___|   \__, ||_|    \__, |
//          __/ | _/ |                       __/ |        __/ |
//         |___/ |__/                       |___/        |___/ ";
//            }
//            if (text == "space")
//            {
//                text = @"  ____                           
// / ___|  _ __    __ _   ___  ___ 
// \___ \ | '_ \  / _` | / __|/ _ \
//  ___) || |_) || (_| || (__|  __/
// |____/ | .__/  \__,_| \___|\___|
//        |_|                      ";
//            }
//            if (text == "inwaders")
//            {
//                text = @"  ___                         _                  
// |_ _| _ __ __   __ __ _   __| |  ___  _ __  ___ 
//  | | | '_ \\ \ / // _` | / _` | / _ \| '__|/ __|
//  | | | | | |\ V /| (_| || (_| ||  __/| |   \__ \
// |___||_| |_| \_/  \__,_| \__,_| \___||_|   |___/
//                                                 ";
//            }
//            if (text == "")
//                return;

//            Console.SetCursorPosition(startColumn, startRow);
//            Console.BackgroundColor = (ConsoleColor)colorBackground;
//            Console.ForegroundColor = (ConsoleColor)colorText;
//            int counter = 0;
//            for (int i = 0; i < text.Length; i++)
//            {
//                Console.Write(text[i]);
//                if (text[i] == '\n')
//                {
//                    Console.SetCursorPosition(startColumn, startRow + (++counter));
//                }
//            }
//            Console.BackgroundColor = ConsoleColor.Black;
//            Console.ForegroundColor = ConsoleColor.White;
//        }

        public static void clearBoard(int startColumn, int startRow, int height, int width, char c=' ') 
        {
            //Console.SetCursorPosition(startColumn, startRow);
            
            
            for(int i=0; i< height; i++)
            {
                Console.SetCursorPosition(startColumn, startRow+i);
                for (int j=0; j<width; j++)
                    Console.Write(c);
            }
            
            
          //Console.Clear();
        }

        public static void drawRectangle(int startColumn, int startRow, int height, int width, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            Console.SetCursorPosition(startColumn, startRow);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╗");
            Console.SetCursorPosition(startColumn, startRow + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(startColumn, startRow + i + 1);
                Console.Write("║");
                Console.SetCursorPosition(startColumn + width - 1, startRow + i+1);
                Console.Write("║");
            }
            Console.SetCursorPosition(startColumn, startRow + height - 1);
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╝");
        }

        //public static void drawFirstMenu(int startRow = 0, int startColumn = 30, int rectangleLength = 100, int resolutionWidth = 160, int colorNumber = 15)
        //{
        //    int littleHight = 10;
        //    int actualRow = startRow;
        //    int firstColumnToSubtitleCrossAndCircle = (resolutionWidth - 84) / 2;
        //    //Main menu
        //    drawSubtitle("space", firstColumnToSubtitleCrossAndCircle, actualRow, 1);
        //    drawSubtitle("inwaders", firstColumnToSubtitleCrossAndCircle + 33, actualRow, 4);
        //    actualRow += 10;
        //    drawRectangle(startColumn, actualRow, littleHight, rectangleLength, colorNumber);
        //    drawSubtitle("Nowa gra", adjustToCenterText(startColumn, startColumn + rectangleLength, 50), actualRow + 2);
        //    actualRow += littleHight;
        //    drawRectangle(startColumn, actualRow, littleHight, rectangleLength, colorNumber);
        //    drawSubtitle("Sala chwaly", adjustToCenterText(startColumn, startColumn + rectangleLength, 66), actualRow + 1);
        //    actualRow += littleHight;
        //    drawRectangle(startColumn, actualRow, 10, rectangleLength, colorNumber);
        //    drawSubtitle("Wyjdz z gry", adjustToCenterText(startColumn, startColumn + rectangleLength, 62), actualRow + 1);
        //    Console.SetCursorPosition(adjustToCenterText(0, resolutionWidth, 115), actualRow + 12);
        //    Console.WriteLine("Zmieniaj opcje używając strzałek góra/dół lub W/S. Zatwierdź wybraną opcję klikając Enter lub Spację. Miłej gry :)");
        //    Console.SetCursorPosition(0, 0);
        //}

        //public static int chooseOptionFirstMenu(int startColumn = 30, int option = 0, int rectangleLength = 100)
        //{
        //    int startRow = 0, startColumnSubtitle = 0, startRowSubtitle = 0;
        //    string text = "";
        //    ConsoleKey key;
        //    do
        //    {
        //        while (!Console.KeyAvailable)
        //        {
        //            switch (option)
        //            {
        //                case 0:
        //                    startColumnSubtitle = adjustToCenterText(startColumn, startColumn + rectangleLength, 50);//38;
        //                    startRowSubtitle = 12;
        //                    startRow = startRowSubtitle - 2;
        //                    text = "Nowa gra";
        //                    break;
        //                case 1:
        //                    startColumnSubtitle = adjustToCenterText(startColumn, startColumn + rectangleLength, 66);
        //                    startRowSubtitle = 21;
        //                    startRow = startRowSubtitle - 1;
        //                    text = "Sala chwaly";
        //                    break;
        //                case 2:
        //                    startColumnSubtitle = adjustToCenterText(startColumn, startColumn + rectangleLength, 62);
        //                    startRowSubtitle = 31;
        //                    startRow = startRowSubtitle - 1;
        //                    text = "Wyjdz z gry";
        //                    break;
        //            }
        //            drawRectangle(startColumn, startRow, 10, rectangleLength, 4); //4 = red
        //            drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 4);
        //            System.Threading.Thread.Sleep(500);
        //            drawRectangle(startColumn, startRow, 10, rectangleLength, 15); //15 = white
        //            drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 15);
        //            System.Threading.Thread.Sleep(500);
        //        }
        //        key = Console.ReadKey(true).Key;
        //        if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
        //        {
        //            Console.Clear();
        //            Console.SetCursorPosition(0, 0);
        //            return option;
        //        }
        //        else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
        //        {
        //            if (option > 0)
        //                option--;
        //            else
        //                option = 2;
        //        }
        //        else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
        //        {
        //            option = (option + 1) % 3;
        //        }
        //    } while (true);
        //}
    }
}
