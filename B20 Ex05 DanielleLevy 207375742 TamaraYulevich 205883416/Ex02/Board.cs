using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02
{
    public class Board
    {
        private List<char> m_DataList = new List<char>();
        private char[,] m_DataMatrix;
        private Cell[,] m_Board;
        private int m_NumberOfRows;
        private int m_NumberOfColums;

        public Board(int i_Rows, int i_Colums)
        {
            m_NumberOfRows = i_Rows;
            m_NumberOfColums = i_Colums;
            m_DataMatrix = new char[i_Rows, i_Colums];
            int timesToActivateRandom = (m_NumberOfRows * m_NumberOfColums) / 2;
            getRandomCharList(timesToActivateRandom);
            arrangeDataMatrix(ref m_DataMatrix);
            initializeEmptyBoard(i_Rows, i_Colums);
        }

        public int Rows
        {
            get
            {
                return m_NumberOfRows;
            }
        }

        public int Columns
        {
            get
            {
                return m_NumberOfColums;
            }
        }

        public List<char> UnmatchedCells
        {
            get
            {
                return m_DataList;
            }
        }

        public char[,] DataMatrix
        {
            get
            {
                return m_DataMatrix;
            }
        }

        public Cell[,] Cells
        {
            get
            {
                return m_Board;
            }
        }

        private static string getBoardString(Board i_Board)
        {
            int i, j, k, rows = i_Board.Rows, columns = i_Board.Columns;
            char charToPrint = 'A';
            string boardString = string.Empty;

            // Top line (Char coordinates)
            boardString += "   ";
            for (i = 0; i < columns; i++)
            {
                boardString += " " + charToPrint++ + "  ";
            }

            boardString += Environment.NewLine;
            boardString += "  =";
            for (i = 0; i < columns; i++)
            {
                boardString += "====";
            }

            boardString += Environment.NewLine;

            // Counted lines section
            for (i = 0; i < rows; i++)
            {
                boardString += string.Empty + (i + 1) + " ";
                for (j = 0; j < columns; j++)
                {
                    charToPrint = (char)i_Board.m_Board[i, j].Data;
                    boardString += "| " + charToPrint + " ";
                }

                boardString += "|" + Environment.NewLine;

                // Print  line divider
                boardString += "  ";
                for (k = 0; k < columns; k++)
                {
                    boardString += "====";
                }

                boardString += "=" + Environment.NewLine;
            }

            return boardString;
        }

        internal static void PrintGameBoard(Board i_BoardGame)
        {
            Console.WriteLine(Board.getBoardString(i_BoardGame));
        }

        internal static bool ValidSize(int i_Rows, int i_Columns)
        {
            bool validRowsNumber = i_Rows >= 4 && i_Rows <= 6;
            bool validColumnsNumber = i_Columns >= 4 && i_Columns <= 6;
            bool evenNumberOfCells = (i_Columns * i_Rows) % 2 == 0;

            return (validColumnsNumber && validRowsNumber) && evenNumberOfCells;
        }

        internal void RemoveMatchedCells(char i_CellData)
        {
            m_DataList.Remove(i_CellData);
            m_DataList.Remove(i_CellData);
        }
        
        internal void AddToBoard(Cell i_Cell)
        {
            i_Cell.Data = m_DataMatrix[i_Cell.RowIndex, i_Cell.ColumnIndex];
            m_Board[i_Cell.RowIndex, i_Cell.ColumnIndex] = i_Cell;
        }

        internal void DeleteFromBoard(Cell i_Cell)
        {
            i_Cell.Data = ' ';
            m_Board[i_Cell.RowIndex, i_Cell.ColumnIndex] = i_Cell;
        }
        
        internal bool BoardIsIncomplete()
        {
            return m_DataList.Count > 0;
        }

        private void initializeEmptyBoard(int i_Rows, int i_Colums)
        {
            m_Board = new Cell[i_Rows, i_Colums];
            for (int i = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Colums; j++)
                {
                    m_Board[i, j] = new Cell(i, j);
                }
            }
        }

        private void getRandomCharList(int i_TimesToActivateRandom)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random randomCellCreator = new Random();
            for (int i = 0; i < i_TimesToActivateRandom; i++)
            {
                int index = randomCellCreator.Next(0, letters.Length);
                m_DataList.Add(letters[index]);
                m_DataList.Add(letters[index]);
                letters = letters.Remove(index, 1);
            }
        }

        private void arrangeDataMatrix(ref char[,] io_DataMatrix)
        {
            List<char> dataListCopy = new List<char>(m_DataList);
            List<char> randomizedList = new List<char>();
            randomizedList = randomizeList(ref randomizedList, dataListCopy);
            int currPosition = 0;
            for (int i = 0; i < m_NumberOfRows; i++)
            {
                for (int j = 0; j < m_NumberOfColums; j++)
                {
                    io_DataMatrix[i, j] = randomizedList[currPosition];
                    currPosition++;
                }
            }
        }

        private List<char> randomizeList(ref List<char> i_RandomizedList, List<char> io_DataList)
        {
            Random random = new Random();
            while (io_DataList.Count > 0)
            {
                int index = random.Next(0, io_DataList.Count);
                i_RandomizedList.Add(io_DataList[index]);
                io_DataList.RemoveAt(index);
            }

            return i_RandomizedList;
        }
    }
}
