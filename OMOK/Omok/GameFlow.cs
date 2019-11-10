using System;

namespace OMOK
{
    class GameFlow
    {
        private GameManager _gameManager;
        public GameFlow(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Run()
        {
            int turn = 0;
            while (true)
            {
                turn++;
                while (true)
                {
                    bool space = false;
                    Console.Clear();
                    Console.WriteLine("\t" + "\t" + "OMOK");
                    if (turn % 2 == 0)
                        Console.WriteLine("BLACK TURN");
                    else
                        Console.WriteLine("WHITE TURN");
                    _gameManager.PRINT();

                    space = KeyAction(turn);

                    _gameManager.ARRANGE();
                    if (space)
                        break;
                }
                if (_gameManager.IsGameEnd())
                {
                    if (turn % 2 == 0)
                        Console.WriteLine("BLACK 승");
                    else
                        Console.WriteLine("WHITE 승");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private bool KeyAction(int turn)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    _gameManager.POS.X--; return false;
                    break;
                case ConsoleKey.RightArrow:
                    _gameManager.POS.X++; return false;
                    break;
                case ConsoleKey.UpArrow:
                    _gameManager.POS.Y--; return false;
                    break;
                case ConsoleKey.DownArrow:
                    _gameManager.POS.Y++; return false;
                    break;
                case ConsoleKey.Spacebar:
                    if (_gameManager.BOARD[_gameManager.POS.Y, _gameManager.POS.X] == 0)
                    {
                        _gameManager.BOARD[_gameManager.POS.Y, _gameManager.POS.X] = turn % 2 + 1;
                        return true;
                    }
                    break;
                default:
                    return false;
            }

            return false;

        }
    }
}
