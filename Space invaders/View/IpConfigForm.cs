using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders.View
{
    public partial class IpConfigForm : Form
    {
        public IpConfigForm()
        {
            InitializeComponent();
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            AppForm f = new AppForm(textBoxServer.Text, int.Parse(textBoxPort.Text), true);
            f.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            AppForm f = new AppForm(textBoxServer.Text, int.Parse(textBoxPort.Text), false);
            f.Show();
        }
    }
}
