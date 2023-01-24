using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Ship : IShip
    {
        private static Ship shipInstance = new Ship();

        public int SHIP_BUFFER_Y_POSITION = 8;
        public int Attack { get; set; }
        public int Hp { get; set; }
        public int Ammunition { get; set; }
        public Position Position { get; set; }
        public string[] sprite { get; set; }

        private Ship() 
        {
            sprite = Sprites.shipString;
            Attack = 1;
            Hp = 3;
            Ammunition = 50;
            Position = new Position(1, Console.WindowHeight - SHIP_BUFFER_Y_POSITION);
        }

        public static Ship getInstance()
        {
            return shipInstance;
        }

        //bonusy metody dekoratorow
        public string[] changeShip()
        {
            return sprite;
        }

        public int getAmmunition()
        {
            return Ammunition;
        }

        public int getHp()
        {
            return Hp;
        }

        public int getAttack()
        {
            return Attack;
        }

        public void moveShip(MoveDirection moveDirection, int BoardWidth)
        {
            for(int i = 0; i < sprite.Length; i++)
            {
                if(moveDirection == MoveDirection.Left)
                {
                    //tylko raz zmienic obecną pozycję
                    if (i == 0)
                    {                    
                        Position.x -= sprite[i].Length;
                        if(Position.x< 0) Position.x = 1;
                    } 
                    
                    Console.SetCursorPosition(Position.x, Position.y + i);
                }

                if(moveDirection == MoveDirection.Right)
                {
                    //tylko raz zmienic obecną pozycję
                    if (i == 0)
                    {
                        Position.x += sprite[i].Length;
                        if (Position.x >= BoardWidth) Position.x = BoardWidth - sprite[i].Length+1;
                    } 
                  
                    Console.SetCursorPosition(Position.x, Position.y + i);
                }

                if(moveDirection == MoveDirection.None)
                {
                    Console.SetCursorPosition(Position.x, Position.y + i);
                }
                Console.Write(sprite[i]);               
            }
        }

        public void ClearShip()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x-1, Position.y+1);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x-1, Position.y+2);
            Console.Write("       ");
            Console.SetCursorPosition(Position.x, Position.y);
        }

        public void shoot()
        {
            if(Ammunition > 0)
            {
                Ammunition--;

                //BulletThread bt = new BulletThread(Position.x, Position.y - 3);
                //Thread thread = new Thread(bt.run);
                //thread.Start();

                

                /*
                Bullet b = new Bullet(Position.x + 1, Position.y-3);
                b.moveBullet();
                */

            }

            
        }
    }
}
