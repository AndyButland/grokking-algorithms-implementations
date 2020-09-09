using System.Linq;
using System.Collections.Generic;
using System;

namespace GrokkingAlgorithms
{
    public static class KeyFinder
    {
        public static Box FindWithLoop(Box box)
        {
            var pile = new List<Box>(box.Boxes);
            while (pile.Any())
            {
                box = pile[0];
                if (box.HasKey)
                {
                    return box;
                }

                pile.AddRange(box.Boxes);
                pile.RemoveAt(0);
            }

            return null;
        }

        public static Box FindWithRecursion(Box box)
        {
            foreach (var boxFromPile in box.Boxes)
            {
                if (boxFromPile.HasKey)
                {
                    return boxFromPile;
                }
                else
                {
                    var boxWithKey = FindWithRecursion(boxFromPile);
                    if (boxWithKey != null)
                    {
                        return boxWithKey;
                    }
                }
            }

            return null;
        }

        public class Box
        {
            public Box[] Boxes { get; set; } = Array.Empty<Box>();

            public bool HasKey { get; set; }
        }

    }
}
