using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms
{
    public static class KnapsackFitter
    {
        public static Result GetMaxValue(int knapsackSize, Item[] items)
        {
            // Create calculation grid sized for the number of items and units of the knapsack size.
            var grid = new GridEntry[items.Length, knapsackSize];

            // Take each item in turn.
            for (var i = 0; i < items.Length; i++)
            {
                var currentItem = items[i];

                // Then loop through each of the units of knapsack size (i.e. if we have a size of 4, we'll check
                // intermediate sizes of 1, 2 and 3.
                for (var j = 0; j < knapsackSize; j++)
                {
                    // Item fits if it's weight is less than or equal to the intermediate knapsack size.
                    var doesItemFit = currentItem.Weight <= j + 1;

                    if (doesItemFit)
                    {
                        int previousMaxValue = 0, valueOfRemainingSpace = 0;
                        if (i > 0)
                        {
                            previousMaxValue = grid[i - 1, j].Value;
                            if (j - currentItem.Weight >= 0)
                            {
                                valueOfRemainingSpace = grid[i - 1, j - currentItem.Weight].Value;
                            }
                        }

                        // Item fits, so we can add it.
                        if (currentItem.Value + valueOfRemainingSpace > previousMaxValue)
                        {
                            // If the current value of the item plus the value of the remaining space is greater than the value added in the row
                            // above, then we'll populate the cell with the current item.
                            if (i == 0 || valueOfRemainingSpace == 0)
                            {
                                // If we're on the first row, or if there's nothing we can add in the remaining space, then
                                // we just put the current item in the cell by itself.
                                grid[i, j] = new GridEntry { Items = new[] { currentItem.Name }, Value = currentItem.Value };
                            }
                            else
                            {
                                // Otherwise we add the current item plus the item(s) from the grid cell we've found that
                                // represents what else we can fit in.
                                var gridEntryToFillFrom = grid[i - 1, j - items[i].Weight];
                                var itemsForCell = new List<string> { currentItem.Name };
                                itemsForCell.AddRange(gridEntryToFillFrom.Items);
                                var valueForCell = currentItem.Value + gridEntryToFillFrom.Value;
                                grid[i, j] = new GridEntry { Items = itemsForCell.ToArray(), Value = valueForCell };

                            }
                        }
                        else
                        {
                            // If the item being added is less than the value we've got already from the previous row,
                            // we just copy that over.
                            grid[i, j] = grid[i, j - 1];
                        }
                    }
                    else
                    {
                        // If the item doesn't fit, we either have an empty entry (for the first row), or we
                        // take whatever we filled for the intermediate knapsack size in the row above.
                        grid[i, j] = i == 0 ? new GridEntry() : grid[i - 1, j];
                    }
                }
            }

            // The result comes from the final entry in the grid.
            var finalEntry = grid[items.Length - 1, knapsackSize - 1];
            return new Result
            {
                Items = string.Join(",", finalEntry.Items.OrderBy(x => x)),
                Value = finalEntry.Value,
            };
        }

        public class Item
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public int Weight { get; set; }
        }

        public class GridEntry
        {
            public string[] Items { get; set; } = Array.Empty<string>();

            public int Value { get; set; }
        }

        public class Result
        {
            public string Items { get; set; }

            public int Value { get; set; }
        }
    }
}
