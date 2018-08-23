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
    public partial class Form3 : Form
    {
        Database dataB = new Database();
        string Name, music, origin; 
        public Form3()
        {
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
        {
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            music = textBox2.Text;
            origin = comboBox1.SelectedItem.ToString();
            Hide();
            Form4 form4 = new Form4(Name, music, origin);
            form4.ShowDialog();
            form4 = null;
            this.Close();
            
            

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
