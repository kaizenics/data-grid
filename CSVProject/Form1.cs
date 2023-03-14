using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSVProject
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    sb.Append(col.HeaderText).Append(",");
                }
                sb.AppendLine();


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        sb.Append(row.Cells[i].Value);
                        if (i < row.Cells.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                }

                System.IO.File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount++;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.SelectedCells[0].ColumnIndex);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
          

        }
       
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Columns.Clear();

                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string line;
                    string[] fields;

                  
                    if ((line = reader.ReadLine()) != null)
                    {
                        fields = line.Split(',');
                        foreach (string field in fields)
                        {
                            dataGridView1.Columns.Add(field, field);
                        }
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        fields = line.Split(',');
                        dataGridView1.Rows.Add(fields);
                    }
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
            else
            {
                Application.ExitThread();
            }

            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Future Full Stack Dev: Nicose John Soriano, BSIT-2nd Year";
            MessageBox.Show(message);

           }
        }
    }
 
