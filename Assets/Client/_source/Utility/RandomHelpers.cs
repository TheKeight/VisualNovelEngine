using System;
using System.Collections.Generic;

namespace NovelEngine.Utility
{
    public static class RandomHelpers
    {
        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int j = UnityEngine.Random.Range(i, n);

                if (j != i)
                {
                    (list[j], list[i]) = (list[i], list[j]);
                }
            }
        }

        public static void Shuffle<T>(Span<T> values, System.Random rng)
        {
            int n = values.Length;

            while (n > 1)
            {
                int j = rng.Next(0, n + 1);
                T temp = values[j];
                values[j] = values[n];
                values[n] = temp;
            }
        }
    }
}
