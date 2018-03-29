using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Sudoku.Board.Square;
using Sudoku.BoardUtil.Parser;

namespace Sudoku
{
    public class BoardFactory<TValue> where TValue : struct
    {
        private readonly IBoardParser<TValue> _parser;
        private readonly Dictionary<int, int> _squareRoots = Enumerable.Range(1, 10).ToDictionary(i => i * i, i => i);

        public BoardFactory(IBoardParser<TValue> parser)
        {
            _parser = parser;
        }

        //public Task<SudokuBoard<TSquare, TValue>> FromFile<TSquare>(Stream file)
        //    where TSquare : ISquare<TValue>
        //{
            
        //}

        public SudokuBoard<TSquare, TValue> FromString<TSquare>(string board)
            where TSquare : ISquare<TValue>
        {
            var squares = _parser.Parse(board);
            return new SudokuBoard<TSquare, TValue>(squares);
        }
    }
}
