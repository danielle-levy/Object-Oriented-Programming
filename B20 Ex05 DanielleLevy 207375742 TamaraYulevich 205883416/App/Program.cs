using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02.ConsoleUtils;

namespace MemoryGameApplication
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
        }
    }
}
