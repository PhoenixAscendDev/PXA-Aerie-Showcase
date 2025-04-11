using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    internal static class LexiconUtility
    {
        public static Dictionary<string, string> MergeWithRequiredDefaults(
            Dictionary<string, string> incoming,
            Dictionary<string, string> required)
        {
            var merged = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Add incoming values (normalize to uppercase keys)
            foreach (var kv in incoming)
                merged[kv.Key.ToUpperInvariant()] = kv.Value;

            // Backfill required entries if missing
            foreach (var kv in required)
            {
                if (!merged.ContainsKey(kv.Key))
                    merged[kv.Key] = kv.Value;
            }

            return merged;
        }
    }
}