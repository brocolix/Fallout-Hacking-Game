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

            // pokud mam jeste nejakej zivot tak jsem to uhadnul
            if(currentAttempts > 0)
            {
                Console.Clear();
                Console.WriteLine("WINNER WINNER CHICKEN DINNER");
            } else
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
            }
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
                // implementace akce porovnani pass a slova
                // ziskam slovo a pozovnam s heslem
                // pokud se schodoje vyhral jsem
                if (ComparePassAndValue(password, field.GetRowWord(selected)))
                {
                    loop = false;
                    return;
                }
                // pokud se neschoduje zivot dolu
                // pokud je nejaka podobnost ve znacich tak vypisu pocet stejnych znaku
                else
                {
                    // spatny pokus
                    FailedAttempt();
                }
            }

            // oznacim slovo
            field.HighlightRow(selected);

            // znovu renderuju pozadovany radek
            field.ReDrawRow(selected);

            // resetuji zvyrazneni minuleho slova
            field.HighlightRow(lastSelected);

            // znovu renderuju pozadovany radek se slovem
            field.ReDrawRow(lastSelected);


        }

        private void FailedAttempt()
        {
            currentAttempts--;

            Console.SetCursorPosition(0, 2);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("Attempts left: " + ParseIntToGrid(currentAttempts));

            // podobnost slova s heslem
            int likeness = TestLikeness(field.GetRowWord(selected));
            Console.SetCursorPosition(0, field.CountRows() + 6);
            Console.WriteLine("> Incorrect!");
            Console.WriteLine("> Likeness: " + likeness);
            Console.WriteLine("> " + field.GetRowWord(selected));
        }

        // porovna pocet stejnych znaku v heslu a fake polozce
        private int TestLikeness(string value)
        {
            int res = 0;
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < value.Length; j++)
                {
                    if(password[i] == value[j])
                    {
                        res++;
                    }
                }
            }
            return res;
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
