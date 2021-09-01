using System.Windows.Forms;

namespace MemoryGameApplication
{
    public partial class GameSettingsForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonAgainstWho = new System.Windows.Forms.Button();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Player Name:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Location = new System.Drawing.Point(324, 157);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 25);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Second Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Board Size:";
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(179, 14);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.firstPlayerNameTextBox.TabIndex = 15;
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Enabled = false;
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(179, 52);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.secondPlayerNameTextBox.TabIndex = 16;
            this.secondPlayerNameTextBox.Text = "- computer -";
            // 
            // buttonAgainstWho
            // 
            this.buttonAgainstWho.Location = new System.Drawing.Point(285, 52);
            this.buttonAgainstWho.Name = "buttonAgainstWho";
            this.buttonAgainstWho.Size = new System.Drawing.Size(139, 25);
            this.buttonAgainstWho.TabIndex = 17;
            this.buttonAgainstWho.Text = "Against a Friend";
            this.buttonAgainstWho.UseVisualStyleBackColor = true;
            this.buttonAgainstWho.Click += new System.EventHandler(this.buttonAgainstWho_Click);
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonBoardSize.Location = new System.Drawing.Point(16, 109);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(121, 73);
            this.buttonBoardSize.TabIndex = 18;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 200);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonAgainstWho);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(463, 247);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(463, 247);
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.buttonClosed_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.Button buttonAgainstWho;
        private System.Windows.Forms.Button buttonBoardSize;
    }
}