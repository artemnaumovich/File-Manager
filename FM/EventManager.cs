using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM
{
    class EventManager
    {
        private DateTime dateTime;
        private string title = "";
        private string description = "";

        public void SetDateTime()
        {
            dateTime = DateTime.Now;
        }   
        public void SetTitle(String title)
        {
            this.title = title;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }

        public override string ToString()
        {
            return dateTime + " " + title + " " + description;
        }
    }
}
