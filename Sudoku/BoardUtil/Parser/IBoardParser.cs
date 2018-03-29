using System.Collections.Generic;

namespace Sudoku.BoardUtil.Parser
{
    public interface IBoardParser<out TValue> where TValue : struct
    {
        IEnumerable<TValue> Parse(string board, char emptySpaceChar = '0');
    }
}
