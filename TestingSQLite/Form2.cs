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
    public partial class Form2 : Form
    {
        Database dataB = new Database();
        string sendBname, sendSname, sendDate, sendSecurity, sendTime,sendLoc;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataB.Count("BandName", "Band") - 1; i++)
            {
                comboBox1.Items.Add(dataB.FillcomboB(i, "Band", "BandName"));
            }
            for (int i = 0; i < dataB.Count("SceneID", "Scene"); i++)
            {
                comboBox2.Items.Add(dataB.FillcomboB(i, "Scene", "SceneID"));
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void bookBand_Click(object sender, EventArgs e)
        {
            
            Form3 form3 = new Form3();
            form3.ShowDialog();
            form3 = null;
            try
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < dataB.Count("BandName", "Band"); i++)
                {
                    comboBox1.Items.Add(dataB.FillcomboB(i, "Band", "BandName"));
                }
            }
            catch { }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sendDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            sendSname = comboBox2.Text;
            sendTime = textBox1.Text;
            sendBname = comboBox1.Text;
            dataB.insertScedual(sendDate, sendSname, sendTime, sendBname);
            //dataB.insertBandScene(sendLoc, sendSname, "Oskar");
        }
        
        
       
        
    } 
}
