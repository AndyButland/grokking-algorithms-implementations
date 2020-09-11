using System.Linq;

namespace GrokkingAlgorithms
{
    public static class NumberSum
    {
        public static int SumWithLoop(int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public static int SumWithRecursion(int[] numbers)
        {
            return numbers.Length == 0
                ? 0
                : numbers[0] + SumWithRecursion(numbers.Skip(1).ToArray());
        }
    }
}
