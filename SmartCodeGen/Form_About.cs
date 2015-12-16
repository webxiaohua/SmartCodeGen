using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartWinControls.SmartControls.Forms;

namespace SmartCodeGen
{
    public partial class Form_About : SmartForm
    {
        public Form_About()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void smartButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
