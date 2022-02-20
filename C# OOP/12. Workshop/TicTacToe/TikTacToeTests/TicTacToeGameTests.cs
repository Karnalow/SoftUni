using Moq;
using NUnit.Framework;
using System.Linq;
using TicTacToe;
using TicTacToe.Players;
using Index = TicTacToe.Index;

namespace TikTacToeTests
{
    [TestFixture]
    public class TicTacToeGameTests
    {
        [Test]
        public void PlayShouldReturnValue()
        {
            var player = new Mock<IPlayer>();
            player.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x) =>
                {
                    return x.GetEmptyPositions().First();
                });

            var game = new TicTacToeGame(player.Object, player.Object);
        }

        [Test]
        public void PlayShouldReturnCorrectWinner()
        {
            int player1CurrentCol = 0;
            int player2CurrentCol = 1;

            var player1 = new Mock<IPlayer>();
            player1.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x) => new Index(0, player1CurrentCol++));

            var player2 = new Mock<IPlayer>();
            player2.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x) => new Index(1, player2CurrentCol++));

            var game = new TicTacToeGame(player1.Object, player2.Object);

            var winner = game.Play();

            Assert.AreEqual(Symbol.X, winner);
        }
    }
}
