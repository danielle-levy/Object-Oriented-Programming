using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
    public struct Cell
    {
        private int m_RowIndex;
        private int m_ColumnIndex;
        private char m_Data;

        public Cell(string i_StrCell)
        {
           m_ColumnIndex = (int)i_StrCell[0] - 65;
           m_RowIndex = int.Parse(i_StrCell.Substring(1)) - 1;
           m_Data = ' ';
        }

        public Cell(int i_RowIndex, int i_ColumnIndex)
        {
            m_ColumnIndex = i_ColumnIndex;
            m_RowIndex = i_RowIndex;
            m_Data = ' ';
        }

        public int RowIndex
        {
            get
            {
                return m_RowIndex;
            }
        }

        public int ColumnIndex
        {
            get
            {
                return m_ColumnIndex;
            }
        }

        public char Data
        {
            get
            {
                return m_Data;
            }

            set
            {
                m_Data = value;
            }
        }

        internal static bool IsValidCell(string i_StrCell, Board i_Board)
        {
            bool isLegal = true;
            UI ui = new UI();

            if (i_StrCell.Length != 2 || !char.IsUpper(i_StrCell[0]) || !char.IsDigit(i_StrCell[1]))
            {
                if (isLegal)
                {
                    ui.SyntaxInvalidCell();
                    isLegal = false;
                }
            }

            if (isLegal)
            {
                outOfBoundCell(ref isLegal, i_StrCell, i_Board);
            }

            if (isLegal)
            {
                isLegal = availableCell(i_StrCell, i_Board);
            }

            return isLegal;
        }

        public static bool outOfBoundCell(ref bool i_IsLegal, string i_StrCell, Board i_Board)
        {
            bool indexOfRowBool = int.TryParse(i_StrCell.Substring(1), out int indexOfRow);
            bool columnOutOfBound = (int)i_StrCell[0] > i_Board.Columns + 64 || (int)i_StrCell[0] < 64;
            bool rowOutOfBound = indexOfRow > i_Board.Rows || indexOfRow < 1 || !indexOfRowBool;
            UI ui = new UI();

            if (columnOutOfBound || rowOutOfBound)
            {                
                if (i_IsLegal)
                {
                    ui.LogicOutOfBoundCell();
                    i_IsLegal = false;
                }
            }

            return i_IsLegal;
        }
    
        private static bool availableCell(string i_StrCell, Board i_Board)
        {
            Cell legalCell = new Cell(i_StrCell);
            bool availableCell = i_Board.UnmatchedCells.Contains(i_Board.DataMatrix[legalCell.RowIndex, legalCell.ColumnIndex]);
            UI ui = new UI();

            if (!availableCell)
            {
                ui.UnavailableCell();
            }

            return availableCell;
        }

        internal bool HasSameIndexes(Cell i_Cell)
        {
            return (m_RowIndex == i_Cell.m_RowIndex) && (m_ColumnIndex == i_Cell.m_ColumnIndex);
        }
    }
}
