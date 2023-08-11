using Bunifu.UI.WinForms.Helpers.Transitions;
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

            var ms1 = new System.Windows.Forms.ToolTip();
            ms1.SetToolTip(btnpassview, "Show Password");
        }

        bool activar = false;

        void deslizarleft()
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(bunifuPanel1, "Left", -10);
            t.add(signin, "Left", 358);
            t.add(panelb, "Left", 376);
            t.add(txtuser, "Left", 274);
            t.add(txtpass, "Left", 274);
            t.add(btnpassview, "Left", 201);
            t.add(btnlogin, "Left", 295);
            t.run();
        }

        void deslizarright()
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(bunifuPanel1, "Left", 311);
            t.add(signin, "Left", 528);
            t.add(panelb, "Left", 546);
            t.add(txtuser, "Left", 444);
            t.add(txtpass, "Left", 444);
            t.add(btnpassview, "Left", 371);
            t.add(btnlogin, "Left", 465);
            t.run();
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
            deslizarleft();

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

        private void btnpassview_Click(object sender, EventArgs e)
        {
            txtpass.PasswordChar = '\0';
        }

        private void txtuser_Click(object sender, EventArgs e)
        {
            activar = true;
            deslizarleft();
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (activar == false)
            {
                deslizarright();
            }
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            deslizarleft();
            activar = true;
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (activar == false)
            {
                deslizarright();
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            deslizarright();
            activar = false;
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            deslizarleft();
        }
    }
}