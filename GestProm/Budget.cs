using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestProm
{
    public partial class Budget : Form
    {
        public Budget()
        {
            InitializeComponent();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            panelgeneral.Visible = true;
            panelnew.Visible = true;
        }

        private void btnbudgetname_Click(object sender, EventArgs e)
        {
            string texto = budgetname.Text;
            if (texto.Count() > 4 )
            {
                panelbudget.Visible = true;
            }
            
            else
            {
                if (texto.Count() > 0) 
                {
                    MessageBox.Show("The name is too short");              
                }

                else
                {
                    MessageBox.Show("Please write a name");
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            paneldtg.Visible = true;
        }
    }
}
