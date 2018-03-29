using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Board.Square
{
    public interface ISquare<TValue> where TValue : struct
    {
        TValue? Value { get; set; }
    }
}
