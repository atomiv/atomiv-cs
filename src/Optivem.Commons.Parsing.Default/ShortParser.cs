﻿namespace Optivem.Commons.Parsing.Default
{
    public class ShortParser : BaseParser<short?>
    {
        protected override short? ParseInner(string value)
        {
            return short.Parse(value);
        }
    }
}
