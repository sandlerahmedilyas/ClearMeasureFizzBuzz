using System;

namespace FizzBuzz.Implementation.Rules
{
    public sealed class FizzRuleDefault : Rule
    {
        private const int FizzValue = 3;

        public override int DivisibleBy
        {
            get { return FizzValue; }
            set { throw new NotSupportedException(); }
        }

        public override string DivisibleByWord
        {
            get { return StringConstants.FizzText; }
            set { throw new NotSupportedException(); }
        }
    }
}
