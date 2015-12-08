namespace Problem_03.RepeatingStrings
{
    using System;
    using System.Text.RegularExpressions;

    public class StringSearcherService : IStringSearcherService
    {
        public int GetCount(string a, string b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("One or more paprams is null");
            }

            var repetitionCount = Regex.Matches(a, b).Count;

            return repetitionCount;
        }
    }
}
