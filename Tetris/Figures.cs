﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Figures
    {
       public static int width = 20;
        public static int height = 20;
        public static int score = 0;
        public static char input;
        public static int rotatingIndex = 0;
        public static int currentX = width / 2;
        public static int currentY = 0;
        public static char[,] board = new char[height, width];
        public static char[,] piece = new char[4, 4];
        static Random random = new Random();
        public static int randomFigure = random.Next(4);

        /// <summary>
        /// generate random piece
        /// </summary>
        public static void GeneratePiece()
        {

            switch (randomFigure)
            {
                case 0:
                    Figure1();
                    break;
                case 1:
                    Figure2();
                    break;
                case 2:
                    Figure3();
                    break;
                case 3:
                    Figure4();
                    break;
                case 4:
                    Figure5();
                    break;
            }
            currentX = width / 2 - 2;
            currentY = 0;
        }


        /// <summary>
        /// all figures using in tetris 1 to 5
        /// </summary>
        public static void Figure1()
        {
            switch (rotatingIndex)
            {
                case 0:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
                case 1:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
                case 2:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
                case 3:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
            }
        }
        public static void Figure2()
        {
            switch (rotatingIndex)
            {
                case 0:
                    piece = new char[,] { { 'X', 'X', 'X', 'X' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
                case 1:
                    piece = new char[,] { { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' } };
                    break;
                case 2:
                    piece = new char[,] { { 'X', 'X', 'X', 'X' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
                    break;
                case 3:
                    piece = new char[,] { { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' }, { 'X', ' ', ' ', ' ' } };
                    break;
            }
        }
        public static void Figure3()
        {
            switch (rotatingIndex)
            {
                case 0:
                    piece = new char[,] { { ' ', 'X', ' ', ' ' }, { ' ', 'X', ' ', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 1:
                    piece = new char[,] { { 'X', 'X', 'X', ' ' }, { 'X', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 2:
                    piece = new char[,] { { 'X', 'X', ' ', ' ' }, { ' ', 'X', ' ', ' ' }, { ' ', 'X', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 3:
                    piece = new char[,] { { ' ', ' ', 'X', ' ' }, { 'X', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
            }
        }
        public static void Figure4()
        {
            switch (rotatingIndex)
            {
                case 0:
                    piece = new char[,] { { ' ', 'X', ' ', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', 'X', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 1:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { 'X', 'X', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 2:
                    piece = new char[,] { { ' ', 'X', ' ', ' ' }, { ' ', 'X', 'X', ' ' }, { ' ', ' ', 'X', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 3:
                    piece = new char[,] { { ' ', 'X', 'X', ' ' }, { 'X', 'X', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
            }
        }
        public static void Figure5()
        {
            switch (rotatingIndex)
            {
                case 0:
                    piece = new char[,] { { ' ', 'X', 'X', 'X' }, { ' ', ' ', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 1:
                    piece = new char[,] { { ' ', 'X', ' ', ' ' }, { 'X', 'X', ' ', ' ' }, { ' ', 'X', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 2:
                    piece = new char[,] { { ' ', 'X', ' ', ' ' }, { 'X', 'X', 'X', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
                case 3:
                    piece = new char[,] { { 'X', ' ', ' ', ' ' }, { 'X', 'X', ' ', ' ' }, { 'X', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };

                    break;
            }
        }
    }
}
