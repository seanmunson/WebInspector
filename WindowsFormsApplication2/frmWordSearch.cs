using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class frmWordSearch : Form
    {
        public MachineContext M;

        public frmWordSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string,ProgramElement> p in M.Elements)
            {
                if (p.Value.ElementType == ElementType.TextFile)
                {
                    
                }
            }
        }
    }
}
