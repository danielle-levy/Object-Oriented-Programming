using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MemoryGameApplication
{
    public class MemoryGame
    {
        private UI m_UI = new UI();
        private Board m_GameBoard;
        private Player m_CurrentPlayer = new Player();
        private Player m_NextPlayer = new Player();

        public MemoryGame(int i_Rows, int i_Columns, string i_Player1Name, string i_Player2Name, bool i_IsPc)
        {
            updateBoardSize(i_Rows, i_Columns);
            updatePlayersDetails(i_Player1Name, i_Player2Name, i_IsPc);
            startGame();
        }

        public MemoryGame()
        {
            m_UI.HelloMessage();
            string firstPlayerName = m_UI.GetPlayersName("your");
            int playerTwoType = m_UI.SecondPlayerType();
            string secondPlayerName = m_UI.GetOpponentsName(playerTwoType);

            m_UI.GetBoardSize(out int numberOfRows, out int numberOfColumns);

            MemoryGame game = new MemoryGame(numberOfRows, numberOfColumns, firstPlayerName, secondPlayerName, playerTwoType == (int)Player.ePlayerType.Computer);
        }

        private void startGame()
        {
            Board.PrintGameBoard(m_GameBoard);
            while (!isEndGame())
            {
                currentPlayerMove();
            }

            gameOver();
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

        private void currentPlayerMove()
        {
            m_UI.PlayerTurn(m_CurrentPlayer);
            Cell firstChosenCell;
            Cell secondChosenCell;

            if (m_CurrentPlayer.PlayerType == (int)Player.ePlayerType.Computer)
            {
                computerPlayerMove(m_CurrentPlayer, m_GameBoard, out firstChosenCell, out secondChosenCell);
            }
            else
            {
                humanPlayerMove(m_CurrentPlayer, m_GameBoard, out firstChosenCell, out secondChosenCell);
            }

            if (isAMatch(firstChosenCell, secondChosenCell))
            {
                m_GameBoard.RemoveMatchedCells(firstChosenCell.Data);
                m_CurrentPlayer.Score++;
            }
            else
            {
                isNotAMatch(firstChosenCell, secondChosenCell);
            }
        }

        private void isNotAMatch(Cell i_FirstChosenCell, Cell i_SecondChosenCell)
        {
            Thread.Sleep(2000);
            m_GameBoard.DeleteFromBoard(i_FirstChosenCell);
            m_GameBoard.DeleteFromBoard(i_SecondChosenCell);
            Ex02.ConsoleUtils.Screen.Clear();
            Board.PrintGameBoard(m_GameBoard);
            switchPlayers();
        }

        private void computerPlayerMove(Player i_Player, Board io_BoardGame, out Cell o_firstChosenCell, out Cell o_secondChosenCell)
        {
            o_firstChosenCell = getCellFromComputer();
            o_secondChosenCell = getCellFromComputer(o_firstChosenCell);
        }

        private void humanPlayerMove(Player i_Player, Board io_BoardGame, out Cell o_firstChosenCell, out Cell o_secondChosenCell)
        {
            o_firstChosenCell = m_UI.GetCellFromCurrentPlayer(i_Player, io_BoardGame);
            o_secondChosenCell = m_UI.GetCellFromCurrentPlayer(i_Player, io_BoardGame);
            while (o_firstChosenCell.HasSameIndexes(o_secondChosenCell))
            {
                m_UI.SameCellMessage();
                o_secondChosenCell = m_UI.GetCellFromCurrentPlayer(i_Player, io_BoardGame);
            }
        }

        private void showTempBoard(Cell i_Cell)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            m_GameBoard.AddToBoard(i_Cell);
            Board.PrintGameBoard(m_GameBoard);
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
            showTempBoard(firstCell);

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
            showTempBoard(secondCell);

            return secondCell;
        }

        private bool isEndGame()
        {
            return !m_GameBoard.BoardIsIncomplete();
        }

        private void resetGame(int i_Rows, int i_Columns)
        {
            updateBoardSize(i_Rows, i_Columns);
            m_CurrentPlayer.Score = 0;
            m_NextPlayer.Score = 0;
            startGame();
        }

        internal string TheWinnerIs()
        {
            string winner = string.Empty;
            if(m_CurrentPlayer.Score > m_NextPlayer.Score)
            {
                winner = m_CurrentPlayer.Name;
            }

            if (m_CurrentPlayer.Score < m_NextPlayer.Score)
            {
                winner = m_NextPlayer.Name;
            }

            return winner;
        }

        private void gameOver()
        {
            m_UI.GameResult(this);
            bool resetGameBool = m_UI.AnotherGame();
            if (resetGameBool)
            {
                m_UI.GetBoardSize(out int numberOfRows, out int numberOfColumns);
                resetGame(numberOfRows, numberOfColumns);
            }
            else
            {
                m_UI.ByeMessage();
            }
        }

        private void updatePlayersDetails(string i_Player1Name, string i_Player2Name, bool i_IsPc)
        {
            int player2Type = i_IsPc == true ? (int)Player.ePlayerType.Computer : (int)Player.ePlayerType.Human;

            m_CurrentPlayer.Name = i_Player1Name;
            m_NextPlayer.Name = i_Player2Name;
            m_NextPlayer.PlayerType = player2Type;
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
