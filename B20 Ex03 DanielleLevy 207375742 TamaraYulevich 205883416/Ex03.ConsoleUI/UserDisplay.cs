using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class UserDisplay
    {
        public void DisplayMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public void ReadLine()
        {
            Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ClearAndDisplayMessage(string i_Message)
        {
            Clear();
            DisplayMessage(i_Message);
        }

        public void DisplayList<T>(List<T> i_List)
        {
            foreach (object item in i_List)
            {
                DisplayMessage(item.ToString());
            }
        }

        public void DisplayAccordingToSize<T>(List<T> i_List, string i_SizeZeroMessage, string i_AboveZeroMessage)
        {
            if (i_List.Count == 0)
            {
                DisplayMessage(i_SizeZeroMessage);
            }
            else
            {
                DisplayMessage(i_AboveZeroMessage);
                DisplayList(i_List);
            }
        }

        public void DisplayEmpty()
        {
            DisplayMessage(string.Empty);
        }

        public void PressEnterToContinue()
        {
            DisplayEmpty();
            DisplayMessage(Messages.k_PleasePressEnterMessage);
            ReadLine();
        }

        public void DisplayExceptionMessage(Exception exception)
        {
            ClearAndDisplayMessage(exception.Message);
            DisplayEmpty();
            DisplayMessage(Messages.k_PleasePressEnterMessage);
        }

        public void GoodByePrinter()
        {
            DisplayMessage(Messages.k_GoodByeMessage);
            DisplayMessage(Messages.k_CloseTheTerminalMessage);
            ReadLine();
        }
    }
}
