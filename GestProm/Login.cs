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

        int time = 300;
        private bool animacionEnCurso = false;

        void deslizarleft()
        {
            if (!animacionEnCurso)
            {
                animacionEnCurso = true;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel1, "Left", -10);
                t.add(signin, "Left", 358);
                t.add(panelb, "Left", 376);
                t.add(txtuser, "Left", 274);
                t.add(txtpass, "Left", 274);
                t.add(btnpassview, "Left", 530);
                t.add(btnlogin, "Left", 295);
                t.run();

                t.TransitionCompletedEvent += (sender, e) => {
                    animacionEnCurso = false;
                };
            }
        }

        void deslizarright()
        {
            if (!animacionEnCurso)
            {
                animacionEnCurso = true;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel1, "Left", 311);
                t.add(signin, "Left", 528);
                t.add(panelb, "Left", 546);
                t.add(txtuser, "Left", 444);
                t.add(txtpass, "Left", 444);
                t.add(btnpassview, "Left", 371);
                t.add(btnlogin, "Left", 465);
                t.run();

                t.TransitionCompletedEvent += (sender, e) => {
                    animacionEnCurso = false;
                };
            }
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
            deslizarleft();
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            deslizarleft();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            deslizarright();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            deslizarleft();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}