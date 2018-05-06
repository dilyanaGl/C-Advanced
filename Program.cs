using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            var plantsCount = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var plantsIndexes = new int[plantsCount];
            var stack = new Stack<int>();
            stack.Push(0);

            for (int i = 0; i < plants.Length; i++)
            {
                var deathDays = 0;

                while (stack.Count > 0 && plants[i] <= plants[stack.Peek()])
                {
                    deathDays = Math.Max(plantsIndexes[stack.Pop()], deathDays);
                }

                if (stack.Count > 0)
                {
                    plantsIndexes[i] = deathDays + 1;
                }

                stack.Push(i);
            }

            Console.WriteLine(plantsIndexes.Max());
        }
    }
}
