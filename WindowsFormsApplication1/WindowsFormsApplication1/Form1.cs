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
    public partial class WebBrowser : Form
    {
        private WebSearch ws;
        public WebBrowser()
        {
            InitializeComponent();
            ws = new WebSearch(webBrowser1);
        }
        private void formatString(String s)
        {
            if (!s.StartsWith("http://") && !s.StartsWith("https://"))
            {
                s = "http://" + s;
            }
        }

        //Searches for address given when the go button is pressed
        private void search_btn_Click(object sender, EventArgs e)
        {

            String s = textBox1.Text;
            formatString(s);
            ws.search(s, true);
            historyToolStripMenuItem.DropDownItems.Add(s);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            formatString(s);
            ws.search(s, true);
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

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
