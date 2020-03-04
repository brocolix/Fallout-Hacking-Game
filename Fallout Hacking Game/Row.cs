using System;
using System.Collections.Generic;
using System.Text;

namespace Fallout_Hacking_Game
{
    // trida reprezentuje radek v hernim poly
    class Row
    {
        public string word;
        private int index;
        private string memAddr;
        private Random rnd;
        private bool mark;

        private List<char> prefixStore;
        private List<char> postfixStore;

        public Row(string word, int rowsWidth, int index)
        {
            this.word = word;
            this.index = index;
            // nevim zda nevyclenit do zvlastni metody az po konstrukci
            rnd = new Random();
            prefixStore = GetPrefixList(rowsWidth);
            postfixStore = GetPostfixList(prefixStore.Count, rowsWidth);
            memAddr = GetMemAddr();
            mark = false;
        }

        private string GetMemAddr()
        {
            string i = index.ToString();
            return "0xF3C80" + i;
        }

        private List<char> GetPrefixList(int maxSize)
        {
            int prefixQuantity = rnd.Next(1, maxSize - word.Length);
            List<char> arr = new List<char>();
            for (int i=0; i<prefixQuantity; i++)
            {
                int rndChar = rnd.Next(0, 6);
                char e = (char)(33 + rndChar);
                arr.Add(e);
            }

            return arr;

        } 

        private List<char> GetPostfixList(int num, int range)
        {
            int postfixQuantity = range - (num + word.Length);
            List<char> arr = new List<char>();
            for (int i = 0; i < postfixQuantity; i++)
            {
                int rndChar = rnd.Next(0, 6);
                char e = (char)(33 + rndChar);
                arr.Add(e);
            }

            return arr;
        }

        public void Highlight()
        {
            if(mark == true)
            {
                mark = false;
            }
            else
            {
                mark = true;
            }
        }

        public void Render()
        {           
            Console.SetCursorPosition(0,index + 4);
            

            Console.Write("{0} ", memAddr);

            for (int i = 0; i < prefixStore.Count; i++)
            {
                Console.Write(prefixStore[i]);
            }

            if(mark == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(word);

            Console.ResetColor();

            for (int i = 0; i < postfixStore.Count; i++)
            {
                Console.Write(postfixStore[i]);
            }
        }
    }
}
