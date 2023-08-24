using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestProm
{
    public partial class Profile : Form
    {

        private int time = 300;
        public Profile()
        {
            InitializeComponent();
            this.bunifuPanel4.MouseWheel += bunifupanel4_MouseWheel;
        }

        private void bunifupanel4_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                circle1.FillColor = Color.White;
                circle1.BorderColor = Color.White;

                circle2.FillColor = Color.Silver;
                circle2.BorderColor = Color.Silver;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel6, "Top", 10);
                t.run();
            }

            else
            {
                circle1.FillColor = Color.Silver;
                circle1.BorderColor = Color.Silver;

                circle2.FillColor = Color.White;
                circle2.BorderColor = Color.White;

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel6, "Top", -200);
                t.run();
            }
        }

        public bool open = false;
        public void AbrirFormEnPanel(object Formhijo)
        {
            if (open == false)
            {
                foreach (Control control in this.main.Controls)
                {
                    control.Visible = false;
                }
                Form fh = Formhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.main.Controls.Add(fh);
                this.main.Tag = fh;
                fh.Show();
                open = true;
            }
        }

        public void CerrarFormEnPanel()
        {
            Form formAbierto = this.main.Controls.OfType<Form>().FirstOrDefault();
            formAbierto?.Close();

            foreach (Control control in this.main.Controls)
            {
                control.Visible = true;
            }

            open = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form?.bunifuButton22.PerformClick();
        }
    }
}