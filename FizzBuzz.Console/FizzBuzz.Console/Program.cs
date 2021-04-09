using FizzBuzz.Implementation;
using FizzBuzz.Implementation.Contracts;
using System;

namespace FizzBuzz.ConsoleRunner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzzRunner();
            const int UpperBound = 100; // Int32.MaxValue;

            var response = fizzBuzz.FizzBuzzRun(new FizzBuzzRequest
            {
                UpperBound = UpperBound,
                UseDefaultRules = true,
            });

            if (response != null)
            {
                foreach (var currentResult in response)
                {
                    Console.WriteLine(currentResult.Result);
                }
            }
            Console.ReadLine();
        }
    }
}
