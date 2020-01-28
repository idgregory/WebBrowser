using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class WebBrowser
    {
        private List<String> site_list;
        int current_index;
        public WebBrowser()
        {
            site_list = new List<string>();
            current_index = 0;
        }

        public void search(String s, System.Windows.Forms.WebBrowser b)
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

            site_list.Add(s);

        }

        private String getPrev()
        {
            return "s";
        }
    }
}
