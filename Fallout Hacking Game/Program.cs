using System;
using System.Collections.Generic;

namespace Fallout_Hacking_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;
            int maxAttempts;
            int maxLetters;
            List<string> items = new List<string>()
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
            maxAttempts = 3;
            maxLetters = 12;
            items.Add(password);

            // vytvorim instanci herniho pole a predam ji pozadovane parametry
            Field field = new Field(maxLetters, items);

            // vytvorim instanci hry a predam ji instanci herniho pole a dalsi parametry
            Game game = new Game(field, maxAttempts, password);

            // start hry
            game.Start();
        }
    }
}
