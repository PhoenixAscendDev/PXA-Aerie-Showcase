using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    public interface ILiteralLexicon
    {
        LexiconEntry Unknown { get; }
        LexiconEntry Enabled { get; }
        LexiconEntry Disabled { get; }
        LexiconEntry Optional { get; }
        // etc.

        // Flexible extension point
        LexiconEntry this[string key] { get; }
    }
}
