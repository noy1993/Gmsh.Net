using System;
using System.Collections.Generic;
using System.Linq;

namespace GmshNet
{
    public static class GmshExtend
    {
        public static int[] ToIntArray(this IEnumerable<ValueTuple<int, int>> pairs)
        {
            var count = pairs.Count();
            int[] list = new int[count * 2];
            int index = 0;
            foreach (var pair in pairs)
            {
                list[index] = pair.Item1;
                list[index + 1] = pair.Item2;
                index += 2;
            }
            return list;
        }

        public static ValueTuple<int, int>[] ToIntPair(this int[] list)
        {
            ValueTuple<int, int>[] ps = new ValueTuple<int, int>[list.Length / 2];
            for (int i = 0; i < list.Length / 2; i++)
            {
                ps[i].Item1 = list[i * 2];
                ps[i].Item2 = list[i * 2 + 1];
            }
            return ps;
        }

        public static ValueTuple<int, int>[][] ToIntPair(this int[][] list)
        {
            var array = new ValueTuple<int, int>[list.Length][];
            for (int i = 0; i < list.Length; i++)
            {
                var ps = new ValueTuple<int, int>[list.Length / 2];
                for (int j = 0; j < list[i].Length / 2; j++)
                {
                    ps[j].Item1 = list[i][j * 2];
                    ps[j].Item2 = list[i][j * 2 + 1];
                }
                array[i] = ps;
            }
            return array;
        }
    }
}