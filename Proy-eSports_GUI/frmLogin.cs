﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proy_eSports_GUI
{
    public partial class frmLogin : Form
    {
        int intentos = 0;
        int tiempo = 10;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() != "" & txtPassword.Text.Trim() != "")
            {
                if (txtLogin.Text == "test" & txtPassword.Text == "12345")
                {
                    this.Hide();
                    timer1.Enabled = false;
                    MDIPrincipal mdi = new MDIPrincipal();
                    mdi.ShowDialog();

                    this.Visible = true;
                    tiempo = 20;
                    txtLogin.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtLogin.Focus();
                    timer1.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Wrong username or password",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                    if (intentos == 3)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or Password required",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intentos += 1;
            }
            if (intentos == 3)
            {
                MessageBox.Show("We're sorry,  number of attemps exceeded",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo -= 1;
            this.Text = "Enter your username and password. You have left..." + tiempo;
            if(tiempo == 0)
            {
                MessageBox.Show("Sorry, timeout",
                   "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}