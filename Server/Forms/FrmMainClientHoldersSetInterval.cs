using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xServer.Core.Networking;

namespace xServer.Forms
{
    public partial class FrmMainClientHoldersSetInterval : Form
    {
        private ClientHolder[] _holders;

        public FrmMainClientHoldersSetInterval(ClientHolder[] holders)
        {
            _holders = holders;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double interval;
            try
            {
                interval = double.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Cannot convert number to double");
                return;
            }
            foreach (ClientHolder holder in _holders)
            {
                holder.SleepInterval = (int)(interval * 1000);
            }
            
            this.Close();
        }
    }
}
