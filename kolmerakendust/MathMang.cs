using System;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class MathMang : Form
    {
        Random rnd = new Random();
        char[] symbols = new char[] { '+', '-', '*', '/' };
        int pluss1, pluss2, miinus1, miinus2, korr1, korr2, jaga1, jaga2, aeglabi;
        TableLayoutPanel tableLayoutPanel;
        Timer timer;
        Label lb1, lb2;
        Button alusta;
        public MathMang()
        {
            this.Text = "Math Mäng";
            this.Width = 500;
            this.Height = 450;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            lb1 = new Label
            {
                Font = new Font(Font.FontFamily, 18),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(140, 30),
            };
            lb2 = new Label
            {
                Font = new Font(Font.FontFamily, 16),
                Text = "Aeg",
                AutoSize = true,
            };
            alusta = new Button
            {
                Text = "Alusta mängu",
                Font = new Font(Font.FontFamily, 14),
                AutoSize = true,
                TabIndex = 0,
            };
            alusta.Click += Alusta_Click;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                },
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 10),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 10),
                }
            };
            for (int i = 1; i < 5; i++)
            {
                Label num1 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label mark = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = symbols[i - 1].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label num2 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label vordub = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "=",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                NumericUpDown numeric = new NumericUpDown
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Width = 100,
                    TabIndex = i + 1,
                };
                tableLayoutPanel.Controls.Add(num1, 0, i);
                tableLayoutPanel.Controls.Add(mark, 1, i);
                tableLayoutPanel.Controls.Add(num2, 2, i);
                tableLayoutPanel.Controls.Add(vordub, 3, i);
                tableLayoutPanel.Controls.Add(numeric, 4, i);
            }
            tableLayoutPanel.Controls.Add(lb1, 3, 0);
            tableLayoutPanel.SetColumnSpan(lb2, 2);
            tableLayoutPanel.SetColumnSpan(lb1, 2);
            tableLayoutPanel.Controls.Add(lb2, 1, 0);
            tableLayoutPanel.SetColumnSpan(alusta, 2);
            tableLayoutPanel.Controls.Add(alusta, 2, 5);
            Controls.Add(tableLayoutPanel);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 1);
            NumericUpDown miinus = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 2);//минус
            NumericUpDown korruta = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 3);//умножить
            NumericUpDown jaga = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 4);//разделить
            if (LabiVaatus())
            {
                timer.Stop();
                MessageBox.Show("Kõik vastused on õiged!", "Võit!");
                alusta.Enabled = true;
            }
            else if (aeglabi > 0)
            {
                aeglabi = aeglabi - 1;
                lb1.Text = aeglabi + " sekundit";
            }
            else
            {
                timer.Stop();
                lb1.Text = "Aeg on läbi!";
                MessageBox.Show("Te ei lõpetanud õigeks ajaks.", "Kaotus!");
                numeric.Value = pluss1 + pluss2;
                miinus.Value = miinus1 - miinus2;
                korruta.Value = korr1 * korr2;
                jaga.Value = jaga1 / jaga2;
                alusta.Enabled = true;
            }
        }
        private void Alusta_Click(object sender, EventArgs e)
        {
            AlustaMangu();
            alusta.Enabled = false;
        }
        private bool LabiVaatus()
        {
            NumericUpDown numeric = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 1);
            NumericUpDown miinus = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 2);
            NumericUpDown korruta = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 3);
            NumericUpDown jaga = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, 4);
            if ((pluss1 + pluss2 == numeric.Value)
                && (miinus1 - miinus2 == miinus.Value)
                && (korr1 * korr2 == korruta.Value)
                && (jaga1 / jaga2 == jaga.Value))
                return true;
            else
                return false;
        }
        public void AlustaMangu()
        {
            for (int row = 1; row < 5; row++)
            {
                Label num1 = (Label)tableLayoutPanel.GetControlFromPosition(0, row);
                Label symbol = (Label)tableLayoutPanel.GetControlFromPosition(1, row);
                Label num2 = (Label)tableLayoutPanel.GetControlFromPosition(2, row);
                NumericUpDown numeric = (NumericUpDown)tableLayoutPanel.GetControlFromPosition(4, row);
                int[] getnums = getNums(symbol.Text);
                num1.Text = getnums[0].ToString();
                num2.Text = getnums[1].ToString();
                numeric.Value = 0;
            }
            aeglabi = 30;
            lb1.Text = "30 sekundit";
            timer.Start();
        }
        public int[] getNums(string sym)
        {
            int num1 = 0;
            int num2 = 0;

            if (sym == "+")
            {
                num1 = rnd.Next(51);
                num2 = rnd.Next(51);
                pluss1 = num1;
                pluss2 = num2;
            }
            else if (sym == "-")
            {
                num1 = rnd.Next(1, 101);
                num2 = rnd.Next(1, num1);
                miinus1 = num1;
                miinus2 = num2;
            }
            else if (sym == "*")
            {
                num1 = rnd.Next(2, 11);
                num2 = rnd.Next(2, 11);
                korr1 = num1;
                korr2 = num2;
            }
            else if (sym == "/")
            {
                num2 = rnd.Next(2, 11);
                int temp = rnd.Next(2, 11);
                num1 = num2 * temp;
                jaga1 = num1;
                jaga2 = num2;
            }
            return new int[2] { num1, num2 };
        }
    }
}