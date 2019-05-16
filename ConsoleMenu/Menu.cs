using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    public delegate void ActionHandler();

    public class Menu
    {
        public ConsoleColor HightlightColor { get; set; }
        public ConsoleColor NormalColor { get; set; }
        private readonly string _title;
        private readonly Dictionary<char, MenuItem> _itemsMap;

        public Menu(string title)
        {
            this._title = title;
            this._itemsMap = new Dictionary<char, MenuItem>();
            this.HightlightColor = ConsoleColor.Yellow;
            this.NormalColor = ConsoleColor.Gray;
        }

        public void AddItem(string text, char ch, ActionHandler handler)
        {
            this._itemsMap.Add(ch, new MenuItem(text, ch, handler));
        }

        public void AddItem(string text, ActionHandler handler)
        {
            char ch = GetHighlightedChar(text);

            this._itemsMap.Add(ch, new MenuItem(text, ch, handler));
        }

        private char GetHighlightedChar(string input)
        {
            // Search for '&' and return for next char (lowercase)
            if (input.Contains("&") && input.IndexOf('&') < input.Length)
            {
                int index = input.IndexOf('&') + 1;

                return Char.ToLower(input[index]);
            }

            // if nothing is found or '&' is last, return '\0'
            //return '\0';
            // jk, we throw
            throw new ArgumentException("No highlight found");
        }

        public void AddItem(MenuItem item)
        {
            this._itemsMap.Add(item.Character, item);
        }

        public void Run()
        {
            while(true)
            {   // Writing the menu to the screen
                this.ShowMenu();

                // waiting for a character to be pressed on the keyboard (any char)
                char Input = Char.ToLower(Console.ReadKey().KeyChar);

                if (!this._itemsMap.ContainsKey(Input))
                {
                    // all other character trigger an error message to be displayed
                    Console.WriteLine("Enter an allowed Key, Please");
                    continue;
                }

                Console.Clear();
                this._itemsMap[Input].Handler();
            };
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(this._title);
            foreach (MenuItem item in this._itemsMap.Values)
            {
                string text = item.Text;
                char highlighted = GetHighlightedChar(text);

                // Make sure that no '&' is shown and char is highlighted
                foreach (char ch in text)
                {
                    if (ch == '&')
                    {
                        continue;
                    }

                    if (Char.ToLower(ch) == highlighted)
                    {
                        Console.ForegroundColor = this.HightlightColor;
                    }
                    else
                    {
                        Console.ForegroundColor = this.NormalColor;
                    }

                    Console.Write(ch);
                }

                Console.Write('\n');
            }

            Console.Write("Your choice?");
        }
    }
}
