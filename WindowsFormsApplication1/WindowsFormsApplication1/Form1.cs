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
        private String curr_string;
        public WebBrowser()
        {
            InitializeComponent();
            ws = new WebSearch(webBrowser1);
            curr_string = null;
        }
        private void formatString()
        {
            if (String.IsNullOrEmpty(curr_string)) return;
            if (curr_string.Equals("about:blank")) return;
            if (!curr_string.StartsWith("http://") && !curr_string.StartsWith("https://")) curr_string = "http://" + curr_string;
        }

        //Searches for address given when the go button is pressed
        private void search_btn_Click(object sender, EventArgs e)
        {

            curr_string = textBox1.Text;
            formatString();
            ws.search(curr_string);
            toolStripComboBox1.BeginUpdate();
            toolStripComboBox1.Items.Add(curr_string);
            toolStripComboBox1.EndUpdate();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            curr_string = textBox1.Text;
            formatString();
            ws.search(curr_string);
            toolStripComboBox1.BeginUpdate();
            toolStripComboBox1.Items.Add(curr_string);
            toolStripComboBox1.EndUpdate();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                curr_string = textBox1.Text;
                formatString();
                ws.search(curr_string);
                toolStripComboBox1.BeginUpdate();
                toolStripComboBox1.Items.Add(curr_string);
                toolStripComboBox1.EndUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ws.goBackwards();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ws.goForward();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ws.refresh();
        }
    }
}
