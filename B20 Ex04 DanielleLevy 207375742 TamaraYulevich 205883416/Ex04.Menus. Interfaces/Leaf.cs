using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class Leaf : IMenuItem
    {
        private IMenuItem m_LeafMethod;
        private string m_ItemTitle;
        
        public Leaf(string i_LeafName, IMenuItem i_LeafMethod)
        {
            m_ItemTitle = i_LeafName;
            m_LeafMethod = i_LeafMethod;
        }

        public string GetTitle()
        {
            return m_ItemTitle;
        }
        
        public void Clicked()
        {
            Console.Clear();
            m_LeafMethod.Clicked();
        }
    }
}
