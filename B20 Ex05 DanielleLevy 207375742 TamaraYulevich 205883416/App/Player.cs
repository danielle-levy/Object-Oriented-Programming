using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameApplication
{
    public class Player
    {
        private const int k_MaxUserNameSize = 20;

        public enum ePlayerType
        {
            Computer = 1,
            Human = 2,
        }

        public enum ePlayerNumber
        {
            PlayerOne = 1,
            PlayerTwo = 2,
        }

        private int m_PlayerType;
        private string m_Name;
        private int m_Score = 0;
        private ePlayerNumber m_PlayerNumber;

        internal static void Swap(ref Player io_PlayerOne, ref Player io_PlayerTwo)
        {
            Player temp;

            temp = io_PlayerOne;
            io_PlayerOne = io_PlayerTwo;
            io_PlayerTwo = temp;
        }

        internal static bool IsValidUserName(string i_UserName)
        {
            bool nameContainSpaces = i_UserName.Contains(" ");

            return i_UserName.Length <= k_MaxUserNameSize && !nameContainSpaces;
        }

        internal static bool IsValidPlayerTypeChoice(string i_playerType, out int o_result)
        {
            bool isNumeric = int.TryParse(i_playerType, out o_result);

            return isNumeric && (o_result == (int)Player.ePlayerType.Computer || o_result == (int)Player.ePlayerType.Human);
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public int PlayerType
        {
            get
            {
                return m_PlayerType;
            }

            set
            {
                m_PlayerType = value;
            }
        }

        public ePlayerNumber PlayerNumber
        {
            get
            {
                return m_PlayerNumber;
            }

            set
            {
                m_PlayerNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }
    }
}
