using ZTP.Projekt;
using System;
using System.Runtime.InteropServices;

class Program
{
    // Definicje funkcji WinAPI
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll", ExactSpelling = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_MAXIMIZE = 3;

    static void Main(string[] args)
    {
        // Ustawienie konsoli na pełny ekran
        IntPtr consoleWindow = GetConsoleWindow();
        if (consoleWindow != IntPtr.Zero)
        {
            ShowWindow(consoleWindow, SW_MAXIMIZE);
        }

        Console.CursorVisible = false;
        int resolutionWidth = 160, resolutionHeight = 65;
        Menu.setResolution(ref resolutionWidth, ref resolutionHeight);
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        //string username = "rzymski";

        Board board = Board.getInstance();
        board.initGame(username);
    }
}