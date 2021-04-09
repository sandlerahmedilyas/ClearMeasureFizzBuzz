namespace FizzBuzz.Implementation.Rules
{
    /// <summary>
    /// Base class that allow implementors to create their own rule using this as the backing
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Gets or Sets the value as a divisible by
        /// </summary>
        public virtual int DivisibleBy { get; set; }

        /// <summary>
        /// Gets or Sets the display word when the number is divisible by
        /// </summary>
        public virtual string DivisibleByWord { get; set; }
    }
}
