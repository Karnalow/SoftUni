using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameWinnerLogic
    {
        public bool IsGameOver(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                if (board.GetRowSymbol(row) != Symbol.None)
                {
                    return true;
                }
            }

            for (int col = 0; col < board.Columns; col++)
            {
                if (board.GetColSymbol(col) != Symbol.None)
                {
                    return true;
                }
            }

            if (board.GetTopLeftBottomRightSymbol() != Symbol.None)
            {
                return true;
            }

            if (board.GetTopRightBottomLeftSymbol() != Symbol.None)
            {
                return true;
            }

            return board.IsFull();
        }

        public Symbol GetWinner(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                var winner = board.GetRowSymbol(row);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            for (int col = 0; col < board.Columns; col++)
            {
                var winner = board.GetColSymbol(col);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            var diagonalTopLeftBottomRight = board.GetTopLeftBottomRightSymbol();

            if (diagonalTopLeftBottomRight != Symbol.None)
            {
                return diagonalTopLeftBottomRight;
            }

            var diagonalTopRightBottomLeft = board.GetTopRightBottomLeftSymbol();

            if (diagonalTopRightBottomLeft != Symbol.None)
            {
                return diagonalTopRightBottomLeft;
            }

            var draw = Symbol.None;

            return draw;
        }
    }
}
