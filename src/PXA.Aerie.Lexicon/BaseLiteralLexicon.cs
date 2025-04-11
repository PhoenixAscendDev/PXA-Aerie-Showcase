using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{
    public abstract class BaseLiteralLexicon : BaseLexicon, ILiteralLexicon
    {



        protected BaseLiteralLexicon() : base()
        {

        }

        protected BaseLiteralLexicon(Dictionary<string, string> incoming) : base(incoming)
        {
        }

       

        public virtual LexiconEntry Unknown => _values["UNKNOWN"];
        public virtual LexiconEntry Enabled => _values["ENABLED"];
        public virtual LexiconEntry Disabled => _values["DISABLED"];
        public virtual LexiconEntry Optional => _values["OPTIONAL"];

        protected override Dictionary<string, string> GetRequiredDefaults() =>  new()
        {
            ["UNKNOWN"] = "Unknown",
            ["ENABLED"] = "Enabled",
            ["DISABLED"] = "Disabled",
            ["OPTIONAL"] = "Optional"
        };


    }
}
