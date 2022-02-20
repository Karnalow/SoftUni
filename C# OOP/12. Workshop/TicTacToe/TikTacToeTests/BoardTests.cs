using NUnit.Framework;
using TicTacToe;
using System.Linq;

namespace TikTacToeTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void IsFullShouldReturnTrueOrFullBoard()
        {
            Board board = new Board(3,3);

            Assert.IsFalse(board.IsFull());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaceSymbol(new TicTacToe.Index(i, j), Symbol.X);
                }
            }

            Assert.IsTrue(board.IsFull());
        }

        [Test]
        public void GetRowSymbolShouldWorkCorrectly()
        {
            Board board = new Board(4, 4);

            for (int i = 0; i < board.Columns; i++)
            {
                board.PlaceSymbol(new TicTacToe.Index(2, i), Symbol.O);
            }

            Assert.AreEqual(Symbol.O, board.GetRowSymbol(2));
        }

        [Test]
        public void GetColSymbolShouldWorkCorrectly()
        {
            Board board = new Board(5, 5);

            for (int i = 0; i < board.Rows; i++)
            {
                board.PlaceSymbol(new TicTacToe.Index(i, 1), Symbol.X);
            }

            Assert.AreEqual(Symbol.X, board.GetColSymbol(1));
        }

        [Test]
        public void GetEmptyPositionsShouldReturnAllPositionsForEmptyBoard()
        {
            var board = new Board(3, 3);

            var positions = board.GetEmptyPositions();

            Assert.AreEqual(3 * 3, positions.Count());
        }


        [Test]
        public void GetEmptyPositionsShouldReturnCorrenctNumberOfPositions()
        {
            var board = new Board(4, 4);

            board.PlaceSymbol(new TicTacToe.Index(1, 1), Symbol.X);
            board.PlaceSymbol(new TicTacToe.Index(2, 2), Symbol.O);

            var positions = board.GetEmptyPositions();

            Assert.AreEqual(4 * 4 - 2, positions.Count());
        }
    }
}
