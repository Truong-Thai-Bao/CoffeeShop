using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataTransferLayer;
namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private SupplierBL supplierBL;
        public Form1()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = supplierBL.GetSuppliers();
        }
    }
}
