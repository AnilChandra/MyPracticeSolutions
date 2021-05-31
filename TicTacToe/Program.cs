using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private int[,] board;
        private int n;
        public TicTacToe(int n)
        {
            this.n = n;
            board = new int[n,n];
        }

        public int Move(int player, int row, int column) {

            if (row < 0 || column < 0 || row >= n || column >= n)
            {
                throw new Exception("oops");
            }
            else if (board[row, column] != 0)
            {
                throw new ArgumentException("ooops", "Rows & Columns");
            }
            else if (player != 0 && player != 1)
            {
                throw new ArgumentException("oops", "player out of range");
            }
            else
            {
                player = player == 0 ? -1 : +1;
                board[row, column] = player == 0 ? -1 : +1;
                bool win = true;
                for (int i =0; i < n; i++)
                {
                    if (board[row,i] != player)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                { return player; }

                for (int i =0; i < n; i++)
                {
                    if (board[i, column] != player)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                { return player; }

                if (row == column)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (board[i, i] != player)
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win)
                { return player; }

                if (row == n - 1 - column)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (board[i, n - 1 - i] != player)
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win)
                { return player; }
                return 9;
            }
           
        }

        static void Main(string[] args)
        {
        }
    }
}
