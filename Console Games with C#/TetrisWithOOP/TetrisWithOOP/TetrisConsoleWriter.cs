using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisWithOOP
{
    public class TetrisConsoleWriter
    {
        private int tetrisRows;
        private int tetrisCols;
        private int infoCols;
        private int consoleRows;
        private int consoleCols;
        private char tetrisCharacter;

        public TetrisConsoleWriter(int tetrisRow,
            int tetrisCols,
            char tetrisCharacter = '*',
            int infoCols = 11)
        {
            this.tetrisRows = tetrisRow;
            this.tetrisCols = tetrisCols;
            this.tetrisCharacter = tetrisCharacter;
            this.infoCols = infoCols;

            this.consoleRows = 1 + this.tetrisRows + 1;
            this.consoleCols = 1 + this.tetrisCols + 1 + this.infoCols + 1;

            this.Frame = 0;
            this.FramesToMoveFigure = 15;

            Console.WindowHeight = this.consoleRows + 1;
            Console.WindowWidth = this.consoleCols;
            Console.BufferHeight = this.consoleRows + 1;
            Console.BufferWidth = this.consoleCols;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "Tetris";
            Console.CursorVisible = false;
        }

        public int Frame { get; set; }

        public int FramesToMoveFigure { get; private set; }

        public void DrawAll(ITetrisGame state, ScoreManager scoreManager)
        {
            this.DrawBorder();
            this.DrawGameState(3 + this.tetrisCols, state, scoreManager);
            this.DrawTetrisField(state.TetrisField);
            this.DrawCurrentFigure(state.CurrentFigure, state.CurrentFigureRow, state.CurrentFigureCol);
        }

        public void DrawGameState(int startCol, ITetrisGame state, ScoreManager scoreManager)
        {
            this.Write("Level:", 1, startCol);
            this.Write(state.Level.ToString(), 2, startCol);
            
            this.Write("Score:", 4, startCol);
            this.Write(scoreManager.Score.ToString(), 5, startCol);
            
            this.Write("Best:", 7, startCol);
            this.Write(scoreManager.HighScore.ToString(), 8, startCol);
            
            this.Write("Frame:", 10, startCol);
            this.Write(this.Frame.ToString() + " / " + (this.FramesToMoveFigure - state.Level).ToString(), 11, startCol);
            
            this.Write("Position:", 13, startCol);
            this.Write($"{state.CurrentFigureRow}, {state.CurrentFigureCol}", 14, startCol);
            
            this.Write("Keys:", 16, startCol);
            this.Write($"  ^ ", 17, startCol);
            this.Write($"<   > ", 18, startCol);
            this.Write($"  v  ", 19, startCol);
        }

        public void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);

            string line = "╔";
            line += new string('═', this.tetrisCols);
            line += "╦";
            line += new string('═', this.infoCols);
            line += "╗";

            Console.Write(line);

            for (int i = 0; i < this.tetrisRows; i++)
            {
                string middleLine = "║";

                middleLine += new string(' ', this.tetrisCols);
                middleLine += "║";
                middleLine += new string(' ', this.infoCols);
                middleLine += "║";

                Console.Write(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', this.tetrisCols);
            endLine += "╩";
            endLine += new string('═', this.infoCols);
            endLine += "╝";

            Console.Write(endLine);
        }

        public void WriteGameOver(int score)
        {
            int row = this.tetrisRows / 2 - 3;
            int col = (this.tetrisCols + 3 + this.infoCols) / 2 - 6;

            var scoreAsString = score.ToString();
            scoreAsString = new string(' ', 7 - scoreAsString.Length) + scoreAsString;

            this.Write("╔═════════╗", row, col);
            this.Write("║ Game    ║", row + 1, col);
            this.Write("║   over! ║", row + 2, col);
            this.Write($"║ {scoreAsString} ║", row + 3, col);
            this.Write("╚═════════╝", row + 4, col);
        }

        public void DrawCurrentFigure(Tetromino currentFigure, int currentFigureRow, int currentFigureCol)
        {
            for (int row = 0; row < currentFigure.Body.GetLength(0); row++)
            {
                for (int col = 0; col < currentFigure.Body.GetLength(1); col++)
                {
                    if (currentFigure.Body[row, col])
                    {
                        Write(tetrisCharacter.ToString(), row + 1 + currentFigureRow, col + 1 + currentFigureCol);
                    }
                }
            }
        }

        public void DrawTetrisField(bool[,] tetrisField)
        {
            for (int row = 0; row < tetrisField.GetLength(0); row++)
            {
                string line = string.Empty;

                for (int col = 0; col < tetrisField.GetLength(1); col++)
                {
                    if (tetrisField[row, col])
                    {
                        line += tetrisCharacter;
                    }
                    else
                    {
                        line += " ";
                    }
                }

                this.Write(line, row + 1, 1);
            }
        }

        private void Write(string text, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }
    }
}
