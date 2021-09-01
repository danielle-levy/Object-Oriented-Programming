using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class Leaf : IMenuItem 
    {
        private event Action m_OnClick;

        private string m_ItemTitle;

        public Leaf(string i_LeafName, Action i_ToInvoke)
        {
            m_ItemTitle = i_LeafName;
            m_OnClick += i_ToInvoke;
        }

        public string GetTitle()
        {
            return m_ItemTitle;
        }
        
        public void Clicked()
        {
            Console.Clear();
            m_OnClick.Invoke();
        }
    }
}
