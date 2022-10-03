using System;
using System.Drawing;
using System.Windows.Forms;

namespace kolmerakendust
{
    public partial class Matching : Form
    {
        TableLayoutPanel tableLayoutPanel;
        public Matching()
        {
            this.Text = "Matching Mäng";
            this.Width = 800;
            this.Height = 800;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
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
            Controls.Add(tableLayoutPanel);
        }
    }
}