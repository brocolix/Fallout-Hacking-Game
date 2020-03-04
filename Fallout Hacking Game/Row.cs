using System;
using System.Collections.Generic;
using System.Text;

namespace Fallout_Hacking_Game
{
    // trida reprezentuje radek v hernim poly
    class Row
    {
        public string text;
        private int prefix;
        private int postfix;
        private int index;
        private Random rnd;
        private bool mark;

        public Row(string text, int maxLetters, int index)
        {
            this.text = text;
            this.index = index;
            // nevim zda nevyclenit do zvlastni metody az po konstrukci
            rnd = new Random();
            prefix = rnd.Next(1, maxLetters - text.Length);
            mark = false;
            postfix = CalculatePostfix(prefix, maxLetters);
        }

        private int CalculatePostfix(int num, int range)
        {
            int result = range - (num + this.text.Length);
            return result;
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

        public void Render(bool reRender = false)
        {
            if(reRender == true)
            {
                Console.SetCursorPosition(0,index + 4);
            }

            Console.Write("0xF2316C ");

            for (int i = 0; i < prefix; i++)
            {
                // doimplementovat generovani znaku z ascii
                Console.Write("o");
            }

            if(mark == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(text);

            Console.ResetColor();

            for (int i = 0; i < postfix; i++)
            {
                // doimplementovat generovani znaku z ascii
                Console.Write("i");
            }
        }
    }
}
