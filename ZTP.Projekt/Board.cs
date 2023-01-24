using IronXL;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing.Processors.Normalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    /// <summary>
    /// Klasa główna gry sterująca rozgrywką
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Instancja tablicy
        /// </summary>
        private static Board boardInstance = new Board();

        /// <summary>
        /// Kolekcja wszystkich obecnych na planszy kosmitów
        /// </summary>
        public AlienCollection Aliens { get; set; } = new AlienCollection();

        /// <summary>
        /// Początkowy wiersz pojawiania się kosmitów
        /// </summary>
        public int startAlienRow { get; set; } = 5;

        /// <summary>
        /// Prawdopodobieństwo wystąpienia MutatedAlien
        /// </summary>
        public int probabilityMutationAlien { get; set; } //from 0 to 100

        /// <summary>
        /// Prawdopodobieństwo wystapienia zwykłego kosmity
        /// </summary>
        public int probabilityAppearanceAlien { get; set; } //from 0 to 100

        /// <summary>
        /// Prawdopodobieństwo pojawienia się bonusu
        /// </summary>
        public int probalityBonusAppearance { get; set; } //from 0 to 100

        /// <summary>
        /// Czas pomiędzy rundami pojawiania sie kosmitów
        /// </summary>
        public int timeBetweenNextWave { get; set; }

        /// <summary>
        /// Początkowy wiersz pojawiania się bonusów
        /// </summary>
        private int startBonusesRow = 1;

        /// <summary>
        /// Obiekt generujący losowe wartości
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Lista wszystkich bonusów widocznych na planszy
        /// </summary>
        public List<Bonus> Bonuses { get; set; } = new List<Bonus>();

        /// <summary>
        /// Statek - obiekt gracza
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Wynik w punktach
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Pozostały czas w turze
        /// </summary>
        public int RemainingTimeInTurn { get; set; }

        /// <summary>
        /// Szerokośc grywalnej planszy
        /// </summary>
        public int BoardWidth { get; set; }

        /// <summary>
        /// Wysokość grywalnej planszy
        /// </summary>
        public int BoardHeight { get; set; }

        /// <summary>
        /// Obeny ruch statku
        /// </summary>
        public MoveDirection currentMove { get; set; } = MoveDirection.None;

        /// <summary>
        /// Poziom trudności
        /// </summary>
        public IDifficultLevel difficultLevel;

        /// <summary>
        /// Flaga końca gry
        /// </summary>
        private bool endGame = false;

        /// <summary>
        /// Plik Excel
        /// </summary>
        private WorkBook ExcelFile;

        /// <summary>
        /// Arkusz pliku Excel
        /// </summary>
        private WorkSheet ws;
        public string PlayerName { get; set; }

        /// <summary>
        /// Lista posisków na planszy
        /// </summary>
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        private Board()
        {
            BoardHeight = Console.WindowHeight-6;
            BoardWidth = 140;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns>Instancja planszy</returns>
        public static Board getInstance()
        {
            return boardInstance;
        }

        /*ZRÓBCIE SOBIE PLIK scores.xlsx w bin->debug*/

        /// <summary>
        /// Inicjalizacja pliku Excel
        /// </summary>
        /// <param name="fileFormat">format pliku</param>
        private void initExcelDoc(ExcelFileFormat fileFormat)
        {
            ExcelFile = WorkBook.Load("scores.xlsx");
            ws = ExcelFile.WorkSheets.First();
        }

        /// <summary>
        /// Rysuje punkty życia użytkownika
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public void drawHp(int x, int y)
        {
            //trzy życia, jak kosmita dotknie statku to -1
            if(!endTheGame())
            {
                Console.SetCursorPosition(x, y);

                Console.Write("Hp: ");

                for (int i = 0; i < Ship.Hp; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("▄");
                    Console.Write(" ");

                    Console.ResetColor();
                }

                for (int i = 0; i < 3 - Ship.Hp; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("▄");
                    Console.Write(" ");

                    Console.ResetColor();
                }
            }
            else
            {
                Console.SetCursorPosition(x, y);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("End");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Rysuje ilość obrażeń zadawanych przez pocisk
        /// </summary>
        /// <param name="x">x Position</param>
        /// <param name="y">y Position</param>
        public void drawAttackPower(int x, int y)
        {
            //ile kosmitow rozwala jeden pocisk, jak kosmita oberwie pociskiem to -1
            if (!endTheGame())
            {
                Console.SetCursorPosition(x, y);

                Console.Write("Attack Power: ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Ship.Attack.ToString());
                Console.Write(" ");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(x, y);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("End");
                Console.ResetColor();
            }
        }

        public void drawDiffLevel(int x, int y)
        {
            Console.SetCursorPosition(BoardWidth + 6, 13);
            Console.Write("Difficulty level: ");
            Console.Write(difficultLevel.name);
        }

        public void ClearDiffLevel(int x ,int y)
        {
            Console.SetCursorPosition(BoardWidth + 6, 13);
            Console.Write("                            ");
        }

        /// <summary>
        /// Rysuje wszystkie parametry rozgrywki
        /// </summary>
        public void drawData()
        {
            drawHp(BoardWidth + 6, 1);
            drawAttackPower(BoardWidth + 6, 4);
            drawAmmunition(BoardWidth + 6, 7);
            drawPoints(BoardWidth + 6, 10);
            drawDiffLevel(BoardWidth + 6, 13);
        }

        void checkDiffLevel()
        {
            if(Score >= 100 && Score < 250)
            {
                difficultLevel = new Mid();
                difficultLevel.setDifficultyLevel(this);
            }
            else if(Score >=  250)
            {
                difficultLevel = new Hard();
                difficultLevel.setDifficultyLevel(this);
            }
            else
            {
                difficultLevel = new Easy();
                difficultLevel.setDifficultyLevel(this);
            }
              
        }

        /// <summary>
        /// Inicjalizacja gry
        /// </summary>
        /// <param name="UserName">nazwa uzytkownika</param>
        public void initGame(string UserName)
        {
            PlayerName = UserName;
            //initExcelDoc(ExcelFileFormat.XLSX);

            /*  TEST ZAPISU
            Score score = new Score();
            score.Id = 1;
            score.PlayerScore = 10;
            score.Nick = "test4";
            score.SaveToExcel(ws);
            ExcelFile.SaveAs("scores.xlsx");
            */

            difficultLevel = new Easy();
            difficultLevel.setDifficultyLevel(this);
            probabilityAppearanceAlien = 10;

            Console.Clear();

            Ship = Ship.getInstance();

            Menu.drawRectangle(0, 0, BoardHeight + 4, BoardWidth + 2, 15);
            drawHp(BoardWidth + 6, 1);
            drawAttackPower(BoardWidth + 6, 4);
            drawData();

            clearAllBoard();
            createAliensFirstLine(startAlienRow, probabilityAppearanceAlien, probabilityMutationAlien);
            createBonuses(probalityBonusAppearance, startBonusesRow);
            drawAliens();
            drawShip();
            startGame();
        }

        /// <summary>
        /// Klasa wątku
        /// </summary>
        class MyThreadClass
        {
            //identyfikator blokady
            static readonly object Identity = new object();
            /// <summary>
            /// tworzenie nowej fali kosmitow w watku, watek blokowany na czas operacji
            /// </summary>
            public static void alienMovements()
            {
                Board b;
                //Na wszelki wypadek dałem blokadę podczas pobierania instacji planszy, żeby nie pobrało złej wartosci czy cos, watki są niebezpieczne w koncu :p
                lock (Identity)
                {
                    b = getInstance();
                }
                while (!b.endTheGame())
                {
                    // Nałożenie blokady na czas rysowania, żeby drugi wątek nie zmienił pozycji rysowania w tym czasie
                    lock (Identity)
                    {
                        b.moveRound();
                        b.clearAndDrawDataAndBonuses();

                        //sprawdzenie kolizji ze statkiem
                        var aliens = b.Aliens.getList();
                        foreach (Alien alien in aliens)
                        {
                            if (alien.Position.y == b.Ship.Position.y && alien.Position.x == b.Ship.Position.x)
                            {
                                b.Ship.Hp -= 1;
                                alien.ClearAlien();
                                //b.Ship.moveShip(MoveDirection.None, b.BoardWidth);
                            }
                        }

                        b.clearAndDrawDataAndBonuses();
                        b.Ship.moveShip(MoveDirection.None, b.BoardWidth);
                    }
                    Thread.Sleep(b.timeBetweenNextWave);
                }
            }

            /// <summary>
            /// ruch statkiem w jednym watka, watek blokowany na czas kluczowej operacji
            /// </summary>
            public static void spaceshipMovements()
            {
                Board b;
                //Na wszelki wypadek dałem blokadę podczas pobierania instacji planszy, żeby nie pobrało złej wartosci czy cos, watki są niebezpieczne w koncu :p
                lock (Identity)
                {
                    b = getInstance();
                }
                while(!b.endTheGame())
                {
                    ConsoleKey key;
                    //Game Main loop
                    b.endTheGame();
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                    {
                        b.currentMove = MoveDirection.Right;
                    }
                    else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                    {
                        b.currentMove = MoveDirection.Left;
                    }
                    else if (key == ConsoleKey.Spacebar)
                    {
                        b.shoot();
                        continue;
                    }
                    // Nałożenie blokady na czas rysowania, żeby drugi wątek nie zmienił pozycji rysowania w tym czasie
                    lock (Identity)
                    {
                        Menu.clearBoard(b.Ship.Position.x, b.Ship.Position.y, 3, 7);
                        b.drawShip();
                    }
                }
            }
            /// <summary>
            /// ruch pocisku w watku, watek blokowany na czas operacji
            /// </summary>
            public static void bulletMovements()
            {
                Board b;
                lock (Identity)
                {
                    b = getInstance();
                }
                while(!b.endTheGame())
                {
                    lock (Identity)
                    {
                        b.bulletsTrajectory();
                    }
                    Thread.Sleep(25);
                }
            }
        }

        /// <summary>
        /// Czyści narysowane bonusy pomiędzy klatkami
        /// </summary>
        /// <param name="x">Kolumna</param>
        /// <param name="startBonusesRow">Początkowy wiersz</param>
        private void clearBonuses(int x, int startBonusesRow)
        {
            Console.SetCursorPosition(x, startBonusesRow);
            Console.Write(new String(' ', BoardWidth));
            Console.SetCursorPosition(x, startBonusesRow+1);
            Console.Write(new String(' ', BoardWidth));
            Console.SetCursorPosition(x, startBonusesRow+2);
            Console.Write(new String(' ', BoardWidth));
            Console.SetCursorPosition(x, startBonusesRow);
        }

        private void clearAndDrawDataAndBonuses()
        {
            clearHp(BoardWidth + 6, 1);
            clearAmmunition(BoardWidth + 6, 4);
            clearPoints(BoardHeight + 6, 7);
            clearBonuses(1, startBonusesRow);
            ClearDiffLevel(BoardWidth + 6, 13);
            drawData();
            drawBonuses();
        }

        /// <summary>
        /// Rysuje punkty
        /// </summary>
        /// <param name="v1">x position</param>
        /// <param name="v2">y position</param>
        private void drawPoints(int v1, int v2)
        {
            Console.SetCursorPosition(v1, v2);
            Console.Write("Points: ");
            Console.Write(this.Score.ToString());
        }

        /// <summary>
        /// Czyści punktu pomiędzy klatkami
        /// </summary>
        /// <param name="v1">x</param>
        /// <param name="v2">y</param>
        private void clearPoints(int v1, int v2)
        {
            Console.SetCursorPosition(v1, v2);
            Console.Write("                 ");
        }

        /// <summary>
        /// Czyści punkty zycia pomiędzy klatkami
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        private void clearHp(int x, int y)
        {
            Console.SetCursorPosition(x, y);
           // Console.Write("     ");
            Console.Write("         ");
        }

        /// <summary>
        /// Sprawdza oraz rysuje kolizję i ruch pocisku
        /// </summary>
        public void bulletsTrajectory()
        {
            drawAmmunition(BoardWidth + 6, 7);
            List<Bullet> bulletsToRemove = new List<Bullet>();
            for (int i = 0; i < Bullets.Count; i++)
            {
                var aliens = Aliens.getList();
                if(bulletColisionWithAliens(aliens, Bullets[i]))
                {
                    bulletsToRemove.Add(Bullets[i]); //dodanie pocisku do listy pociskow do usuniecia
                }

                List<Bonus> bonusesToRemove = new List<Bonus>();
                if(activateBonus(Bullets[i], bonusesToRemove))
                {
                    bulletsToRemove.Add(Bullets[i]); //dodanie pocisku do listy pociskow do usuniecia
                }

                if (Bullets[i].position.y <= 3) // usuniecie pocisk co dotarl do linii bonusow
                {
                    bulletsToRemove.Add(Bullets[i]);
                    Menu.clearBoard(Bullets[i].position.x, Bullets[i].position.y + 1, 1, 1);
                    Bullets[i].penetrationValue = 0;
                }
                if (Bullets[i].penetrationValue > 0)
                {
                    Bullets[i].moveBullet();
                    Console.SetCursorPosition(Bullets[i].position.x, Bullets[i].position.y);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.Write("X");
                    Console.Write(Bullets[i].bullerChar);
                    Menu.clearBoard(Bullets[i].position.x, Bullets[i].position.y + 1, 1, 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Bullets[i].position.y -= 1;
                    //Console.ReadKey();
                }
                for (int j = 0; j < bonusesToRemove.Count; j++)
                {
                    Bonuses.Remove(bonusesToRemove[j]);
                }
            }
            for (int i=0; i < bulletsToRemove.Count; i++)
            {
                Menu.clearBoard(bulletsToRemove[i].position.x, bulletsToRemove[i].position.y + 1, 1, 1);
                Bullets.Remove(bulletsToRemove[i]);
            }
        }

        /// <summary>
        /// trafienie pociskiem w kosmite
        /// </summary>
        /// <param name="aliens"></param>
        /// <param name="bullet"></param>
        /// <returns></returns>
        public bool bulletColisionWithAliens(List<Alien> aliens, Bullet bullet)
        {
            bool bulletToRemove = false;
            foreach (Alien alien in aliens)
            {
                //if ((Bullets[i].position.x == alien.Position.x + 3) && (Bullets[i].position.y >= alien.Position.y && Bullets[i].position.y <= alien.Position.y + 3) && !alien.isDead)
                if ((bullet.position.y == alien.Position.y + 3) && (bullet.position.x >= alien.Position.x - 2 && bullet.position.x <= alien.Position.x + 5) && !alien.isDead)
                {
                    //trafienie kosmity
                    int dealtDemage = bullet.penetrationValue;
                    bullet.penetrationValue -= alien.Hp;
                    alien.notifyObserver(dealtDemage);
                    if (bullet.penetrationValue <= 0)
                    {
                        bulletToRemove = true;
                        Menu.clearBoard(bullet.position.x, bullet.position.y + 1, 1, 1);
                    }
                    drawPoints(BoardWidth+6, 10);
                }
            }
            return bulletToRemove;
        }

        /// <summary>
        /// aktywacja bonusow
        /// </summary>
        /// <param name="bullet"></param>
        /// <param name="bonusesToRemove"></param>
        /// <returns></returns>
        public bool activateBonus(Bullet bullet, List<Bonus> bonusesToRemove)
        {
            bool bulletToRemove = false;
            //List<Bonus> bonusesToRemove = new List<Bonus>();
            foreach (Bonus bonus in Bonuses)
            {
                if ((bullet.position.y == bonus.Position.y + 3) && (bullet.position.x >= bonus.Position.x && bullet.position.x <= bonus.Position.x + 3))
                {
                    bulletToRemove = true; //dodanie pocisku do listy pociskow do usuniecia

                    Ship.sprite = bonus.changeShip();
                    Ship.Ammunition = bonus.getAmmunition();
                    Ship.Hp = bonus.getHp();
                    Ship.Attack = bonus.getAttack();
                    bonusesToRemove.Add(bonus); //dodanie bonusu do listy bonusow do usuniecia
                    bullet.penetrationValue = 0;
                    Menu.clearBoard(bonus.Position.x, bonus.Position.y, 3, 7);
                    drawHp(BoardWidth + 6, 1);
                    drawAttackPower(BoardWidth+6, 4);
                }
            }
            return bulletToRemove;
        }

        /// <summary>
        /// Inicjalizuje strzał statku
        /// </summary>
        public void shoot()
        {
            if(Ship.Ammunition > 0)
            {
                Ship.shoot();
                Bullet bullet = new Bullet(Ship.Position.x + 3, Ship.Position.y - 2, Ship.Attack);
                Bullets.Add(bullet);
            }
            else
            {
                Ship.sprite = Sprites.shipWithoutAmmoString;
            }
        }

        /// <summary>
        /// Rysuje pozostała liczbe pocisków
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public void drawAmmunition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("Ammunition:           ");
            Console.SetCursorPosition(x+12,y);
            Console.Write(Ship.Ammunition.ToString());
        }

        /// <summary>
        /// Czyści liczbe pocisków pomiędzy klatkami
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public void clearAmmunition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("               ");
        }

        /// <summary>
        /// Rysuje statek - gracza
        /// </summary>
        public void drawShip()
        {
            Ship.moveShip(currentMove, BoardWidth);
        }

        /// <summary>
        /// Rozpoczyna gre
        /// </summary>
        public void startGame()
        {
            Thread one = new Thread(MyThreadClass.alienMovements);
            Thread two = new Thread(MyThreadClass.spaceshipMovements);
            one.Start();
            two.Start();

            Thread third = new Thread(MyThreadClass.bulletMovements);
            third.Start();
        }

        /// <summary>
        /// Sprawdza warunek końca gry i kończy gre
        /// </summary>
        /// <returns>Czy gra skończona</returns>
        private bool endTheGame()
        {
            
            if(Ship.Hp <= 0 && endGame==false)
            {
                Ship.sprite = Sprites.shipDestroyedString;
                endGame = true;
                Score score = new Score();
                score.PlayerScore = this.Score;
                score.Nick = this.PlayerName;
                //score.SaveToExcel(ws);
                //ExcelFile.Save();
            }
            return endGame;
        }

        /// <summary>
        /// Rysuje pierwszą linię kosmitów
        /// </summary>
        /// <param name="startAlienRow">Początkowy wiersz kosmitów</param>
        /// <param name="probalityAppearance">Prawdopodobieństwo wystąpienia kosmity</param>
        /// <param name="probalityMutation">Prawdonodobieństwo występienie MutatedAlien'a</param>
        public void createAliensFirstLine(int startAlienRow, int probalityAppearance, int probalityMutation)
        {
            for (int i = 0; i < 20; i++)
            {
                int randomNumverToAppearance = random.Next(101);
                int randomNumber = random.Next(101);
                if (randomNumverToAppearance < probalityAppearance)
                {
                    IAlienFactory alienFactory;
                    if (randomNumber >= probalityMutation)
                        alienFactory = new AlienFactoryNormal();
                    else
                        alienFactory = new AlienFactoryMutated();
                    Alien alien = (Alien)alienFactory.createAlien();
                    alien.Hp *= 1+ (Score / 1000); //1000;
                    alien.Position.y = startAlienRow;
                    alien.Position.x = 7 * i + 1;
                    Aliens.Add(alien);
                }
            }
        }

        /// <summary>
        /// Tworzy bonusy i dodaje je do listy
        /// </summary>
        /// <param name="probalityAppearance">Prawdobodobieństwo wystąpienia bonusu</param>
        /// <param name="startBonusesRow">Początkowy wiersz</param>
        public void createBonuses(int probalityAppearance, int startBonusesRow)
        {
            for (int i = 0; i < 20; i++)
            {
                int randomNumber = random.Next(101);
                int bonusType = random.Next(7);
                if (randomNumber <= probalityAppearance)
                {
                    bool bonusExistInThisPosition = false;
                    foreach(Bonus bonus in Bonuses)
                    {
                        if(bonus.Position.x == i * 7 + 1)
                        {
                            bonusExistInThisPosition = true;
                            break;
                        }
                    }
                    if (!bonusExistInThisPosition)
                    {
                        Bonus b = chooseBonusType(bonusType);
                        b.Position.x = i * 7 + 1;
                        b.Position.y = startBonusesRow;
                        Bonuses.Add(b);
                    }
                }
            }
        }

        /// <summary>
        /// wybranie odpowiedniego typu bonusu
        /// </summary>
        /// <param name="bonusType"></param>
        /// <returns></returns>
        public Bonus chooseBonusType(int bonusType)
        {
            Bonus b = null;
            switch (bonusType)
            {
                case 0:
                    b = new BonusAmmunition(Ship);
                    b.Sprite = Sprites.bonusAmmoString;
                    b.ColorValue = 6;
                    break;
                case 1:
                    b = new BonusAttack(Ship);
                    b.Sprite = Sprites.bonusAttackString;
                    b.ColorValue = 14;
                    break;
                case 2:
                    b = new BonusHp(Ship);
                    b.Sprite = Sprites.bonusHealthString;
                    b.ColorValue = 10;
                    break;
                case 3:
                    b = new BonusAttack(new BonusHp(Ship));
                    b.Sprite = Sprites.bonusHealthAttackString;
                    b.ColorValue = 13;
                    break;
                case 4:
                    b = new BonusNothing(Ship);
                    b.Sprite = Sprites.bonusNothingString;
                    b.ColorValue = 15;
                    break;
                case 5:
                    b = new BonusAmmunition(new BonusHp(Ship));
                    b.Sprite = Sprites.bonusHealthAmmoString;
                    b.ColorValue = 12;
                    break;
                case 6:
                    b = new BonusAmmunition(new BonusAmmunition(Ship));
                    b.Sprite = Sprites.bonusDoubleAmmoString;
                    b.ColorValue = 11;
                    break;
            }
            return b;
        }

        /// <summary>
        /// Czysci całą grywalną plansze
        /// </summary>
        public void clearAllBoard()
        {
            //Console.Clear();
            Menu.clearBoard(1, 1, BoardHeight+2, BoardWidth);//Czyszczenie calej planszy bez obwodki
        }

        /// <summary>
        /// Rysuje kosmitów
        /// </summary>
        public void drawAliens()
        {
            MoveDirection move = MoveDirection.None;
            //IIterator<Alien> iterator = Aliens.createIteratorNormal(move, BoardWidth, BoardHeight);
            IIterator<Alien> iterator = Aliens.createIteratorHalfAliensDoubleSpeed(move, BoardWidth, BoardHeight);
            while (iterator.hasNext())
            {
                Alien alien = iterator.next();
            }
        }

        /// <summary>
        /// Rysuje bonusy
        /// </summary>
        public void drawBonuses() 
        {
            foreach(Bonus b in Bonuses)
            {
                Console.ForegroundColor = (ConsoleColor)b.ColorValue;
                for (int i = 0; i < b.Sprite.Length; i++)
                {
                    Console.SetCursorPosition(b.Position.x, b.Position.y + i);
                    Console.Write(b.Sprite[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Co runde przesuwa kosmitow i dodaje nowe bonusy/kosmitow
        /// </summary>
        public void moveRound()
        {
            checkDiffLevel();
            List<Alien> aliens = Aliens.getList();
            foreach (Alien alien in aliens)
            {
                alien.ClearAlien();
            }
            createBonuses(probalityBonusAppearance, startBonusesRow);
            createAliensFirstLine(startAlienRow, probabilityAppearanceAlien, probabilityMutationAlien);

            MoveDirection move = MoveDirection.Down;
            IIterator<Alien> iterator = Aliens.createIteratorNormal(move, BoardWidth, BoardHeight);

            if (difficultLevel.chooseIterator() == 2)
                iterator = Aliens.createIteratorHalfAliensDoubleSpeed(move, BoardWidth, BoardHeight);
            if (difficultLevel.chooseIterator() == 1)
                iterator = Aliens.createIteratorMoveRight(move, BoardWidth, BoardHeight);
            //iterator = Aliens.createIteratorNormal(move, BoardWidth, BoardHeight);
            //IIterator<Alien> iterator = Aliens.createIteratorNormal(move, BoardWidth, BoardHeight);
            //IIterator<Alien> iterator = Aliens.createIteratorHalfAliensDoubleSpeed(move, BoardWidth, BoardHeight);
            while (iterator.hasNext())
            {
                Alien alien = iterator.next();
            }
        }
    }
}
