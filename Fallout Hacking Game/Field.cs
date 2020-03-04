using System;
using System.Collections.Generic;
using System.Text;

namespace Fallout_Hacking_Game
{
    // trida reprezentuje hraci pole
    class Field
    {
        // maximalni pocet znaku na radce
        private int rowsWidth;

        // list napleny instancemi radku
        private List<Row> rowsStore;

        // konstruktor 
        public Field(int rowsWidth, List<string> words)
        {
            this.rowsWidth = rowsWidth;
            CreateRows(words);
        }

        // naplni promenou s tabulkou radky
        private void CreateRows(List<string> words)
        {
            rowsStore = new List<Row>(words.Count);

            for(int i=0; i < words.Count; i++)
            {
                Row row = new Row(words[i], rowsWidth, i);
                // prvni polozka aktivni
                if (i == 0)
                {
                    row.Highlight();
                }
                rowsStore.Add(row);
            }
        }


        // ziska slovo ze zadaneho radku
        public string GetRowWord(int row)
        {
            return rowsStore[row].word;
        }

        // zvyrazni dany radek
        public void HighlightRow(int index)
        {
            rowsStore[index].Highlight();
            // resetuju zvyrazneni pro radky
        }

        public void ReDrawRow(int index)
        {
            rowsStore[index].Render();
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
