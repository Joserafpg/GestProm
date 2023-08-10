using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestProm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        void bordesradius()
        {
            int borderRadius = 20;
            GraphicsPath objDraw = new GraphicsPath();

            objDraw.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            objDraw.AddArc(this.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            objDraw.AddArc(this.Width - borderRadius * 2, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            objDraw.AddArc(0, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            objDraw.CloseFigure();

            this.Region = new Region(objDraw);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            bordesradius();

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtpass.Text;

            bool containsLetterOrDigit = false;

            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsDigit(c))
                {
                    containsLetterOrDigit = true;
                    break;
                }
            }

            if (containsLetterOrDigit)
            {
                txtpass.PasswordChar = '●';
                btnpassview.Visible = true;
            }
            else
            {
                txtpass.PasswordChar = '\0';
                btnpassview.Visible = false;
            }
        }

        private void bunifuIconButton1_MouseDown(object sender, MouseEventArgs e)
        {
            txtpass.PasswordChar = '\0';
        }

        private void bunifuIconButton1_MouseUp(object sender, MouseEventArgs e)
        {
            txtpass.PasswordChar = '●';
        }
    }
}
