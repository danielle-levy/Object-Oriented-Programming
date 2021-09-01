using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class DelegatesTest
    {
        public DelegatesTest()
        {
            Methods.CountCapitals countCapitals = new Methods.CountCapitals();
            Methods.ShowVersion showVersion = new Methods.ShowVersion();
            Methods.ShowTime showTime = new Methods.ShowTime();
            Methods.ShowDate showDate = new Methods.ShowDate();

            Menus.Delegates.MainMenu delegatesMainMenu = new Menus.Delegates.MainMenu("(Using delegates)");

            delegatesMainMenu.AddSubMenu("Version and Capitals");
            delegatesMainMenu.AddSubMenu("Show Date/Time");

            delegatesMainMenu.GetSubMenuByName("Version and Capitals").AddLeaf(countCapitals.GetTitle(), new Action(countCapitals.Clicked));
            delegatesMainMenu.GetSubMenuByName("Version and Capitals").AddLeaf(showVersion.GetTitle(), new Action(showVersion.Clicked));

            delegatesMainMenu.GetSubMenuByName("Show Date/Time").AddLeaf(showTime.GetTitle(), new Action(showTime.Clicked));
            delegatesMainMenu.GetSubMenuByName("Show Date/Time").AddLeaf(showDate.GetTitle(), new Action(showDate.Clicked));

            delegatesMainMenu.Show();
        }
    }
}
