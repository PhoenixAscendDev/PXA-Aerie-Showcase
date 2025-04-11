
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    public abstract class BaseLexicon
    {
        protected readonly Dictionary<string, string> _values;

        protected BaseLexicon()
        {
            _values = LexiconUtility.MergeWithRequiredDefaults(
                new Dictionary<string, string>(),
                GetRequiredDefaults()
            );
        }

        protected BaseLexicon(Dictionary<string, string> incoming)
        {
            _values = LexiconUtility.MergeWithRequiredDefaults(
                incoming,
                GetRequiredDefaults()
            );
        }

        protected abstract Dictionary<string, string> GetRequiredDefaults();

        public virtual LexiconEntry this[string key]
        {
            get
            {
                return _values.TryGetValue(key.ToUpperInvariant(), out var val)
                    ? LexiconEntry.FoundEntry(key, val)
                    : LexiconEntry.Missing(key);
            }
        }
    }
}

