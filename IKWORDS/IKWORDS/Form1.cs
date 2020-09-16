using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKWORDS
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int lastSelectedIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void turnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.tableTableAdapter.Update(this.database1DataSet.Table);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RandomRecord();
        }

        void RandomRecord()
        {
            int noRows = tableDataGridView.Rows.Count;
            int index = rnd.Next(noRows);

            while (index == lastSelectedIndex && noRows > 1)
            {
                index = rnd.Next(noRows);
            }
            if (lastSelectedIndex >= 0)
            {
                tableDataGridView.Rows[lastSelectedIndex].Selected = false;
            }
            lastSelectedIndex = index;
            tableDataGridView.Rows[index].Selected = true;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
