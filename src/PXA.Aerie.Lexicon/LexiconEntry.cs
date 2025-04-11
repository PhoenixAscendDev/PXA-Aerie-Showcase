using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    public class LexiconEntry
    {
        public string Key { get; init; }
        public bool Found { get; init; }
        public string? Value { get; init; }

        public static LexiconEntry FoundEntry(string key, string value) => new()
        {
            Key = key,
            Found = true,
            Value = value
        };

        public static LexiconEntry Missing(string key) => new()
        {
            Key = key,
            Found = false,
            Value = null
        };

        // ✅ Allows: string s = lexicon["FOO"];
        public static implicit operator string?(LexiconEntry entry)
        {
            return entry?.Value;
        }

        // ✅ Allows: LexiconEntry entry = "hello";
        public static implicit operator LexiconEntry(string value)
        {
            return new LexiconEntry
            {
                Value = value,
                Found = true
            };
        }
    }

}
