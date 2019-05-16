using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class MenuItem
    {
        public string Text { get; set; }
        public char Character{ get; set; }
        public ActionHandler Handler { get; set; }

        public MenuItem(string text, char ch, ActionHandler handler)
        {
            this.Text = text;
            this.Character = ch;
            this.Handler = handler;
        }
    }
}
