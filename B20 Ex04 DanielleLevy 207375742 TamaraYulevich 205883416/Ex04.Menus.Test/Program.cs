using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfacesTest interfacesTest = new InterfacesTest();
            DelegatesTest delegatesTest = new DelegatesTest();
        }
    }
}
