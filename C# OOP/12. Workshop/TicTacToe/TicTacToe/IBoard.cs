using System.Collections.Generic;

namespace TicTacToe
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(Index row, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbol(int row);

        Symbol GetColSymbol(int column);

        Symbol GetTopLeftBottomRightSymbol();

        Symbol GetTopRightBottomLeftSymbol();
    }
}
