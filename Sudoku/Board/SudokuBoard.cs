using System;
using Sudoku.Board;
using Sudoku.Board.Square;

namespace Sudoku
{
    public class SudokuBoard<TSquare, TValue> : Grid<TSquare, TValue>
        where TValue : struct
        where TSquare : ISquare<TValue>
    {

    }
}
