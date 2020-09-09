using System.Linq;
using System.Collections.Generic;

namespace GrokkingAlgorithms
{
    public static class ListSorter
    {
        public static Item[] SelectionSort(Item[] items)
        {
            var itemsAsList = items.ToList();
            var result = new List<Item>();
            while (itemsAsList.Any())
            {
                var highestCountIndex = FindIndexOfItemWithHighestCount(itemsAsList);
                result.Add(itemsAsList[highestCountIndex]);
                itemsAsList.RemoveAt(highestCountIndex);
            }

            return result.ToArray();
        }

        private static int FindIndexOfItemWithHighestCount(List<Item> items)
        {
            var highestCountIndex = 0;
            var highestCount = 0;
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Count > highestCount)
                {
                    highestCountIndex = i;
                    highestCount = items[i].Count;
                }
            }

            return highestCountIndex;
        }

        public class Item
        {
            public string Name { get; set; }

            public int Count { get; set; }
        }
    }
}
