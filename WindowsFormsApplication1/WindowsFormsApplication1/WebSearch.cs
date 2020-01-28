﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class WebSearch
    {
        private List<string> site_list;
        private WebBrowser b;
        int current_index;
        public WebSearch(WebBrowser b)
        {
            site_list = new List<string>();
            current_index = 0;
            this.b = b;
        }

        public void search(String s, bool isNew)
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


            if (isNew)
            {
                if (site_list.Count() > 0) current_index++;
                site_list.Add(s);
            }

        }

        //searches the list for the webpage after the the current index
        public void search_prev()
        {
            String prev = getPrev();
            if (prev == null) return;
            search(prev, false);
            current_index++;
        }

        //Searches for the webpage before the current index
        public void search_back()
        {
            String back = getBack();
            if (back == null) return;
            search(back, false);
            current_index--;
        }

        //Helper function that gets the item after the current index
        //Returns null if there aren't any webpages after the current index
        private String getPrev()
        {
            if (current_index >= (site_list.Count() - 1)) return null;
            return site_list[current_index + 1];
        }

        //Helper function that gets the item before the current index
        //Returns null if there aren't any webpages that have been searched
        private String getBack()
        {
            if (current_index == 0) return null;
            return site_list[current_index - 1];
        }
    }
}