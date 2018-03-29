using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Board.Square;

namespace Sudoku.Board
{
    public class Grid<TSquare, TValue>
        where TValue : struct
        where TSquare : ISquare<TValue>
    {
        protected readonly TSquare[,] Squares;
        public TSquare this[int x, int y] => Squares[x, y];
    }
}
