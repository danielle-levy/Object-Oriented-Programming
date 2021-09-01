using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MemoryGameApplication
{
    public class GameManager
    {
        private UI m_UI = new UI();

        private Board m_GameBoard;
        private Player m_CurrentPlayer = new Player();
        private Player m_NextPlayer = new Player();
   
        public GameManager(int i_Rows, int i_Columns, string i_Player1Name, string i_Player2Name, bool i_IsPc)
        {
            updateBoardSize(i_Rows, i_Columns);
            updatePlayersDetails(i_Player1Name, i_Player2Name, i_IsPc);
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public Player NextPlayer
        {
            get
            {
                return m_NextPlayer;
            }
        }

        public Board Board
        {
            get
            {
                return m_GameBoard;
            }
        }

        internal bool CurrentPlayerMove(Cell firstChosenCell, Cell secondChosenCell)
        {
            bool thereWasAMatch = false;
            if (isAMatch(firstChosenCell, secondChosenCell))
            {
                m_GameBoard.RemoveMatchedCells(firstChosenCell.Data);
                m_CurrentPlayer.Score++;
                thereWasAMatch = true;
            }
            else
            {
                isNotAMatch(firstChosenCell, secondChosenCell);
            }

            return thereWasAMatch;
        }

        private void isNotAMatch(Cell i_FirstChosenCell, Cell i_SecondChosenCell)
        {
            Thread.Sleep(2000);
            switchPlayers();
        }

        internal void ComputerPlayerMove(Board io_BoardGame, out Cell o_firstChosenCell, out Cell o_secondChosenCell)
        {
            o_firstChosenCell = getCellFromComputer();
            o_secondChosenCell = getCellFromComputer(o_firstChosenCell);
        }

        private Cell getCellFromComputer()
        {
            Random random = new Random();
            int columnIndex = random.Next(0, m_GameBoard.Columns);
            int rowIndex = random.Next(0, m_GameBoard.Rows);

            while (m_GameBoard.Cells[rowIndex, columnIndex].Data != ' ')
            {
                columnIndex = random.Next(0, m_GameBoard.Columns);
                rowIndex = random.Next(0, m_GameBoard.Rows);
            }

            Cell firstCell = new Cell(rowIndex, columnIndex);
            firstCell.Data = m_GameBoard.DataMatrix[rowIndex, columnIndex];

            return firstCell;
        }

        private Cell getCellFromComputer(Cell i_OtherCell)
        {
            Random random = new Random();
            int columnIndex = random.Next(0, m_GameBoard.Columns);
            int rowIndex = random.Next(0, m_GameBoard.Rows);

            while (m_GameBoard.Cells[rowIndex, columnIndex].Data != ' ' || (rowIndex == i_OtherCell.RowIndex && columnIndex == i_OtherCell.ColumnIndex))
            {
                columnIndex = random.Next(0, m_GameBoard.Columns);
                rowIndex = random.Next(0, m_GameBoard.Rows);
            }

            Cell secondCell = new Cell(rowIndex, columnIndex);
            secondCell.Data = m_GameBoard.DataMatrix[rowIndex, columnIndex];

            return secondCell;
        }

        internal bool IsEndGame()
        {
            return !m_GameBoard.BoardIsIncomplete();
        }

        private void resetGame(int i_Rows, int i_Columns)
        {
            m_CurrentPlayer.Score = 0;
            m_NextPlayer.Score = 0;
            updateBoardSize(i_Rows, i_Columns);
        }

        internal string TheWinnerIs()
        {
            string winner = "It's a tie!";
            if (m_CurrentPlayer.Score > m_NextPlayer.Score)
            {
                winner = m_CurrentPlayer.Name;
            }

            if (m_CurrentPlayer.Score < m_NextPlayer.Score)
            {
                winner = m_NextPlayer.Name;
            }

            return winner;
        }

        internal int GetWinnerScore()
        {
            return CurrentPlayer.Score > NextPlayer.Score ? CurrentPlayer.Score : NextPlayer.Score;
        }

        internal void GameOver(bool i_EndGame)
        {
            if (!i_EndGame)
            {
               resetGame(m_GameBoard.Rows, m_GameBoard.Columns);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void updatePlayersDetails(string i_Player1Name, string i_Player2Name, bool i_IsPc)
        {
            int player2Type = i_IsPc == true ? (int)Player.ePlayerType.Computer : (int)Player.ePlayerType.Human;

            m_CurrentPlayer.Name = i_Player1Name;
            m_CurrentPlayer.PlayerNumber = Player.ePlayerNumber.PlayerOne;
            m_NextPlayer.Name = i_Player2Name;
            m_NextPlayer.PlayerType = player2Type;
            m_NextPlayer.PlayerNumber = Player.ePlayerNumber.PlayerTwo;
            m_CurrentPlayer.PlayerType = (int)Player.ePlayerType.Human;
        }

        private void updateBoardSize(int i_Rows, int i_Columns)
        {
            m_GameBoard = new Board(i_Rows, i_Columns);
        }

        private void switchPlayers()
        {
            Player.Swap(ref m_CurrentPlayer, ref m_NextPlayer);
        }

        private bool isAMatch(Cell i_FirstCell, Cell i_SecondCell)
        {
            return i_FirstCell.Data == i_SecondCell.Data;
        }
    }
}
