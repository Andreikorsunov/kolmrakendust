using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace kolmerakendust
{
    public partial class Form1 : Form
    {
        TableLayoutPanel tableLayoutPanel;
        FlowLayoutPanel flowLayoutPanel;
        Button showPicture;
        PictureBox pb;
        System.Windows.Forms.CheckBox cb;
        ColorDialog colorDialog;
        OpenFileDialog openFileDialog;


        public Form1()
        {
            this.Text = "Pildid";
            this.Size = new System.Drawing.Size(800, 800);
            openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "JPEG Files(*.jpg) | *.jpg | PNG Files(*.png) | *.png | BMP Files(*.bmp) | *.bmp | All files( *.*)";
            colorDialog = new ColorDialog();
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(20, 20),
                TabIndex = 0,
                BackColor = System.Drawing.Color.White,
            };
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 10F));
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
                WrapContents = false,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            Button showPicture = new Button
            {
                Text = "Näita foto",
            };
            showPicture.Click += showButton_Click;
            Button background = new Button
            {
                Text = "Määrake taustavärv",
            };
            background.Click += backgroundButton_Click;
            Button close = new Button
            {
                Text = "Sulge",
            };
            close.Click += closeButton_Click;
            Button clear = new Button
            {
                Text = "Tühjenda pilt",
            };
            clear.Click += clearButton_Click;
            Button[] buttons = { showPicture, background, close, close };

            PictureBox pb = new PictureBox
            {
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TabIndex = 0,
                TabStop = false,
            };

            cb = new CheckBox
            {
                Text = "Venitada",
            };
            cb.CheckedChanged += checkBox1_CheckedChanged;
            tableLayoutPanel.Controls.Add(pb, 1, 0);

            this.Controls.Add(tableLayoutPanel);
           // tableLayoutPanel.Controls.Add(buttons, 1, 1);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
            tableLayoutPanel.Controls.Add(pb, 1, 0);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb.Load(openFileDialog.FileName);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture.
            pb.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Show the color dialog box. If the user clicks OK, change the
            // PictureBox control's background to the color the user chose.
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pb.BackColor = colorDialog.Color;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the Stretch check box, 
            // change the PictureBox's
            // SizeMode property to "Stretch". If the user clears 
            // the check box, change it to "Normal".
            if (cb.Checked)
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pb.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}