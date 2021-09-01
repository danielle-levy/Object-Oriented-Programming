using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace MemoryGameApplication
{
    public partial class MemoryGameBoardForm : Form
    {
        private readonly Dictionary<char, Image> r_ImageLetterDict = new Dictionary<char, Image>();
        private readonly Button[,] r_ButtonsBoard;
        private readonly GameManager r_GameManager;
        private readonly Label r_CurrentPlayerTurn = new Label();
        private readonly Label r_Player1Name = new Label();
        private readonly Label r_Player2Name = new Label();
        private readonly string r_FirstPlayerName;
        private readonly string r_SecondPlayerName;
        private Button m_FirstButtonClicked;
        private Button m_SecondButtonClicked;
        private Color m_PurpleBackColor = Color.FromArgb(191, 191, 255);
        private Color m_GreenBackColor = Color.FromArgb(192, 255, 192);

        public MemoryGameBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_NumOfRows, int i_NumOfColumns, bool i_IsComputer)
        {
            r_FirstPlayerName = i_FirstPlayerName;
            r_SecondPlayerName = i_SecondPlayerName;
            r_GameManager = new GameManager(i_NumOfRows, i_NumOfColumns, i_FirstPlayerName, i_SecondPlayerName, i_IsComputer);
            r_ButtonsBoard = new Button[i_NumOfRows, i_NumOfColumns];
            initComponents();
            buildImageLetterDict();
        }

        private void initComponents()
        {
            Text = "Memory Game";
            MaximizeBox = false;
            const int blockSize = 60;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += new FormClosingEventHandler(MemoryGame_Closing);
            Controls.Clear();
            int maxRowColumns = Math.Max(r_GameManager.Board.Columns, r_GameManager.Board.Rows);
            Size = new Size((r_GameManager.Board.Columns * blockSize) + ((r_GameManager.Board.Columns - 1) * 10) + 37, (r_GameManager.Board.Rows * blockSize) + ((r_GameManager.Board.Rows - 1) * 10) + 150);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int i = 0; i < r_GameManager.Board.Rows; i++)
            {
                for (int j = 0; j < r_GameManager.Board.Columns; j++)
                {
                    r_ButtonsBoard[i, j] = new Button();
                    r_ButtonsBoard[i, j].Size = new Size(blockSize, blockSize);
                    r_ButtonsBoard[i, j].Location = new Point(10 + (j * 70), 10 + (i * 70));
                    r_ButtonsBoard[i, j].Name = string.Format("{0}{1}", i + 1, (char)(j + 65));
                    r_ButtonsBoard[i, j].BackColor = Color.LightGray;
                    Controls.Add(r_ButtonsBoard[i, j]);
                    r_ButtonsBoard[i, j].Click += new EventHandler(buttons_FirstClick);
                }
            }

            r_CurrentPlayerTurn.AutoSize = true;
            r_CurrentPlayerTurn.Top = (r_GameManager.Board.Rows * blockSize) + ((r_GameManager.Board.Rows - 1) * 10) + 20;
            r_CurrentPlayerTurn.Left = 12;
            r_CurrentPlayerTurn.Name = "currentPlayerTurn";
            r_CurrentPlayerTurn.TabIndex = 1;
            r_CurrentPlayerTurn.BackColor = m_GreenBackColor;
            r_CurrentPlayerTurn.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
            Controls.Add(r_CurrentPlayerTurn);

            r_Player1Name.AutoSize = true;
            r_Player1Name.Top = r_CurrentPlayerTurn.Bottom + 10;
            r_Player1Name.Left = 12;
            r_Player1Name.Name = "player1Name";
            r_Player1Name.TabIndex = 0;
            r_Player1Name.BackColor = m_GreenBackColor;
            r_Player1Name.Text = r_GameManager.CurrentPlayer.Name + ": 0 Pair";

            r_Player2Name.AutoSize = true;
            r_Player2Name.Top = r_Player1Name.Bottom + 5;
            r_Player2Name.Left = 12;
            r_Player2Name.Name = "player2Name";
            r_Player2Name.TabIndex = 1;
            r_Player2Name.BackColor = m_PurpleBackColor;
            r_Player2Name.Text = r_GameManager.NextPlayer.Name + ": 0 Pair";

            Controls.Add(r_Player1Name);
            Controls.Add(r_Player2Name);
        }

        private void buildImageLetterDict()
        {
            WebClient webClient = new WebClient();
            for (int i = 0; i < r_GameManager.Board.UnmatchedCells.Count; i++)
            {
                if (!r_ImageLetterDict.ContainsKey(r_GameManager.Board.UnmatchedCells[i]))
                {
                    byte[] bytes = webClient.DownloadData("https://picsum.photos/80");
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    Image image = Image.FromStream(memoryStream);
                    r_ImageLetterDict.Add(r_GameManager.Board.UnmatchedCells[i], image);
                }
            }
        }

        public void UpdatePlayersScore()
        {
            bool scoreIsOne = GetFirstPlayerScore() == 1;
            r_Player1Name.Text = string.Format("{0}: {1} Pair{2}s{3}", r_FirstPlayerName, GetFirstPlayerScore(), scoreIsOne ? "(" : string.Empty, scoreIsOne ? ")" : string.Empty);
            r_Player1Name.BackColor = m_GreenBackColor;
            r_Player1Name.Update();
            scoreIsOne = GetSecondPlayerScore() == 1;
            r_Player2Name.Text = string.Format("{0}: {1} Pair{2}s{3}", r_SecondPlayerName, GetSecondPlayerScore(), scoreIsOne ? "(" : string.Empty, scoreIsOne ? ")" : string.Empty);
            r_Player2Name.BackColor = m_PurpleBackColor;
            r_Player2Name.Update();
        }

        public int GetFirstPlayerScore()
        {
            int score;
            if (r_GameManager.CurrentPlayer.PlayerNumber == Player.ePlayerNumber.PlayerOne)
            {
                score = r_GameManager.CurrentPlayer.Score;
            }
            else
            {
                score = r_GameManager.NextPlayer.Score;
            }

            return score;
        }

        public int GetSecondPlayerScore()
        {
            int score;
            if (r_GameManager.CurrentPlayer.PlayerNumber == Player.ePlayerNumber.PlayerTwo)
            {
                score = r_GameManager.CurrentPlayer.Score;
            }
            else
            {
                score = r_GameManager.NextPlayer.Score;
            }

            return score;
        }

        private void buttons_FirstClick(object sender, EventArgs e)
        {
            updateButtonsSettings(sender as Button);
            m_FirstButtonClicked = sender as Button;

            foreach (Button b in r_ButtonsBoard)
            {
                b.Click -= buttons_FirstClick;
                b.Click += buttons_SecondClick;
            }
        }

        private void buttons_SecondClick(object sender, EventArgs e)
        {
            updateButtonsSettings(sender as Button);
            m_SecondButtonClicked = sender as Button;
            Cell firstChosenCell = new Cell(m_FirstButtonClicked.Name.ToString());
            Cell secondChosenCell = new Cell(m_SecondButtonClicked.Name.ToString());
            firstChosenCell.Data = m_FirstButtonClicked.Tag.ToString()[0];
            secondChosenCell.Data = (char)m_SecondButtonClicked.Tag.ToString()[0];
            bool checkIfMatched = r_GameManager.CurrentPlayerMove(firstChosenCell, secondChosenCell);
            if (!checkIfMatched)
            {
                unClickButtons();
                UpdateCurrentPlayer();
            }
            else
            {
                UpdatePlayersScore();
                updateMatched();
            }

            if (r_GameManager.IsEndGame())
            {
                messageBoxEndGame();
            }

            foreach (Button b in r_ButtonsBoard)
            {
                b.Click -= buttons_SecondClick;
                b.Click += buttons_FirstClick;
            }

            if (r_GameManager.CurrentPlayer.PlayerType == (int)Player.ePlayerType.Computer)
            {
                ComputerMove();
            }
        }

        private void unClickButtons()
        {
            m_FirstButtonClicked.BackColor = Color.LightGray;
            m_SecondButtonClicked.BackColor = Color.LightGray;
            m_FirstButtonClicked.Tag = string.Empty;
            m_FirstButtonClicked.Enabled = true;
            m_SecondButtonClicked.Tag = string.Empty;
            m_SecondButtonClicked.Enabled = true;
            m_FirstButtonClicked.BackgroundImage = null;
            m_SecondButtonClicked.BackgroundImage = null;
            m_FirstButtonClicked.Update();
            m_SecondButtonClicked.Update();
        }

        private void updateMatched()
        {
            r_GameManager.Board.Cells[m_FirstButtonClicked.Name[0] - 49, m_FirstButtonClicked.Name[1] - 65].Data = m_FirstButtonClicked.Tag.ToString()[0];
            r_GameManager.Board.Cells[m_SecondButtonClicked.Name[0] - 49, m_SecondButtonClicked.Name[1] - 65].Data = m_SecondButtonClicked.Tag.ToString()[0];
        }

        private void updateButtonsSettings(Button i_Button)
        {
            int i = i_Button.Name[0] - 49;
            int j = i_Button.Name[1] - 65;
            i_Button.BackColor = r_CurrentPlayerTurn.BackColor;
            i_Button.BackgroundImage = new Bitmap(r_ImageLetterDict[r_GameManager.Board.DataMatrix[i, j]], new Size(45, 45));
            i_Button.BackgroundImageLayout = ImageLayout.Center;
            i_Button.Tag = r_GameManager.Board.DataMatrix[i, j].ToString();
            i_Button.Update();
            i_Button.Enabled = false;
        }

        public void ComputerClick(Cell i_Cell)
        {
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].Tag = i_Cell.Data.ToString();
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].BackColor = m_PurpleBackColor;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].BackgroundImage = new Bitmap(r_ImageLetterDict[r_GameManager.Board.DataMatrix[i_Cell.RowIndex, i_Cell.ColumnIndex]], new Size(45, 45));
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].BackgroundImageLayout = ImageLayout.Center;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].Enabled = false;
        }

        public void CancleComputerClick(Cell i_Cell)
        {
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].Enabled = true;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].Tag = string.Empty;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].BackColor = Color.LightGray;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].BackgroundImage = null;
            r_ButtonsBoard[i_Cell.RowIndex, i_Cell.ColumnIndex].Update();
        }

        private void ComputerMove()
        {
            if (r_GameManager.IsEndGame())
            {
                messageBoxEndGame();
                return;
            }

            Cell firstChosenCell;
            Cell secondChosenCell;
            r_GameManager.ComputerPlayerMove(r_GameManager.Board, out firstChosenCell, out secondChosenCell);
            performComputerMove(firstChosenCell, secondChosenCell);
            bool checkIfMatched = r_GameManager.CurrentPlayerMove(firstChosenCell, secondChosenCell);
            if (!checkIfMatched)
            {
                CancleComputerClick(firstChosenCell);
                CancleComputerClick(secondChosenCell);
                UpdateCurrentPlayer();
            }
            else
            {
                UpdatePlayersScore();
                r_GameManager.Board.AddToBoard(firstChosenCell);
                r_GameManager.Board.AddToBoard(secondChosenCell);
                Thread.Sleep(1000);
                ComputerMove();
            }
        }

        private void performComputerMove(Cell i_FirstChosenCell, Cell i_SecondChosenCell)
        {
            ComputerClick(i_FirstChosenCell);
            Thread.Sleep(500);
            ComputerClick(i_SecondChosenCell);
        }

        private void MemoryGame_Closing(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void UpdateCurrentPlayer()
        {
            bool currentBackColorIsPurple = r_CurrentPlayerTurn.BackColor == m_PurpleBackColor;
            r_CurrentPlayerTurn.BackColor = currentBackColorIsPurple ? m_GreenBackColor : m_PurpleBackColor;
            r_CurrentPlayerTurn.Text = "Current Player: " + r_GameManager.CurrentPlayer.Name;
            r_CurrentPlayerTurn.Refresh();
        }

        private void messageBoxEndGame()
        {
            string message = r_GameManager.TheWinnerIs() == "It's a tie!" ? "It's a tie!" : $"{r_GameManager.TheWinnerIs()} won with the score of: {r_GameManager.GetWinnerScore()}";
            message = string.Format(
                @"{0} 
Would you like to play again?", 
                message);
            const string caption = "Game over ッ";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            r_GameManager.GameOver(result == DialogResult.No);
            if (result == DialogResult.Yes)
            {
                ResetForm();
            }
        }
        
        private void ResetForm()
        {
            foreach(Button button in r_ButtonsBoard)
            {
                button.Tag = string.Empty;
                button.Enabled = true;
                button.BackColor = Color.LightGray;
                button.BackgroundImage = null;
            }

            buildImageLetterDict();
            UpdatePlayersScore();
        }
    }
}