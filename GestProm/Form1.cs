using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestProm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async Task EsperarAsync()
        {
            await Task.Delay(1000);
        }

        async void dezplazaradentro()
        {
            Transition p = new Transition(new TransitionType_EaseInEaseOut(1000));
            p.add(btnmenud, "Left", -29);
            p.add(pmenud, "Left", -64);
            p.run();

            await EsperarAsync();

            btnmenud.Visible = false;
            pmenud.Visible = false;
        }

        void dezplazaraafuera()
        {
            Transition p = new Transition(new TransitionType_EaseInEaseOut(1000));
            btnmenud.Visible = true;
            pmenud.Visible = true;
            p.add(btnmenud, "Left", 19);
            p.add(pmenud, "Left", -16);
            p.run();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
            t.add(menu, "Left", -300);
            t.run();
            pmenud.Visible = true;
            btnmenud.Visible = true;

            Task.Delay(2000);
            bunifuIconButton2.Visible = false;

            dezplazaraafuera();
        }

        private void btnmenud_Click(object sender, EventArgs e)
        {
            Transition l = new Transition(new TransitionType_EaseInEaseOut(1000));
            l.add(menu, "Left", 23);
            bunifuIconButton2.Visible = true;
            l.run();

            dezplazaradentro();
        }
    }
}
