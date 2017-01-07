using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Sudoko
    {
        public bool IsValidSudoku(char[,] board)
        {
            if (board == null || board.Length < 81) return false;

            var rows = Enumerable.Range(1, 9).Select(i => new HashSet<char>()).ToArray();
            var cols = Enumerable.Range(1, 9).Select(i => new HashSet<char>()).ToArray();
            var cubes = Enumerable.Range(1, 9).Select(i => new HashSet<char>()).ToArray();

            HashSet<char> set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int cube = 3 * (row / 3) + col / 3;

                    if (set.Contains(board[row, col]))
                    {
                        if (!rows[row].Add(board[row, col]) || !cols[col].Add(board[row, col]) || !cubes[cube].Add(board[row, col]))
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
    }
}
