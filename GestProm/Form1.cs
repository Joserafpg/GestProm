using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestProm
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int time = 300;

        public Form1()
        {
            InitializeComponent();
            
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();

            var ms1 = new ToolTip();
            ms1.SetToolTip(btnclose, "Exit");

            var ms2 = new ToolTip();
            ms2.SetToolTip(btnminimize, "Minimize");

            var ms3 = new ToolTip();
            ms3.SetToolTip(closemenu, "Close Menu");

            var ms4 = new ToolTip();
            ms4.SetToolTip(btnmenud, "Open Menu");

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelhora.Text = DateTime.Now.ToString("HH:mm");

            DateTime fechaActual = DateTime.Now;
            fecha.Text = fechaActual.ToString("dd/MM/yyyy HH:mm:ss");
        }

        async Task EsperarAsync()
        {
            await Task.Delay(time);
        }

        async void dezplazaradentro()
        {
            Transition p = new Transition(new TransitionType_EaseInEaseOut(time));
            p.add(btnmenud, "Left", -29);
            p.add(pmenud, "Left", -64);
            p.run();

            await EsperarAsync();

            btnmenud.Visible = false;
            pmenud.Visible = false;
        }

        void dezplazaraafuera()
        {
            Transition p = new Transition(new TransitionType_EaseInEaseOut(time));
            btnmenud.Visible = true;
            pmenud.Visible = true;
            p.add(btnmenud, "Left", 19);
            p.add(pmenud, "Left", -16);
            p.run();
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelDesktop.Controls.Count > 0)
                this.panelDesktop.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(fh);
            this.panelDesktop.Tag = fh;
            fh.Show();
        }

        public void text(string tittle, string description)
        {
            tittlepage.Text = tittle;
            descriptiontext.Text = description;
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuIconButton1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
            t.add(menu, "Left", -300);
            t.add(tittlepage, "Left", 70);
            t.add(descriptiontext, "Left", 75);
            t.run();
            pmenud.Visible = true;
            btnmenud.Visible = true;

            closemenu.Visible = false;
            dezplazaraafuera();
        }

        private void btnmenud_Click(object sender, EventArgs e)
        {
            Transition l = new Transition(new TransitionType_EaseInEaseOut(time));
            l.add(menu, "Left", 23);
            l.add(tittlepage, "Left", 250);
            l.add(descriptiontext, "Left", 255);
            closemenu.Visible = true;
            l.run();

            dezplazaradentro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bordesradius();
            bunifuButton21.PerformClick();
        }

        private void labelhora_MouseLeave(object sender, EventArgs e)
        {
            panelfecha.Visible = false;
        }

        private void labelhora_MouseEnter(object sender, EventArgs e)
        {
            panelfecha.Visible = true;
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Close();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            text("Settings", "Easily customizable settings and preferences.");
            AbrirFormEnPanel(new Settings());
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            text("Analytics", "Display analytics about your channel.");
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            text("Budget", "???");
            AbrirFormEnPanel(new Budget());
        }

        public void bunifuButton22_Click(object sender, EventArgs e)
        {
            text("Profile", "???");
            AbrirFormEnPanel(new Dashboard());
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            text("Dashboard", "???");
            AbrirFormEnPanel(new Profile());
        }
    }
}