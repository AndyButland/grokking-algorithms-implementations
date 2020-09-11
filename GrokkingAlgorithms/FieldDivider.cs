using System;

namespace GrokkingAlgorithms
{
    public static class FieldDivider
    {
        public static int GetMaxSquareSize(int length, int width)
        {
            if (width > length)
            {
                throw new ArgumentException("Field length must be greater than or equal to the width.");
            }

            return length % width == 0
                ? width
                : GetMaxSquareSize(width, length % width);
        }
    }
}
