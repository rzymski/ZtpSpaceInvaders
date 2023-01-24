using ZTP.Projekt;

Console.CursorVisible = false;
int resolutionWidth = 160, resolutionHeight = 65;
Menu.setResolution(ref resolutionWidth, ref resolutionHeight);
//int startColumnToDraw = (resolutionWidth - 100) / 2;
//Menu.drawFirstMenu(0, startColumnToDraw, 100, resolutionWidth);
//int chosenOption = Menu.chooseOptionFirstMenu(startColumnToDraw);

//Board board = Board.getInstance();

//if(chosenOption == 0)
//{
//    board.initGame();
//}

string text = @"
███████╗███╗   ██╗████████╗███████╗██████╗     ██╗   ██╗███████╗███████╗██████╗     ███╗   ██╗ █████╗ ███╗   ███╗███████╗       
██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔══██╗    ██║   ██║██╔════╝██╔════╝██╔══██╗    ████╗  ██║██╔══██╗████╗ ████║██╔════╝██╗    
█████╗  ██╔██╗ ██║   ██║   █████╗  ██████╔╝    ██║   ██║███████╗█████╗  ██████╔╝    ██╔██╗ ██║███████║██╔████╔██║█████╗  ╚═╝    
██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗    ██║   ██║╚════██║██╔══╝  ██╔══██╗    ██║╚██╗██║██╔══██║██║╚██╔╝██║██╔══╝  ██╗    
███████╗██║ ╚████║   ██║   ███████╗██║  ██║    ╚██████╔╝███████║███████╗██║  ██║    ██║ ╚████║██║  ██║██║ ╚═╝ ██║███████╗╚═╝    
╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝     ╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═╝    ╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝       
                                                                                                                                
";

//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(text);
//Console.ResetColor();
//string username = Console.ReadLine();
string username = "rzymski";

Board board = Board.getInstance();
board.initGame(username);