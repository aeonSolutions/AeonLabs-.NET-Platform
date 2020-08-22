using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.BasicLibraries
{
    public static class arraysLibrary
    {
        public static int InQueryDictionary(ref Dictionary<string, List<string>> arr, string needle, string key)
        {
            int i;
            if (arr is null)
            {
                return -2;
            }

            var loopTo = arr[key].Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (arr[key][i].Equals(needle))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int InArrayInt( int[] arr, int needle)
        {
            int i;
            if (arr is null)
            {
                return -2;
            }

            var loopTo = arr.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(arr[i], needle, false)))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int InArray(ref int[][] arr, string needle, int pos)
        {
            int i;
            if (arr is null)
            {
                return -2;
            }

            var loopTo = arr.GetLength(0) - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (arr[i][pos].ToString().Equals(needle))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}