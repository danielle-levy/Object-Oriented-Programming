using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : Menu, IMenuItem
    {
        public SubMenu(string i_SubMenuName, Menu i_Parent)
        {
            Title = i_SubMenuName;
            Parent = i_Parent;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void Clicked()
        {
            Console.Clear();
            Console.WriteLine(this);
        }
    }
}
