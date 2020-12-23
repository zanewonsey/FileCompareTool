using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompareTool
{
    public partial class DifferenceListForm : Form
    {
        //public Form1 MyParentForm;

        public DifferenceListForm()
        {
            InitializeComponent();
        }

        private void Populate()
        {
            LB_DifferenceList.Items.Clear();
            List<string> diffList = ((Form1) this.Owner).differences; //((Form1)MyParentForm).differences;
            foreach (string diff in diffList)
            {
                LB_DifferenceList.Items.Add(diff);
            }
        }

        public void Notify(IWin32Window owner)
        {
            this.Owner = (Form1) owner;
            Populate();
        }

        private void DifferenceListForm_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
