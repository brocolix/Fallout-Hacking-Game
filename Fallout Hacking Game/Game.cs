using System;
using System.Collections.Generic;
using System.Text;

namespace Fallout_Hacking_Game
{
    // trida reprezentuje hlavni instanci hry
    class Game
    {
        private Field field;
        private string password;
        private int maxAttempts;
        private int currentAttempts;
        private int selected = 0;
        private bool loop = true;

        public Game(Field field, int maxAttempts, string password)
        {
            this.field = field;
            this.maxAttempts = maxAttempts;
            currentAttempts = maxAttempts;
            this.password = password;
        }

        public void Start()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome in ROBCO terminal");
            Console.WriteLine("PASSWORD REQUIRED");
            Console.WriteLine("Attempts left: " + ParseIntToGrid(currentAttempts));
            Console.WriteLine("-------------------------");
            field.RenderField();
            // klavesy ctu do doby nez uhadbu heslo nebo dojdou zivoty
            while (loop == true && currentAttempts > 0)
            {
                // nactu klavesu
                ConsoleKeyInfo cKey = Console.ReadKey();
                // zpracuju klavesu
                HandleClick(cKey);
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");
        }


        // akce po stisknuti tlacitka
        private void HandleClick(ConsoleKeyInfo cKey)
        {
            int lastSelected = selected;
            
            // zpracovani klavesy sipka dolu
            if (cKey.Key == ConsoleKey.DownArrow)
            {
                // implementace akce
                if (selected == field.CountRows() - 1)
                {
                    selected = 0;
                }
                else
                {
                    selected++;
                }
            }
            // zpracovani klavesy sipka nahoru
            else if (cKey.Key == ConsoleKey.UpArrow)
            {
                // implementace akce
                if (selected == 0)
                {
                    selected = field.CountRows() - 1;
                }
                else
                {
                    selected--;
                }
            }
            // zpracovani klavesy sipka enter
            else if (cKey.Key == ConsoleKey.Enter)
            {
                // implementace akce porovnani pass a polozky
                // ziskam text z polozky a pozovnam s heslem
                // pokud se schodoje vyhral jsem
                if (ComparePassAndValue(password, field.getRowValue(selected)))
                {
                    Console.Clear();
                    Console.WriteLine("WINNER WINNER CHICKEN DINNER");
                    loop = false;
                    return;
                }
                // pokud se neschoduje zivot dolu
                // pokud je nejaka podobnost ve znacich tak vypisu pocet stejnych znaku
                else
                {
                    //minus zivot
                    currentAttempts--;
                    Console.SetCursorPosition(0, 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("Attempts left: " + ParseIntToGrid(currentAttempts));

                    int likeness = TestLikeness(password, field.getRowValue(selected));
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("> Incorrect!");
                    Console.WriteLine("> Likeness: " + likeness);
                    Console.WriteLine("> " + field.getRowValue(selected));
                }
            }

            // oznacim polozku
            // zvyraznim radek s indexem
            field.HighLightRow(selected);

            // znovu renderuju pozadovany radek
            field.ReDrawRow(selected);

            // resetuju minulou polozku
            field.HighLightRow(lastSelected);

            // znovu renderuju pozadovany radek
            field.ReDrawRow(lastSelected);


        }

        // porovna pocet stejnych znaku v heslu a fake polozce
        private int TestLikeness(string password, string value)
        {
            return 2;
        }

        private bool ComparePassAndValue(string password, string value)
        {
            if (password == value)
            {
                return true;
            } else
            {
                return false;
            }
        }

        // prevede hodnotu na mrizky
        private string ParseIntToGrid(int num)
        {
            string result = "";
            for (int i = 0; i < num; i++)
            {
                result += "#";
            }

            return result;
        }
    }
}
