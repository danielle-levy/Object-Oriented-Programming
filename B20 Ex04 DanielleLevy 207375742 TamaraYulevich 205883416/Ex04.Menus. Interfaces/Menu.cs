using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class Menu
    {
        private readonly List<IMenuItem> m_MenuItemsList = new List<IMenuItem>();
        private string m_MenuTitle;
        private Menu m_Parent;

        public Menu Parent
        {
            get
            {
                return m_Parent;
            }

            set
            {
                m_Parent = value;
            }
        }

        public string Title
        {
            get
            {
                return m_MenuTitle;
            }

            set
            {
                m_MenuTitle = value;
            }
        }

        public void AddLeaf(string i_ItemName, IMenuItem i_MethodToAdd)
        {
            Leaf leaf = new Leaf(i_ItemName, i_MethodToAdd);
            m_MenuItemsList.Add(leaf);
        }

        public void AddSubMenu(string i_ItemName)
        {
            SubMenu subMenu = new SubMenu(i_ItemName, this);
            m_MenuItemsList.Add(subMenu);
        }

        public SubMenu GetSubMenuByName(string i_subMenuName)
        {
            IMenuItem subMenu = null;
            foreach (IMenuItem item in m_MenuItemsList)
            {
                if(item.GetTitle() == i_subMenuName && item is SubMenu)
                {
                    subMenu = item;
                }
            }

            return (SubMenu)subMenu;
        }

        public int GetInputFromUser()
        {
            string input = Console.ReadLine();
            while (!inputIsValid(input))
            {
                Console.WriteLine("The input is not valid, Please try again");
                input = Console.ReadLine();
            }

            return int.Parse(input);
        }

        private bool inputIsValid(string i_Input)
        {
            return int.TryParse(i_Input, out int isValid) && InputIsInRange(isValid);
        }

        public bool InputIsInRange(int i_Input)
        {
            bool isInRange = false;
            if (i_Input <= m_MenuItemsList.Count && i_Input >= 0)
            {
                isInRange = true;
            }

            return isInRange;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(this);
            int currentUserChoice = GetInputFromUser();
            Menu currentMenu = null;
            while (!exit(currentUserChoice) && !back(currentUserChoice) && currentUserChoice != 0)
            {
                if (m_MenuItemsList[currentUserChoice - 1] is SubMenu)
                {
                    currentMenu = (SubMenu)m_MenuItemsList[currentUserChoice - 1];
                    currentMenu.Show();
                }
                else if (m_MenuItemsList[currentUserChoice - 1] is Leaf)
                {
                    m_MenuItemsList[currentUserChoice - 1].Clicked();
                    Console.WriteLine("Press enter key to continue");
                    Console.ReadLine();
                    this.Show();
                }

                break;
            }
        }

        private bool exit(int i_UserChoice)
        {
            return i_UserChoice == 0 && this is MainMenu;
        }

        private bool back(int i_UserChoice)
        {
            bool back = false;
            if (i_UserChoice == 0 && this is SubMenu)
            {
                Parent.Show();
                back = true;
            }

            return back;
        }

        public override string ToString()
        {
            string result = string.Format(
                @"{0}
==============
",
                Title);
            result += string.Format(
                @"0. {0}
", 
                (this is MainMenu) ? "Exit" : "Back");
            int i = 1;
            foreach (IMenuItem item in m_MenuItemsList)
            {
                result += string.Format(
                    @"{0}. {1}
",
                    i,
                    item.GetTitle());
                i++;
            }

            result += string.Format(
                @"Please enter your choice (1-{0} or 0 to {1}):
>> ",
                i - 1,
                (this is MainMenu) ? "exit" : "back");
            return result;
        }
    }
}
