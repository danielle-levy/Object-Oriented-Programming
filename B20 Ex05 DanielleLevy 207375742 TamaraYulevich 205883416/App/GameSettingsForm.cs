using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace MemoryGameApplication
{
    public partial class GameSettingsForm : Form
    {
        private Queue<string> m_PossibleSizes = new Queue<string>(new string[] { "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6" });
       
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public TextBox SecondPlayerNameTextBox { get => secondPlayerNameTextBox; }

        public string Player1Name { get => firstPlayerNameTextBox.Text; }

        public string Player2Name { get => secondPlayerNameTextBox.Text; }

        public int NumOfRows
        {
            get
            {
                return buttonBoardSize.Text[0] - 48;
            }
        }

        public int NumOfColumns
        {
            get
            {
                return buttonBoardSize.Text[4] - 48;
            }
        }

        private void buttonAgainstWho_Click(object sender, EventArgs e)
        {
            if (SecondPlayerNameTextBox.Enabled)
            {
                SecondPlayerNameTextBox.Enabled = false;
                SecondPlayerNameTextBox.Text = "- computer -";
                buttonAgainstWho.Text = "Against a Friend";
            }
            else
            {
                SecondPlayerNameTextBox.Enabled = true;
                SecondPlayerNameTextBox.Text = string.Empty;
                buttonAgainstWho.Text = "Against Computer";
            }
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            m_PossibleSizes.Enqueue(buttonBoardSize.Text);
            buttonBoardSize.Text = m_PossibleSizes.Peek();
            m_PossibleSizes.Dequeue();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            showBoardForm();
        }

        private void buttonClosed_Click(object sender, FormClosedEventArgs e)
        {
            showBoardForm();
        }

        private void showBoardForm()
        {
            this.Hide();
            bool isComputer = !SecondPlayerNameTextBox.Enabled;
            MemoryGameBoardForm memoryGameBoardForm = new MemoryGameBoardForm(Player1Name, Player2Name, NumOfRows, NumOfColumns, isComputer);
            memoryGameBoardForm.ShowDialog();
        }
    }
}
