using System;

namespace SkipListCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList skipList = new SkipList(1, 5);

            // Insert values
            for (int i = 0; i < 10; i++)
            {
                skipList.Insert(i);
            }

            Console.WriteLine("Before deletion:");
            skipList.Print();

            // Search for a value
            Console.WriteLine($"Search for value 5: {skipList.Search(5)}");

            // Delete a value
            skipList.Delete(3);

            Console.WriteLine("\nAfter deletion:");
            skipList.Print();

            Console.ReadKey();
        }
    }
}
