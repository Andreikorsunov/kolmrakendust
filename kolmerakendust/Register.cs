using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class Matching : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Timer timer;
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Matching()
        {
            this.Text = "Matching Mäng";
            this.Size = new Size(600, 600);
            this.BackColor = Color.CornflowerBlue;

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 25),
                    new ColumnStyle(SizeType.Percent, 25),
                    new ColumnStyle(SizeType.Percent, 25),
                    new ColumnStyle(SizeType.Percent, 25),
                },
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 25),
                    new RowStyle(SizeType.Percent, 25),
                    new RowStyle(SizeType.Percent, 25),
                    new RowStyle(SizeType.Percent, 25),
                }
            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lb = new Label
                    {
                        BackColor = ColorTranslator.FromHtml("#3333FF"),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Size = new Size(48, 48),
                        Text = "c"
                    };
                    lb.Click += lb_Click;
                    tableLayoutPanel.Controls.Add(lb, i, j);
                }
            }
            timer = new Timer();
            timer.Interval = 750;
            timer.Tick += Timer_Click;
            Controls.AddRange(new Control[] { tableLayoutPanel });
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void Timer_Click(object sender, EventArgs e)
        {
            timer.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void lb_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer.Start();
            }
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Kõik arvasid!", "Võit");
            Close();
        }
    }
}