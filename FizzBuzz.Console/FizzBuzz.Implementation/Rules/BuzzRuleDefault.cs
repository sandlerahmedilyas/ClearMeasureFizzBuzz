using System;

namespace FizzBuzz.Implementation.Rules
{
    public sealed class BuzzRuleDefault : Rule
    {
        private const int BuzzValue = 5;
        public override int DivisibleBy
        {
            get { return BuzzValue; }
            set { throw new NotSupportedException(); }
        }

        public override string DivisibleByWord
        {
            get { return StringConstants.BuzzText; }
            set { throw new NotSupportedException(); }
        }
    }
}
