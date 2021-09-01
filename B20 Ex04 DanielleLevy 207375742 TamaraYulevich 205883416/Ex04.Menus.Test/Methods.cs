using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class Methods
    {
        internal class CountCapitals : IMenuItem
        {
            public void Clicked()
            {
                Console.WriteLine("Please enter a sentence:");
                string answer = Console.ReadLine();
                int counter = 0;
                foreach (char c in answer)
                {
                    if (char.IsUpper(c))
                    {
                        counter++;
                    }
                }

                Console.WriteLine(string.Format("There are {0} capital letters in your input.", counter));
            }

            public string GetTitle()
            {
                return "Count Capitals";
            }
        }

        internal class ShowVersion : IMenuItem
        {
            public void Clicked()
            {
                Console.WriteLine("Version: 20.2.4.30620");
            }

            public string GetTitle()
            {
                return "Show Version";
            }
        }

        internal class ShowTime : IMenuItem
        {
            public void Clicked()
            {
                Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
            }

            public string GetTitle()
            {
                return "Show Time";
            }
        }

        internal class ShowDate : IMenuItem
        {
            public void Clicked()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }

            public string GetTitle()
            {
                return "Show Date";
            }
        }
    }
}
