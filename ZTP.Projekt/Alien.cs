using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Alien : IAlien
    {
        public int Hp { get; set; }
        //public int PosX { get; set; }
        //public int PosY { get; set; }
        public Position Position { get; set; } = new Position();
        public string[] Sprite { get; set; }
        public int ColorValue { get; set; }
        private bool statusToDelete = false;
        private Observer observer { get; set; }

        public bool isDead { get; set; } = false;

        public int pointsForKill { get; set; }

        public Alien(string alienType)
        {
            //Position = new Position(positionColumn, positionRow);
        }

        public void moveAlien(MoveDirection moveDirection, int BoardWidth, int BoardHight)
        {
            Console.ForegroundColor = (ConsoleColor)ColorValue;
            for (int i = 0; i < Sprite.Length; i++)
            {
                if (moveDirection == MoveDirection.Left)
                {
                    //tylko raz zmienic obecną pozycję
                    if (i == 0)
                    {
                        Position.x -= Sprite[i].Length;
                        if (Position.x - Sprite[i].Length < 0) Position.x = 0;
                    }
                }

                if (moveDirection == MoveDirection.Right)
                {
                    //tylko raz zmienic obecną pozycję
                    if (i == 0)
                    {
                        Position.x += Sprite[i].Length;
                        if (Position.x + 1  > BoardWidth) 
                            Position.x = 1; //alternatywna wersja Position.x = BoardWidth - Sprite[i].Length;
                    }
                }

                if (moveDirection == MoveDirection.Down)
                {
                    //tylko raz zmienic obecną pozycję
                    if (i == 0)
                    {
                        Position.y += 5;
                        if (Position.y >= BoardHight) //Alien przeszedł linie i powinien zostac usuniety
                        {
                            Position.y = BoardHight - Sprite[i].Length;
                            statusToDelete = true;
                            break;
                        }
                    }
                }
                Console.SetCursorPosition(Position.x, Position.y + i);
                Console.Write(Sprite[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //public void x(int i, int BoardHight)
        //{
        //    if (i == 0)
        //    {
        //        Position.y += 2 * 5;
        //        //if (Position.y >= BoardHight) Position.y = BoardHight - Sprite[i].Length;
        //        if (Position.y >= BoardHight) //Alien przeszedł linie i powinien zostac usuniety
        //        {
        //            Position.y = BoardHight - Sprite[i].Length;
        //            statusToDelete = true;
        //            break;
        //        }
        //    }
        //    Console.SetCursorPosition(Position.x, Position.y + i);
        //}

        public bool getStatusToDelete()
        {
            return statusToDelete;
        }

        public void setStatusToDelete()
        {
            isDead = true;
            statusToDelete = true;
        }

        //do czyszczenia w jednej klatce zeby nie było migotania planszy
        public void ClearAlien()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x, Position.y+1);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x, Position.y+2);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x, Position.y);
        }

        public void doSomething()
        {

        }

        public void attach(Observer observer)
        {
            this.observer = observer;
        }

        public void notifyObserver()
        {
            //isDead = true;
            observer.updateAlienStatus();
        }
    }
}
