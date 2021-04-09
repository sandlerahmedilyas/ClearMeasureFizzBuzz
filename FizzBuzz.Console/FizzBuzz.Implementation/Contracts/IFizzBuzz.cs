using System.Collections.Generic;

namespace FizzBuzz.Implementation.Contracts
{
    public interface IFizzBuzz
    {
        IEnumerable<FizzBuzzResponse> FizzBuzzRun(FizzBuzzRequest request);
    }
}
