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
    public partial class Form4 : Form
    {
        string  send1,send2,send3,send4,send5,sendseleceted;
        int sendint5;
        bool procced;
        bool editible;
        Database dataB = new Database();
        public Form4(string sent1, string sent2, string sent3)
        {
            InitializeComponent();
            send1 = sent1;
            send2 = sent2;
            send3 = sent3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Add Worker" && editible == false)
            {
                send4 = textBox1.Text;
                send5 = textBox2.Text;
                send1 = send1;
                try
                {
                    sendint5 = Convert.ToInt32(send5);
                    procced = true;
                }
                catch
                {
                    MessageBox.Show("ID is not a string try again");
                    procced = false;
                }
                if (procced == true)
                {

                    dataB.insertWorker(send4, sendint5);
                    dataB.insertManager(send4, sendint5, send1);
                    dataB.insertBand(send1, send2, send3, send4);
                    
                    this.Close();
                }
                else if (comboBox1.SelectedItem != "Add Worker" && editible == true)
                {
                    send4 = comboBox1.Text;
                    send5 = comboBox2.Text;
                    
                    try
                    {
                        sendint5 = Convert.ToInt32(send5);
                        procced = true;
                    }
                    catch
                    {
                        MessageBox.Show("ID is not a string try again");
                        procced = false;
                    }
                    if (procced != false)
                    {
                        
                        dataB.UpdateWorker(send4, sendint5);
                        dataB.insertManager(send4, sendint5, send1);
                        dataB.insertBand(send1, send2, send3, send4);
                        
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Add Worker");
            comboBox1.SelectedItem = "Add Worker";
            for (int i = 0; i < dataB.Count("Name", "Worker") - 1; i++)
            {
                comboBox1.Items.Add(dataB.Worker(i));
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "Add Worker")
            {
                editible = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                try
                {
                    sendseleceted = comboBox1.Text;
                    comboBox2.Items.Clear();
                    for (int i = 0; i < dataB.CountID("ID", "Worker", sendseleceted); i++)
                    {
                        comboBox2.Items.Add(dataB.GetWorkerID(sendseleceted, i));
                    }
                }
                catch { }
            }
            else if(comboBox1.SelectedItem == "Add Worker")
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                editible = false;  
            }
        }
    }
}
