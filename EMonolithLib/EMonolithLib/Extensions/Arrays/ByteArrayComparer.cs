using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Extensions.Arrays
{
    /// <summary>
    /// Class for simplify searching byte array in another byte array.
    /// </summary>
    public static class ByteArrayComparer
    {
        /// <summary>
        /// Checks if one array is contained in another.
        /// </summary>
        /// <param name="whereToFind">The array that possibly contains another array.</param>
        /// <param name="whatToFind">The array we want to find in another one.</param>
        /// <returns>Returns result of searching one array in another.</returns>
        public static bool Contains(this byte[] whereToFind, byte[] whatToFind)
        {
            if (IsEmptyLocate(whereToFind, whatToFind))
                return false;

            for (int i = 0; i < whereToFind.Length; i++)
            {
                if (!IsMatch(whereToFind, i, whatToFind))
                    continue;

                return true;
            }

            return false;
        }

        private static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;

            return true;
        }

        private static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
        }
    }
}
