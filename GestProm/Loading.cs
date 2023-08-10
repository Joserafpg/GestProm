using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestProm
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            Thread progressThread = new Thread(UpdateProgressBar);
            progressThread.Start();
        }

        private void UpdateProgressBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Invoke(new Action(() => progressBar1.Value = i));
                Thread.Sleep(100);

                if (i == 100)
                {
                    Invoke(new Action(() => OpenMainForm()));
                }
            }
        }

        private void OpenMainForm()
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }
    }
}
