﻿using Guna.UI2.WinForms;
using media.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace media
{
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();



            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelChatBox.Resize += (sender, e) =>
            {
                int availableWidth = panelChatBox.ClientSize.Width - panelChatBox.Padding.Left - panelChatBox.Padding.Right;
                panel2.Width = availableWidth;
                sendPanel.Width = availableWidth;
            };


            panel2.Resize += (sender, e) =>
            {
                panel2.Location = new Point(panelChatBox.Location.X + 30, panelChatBox.Location.Y);
            };
            sendPanel.Resize += (sender, e) =>
            {
                sendPanel.Location = new Point(panelChatBox.Location.X + 30, panelChatList.Height+50);
            };            
            guna2Panel27.Resize += (sender, e) =>
            {
                guna2Panel27.Location = new Point(panelChatBox.Location.X + 30, panelChatList.Height+50);
                guna2Panel27.Width=panelChatBox.Width-100;
            };
            panel2.BringToFront();
            this.sendPanel.BringToFront();

            this.Visible= false;
            Methods.SetDoubleBuffer(panel2, true);
            Methods.SetDoubleBuffer(panel3, true);
            Methods.SetDoubleBuffer(panel4, true);


        }
        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            panelChatBox.Size = new Size(tableLayoutPanel1.ClientSize.Width, tableLayoutPanel1.ClientSize.Height);            
            Methods.RoundPanelCorners(ref panelChatBox, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            this.Visible= false;

        }

        private void panelChatBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void p()
        {
            Guna2Panel sendPanel=new Guna2Panel();
            Guna2Button btn13 = new Guna2Button();
            Guna2Button btn4 = new Guna2Button();
            Guna2Button btn3 = new Guna2Button();

            sendPanel.BackColor = System.Drawing.Color.Transparent;
            sendPanel.BorderRadius = 30;
            sendPanel.Controls.Add(btn13);
            sendPanel.Controls.Add(btn4);
            sendPanel.Controls.Add(btn3);
            sendPanel.FillColor = System.Drawing.Color.Indigo;
            sendPanel.ForeColor = System.Drawing.SystemColors.Info;
            sendPanel.Location = new System.Drawing.Point(510, 629);
            sendPanel.Margin = new System.Windows.Forms.Padding(4);
            sendPanel.Name = "sendPanel";
            sendPanel.Padding = new System.Windows.Forms.Padding(40, 6, 40, 6);
            sendPanel.Size = new System.Drawing.Size(868, 84);
            sendPanel.TabIndex = 2;



            btn13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn13.Dock = System.Windows.Forms.DockStyle.Right;     
            btn13.Location = new System.Drawing.Point(586, 6);
            btn13.Margin = new System.Windows.Forms.Padding(4);
            btn13.Name = "btn13";
            btn13.Size = new System.Drawing.Size(83, 72);
            btn13.TabIndex = 39;

            btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn4.Dock = System.Windows.Forms.DockStyle.Right;
            btn4.Location = new System.Drawing.Point(669, 6);
            btn4.Margin = new System.Windows.Forms.Padding(4);
            btn4.Name = "btn4";
            btn4.Size = new System.Drawing.Size(83, 72);
            btn4.TabIndex = 38;
            // 
            // button3
            // 
            btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn3.Dock = System.Windows.Forms.DockStyle.Right;
            btn3.Location = new System.Drawing.Point(752, 6);
            btn3.Margin = new System.Windows.Forms.Padding(4);
            btn3.Name = "btn3";
            btn3.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            btn3.Size = new System.Drawing.Size(76, 72);
            btn3.TabIndex = 37;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.panel2.Width=panelChatBox.Width-panelChatBox.Padding.Right;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            
                int availableWidth = panelChatBox.ClientSize.Width - panelChatBox.Padding.Left - panelChatBox.Padding.Right;
                int availableHeight = panelChatBox.ClientSize.Height - panelChatBox.Padding.Top - panelChatBox.Padding.Bottom;

                panel2.Size = new Size(availableWidth, availableHeight);
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
                    }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void sendPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}