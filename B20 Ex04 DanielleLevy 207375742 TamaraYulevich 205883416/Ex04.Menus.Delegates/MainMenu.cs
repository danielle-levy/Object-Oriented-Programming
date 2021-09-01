using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        public MainMenu(string i_MainMenuName)
        {
            Title = i_MainMenuName;
            Parent = null;
        }
    }
}
