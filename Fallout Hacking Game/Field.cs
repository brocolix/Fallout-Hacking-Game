using System;
using System.Collections.Generic;
using System.Text;

namespace Fallout_Hacking_Game
{
    // trida reprezentuje hraci pole
    class Field
    {
        // maximalni pocet znaku na radce
        private int maxLetters;

        // list napleny instancemi radku
        private List<Row> rowsStore;

        // konstruktor 
        public Field(int maxLetters, List<string> items)
        {
            this.maxLetters = maxLetters;
            CreateRows(items);
        }

        // naplni promenou s tabulkou radky
        private void CreateRows(List<string> items)
        {
            rowsStore = new List<Row>(items.Count);

            for(int i=0; i < items.Count; i++)
            {
                Row row = new Row(items[i], maxLetters, i);
                // prvni polozka aktivni
                if (i == 0)
                {
                    row.Highlight();
                }
                rowsStore.Add(row);
            }
        }

        public string getRowValue(int row)
        {
            return rowsStore[row].text;
        }

        // zvyrazni dany radek
        public void HighLightRow(int index)
        {
            rowsStore[index].Highlight();
            // resetuju zvyrazneni pro radky
        }

        public void ReDrawRow(int index)
        {
            rowsStore[index].Render(true);
        }

        // vrati pocet radku v tabulce
        public int CountRows()
        {
            return rowsStore.Count;
        }

        // zavola metody radku pro vykresleni
        public void RenderField()
        {
            foreach(Row row in rowsStore)
            {
                row.Render();
                Console.WriteLine("");
            }
        }
    }
}
