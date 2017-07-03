using System;
using System.Buffers;
using System.Linq;

namespace SpanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "this is a long string a long string a " +
                "very long string this is a long string a long string a very long string ";

            ReadOnlySpan<char> span1 = s.AsSpan();

            var span2 = span1.Slice(20, 10);

            int[] arr = Enumerable.Range(0, 10000).ToArray();
            Span<int> span3 = arr.AsSpan();
            Span<int> span4 = span3.Slice(40, 10);

            for (int i = 0; i < span4.Length; i++)
            {
                Console.WriteLine(span4[i]);
            }

            int[] arr2 = ArrayPool<int>.Shared.Rent(100);

            ArrayPool<int>.Shared.Return(arr2, clearArray: true);
        }
    }
}