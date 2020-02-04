using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class WebSearch
    {
        private List<string> history;
        private System.Windows.Forms.WebBrowser b;
        public WebSearch(System.Windows.Forms.WebBrowser b)
        {
            history = new List<string>();
            this.b = b;
            
        }

        //searches for the given url
        //bool isNew tells the function if the search is new or a previous search
        public void search(String s)
        {
            if (String.IsNullOrEmpty(s)) return;
            if (s.Equals("about:blank")) return;

            if (!s.StartsWith("http://") && !s.StartsWith("https://"))
            {
                s = "http://" + s;
            }
            try
            {
                b.Navigate(new Uri(s));
            }
            catch (System.UriFormatException)
            {
                return;
            }

            history.Add(s);
        }

        public void goForward()
        {
            if(b.CanGoForward) b.GoForward();
        }

        public void goBackwards()
        {
            if (b.CanGoBack) b.GoBack();
        }

        public void goToSearchEngine()
        {
            b.GoSearch();
        }
        public void refresh()
        {
            b.Refresh();
        }

        public void printPage()
        {
            b.Print();
        }
    }
}
