using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private WebSearch ws;
        public Form1()
        {
            InitializeComponent();
            ws = new WebSearch(webBrowser1);
        }

        //Searches for address given when the go button is pressed
        private void search_btn_Click(object sender, EventArgs e)
        {
            ws.search(textBox1.Text, true);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           ws.search(textBox1.Text, true);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ws.search(textBox1.Text, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ws.search_back();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.search_prev();
        }
    }
}
