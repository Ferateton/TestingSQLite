using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TestingSQLite
{
    
    public partial class Form1 : Form
    {
        Database dataB = new Database();
        

        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataB.LoadTable();
            bandI.Checked = true;
            for (int i = 0; i < dataB.Count("BandName", "Band") - 1; i++)
            {
                comboBox2.Items.Add(dataB.FillcomboB(i, "Band", "BandName"));
            }
            comboBox1.Items.Clear();
            for (int i = 0; i < dataB.Count("SceneID", "Scene"); i++)
            {
                comboBox1.Items.Add(dataB.FillcomboB(i, "Scene", "SceneID"));
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            form2 = null;
            Show();
        }
        
        public void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dataB.LoadTable();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Band";
                dataGridView1.Columns[2].Name = "Instrument";
                string send;
                send = textBox1.Text;
                for (int i = 0; i < 20; i++)
                {
                    dataGridView1.Rows.Add(dataB.Member(send,i));  
                }                
                
                
            }
            catch (Exception)
            { }
           
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string send;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Date";
            dataGridView1.Columns[1].Name = "Scene";
            dataGridView1.Columns[2].Name = "Time";
            dataGridView1.Columns[2].Name = "Band";

            send = comboBox1.Text;
            for (int i = 0; i < 20; i++)
            {
                 dataGridView1.Rows.Add(dataB.Scene(send, i));
            }
        }


        private void bandI_CheckedChanged(object sender, EventArgs e)
        {
            if (bandI.Checked == true)
            { BandS.Checked = false; }
        }

        private void BandS_CheckedChanged(object sender, EventArgs e)
        {
            if (BandS.Checked == true)
            { bandI.Checked = false; }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string send;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 4;


            send = comboBox2.Text;
            if (bandI.Checked && !BandS.Checked)
            {
                dataGridView1.Columns[0].Name = "Members";
                dataGridView1.Columns[1].Name = "Origin";
                dataGridView1.Columns[2].Name = "Music Style";
                dataGridView1.Columns[3].Name = "Band";
                for (int i = 0; i < 20; i++)
                {

                    dataGridView1.Rows.Add(dataB.Band(send, i));
                }
            }
            else if (!bandI.Checked && BandS.Checked)
            {

                for (int i = 0; i < 20; i++)
                {
                    dataGridView1.Columns[0].Name = "Day";
                    dataGridView1.Columns[1].Name = "Scene";
                    dataGridView1.Columns[2].Name = "Time";
                    dataGridView1.Columns[3].Name = "";
                    dataGridView1.Rows.Add(dataB.Playing(send, i));
                }
            }
        }

        
        


        

        

        

        
          
    }
}
