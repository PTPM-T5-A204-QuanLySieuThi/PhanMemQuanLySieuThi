using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLoading : MetroFramework.Forms.MetroForm
    {
        public frmLoading()
        {
            InitializeComponent();
            timerLoading = new Timer();
            timerLoading.Interval = 1;
            timerLoading.Enabled = true;
            timerLoading.Tick += TimerLoading_Tick;
        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            timeLine.Width += 3;
            if(timeLine.Width >= 686)
            {
                timerLoading.Stop();
            }
        }
    }
}
