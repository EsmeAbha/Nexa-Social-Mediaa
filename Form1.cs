﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace media
{
    public partial class Form1 : Form
    {
        private Form activeForm = null;
        private Color defColor = Color.FromArgb(134, 27, 242);
        public Color myColor = Color.FromArgb(120, 24, 217);

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelSubMain.Controls.Add(childForm);
                panelSubMain.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }else
            {
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelSubMain.Controls.Add(childForm);
                panelSubMain.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

            }

        }
        public Form1()
        {
            InitializeComponent();
            Methods.SetDoubleBuffer(panelSubMain, true);


        }

        private void ShowSubmenu(Panel subMenu)
        {

            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else subMenu.Visible=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Invalidate();
        }




        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {
           Methods.RoundPanelCorners(ref panelSideMenu,20);

            
        }



        public void ExpandOnHover(Panel panel, int minWidth, int maxWidth)
        {
            
            panel.MinimumSize = new Size(minWidth, panel.Height);

            panel.MouseEnter += (sender, args) =>
            {
                panel.Width = maxWidth;
                Methods.RoundPanelCorners(ref panelSideMenu, 20);
            };

            panel.MouseLeave += (sender, args) =>
            {
                panel.Width = minWidth;
                Methods.RoundPanelCorners(ref panelSideMenu, 20);
            };
        }


        private void DefaultButtonColor(ref Button button)
        {
            buttonTwizzle.BackColor = defColor;
            buttonHome.BackColor = defColor;
            buttonSearch.BackColor = defColor;
            buttonSettings.BackColor = defColor;
            buttonMessages.BackColor = defColor;
            buttonCreate.BackColor = defColor;
            buttonNotification.BackColor = defColor;
            buttonMarketPlace.BackColor = defColor;
            buttonReels.BackColor = defColor;
            buttonTwizzle.BackColor = defColor;
            buttonGames.BackColor = defColor;

            button.BackColor = myColor;
        }

        private void buttonTwizzle_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonTwizzle);
            FormProfile profile = new FormProfile();
            openChildForm(profile);
            profile.Visible = true;
        }
        private void buttonReels_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonReels);
            FormStorySingle profile = new FormStorySingle();
            openChildForm(profile);
            profile.Visible = true;
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonSettings);
        }



        private void buttonNotification_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonNotification);
        }

        private void buttonGames_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonGames);
            GamesPage games= new GamesPage();   
            openChildForm(games);
            games.Visible= true;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonHome);
            //Home h= new Home();
            openChildForm(new Home());
            //h.Visible= true;
        }
        


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonCreate);
            FormCreate fc= new FormCreate();
            openChildForm(fc);
            fc.Visible= true;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonSearch);
        }
        private void buttonMarketPlace_Click(object sender, EventArgs e)
        {
            DefaultButtonColor(ref buttonMarketPlace);
            FormMarketPlace c = new FormMarketPlace();
            openChildForm(c);
            c.Visible = true;
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            FormChat c=new FormChat();
            DefaultButtonColor(ref buttonMessages);
            openChildForm(c);
            c.Visible= true;
        }

        private void panelSubMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}