using System;

namespace TidyFiller
{
    public class ConflictingCurrencyException : Exception
    {
        public ConflictingCurrencyException(string message)
            : base(message) { }
    }
}