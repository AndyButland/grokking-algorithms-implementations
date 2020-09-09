namespace GrokkingAlgorithms
{
    public static class NumberSearcher
    {
        public static int SimpleSearch(int[] haystack, int needle)
        {
            for (var i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] haystack, int needle)
        {
            var low = 0;
            var high = haystack.Length - 1;
            
            while (low <= high)  // Keep searching until we've narrowed down the range to one element.
            {
                var mid = (low + high) / 2;
                var guess = haystack[mid];
                if (guess == needle)
                {
                    return mid;
                }

                if (guess > needle)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
