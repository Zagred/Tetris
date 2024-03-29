﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Game:Figures
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
        /// <summary>
        /// stop the movement if figures colide with X
        /// </summary>
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

        /// <summary>
        /// chek if the border has full line
        /// </summary>
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
                    level += 1;
                    //threadTimer -= 100;
                    ClearLine(i);
                    i++;
                }
            }
        }
        /// <summary>
        /// clearing full line
        /// </summary>
        /// <param name="line"></param>
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
        /// <summary>
        /// updates the border
        /// </summary>
        public static void draw()
        {
            Console.Clear();
            Console.WriteLine("Points:" + score);
            Console.WriteLine("Current level:" + level);

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
        }
        public static void movement()
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
                    if (!Colliding(currentX, currentY) && !Colliding(currentX, currentY + 1) && !Colliding(currentX - 1, currentY) && !Colliding(currentX + 1, currentY))
                    {
                        if (rotatingIndex >= 3)
                        {
                            rotatingIndex -= 3;
                        }
                        else if (rotatingIndex < 3)
                        {
                            rotatingIndex++;
                        }
                        isRotating = true;
                        GeneratePiece();
                    }
                    break;
            }
        }
        public static void game()
        {
            Border();
            do { 
                draw();

                //if (Console.KeyAvailable)
                //{

                movement();
                //}
                if (Colliding(currentX, currentY + 1))
                {
                    MergePiece();
                    CheckLines();
                    randomFigure = random.Next(6);
                    isRotating = false;
                    GeneratePiece();

                    if (Colliding(currentX, currentY))
                        input = 'q';
                }
                else
                {
                    currentY++;
                }
                //if (!Colliding(currentX, currentY + 1))
                //{
                //    Thread.Sleep(threadTimer);
                //    currentY++;
                //}
            } while (input != 'q');
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Points:" + score);
            Console.WriteLine("Lever reached:" + level);
        }

    }
}
