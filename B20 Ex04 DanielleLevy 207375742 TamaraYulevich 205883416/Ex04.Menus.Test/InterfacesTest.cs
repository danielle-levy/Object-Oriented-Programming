using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class InterfacesTest
    {
        public InterfacesTest()
        {
            Methods.CountCapitals countCapitals = new Methods.CountCapitals();
            Methods.ShowVersion showVersion = new Methods.ShowVersion();
            Methods.ShowTime showTime = new Methods.ShowTime();
            Methods.ShowDate showDate = new Methods.ShowDate();

            Menus.Interfaces.MainMenu interfaceMainMenu = new Menus.Interfaces.MainMenu("(Using interfaces)");

            interfaceMainMenu.AddSubMenu("Version and Capitals");
            interfaceMainMenu.AddSubMenu("Show Date/Time");

            interfaceMainMenu.GetSubMenuByName("Version and Capitals").AddLeaf(countCapitals.GetTitle(), countCapitals);
            interfaceMainMenu.GetSubMenuByName("Version and Capitals").AddLeaf(showVersion.GetTitle(), showVersion);

            interfaceMainMenu.GetSubMenuByName("Show Date/Time").AddLeaf(showTime.GetTitle(), showTime);
            interfaceMainMenu.GetSubMenuByName("Show Date/Time").AddLeaf(showDate.GetTitle(), showDate);

            interfaceMainMenu.Show();
        }
    }
}
