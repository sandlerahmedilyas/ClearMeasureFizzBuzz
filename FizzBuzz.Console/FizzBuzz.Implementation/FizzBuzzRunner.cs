using FizzBuzz.Implementation.Contracts;
using FizzBuzz.Implementation.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Implementation
{
    public sealed class FizzBuzzRunner : IFizzBuzz
    {
        /// <summary>
        /// Main entry point for FizzBuzz!
        /// </summary>
        /// <param name="request">The request object containing parameters for execution</param>
        /// <returns>Enumerable of a response object indicating the result of the operation</returns>
        public IEnumerable<FizzBuzzResponse> FizzBuzzRun(FizzBuzzRequest request)
        {
            // Let's use default rules, in case if the consumer does not provide any rules
            Rule fizzRule = new FizzRuleDefault { };
            Rule buzzRule = new BuzzRuleDefault { };
            Rule noMatch = new NoMatchRuleDefault { };

            // Validate our inputs

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "A valid request object must be supplied");
            }

            // Do they want to use default rules?
            if (!request.UseDefaultRules)
            {
                if (request.FizzRule == null)
                {
                    throw new ArgumentNullException(nameof(request.FizzRule), "A valid fizz rule must be supplied");
                }

                if (request.BuzzRule == null)
                {
                    throw new ArgumentNullException(nameof(request.FizzRule), "A valid buzz rule must be supplied");
                }

                if (request.NoMatch == null)
                {
                    throw new ArgumentNullException(nameof(request.NoMatch), "A valid no match rule must be supplied");
                }

                fizzRule = request.FizzRule;
                buzzRule = request.BuzzRule;
                noMatch = request.NoMatch;
            }

            if (request.UpperBound < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(request.UpperBound), "UpperBound must be greater than 1");
            }

            // Let's get an enumerable range of numbers based on low point and our upper point as specified by consumer
            var range = Enumerable.Range(1, request.UpperBound);

            foreach (var currentNumber in range)
            {
                // FizzBuzz!
                if (currentNumber % fizzRule.DivisibleBy == 0 && currentNumber % buzzRule.DivisibleBy == 0)
                {
                    yield return new FizzBuzzResponse
                    {
                        Success = true,
                        Result = $"{fizzRule.DivisibleByWord}{buzzRule.DivisibleByWord}"
                    };
                }
                else if (currentNumber % fizzRule.DivisibleBy == 0) // Fizz
                {
                    yield return new FizzBuzzResponse
                    {
                        Success = true,
                        Result = fizzRule.DivisibleByWord
                    };
                }
                else if (currentNumber % buzzRule.DivisibleBy == 0) // Buzz
                {
                    yield return new FizzBuzzResponse
                    {
                        Success = true,
                        Result = buzzRule.DivisibleByWord
                    };
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(noMatch.DivisibleByWord)) // No match so let's see if the input has a word to return or not
                    {
                        yield return new FizzBuzzResponse
                        {
                            Success = true,
                            Result = currentNumber.ToString() // just use counter
                        };
                    }
                    else
                    {
                        yield return new FizzBuzzResponse
                        {
                            Success = true,
                            Result = noMatch.DivisibleByWord // just use what was supplied instead
                        };
                    }
                }
            }
        }
    }
}
