using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{

    public class Board : IBoard
    {
        private Symbol[,] board;

        public Board()
            : this(3, 3)
        {

        }

        public Board(int rows, int columns)
        {
            if (rows != columns)
            {
                throw new ArgumentException("Rows should be equal to columns");
            }

            Rows = rows;
            Columns = columns;

            board = new Symbol[rows, columns];
        }

        public int Rows { get; }

        public int Columns { get; }

        public Symbol[,] BoardState => this.board;

        public IEnumerable<Index> GetEmptyPositions()
        {
            List<Index> positions = new List<Index>();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (this.board[row, col] == Symbol.None)
                    {
                        positions.Add(new Index(row, col));
                    }
                }
            }

            return positions;
        }

        public Symbol GetRowSymbol(int row)
        {
            var symbol = this.board[row, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int col = 1; col < this.Columns; col++)
            {
                if (this.board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetColSymbol(int column)
        {
            var symbol = this.board[0, column];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < this.Rows; row++)
            {
                if (this.board[row, column] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetTopLeftBottomRightSymbol()
        {
            var symbol = this.board[0, 0];

            if (symbol == Symbol.None)
            {
                return symbol;
            }

            for (int i = 1; i < this.Rows; i++)
            {
                if (this.board[i, i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetTopRightBottomLeftSymbol()
        {
            var symbol = this.board[0, this.Rows - 0 - 1];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < this.Rows; row++)
            {
                if (this.board[row, this.Rows - row - 1] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public bool IsFull()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (this.board[row, col] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Column < 0 ||
                index.Row > this.Rows || index.Column > this.Columns)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            this.board[index.Row, index.Column] = symbol;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (this.board[row, col] == Symbol.None)
                    {
                        sb.Append('.');
                    }
                    else
                    {
                        sb.Append(this.board[row, col]);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
