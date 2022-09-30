using System;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class MathMang : Form
    {
        TableLayoutPanel tableLayoutPanel;
        NumericUpDown numericUpDown;
        public MathMang()
        {
            this.Text = "Math Mäng";
            this.Size = new System.Drawing.Size(850, 700);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnStyles =
                {new ColumnStyle(SizeType.Percent, 15),
                    new ColumnStyle(SizeType.Percent, 15),
                new ColumnStyle(SizeType.Percent, 15),
                new ColumnStyle(SizeType.Percent, 15),
                new ColumnStyle(SizeType.Percent, 15)},
                RowStyles = { new RowStyle(SizeType.Percent, 21),
                    new RowStyle(SizeType.Percent, 21),
                    new RowStyle(SizeType.Percent, 21),
                    new RowStyle(SizeType.Percent, 21)}
            };

            Label aeg = new Label
            {
                Text = "Time Left"
            };
            Label plusLeftLabel = new Label
            {
                Text = "?"
            };
            Label mark1 = new Label
            {
                Text = "+"
            };
            Label mark2 = new Label
            {
                Text = "+"
            };
            Label plusRightLabel = new Label
            {
                Text = "?"
            };
            Label vordub = new Label
            {
                Text = "="
            };
            Button alusta = new Button
            {
                Text = "Alusta Mängu"
            };
            NumericUpDown numericUpDown1 = new NumericUpDown
            {

            };
        }
    }
}