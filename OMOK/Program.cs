using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMOK
{
    class GAMEMANAGE
    {
        public GAMEMANAGE()
        {
            POS.X = 0;
            POS.Y = 0;
            BOARD = new int[10, 10];
        }

        public int[,] BOARD;

        public struct COORD
        {
            public int X;
            public int Y;
        };

        public COORD POS;

        public void PRINT()
        {
            for (int i = 0; i < BOARD.GetLength(0); i++)
            {
                for (int j = 0; j < BOARD.GetLength(1); j++)
                {
                    if (i == POS.Y && j == POS.X)
                        Console.Write("♠");
                    else if (BOARD[i, j] == 0)
                        Console.Write("┼ ");
                    else if (BOARD[i, j] == 1)
                        Console.Write("○");
                    else if (BOARD[i, j] == 2)
                        Console.Write("●");
                }
                Console.WriteLine();
            }
        }

        public void ARRANGE()
        {
            if (POS.X < 0)
                POS.X = 0;
            if (POS.Y < 0)
                POS.Y = 0;
            if (POS.X >= BOARD.GetLength(1))
                POS.X = BOARD.GetLength(1) - 1;
            if (POS.Y >= BOARD.GetLength(0))
                POS.Y = BOARD.GetLength(0) - 1;
        }


        public bool CHE(int NUMBER)
        {
            //세로
            for (int i = 0; i < BOARD.GetLength(0) - 4; i++)
            {
                for (int j = 0; j < BOARD.GetLength(1); j++)
                {
                    bool flag = true;
                    for (int k = 0; k < 5; k++)
                    {
                       flag = (flag && BOARD[i + k, j] == NUMBER);

                    }
                    if (flag)
                        return true;
                }
            }

            //가로
            for (int i = 0; i < BOARD.GetLength(0); i++)
            {
                for (int j = 0; j < BOARD.GetLength(1) - 4; j++)
                {
                    bool flag = true;
                    for (int k = 0; k < 5; k++)
                    {
                        flag = (flag && BOARD[i, j + k] == NUMBER);
                    }
                    if (flag)
                        return true;
                }
            }

            //좌상단부터
            for (int i = 0; i < BOARD.GetLength(0) - 4; i++)
            {
                for (int j = 0; j < BOARD.GetLength(1) - 4; j++)
                {
                    bool flag = true;
                    for (int k = 0; k < 5; k++)
                    {
                        flag = (flag && BOARD[i + k, j + k] == NUMBER);
                    }
                    if (flag)
                        return true;
                }
            }
            //좌하단부터
            for (int i = 0; i < BOARD.GetLength(0) - 4; i++)
            {
                for (int j = 0; j < BOARD.GetLength(1) - 4; j++)
                {
                    bool flag = true;
                    for (int k = 0; k < 5; k++)
                    {
                        flag = (flag && BOARD[i + k, j + 4 - k] == NUMBER);
                    }
                    if (flag)
                        return true;
                }
            }
            return false;
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Console.Title = "OMOK";
                GAMEMANAGE GAME = new GAMEMANAGE();
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
                            GAME.PRINT();
                             switch (Console.ReadKey().Key)
                             {
                                     case ConsoleKey.LeftArrow:
                                          GAME.POS.X--;
                                          break;
                                        case ConsoleKey.RightArrow:
                                         GAME.POS.X++;
                                           break;
                                       case ConsoleKey.UpArrow:
                                          GAME.POS.Y--;
                                           break;
                                        case ConsoleKey.DownArrow:
                                         GAME.POS.Y++;
                                         break;
                                        case ConsoleKey.Spacebar:
                                            if (GAME.BOARD[GAME.POS.Y, GAME.POS.X] == 0)
                                            {
                                                GAME.BOARD[GAME.POS.Y, GAME.POS.X] = turn % 2 + 1;
                                                space = true;
                                            }
                                            break;
                             }
                                    GAME.ARRANGE();
                                    if (space)
                                        break;
                       }
                    if (GAME.CHE(1) || GAME.CHE(2))
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
            
        }
}
