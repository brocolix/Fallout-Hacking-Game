using System;
using System.Collections.Generic;

namespace Fallout_Hacking_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // hledane heslo
            string password;
            // maximalni pocet pokusu
            int maxAttempts;
            // maximalni pocet znaku na radce
            int rowsWidth;
            List<string> fakeWords = new List<string>()
            {
                "same",
                "fear",
                "arts",
                "wars",
                "gear",
                "body",
                "fish",
                "holy",
                "gave"
            };

            password = "game";
            maxAttempts = 5;
            rowsWidth = 24;

            // prida heslo da listu s dalsimi slovy 
            fakeWords.Add(password);

            // promicha slova
            Helper.Shuffle<string>(fakeWords);

            // vytvori instanci herniho pole a preda ji pozadovane parametry
            Field field = new Field(rowsWidth, fakeWords);

            // vytvorim instanci hry a predam ji instanci herniho pole a dalsi parametry
            Game game = new Game(field, maxAttempts, password);

            // start hry
            game.Start();
        }
    }
}
