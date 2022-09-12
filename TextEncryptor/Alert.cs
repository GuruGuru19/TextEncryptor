using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEncryptor
{
    public partial class Alert : Form
    {
        public Alert(string text, int time = 5000)
        {
            InitializeComponent();
            timeout.Interval = time;
            label1.Text = text;
            this.Show();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
