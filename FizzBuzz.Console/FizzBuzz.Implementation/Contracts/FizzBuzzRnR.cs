using FizzBuzz.Implementation.Rules;

namespace FizzBuzz.Implementation.Contracts
{
    public sealed class FizzBuzzRequest
    {
        /// <summary>
        /// Gets or Sets the upper bound (max value) to increment to.
        /// </summary>
        public int UpperBound { get; set; } = 1;

        /// <summary>
        /// Gets or Sets the Fizz Rule
        /// </summary>
        public Rule FizzRule { get; set; }

        /// <summary>
        /// Gets or Sets the Buzz Rule
        /// </summary>
        public Rule BuzzRule { get; set; }

        /// <summary>
        /// Gets or Sets the no match Rule
        /// </summary>
        public Rule NoMatch { get; set; }

        /// <summary>
        /// Gets or sets the option to use system defaults, which will always be used when set
        /// </summary>
        public bool UseDefaultRules { get; set; }
    }

    public sealed class FizzBuzzResponse : BaseResponse
    {
        public string Result { get; set; }
    }
}
