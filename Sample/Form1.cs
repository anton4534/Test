using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample.Controller;

namespace Sample
{
    public partial class Form1 : Form
    {
        Query controller;

        public Form1()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePerson();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            string selectString =
 "PIB Like '%" + textBox4.Text.Trim() + "%'";

            DataRowCollection allRows =
            ((DataTable)dataGridView1.DataSource).Rows;

            DataRow[] searchedRows =
            ((DataTable)dataGridView1.DataSource).
            Select(selectString);

            int rowIndex = allRows.IndexOf(searchedRows[0]);

            dataGridView1.CurrentCell =
            dataGridView1[0, rowIndex];
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
                f2.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
                f3.Show();
        }
    }
}
