using System;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class MathMang : Form
    {
        TableLayoutPanel tableLayoutPanel;
        public MathMang()
        {
            this.Text = "Math Mäng";
            this.Size = new System.Drawing.Size(850, 700);

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnStyles =
                {new ColumnStyle(SizeType.Percent, 15),
                    new ColumnStyle(SizeType.Percent, 85)},
                RowStyles = { new RowStyle(SizeType.Percent, 90),
                    new RowStyle(SizeType.Percent, 10) }
            };

            Label aeg = new Label
            {
                Text = "Time Left"
            };
            Label plusLeftLabel = new Label
            {
                Text = "?"
            };
            Label plusLeftLabel = new Label
            {
                Text = "?"
            };
            Label plusLeftLabel = new Label
            {
                Text = "?"
            };
            Label plusRightLabel = new Label
            {
                Text = "?"
            };
            Button alusta = new Button
            {
                Text = "Alusta Mängu"
            };
        }
    }
}