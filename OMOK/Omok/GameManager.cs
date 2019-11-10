using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMOK
{
    class GameManager
    {
        public GameManager()
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

        public bool IsGameEnd()
        {
            return IsGameEnd(Constant.White) || IsGameEnd(Constant.Black);

        }

        public bool IsGameEnd(int NUMBER)
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
}
