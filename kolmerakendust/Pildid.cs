using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using CheckBox = System.Windows.Forms.CheckBox;

namespace kolmerakendust
{
    public partial class Pildid : Form
    {
        TableLayoutPanel tableLayoutPanel;
        FlowLayoutPanel flowLayoutPanel;
        PictureBox pb;
        System.Windows.Forms.CheckBox cb;
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*",
            Title = "Vali pildi"
        };
        ColorDialog colorDialog = new ColorDialog { };

        public Pildid()
        {
            this.Text = "Pildid";
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
            flowLayoutPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill
            };
            Button showPicture = new Button
            {
                Text = "Näita foto"
            };
            Button background = new Button
            {
                Text = "Määrake taustavärv"
            };
            Button close = new Button
            {
                Text = "Sulge"
            };
            Button clear = new Button
            {
                Text = "Tühjenda pilt"
            };
            Button[] buttons = { showPicture, background, close, close };

            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D
            };
            CheckBox cb = new CheckBox
            {
                Text = "Venitada"
            };

            cb.CheckedChanged += checkBox1_CheckedChanged;
            clear.Click += clearButton_Click;
            close.Click += closeButton_Click;
            background.Click += backgroundButton_Click;
            showPicture.Click += showButton_Click;

            flowLayoutPanel.Controls.Add(showPicture);
            flowLayoutPanel.Controls.Add(clear);
            flowLayoutPanel.Controls.Add(background);
            flowLayoutPanel.Controls.Add(close);

            tableLayoutPanel.Controls.Add(pb);
            tableLayoutPanel.SetColumnSpan(pb, 2);
            tableLayoutPanel.Controls.Add(cb);
            tableLayoutPanel.Controls.Add(flowLayoutPanel);
            tableLayoutPanel.SetCellPosition(flowLayoutPanel, new TableLayoutPanelCellPosition(1, 1));

            this.Controls.Add(tableLayoutPanel);
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb.Load(openFileDialog.FileName);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            pb.Image = null;
        }
        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pb.BackColor = colorDialog.Color;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb.Checked)
            {
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pb.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}