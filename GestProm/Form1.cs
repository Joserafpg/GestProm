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
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;

            // Iniciar el Timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelhora.Text = DateTime.Now.ToString("HH:mm");
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

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(time));
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
            Transition l = new Transition(new TransitionType_EaseInEaseOut(time));
            l.add(menu, "Left", 23);
            bunifuIconButton2.Visible = true;
            l.run();

            dezplazaradentro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bordesradius();
        }
    }
}