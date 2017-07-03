using System;

namespace OverflowSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.MaxValue;
            checked
            {
                x++;
                Console.WriteLine($"{x}, hex: {x:X}");
            }
        }
    }
}