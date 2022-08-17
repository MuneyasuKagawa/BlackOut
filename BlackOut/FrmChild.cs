using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackOut
{
    public partial class FrmChild : Form
    {
        public Action KillAction { get; set; }

        public FrmChild(Action killAction)
        {
            InitializeComponent();
            this.KillAction = killAction;
        }

        private void FrmChild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.KillAction();
            }
        }
    }
}
