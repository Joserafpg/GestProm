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

namespace GestProm
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
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
            if (formAbierto != null)
            {
                formAbierto.Close();
            }

            foreach (Control control in this.main.Controls)
            {
                control.Visible = true;
            }

            open = false;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Settings());
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            CerrarFormEnPanel();
        }
    }
}
