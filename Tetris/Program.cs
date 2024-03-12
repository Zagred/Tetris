using System;
using System.Threading;
namespace Tetris
{
    class Tetris:Figures
    {

        static Random random = new Random();

        /// <summary>
        /// Make border for the game
        /// </summary>
        public static void Border()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    board[i, j] = ' ';
                }
            }
            GeneratePiece();
        }

   


        /// <summary>
        /// check for coliding 
        /// </summary>
        /// <returns></returns>
        static bool Colliding(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (piece[i, j] == 'X' && (y + i >= height || x + j < 0 || x + j >= width || board[y + i, x + j] == 'X'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void MergePiece()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (piece[i, j] == 'X')
                    {
                        board[currentY + i, currentX + j] = 'X';
                    }
                }
            }
        }


        static void CheckLines()
        {
            for (int i = height - 1; i >= 0; i--)
            {
                bool full = true;
                for (int j = 0; j < width; j++)
                {
                    if (board[i, j] != 'X')
                    {
                        full = false;
                        break;
                    }
                }

                if (full)
                {
                    score += 100;
                    ClearLine(i);
                    i++;
                }
            }
        }

        static void ClearLine(int line)
        {
            for (int i = line; i > 0; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    board[i, j] = board[i - 1, j];
                }
            }
        }

        static void Main(string[] args)
        {
            Border();
            do
            {
                
                Console.Clear();
                Console.WriteLine("Points:"+score);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        bool isPiece = false;
                        for (int pi = 0; pi < 4; pi++)
                        {
                            for (int pj = 0; pj < 4; pj++)
                            {
                                if (currentY + pi >= 0 && currentY + pi < height && currentX + pj >= 0 && currentX + pj < width &&
                                    piece[pi, pj] == 'X' && i == currentY + pi && j == currentX + pj)
                                {
                                    Console.Write('X');
                                    isPiece = true;
                                    break;
                                }
                            }
                            if (isPiece)
                                break;
                        }
                        if (!isPiece)
                        {
                            Console.Write(board[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    input = key.KeyChar;
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            if (!Colliding(currentX - 1, currentY))
                            {
                                currentX--;
                            }
                            break;
                        case ConsoleKey.D:
                            if (!Colliding(currentX + 1, currentY))
                            {
                                currentX++;
                            }
                            break;
                        case ConsoleKey.S:
                            if (!Colliding(currentX, currentY + 1))
                            {
                                currentY++;
                            }
                            break;
                        case ConsoleKey.R:
                            if (!Colliding(currentX, currentY))
                            {
                                if (rotatingIndex >= 3)
                                {
                                    rotatingIndex -= 3;
                                }
                                else if (rotatingIndex < 3)
                                {
                                    rotatingIndex++;
                                }
                                GeneratePiece();
                            }
                            break;

                    }
                }
                if (!Colliding(currentX, currentY + 1))
                {
                    currentY++;
                }
                if (Colliding(currentX, currentY + 1))
                {
                    MergePiece();
                    CheckLines();
                    randomFigure=random.Next(4);
                    GeneratePiece();

                    if (Colliding(currentX, currentY))
                        input = 'q';            
                }
                else
                {
                    currentY++;
                }
                Thread.Sleep(500);

            } while (input!= 'q');
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Points:" + score);
        }


    }
}