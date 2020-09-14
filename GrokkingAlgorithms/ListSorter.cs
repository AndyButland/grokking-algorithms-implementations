using System.Linq;
using System.Collections.Generic;
using System;

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

        public static Item[] QuickSort(Item[] items)
        {
            if (items.Length < 2)
            {
                return items;   // As "base case" array with 0 or 1 elements is already sorted.
            }

            var pivot = items[0];
            var less = new List<Item>();
            var greater = new List<Item>();

            for (var i = 1; i < items.Length; i++)
            {
                if (items[i].Count <= pivot.Count)
                {
                    less.Add(items[i]);
                }
                else
                {
                    greater.Add(items[i]);
                }
            }

            return QuickSort(greater.ToArray()).Concat(new Item[] { pivot }).Concat(QuickSort(less.ToArray())).ToArray();
        }

        public static List<Item> QuickSort2(List<Item> items)
        {
            if (items.Count < 2)
            {
                return items;   // As "base case" array with 0 or 1 elements is already sorted.
            }

            var pivot = items.First();
            var rest = items.Skip(1);
            var less = rest.Where(x => x.Count <= pivot.Count).ToList();
            var greater = rest.Where(x => x.Count > pivot.Count).ToList();

            var result = QuickSort2(greater);
            result.Add(pivot);
            result.AddRange(QuickSort2(less));
            return result;
        }

        public class Item
        {
            public string Name { get; set; }

            public int Count { get; set; }
        }
    }
}
