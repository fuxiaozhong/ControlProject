using ControlStart.JobMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.ControlForms
{
    public partial class Form_Home : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        public Form_Home()
        {
            InitializeComponent();

        }

        public void CamWork(string CamName, HalconDotNet.HObject image)
        {
            Work.CamWork(autoHalconWindow1[0], CamName, image);
        }

        private void Form_Home_Load(object sender, EventArgs e)
        {
            autoHalconWindow1.Count = 1;
            //this.Dock = DockStyle.Fill;

        }
    }
}
