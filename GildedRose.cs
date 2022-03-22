using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public static int _maxQuality = 50;
        public static int _minQuality = 0;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        /// <summary>
        /// Determines if the original or updated code is to be run baseed on user input.
        /// </summary>
        /// <param name="choice">Numerical choice the user typed at the prompt.</param>
        public void UpdateQuality(int choice)
        {
            switch (choice)
                {
                case 1:
                    RunOriginalCode();
                    break;
                case 2:
                    RunCleanedCode();
                    break;
            }
        }

        /// <summary>
        /// Updated code. It has been rewritten to be cleaner, easier to read, more maintainable, and easier to expand upon.
        /// </summary>
        public void RunCleanedCode()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        {
                            // I was a little confused by the code given versus the conditions given for Aged Brie. In a real world setting, I would've just reached out to a BA, PM, or the client directly for clarification.
                            // Since I didn't really have those resources, I coded it both ways and could simply delete the wrong one based on the response.

                            // Increase quality of Aged Brie by 1. This is how I interpreted the requirements, but I could be wrong. I just don't see how it could ever increase if quality by 2 each day given the conditions.
                            Items[i].Quality = Items[i].Quality < _maxQuality ? IncrementQuality(Items[i].Quality, 1) : Items[i].Quality;

                            // Increase quality of Aged Brie by 2 once sell in date is less than zero. This is how the code works, but I think it's a bug. The original code (saved towards the bottom of this document) has Aged Brie decreasing in quality twice each day, but the requirements say otherwise.
                            //Items[i].Quality = Items[i].Quality < _maxQuality ? IncrementQuality(Items[i].Quality, 2) : Items[i].Quality;

                            break;
                        }
                    case "Backstage passes to a TAFKAL80ETC concert":
                        {
                            Items[i].Quality = (Items[i].SellIn <= 0) ? Items[i].Quality = 0 : // If the item's sell-in days is 0 or below - set it's quality to 0.
                                               (Items[i].SellIn > 0 && Items[i].SellIn <= 5) ? IncrementQuality(Items[i].Quality, 3) : // If the item's sell-in days is between 1 and 5 - increase it's quality by 3.
                                               (Items[i].SellIn > 5 && Items[i].SellIn <= 10) ? IncrementQuality(Items[i].Quality, 2) : // If the item's sell-in days is between 6 and 10 - increase it's quality by 2.
                                               (Items[i].Quality < _maxQuality && Items[i].Quality != 0) ? IncrementQuality(Items[i].Quality, 1) : // If the item's quality is less than the max quality, and not equal to 0 - increase it's quality by 1.
                                               Items[i].Quality; // No change to item's quality.

                            Items[i].Quality = IsItemMaxQuality(Items[i].Quality);

                            break;
                        }
                    case string item when Items[i].Name.Contains("Conjured"):
                        {
                            Items[i].Quality = (Items[i].Quality >= 1) ? DecrementQuality(Items[i].Quality, 2) : Items[i].Quality;

                            break;
                        }
                    case "Sulfuras, Hand of Ragnaros":
                        {
                            // This item has a set quality. If detected, it'll bypass any logic that alters an item's quality.
                            break;
                        }
                    default:
                        {
                            Items[i].Quality = (Items[i].Quality == 0) ? Items[i].Quality : // If the quality of an item is 0 - don't alter it.
                                               (Items[i].SellIn <= 0) ? DecrementQuality(Items[i].Quality, 2) : // If the item's sell-in days is less than or equal to 0 - decrease it's quality by 2.
                                               (Items[i].Quality > _minQuality) ? DecrementQuality(Items[i].Quality, 1) : // If the item's quality is higher than the minimum quality allowed - decrease it's quality by 1.         
                                               Items[i].Quality; // No change to item's quality.

                            break;
                        }
                }

                ReduceSellInDays(Items[i], 1);
            }
        }

        /// <summary>
        /// Checks if the quality of an item is higher than the max allowed. If it is, set the item's quality to the max quality.
        /// </summary>
        /// <param name="itemQuality">Quality of the Item.</param>
        /// <returns>The item's quality.</returns>
        public int IsItemMaxQuality(int itemQuality)
        {
            return itemQuality = (itemQuality > _maxQuality) ? _maxQuality : itemQuality;
        }

        /// <summary>
        /// Reduce the item's sell in days by one.
        /// </summary>
        /// <param name="item">Item object.</param>
        public void ReduceSellInDays(Item item, int daysToReduce)
        {
            if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn = item.SellIn - daysToReduce;
            }
        }

        /// <summary>
        /// Increase an item's quality based on the supplied parameter.
        /// </summary>
        /// <param name="itemQuality">Item's current quality.</param>
        /// <param name="increaseQualityBy">Number to increase the item's quality by.</param>
        /// <returns>Item's updated quality.</returns>
        public int IncrementQuality(int itemQuality, int increaseQualityBy)
        {
            return itemQuality = itemQuality + increaseQualityBy;
        }

        /// <summary>
        /// Decrease an item's quality based on the supplied parameter.
        /// </summary>
        /// <param name="itemQuality">Item's current quality.</param>
        /// <param name="decreaseQualityBy">Number to decrease the item's quality by.</param>
        /// <returns>Item's updated quality.</returns>
        public int DecrementQuality(int itemQuality, int decreaseQualityBy)
        {
            return itemQuality = itemQuality - decreaseQualityBy;
        }

        /// <summary>
        /// Original messy code. It has been updated with the new Conjured item.
        /// </summary>
        public void RunOriginalCode()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros" && Items[i].Name != "Conjured Mana Cake")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                        else if (Items[i].Name == "Conjured Mana Cake") // Code added to handle the new Conjured item.
                        {
                            Items[i].Quality = Items[i].Quality - 2;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
