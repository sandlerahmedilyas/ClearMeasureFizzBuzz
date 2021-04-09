using System;

namespace FizzBuzz.Implementation.Rules
{
    public sealed class NoMatchRuleDefault : Rule
    {

        public override int DivisibleBy
        {
            get { return 0; }
            set { throw new NotSupportedException(); }
        }

        public override string DivisibleByWord
        {
            get; set;
        }
    }
}
