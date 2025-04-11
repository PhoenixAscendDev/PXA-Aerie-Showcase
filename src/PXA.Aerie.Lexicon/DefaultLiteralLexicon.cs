using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    public class DefaultLiteralLexicon : BaseLiteralLexicon, ILiteralLexicon
    {
        public DefaultLiteralLexicon(Dictionary<string, string> values) : base(values)
        {

        }
        public DefaultLiteralLexicon(): base()
        {

        }

    }
}
