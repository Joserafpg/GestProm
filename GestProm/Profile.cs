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

        const int time = 300;
        public Profile()
        {
            InitializeComponent();
            this.bunifuPanel4.MouseWheel += bunifupanel4_MouseWheel;
        }

        async Task EsperarAsync()
        {
            await Task.Delay(time);
        }

        async void open()
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
            t.add(btnshort, "Left", 12);
            t.run();
            btngoto.Visible = false;

            await EsperarAsync();

            btnshort.Width = 205;
            btnscroll1.Location = new Point(19, 3);
            btnscroll2.Location = new Point(60, 3);
            btnscroll3.Location = new Point(101, 3);

            btnscroll1.Visible = true;
            btnscroll2.Visible = true;
            btnscroll3.Visible = true;
        }
        
        void close()
        {
            btnshort.Width = 46;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
            t.add(btnshort, "Left", 167);
            t.run();

            btngoto.Visible = true;

            btnscroll1.Visible = false;
            btnscroll2.Visible = false;
            btnscroll3.Visible = false;
        }

        private void bunifupanel4_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                circle1.FillColor = Color.White;
                circle1.BorderColor = Color.White;

                circle2.FillColor = Color.Silver;
                circle2.BorderColor = Color.Silver;
                //bunifuPanel6.Width = 244;
                //bunifuPanel6.Location = new Point(3, 0);

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel6, "Top", 0);
                t.run();
                
                Transition d = new Transition(new TransitionType_EaseInEaseOut(time));
                d.add(bunifuGradientPanel3, "Top", 290);
                d.run();
            }

            else
            {
                circle1.FillColor = Color.Silver;
                circle1.BorderColor = Color.Silver;

                circle2.FillColor = Color.White;
                circle2.BorderColor = Color.White;
                //bunifuPanel6.Width = 217;
                //bunifuPanel6.Location = new Point(16, 0);

                Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
                t.add(bunifuPanel6, "Top", -290);
                t.run();
                
                Transition y = new Transition(new TransitionType_EaseInEaseOut(time));
                y.add(bunifuGradientPanel3, "Top", 0);
                y.run();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form?.bunifuButton22.PerformClick();
        }
                
        private void btnshort_Click(object sender, EventArgs e)
        {
            if (btnshort.Location.X == 12)
            {
                close();
            }

            else
            {
                open();
            }
        }
    }
}