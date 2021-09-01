using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace B20_Ex02
{
    public class UI
    {
        public void HelloMessage()
        {
            Console.WriteLine("Hello! Welcome to our memory game!");
        }

        public void ByeMessage()
        {
            Console.WriteLine("See you next time! Bye :)");
        }

        public string GetPlayersName(string i_Player)
        {
            Console.WriteLine(string.Format("Please enter {0} name: (20 characters max, without spaces)", i_Player));
            string playerName = Console.ReadLine();

            while (!Player.IsValidUserName(playerName))
            {
                Console.WriteLine(string.Format("The name you entered is not valid, Please try again:"));
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        public int SecondPlayerType()
        {
            int playerTwoType;
            Console.WriteLine(string.Format(@"Choose one of the options:
1.If you want to play vs the computer type '1'
2.If you want to play vs another player type '2'"));
            string secondPlayerType = Console.ReadLine();

            while (!Player.IsValidPlayerTypeChoice(secondPlayerType, out playerTwoType))
            {
                Console.WriteLine("This is not a valid option, please try again:");
                secondPlayerType = Console.ReadLine();
            }

            return playerTwoType;
        }

        public string GetOpponentsName(int i_Type)
        {
            string secondPlayerName = string.Empty;
            if (i_Type == (int)Player.ePlayerType.Human)
            {
                secondPlayerName = GetPlayersName("your opponent's");
            }

            if (i_Type == (int)Player.ePlayerType.Computer)
            {
                secondPlayerName = "Computer";
            }

            return secondPlayerName;
        }

        public void GetBoardSize(out int o_NumOfRows, out int o_NumOfColumns)
        {
            Console.WriteLine("Please enter number of rows: (a number between 4-6)");
            bool rowsBool = int.TryParse(Console.ReadLine(), out o_NumOfRows);
            Console.WriteLine("Please enter number of columns: (a number between 4-6)");
            bool columnsBool = int.TryParse(Console.ReadLine(), out o_NumOfColumns);
            while (!Board.ValidSize(o_NumOfRows, o_NumOfColumns) || !rowsBool || !columnsBool)
            {
                Console.WriteLine(string.Format(@"The size you entered is not valid, you should
enter at least one even number."));
                Console.WriteLine("Please enter number of rows: (a number between 4-6)");
                rowsBool = int.TryParse(Console.ReadLine(), out o_NumOfRows);
                Console.WriteLine("Please enter number of columns: (a number between 4-6)");
                columnsBool = int.TryParse(Console.ReadLine(), out o_NumOfColumns);
            }
        }

        public Cell GetCellFromCurrentPlayer(Player i_CurrentPlayer, Board i_Board)
        {
            Console.WriteLine("Please choose a valid cell index:");
            string currentPlayerCell = Console.ReadLine();

            while (!Cell.IsValidCell(currentPlayerCell, i_Board))
            {
                if (CheckIfQuit(currentPlayerCell))
                {
                    Environment.Exit(1);
                }

                currentPlayerCell = Console.ReadLine();
            }

            Cell chosenCell = new Cell(currentPlayerCell);
            chosenCell.Data = i_Board.DataMatrix[chosenCell.RowIndex, chosenCell.ColumnIndex];
            Ex02.ConsoleUtils.Screen.Clear();
            i_Board.AddToBoard(chosenCell);
            Board.PrintGameBoard(i_Board);

            return chosenCell;
        }

        public bool CheckIfQuit(string i_Str)
        {
            return i_Str == "Q";
        }

        public void SameCellMessage()
        {
            Console.WriteLine("You already chose this cell, please try again:");
        }

        public void SyntaxInvalidCell()
        {
            Console.WriteLine("Invalid syntax! Please type an uppercase letter followed by a digit:");
        }

        public void LogicOutOfBoundCell()
        {
            Console.WriteLine("The cell you chose is out of bound! Please try again:");
        }

        public void UnavailableCell()
        {
            Console.WriteLine("This cell already found it's pair! Please try again:");
        }

        public bool AnotherGame()
        {
            bool resetGame = true;
            Console.WriteLine("Would you like to start another game? Y / N:");
            string answer = Console.ReadLine();
            while (answer != "Y" && answer != "N")
            {
                Console.WriteLine("Please type Y or N:");
                answer = Console.ReadLine();
            }

            if (answer == "N")
            {
                resetGame = false;
            }

            return resetGame;
        }

        public void GameResult(MemoryGame i_MemoryGame)
        {
            Console.WriteLine("{0}'s score is: {1}", i_MemoryGame.CurrentPlayer.Name, i_MemoryGame.CurrentPlayer.Score);
            Console.WriteLine("{0}'s score is: {1}", i_MemoryGame.NextPlayer.Name, i_MemoryGame.NextPlayer.Score);
         
            if (i_MemoryGame.TheWinnerIs() == string.Empty)
            {
                Console.WriteLine("It's a tie!");
            }
            else
            {
                Console.WriteLine("The winner is: {0}, Congratulations!", i_MemoryGame.TheWinnerIs());
            }
        }

        public void PlayerTurn(Player i_CurrentPlayer)
        {
            Console.WriteLine(string.Format("{0}'s turn:", i_CurrentPlayer.Name));
        }
    }
}
