using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExam
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int wRow = -1, wCol = -1, bRow = -1, bCol = -1;

            for (int i = 0; i < 8; i++)
            {
                char[] boardRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = boardRow[j];
                    if(board[i, j] == 'w')
                    {
                        wRow = i;
                        wCol = j;
                    }
                    if(board[i, j] == 'b')
                    {
                        bRow = i;
                        bCol = j;
                    }
                }
            }

            int countTurn = 0;

            while (true)
            {
                countTurn++;
                if(countTurn % 2 != 0)
                {
                    bool isBlackFound = false;
                    board[wRow, wCol] = '-';
					
                    //check if white is capturing black 
                    if(wCol-1 >= 0)
                    {
                        if(board[wRow - 1, wCol - 1] == 'b')
                        {
                            isBlackFound = true;
                        }
                    }
                    
                    if(wCol +1 < 8)
                    {
                        if (board[wRow - 1, wCol + 1] == 'b')
                        {
                            isBlackFound = true;
                        }
                    }

                    if (isBlackFound)
                    {
                        Console.WriteLine($"Game over! White capture on {(char)(97+bCol)}{8-bRow}.");
                        break;
                    }

					//move to next position
                    wRow--;
					
                    //check if white has become a Queen
                    if (wRow == 0 )
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + wCol)}{8 - wRow}.");
                        break;
                    }

                    board[wRow, wCol] = 'w';
                }

                if (countTurn % 2 == 0)
                {
                    bool isWhiteFound = false;
                    board[bRow, bCol] = '-';

					//check if black is capturing white 
                    if (bCol - 1 >= 0)
                    {
                        if (board[bRow + 1, bCol - 1] == 'w')
                        {
                            isWhiteFound = true;
                        }
                    }

                    if (bCol + 1 < 8)
                    {
                        if (board[bRow + 1, bCol + 1] == 'w')
                        {
                            isWhiteFound = true;
                        }
                    }

                    if (isWhiteFound)
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + wCol)}{8 - wRow}.");
                        break;
                    }

					//move to next position
                    bRow++;
					
                    //check if black has become Queen
                    if (bRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + bCol)}{8 - bRow}.");
                        break;
                    }
                    board[bRow, bCol] = 'b';
                }
            }
        }
    }
}
