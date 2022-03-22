using System;
using System.Collections.Generic;
using ConsoleTables;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            try
            {
                Console.WriteLine("Press 1 to run the original code or 2 to run the updated code.");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice != 1 && choice != 2)
                {
                    throw new ArgumentException();
                }

                for (var i = 0; i < 31; i++)
                {
                    Console.WriteLine("-- Day " + i);

                    // Create a new ConsoleTables object to better display the stores items. Improves readability of table-like data on a console app.
                    var table = new ConsoleTable("Name", "Sell In", "Quality");

                    for (var j = 0; j < Items.Count; j++)
                    {
                        table.AddRow(Items[j].Name, Items[j].SellIn, Items[j].Quality);
                    }

                    table.Options.EnableCount = false;
                    table.Write();
                    Console.WriteLine();

                    app.UpdateQuality(choice);
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Allison's pet dragonhawk didn't like that and shoots a fireball as a warning shot.");
                Console.WriteLine();
                Items.Clear();
                Main(new string[0]);
            }
        }
    }
}
