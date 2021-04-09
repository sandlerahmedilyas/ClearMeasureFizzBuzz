using FizzBuzz.Implementation;
using FizzBuzz.Implementation.Contracts;
using FizzBuzz.Implementation.Rules;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzUnitTests
{
    [TestFixture]
    public class FizzBuzzUnitTests
    {
        [Test]        
        public void NullRequestObject_ThrowsArgumentNullExceptionWhenExecuting()
        {
            FizzBuzzRequest req = null;
            var runner = new FizzBuzzRunner();
            Assert.Throws<ArgumentNullException>(() =>  runner.FizzBuzzRun(req).ToList());
        }

        [Test]
        public void LessThanOneUpperBound_ThrowsArgumentOutOfRangeExceptionWhenExecuting()
        {            
            FizzBuzzRequest req = new FizzBuzzRequest { UpperBound = -2, BuzzRule = new BuzzRuleDefault(), FizzRule = new FizzRuleDefault(), NoMatch = new NoMatchRuleDefault() };
            var runner = new FizzBuzzRunner();
            Assert.Throws<ArgumentOutOfRangeException>(() => runner.FizzBuzzRun(req).ToList());
        }

        [Test]
        public void AllNullRules_ThrowsArgumentNullExceptionWhenExecuting()
        {
            FizzBuzzRequest req = new FizzBuzzRequest { UpperBound = 100, BuzzRule = null, FizzRule = null, NoMatch = null };
            var runner = new FizzBuzzRunner();
            Assert.Throws<ArgumentNullException>(() => runner.FizzBuzzRun(req).ToList());
        }

        [Test]
        public void AnyNullRules_ThrowsArgumentNullExceptionWhenExecuting()
        {
            FizzBuzzRequest req = new FizzBuzzRequest { UpperBound = 100, BuzzRule = new BuzzRuleDefault(), FizzRule = null, NoMatch = null };
            var runner = new FizzBuzzRunner();
            Assert.Throws<ArgumentNullException>(() => runner.FizzBuzzRun(req).ToList());
        }

        [Test]
        public void ReturnsFizzBuzz_WhenDivisible_By_ThreeAndFive()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest fifteenUpperBound = new FizzBuzzRequest { UpperBound = 15, UseDefaultRules = true };
            FizzBuzzRequest thirtyUpperBound = new FizzBuzzRequest { UpperBound = 30, UseDefaultRules = true };
            FizzBuzzRequest fortyFiveUpperBound = new FizzBuzzRequest { UpperBound = 45, UseDefaultRules = true };

            var runner = new FizzBuzzRunner();
            var expectedFizzBuzz = "FizzBuzz";

            var actualRunnerFifteenResult = runner.FizzBuzzRun(fifteenUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerFifteenResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzResult.Result);


            var actualRunnerThirtyResult = runner.FizzBuzzRun(fifteenUpperBound).ToList();
            var actualFizzBuzzThirtyResult = actualRunnerThirtyResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzThirtyResult.Result);

            var actualRunnerFortyFiveResult = runner.FizzBuzzRun(fifteenUpperBound).ToList();
            var actualFizzBuzzFortyFiveResult = actualRunnerFortyFiveResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzFortyFiveResult.Result);
        }

        [Test]
        public void DoesNotReturnFizzBuzz_WhenDivisible_By_ThreeOnly()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest fifteenUpperBound = new FizzBuzzRequest { UpperBound = 6, UseDefaultRules = true };
            FizzBuzzRequest thirtyUpperBound = new FizzBuzzRequest { UpperBound = 2, UseDefaultRules = true };
            FizzBuzzRequest fortyFiveUpperBound = new FizzBuzzRequest { UpperBound = 7, UseDefaultRules = true };

            var runner = new FizzBuzzRunner();
            var expectedFizzBuzz = "FizzBuzz";

            var actualRunnerFifteenResult = runner.FizzBuzzRun(fifteenUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerFifteenResult.Last();
            StringAssert.AreNotEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzResult.Result);

            var actualRunnerThirtyResult = runner.FizzBuzzRun(thirtyUpperBound).ToList();
            var actualFizzBuzzThirtyResult = actualRunnerThirtyResult.Last();
            StringAssert.AreNotEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzThirtyResult.Result);

            var actualRunnerFortyFiveResult = runner.FizzBuzzRun(fortyFiveUpperBound).ToList();
            var actualFizzBuzzFortyFiveResult = actualRunnerFortyFiveResult.Last();
            StringAssert.AreNotEqualIgnoringCase(expectedFizzBuzz, actualFizzBuzzFortyFiveResult.Result);
        }

        [Test]
        public void ReturnsFizz_WhenDivisible_By_ThreeOnly()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest threeUpperBound = new FizzBuzzRequest { UpperBound = 3, UseDefaultRules = true };
            FizzBuzzRequest sixUpperBound = new FizzBuzzRequest { UpperBound = 6, UseDefaultRules = true };
            FizzBuzzRequest nineFiveUpperBound = new FizzBuzzRequest { UpperBound = 9, UseDefaultRules = true };

            var runner = new FizzBuzzRunner();
            var expectedFizz = "Fizz";

            var actualRunnerThreeResult = runner.FizzBuzzRun(threeUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerThreeResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzResult.Result);


            var actualRunnerSixResult = runner.FizzBuzzRun(sixUpperBound).ToList();
            var actualFizzBuzzSixResult = actualRunnerSixResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzSixResult.Result);

            var actualRunnerNineResult = runner.FizzBuzzRun(nineFiveUpperBound).ToList();
            var actualFizzNineFiveResult = actualRunnerNineResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzNineFiveResult.Result);
        }


        [Test]
        public void ReturnsBuzz_WhenDivisible_By_FiveOnly()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest fiveUpperBound = new FizzBuzzRequest { UpperBound = 5, UseDefaultRules = true };
            FizzBuzzRequest tenUpperBound = new FizzBuzzRequest { UpperBound = 10, UseDefaultRules = true };
            FizzBuzzRequest twentyFiveUpperBound = new FizzBuzzRequest { UpperBound = 20, UseDefaultRules = true };

            var runner = new FizzBuzzRunner();
            var expectedFizz = "Buzz";

            var actualRunnerFiveResult = runner.FizzBuzzRun(fiveUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerFiveResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzResult.Result);


            var actualRunnerTenResult = runner.FizzBuzzRun(tenUpperBound).ToList();
            var actualFizzBuzzTenResult = actualRunnerTenResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzTenResult.Result);

            var actualRunnerTwentyResult = runner.FizzBuzzRun(twentyFiveUpperBound).ToList();
            var actualFizzNineTwentyResult = actualRunnerTwentyResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzNineTwentyResult.Result);
        }

        [Test]
        public void ReturnsCustomWordForFizz_WhenDivisible_By_ThreeOnly()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest threeUpperBound = new FizzBuzzRequest { UpperBound = 3, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "Hello" }, BuzzRule = new BuzzRuleDefault(), NoMatch = new  NoMatchRuleDefault() };
            FizzBuzzRequest sixUpperBound = new FizzBuzzRequest { UpperBound = 6, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "Hello" }, BuzzRule = new BuzzRuleDefault(), NoMatch = new NoMatchRuleDefault() };
            FizzBuzzRequest nineFiveUpperBound = new FizzBuzzRequest { UpperBound = 9, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "Hello" }, BuzzRule = new BuzzRuleDefault(), NoMatch = new NoMatchRuleDefault() };

            var runner = new FizzBuzzRunner();
            var expectedFizzReplacementWord = "Hello";

            var actualRunnerThreeResult = runner.FizzBuzzRun(threeUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerThreeResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzReplacementWord, actualFizzBuzzResult.Result);


            var actualRunnerSixResult = runner.FizzBuzzRun(sixUpperBound).ToList();
            var actualFizzBuzzSixResult = actualRunnerSixResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzReplacementWord, actualFizzBuzzSixResult.Result);

            var actualRunnerNineResult = runner.FizzBuzzRun(nineFiveUpperBound).ToList();
            var actualFizzNineFiveResult = actualRunnerNineResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzReplacementWord, actualFizzNineFiveResult.Result);
        }


        [Test]
        public void ReturnsCustomWordForBuzz_WhenDivisible_By_FiveOnly()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest fiveUpperBound = new FizzBuzzRequest { UpperBound = 5, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new NoMatchRuleDefault(), FizzRule = new FizzRuleDefault() };
            FizzBuzzRequest tenUpperBound = new FizzBuzzRequest { UpperBound = 10, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new NoMatchRuleDefault(), FizzRule = new FizzRuleDefault() };
            FizzBuzzRequest twentyFiveUpperBound = new FizzBuzzRequest { UpperBound = 20, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new NoMatchRuleDefault(), FizzRule = new FizzRuleDefault() };

            var runner = new FizzBuzzRunner();
            var expectedFizz = "World";

            var actualRunnerFiveResult = runner.FizzBuzzRun(fiveUpperBound).ToList();
            var actualFizzBuzzResult = actualRunnerFiveResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzResult.Result);


            var actualRunnerTenResult = runner.FizzBuzzRun(tenUpperBound).ToList();
            var actualFizzBuzzTenResult = actualRunnerTenResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzBuzzTenResult.Result);

            var actualRunnerTwentyResult = runner.FizzBuzzRun(twentyFiveUpperBound).ToList();
            var actualFizzNineTwentyResult = actualRunnerTwentyResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizz, actualFizzNineTwentyResult.Result);
        }

        [Test]
        public void ReturnsCustomWordForFizzBuzz_WhenDivisible_By_ThreeAndFive()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest fifteenUpperBound = new FizzBuzzRequest { UpperBound = 15, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "My" } };
            FizzBuzzRequest thirtyUpperBound = new FizzBuzzRequest { UpperBound = 30, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "My" } };
            FizzBuzzRequest fortyFiveUpperBound = new FizzBuzzRequest { UpperBound = 45, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "My" } };

            var runner = new FizzBuzzRunner();
            var expectedFizzBuzzReplacement = "MyWorld";

            var actualRunnerFifteenResult = runner.FizzBuzzRun(fifteenUpperBound).ToList();
            var actualFizzBuzzFifteenResult = actualRunnerFifteenResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzzReplacement, actualFizzBuzzFifteenResult.Result);


            var actualRunnerThirtyResult = runner.FizzBuzzRun(thirtyUpperBound).ToList();
            var actualFizzBuzzThirtyResult = actualRunnerThirtyResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzzReplacement, actualFizzBuzzThirtyResult.Result);

            var actualRunnerFortyFiveResult = runner.FizzBuzzRun(fortyFiveUpperBound).ToList();
            var actualFizzFortyFiveResult = actualRunnerFortyFiveResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedFizzBuzzReplacement, actualFizzFortyFiveResult.Result);
        }

        [Test]
        public void WillRunSuccessfully_DoesNotThrowException_ForLargeIterations()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest largeUpperBoundRequest = new FizzBuzzRequest { UpperBound = Int32.MaxValue, BuzzRule = new Rule { DivisibleByWord = "World", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "My" } };
           
            var runner = new FizzBuzzRunner();            

            Assert.DoesNotThrow(() => 
            {
                foreach (var currentItem in runner.FizzBuzzRun(largeUpperBoundRequest))
                {
                    // do nothing
                }
            });
        }


        [Test]
        public void ReturnsCustomWordForNoMatch_WhenNotDivisible_By_Three_Or_Five_Or_ThreeAndFive()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest eightUpperBound = new FizzBuzzRequest { UpperBound = 8, BuzzRule = new Rule { DivisibleByWord = "Buzz", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "Fizz" } };
           
            var runner = new FizzBuzzRunner();
            var expectedNoMatchReplacement = "Nothing";

            var actualRunnerResult = runner.FizzBuzzRun(eightUpperBound).ToList();
            var actualResult = actualRunnerResult.Last();
            StringAssert.AreEqualIgnoringCase(expectedNoMatchReplacement, actualResult.Result);
        }

        [Test]
        public void Returns_Fizz_Buzz_FizzBuzz_And_NoHit()
        {
            // given the way the solution is, let us only execute up until the point of where we expect the end result to be
            // grab the last result and compare with the actual execution for each of the points for FizzBuzz.

            FizzBuzzRequest twentyUpperBound = new FizzBuzzRequest { UpperBound = 20, BuzzRule = new Rule { DivisibleByWord = "Buzz", DivisibleBy = 5 }, NoMatch = new Rule { DivisibleByWord = "Nothing" }, FizzRule = new Rule { DivisibleBy = 3, DivisibleByWord = "Fizz" } };

            var runner = new FizzBuzzRunner();
            var expectedNoMatchReplacement = "Nothing";
            var fizz = "Fizz";
            var buzz = "Buzz";

            var actualRunnerResult = runner.FizzBuzzRun(twentyUpperBound).ToList();
            var buzzResult = actualRunnerResult.Last();
            var noMatchResult = actualRunnerResult.Skip(18).Take(1).First();
            var fizzResult = actualRunnerResult.Skip(17).Take(1).First();
            var fizzBuzzResult = actualRunnerResult.Skip(14).Take(1).First();

            StringAssert.AreEqualIgnoringCase(expectedNoMatchReplacement, noMatchResult.Result);
            StringAssert.AreEqualIgnoringCase(fizz, fizzResult.Result);
            StringAssert.AreEqualIgnoringCase(buzz, buzzResult.Result);
            StringAssert.AreEqualIgnoringCase($"{fizz}{buzz}", fizzBuzzResult.Result);
        }
    }
}
