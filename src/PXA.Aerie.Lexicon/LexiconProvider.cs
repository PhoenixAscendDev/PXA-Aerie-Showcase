using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Lexicon
{

    public static class LexiconProvider
    {
        public static ILiteralLexicon Literals { get; private set; } = new DefaultLiteralLexicon();
       // public static IExceptionMessageLexicon ExceptionMessages { get; private set; } = new DefaultExceptionMessageLexicon();

       // public static IRegExLexicon RegExpressions { get; private set; } = new DefaultRegExLexicon();
        public static void UseLiteralLexicon(ILiteralLexicon customLexicon)
        {
            Literals = customLexicon ?? new DefaultLiteralLexicon();
        }
        //public static void UseRegExLexicon(IRegExLexicon customLexicon)
        //{
        //    RegExpressions = customLexicon ?? new DefaultRegExLexicon();
        //}
        //public static void UseExceptionMessagesLexicon(IExceptionMessageLexicon customLexicon)
        //{
        //    ExceptionMessages = customLexicon ?? new DefaultExceptionMessageLexicon();
        //}
    }
}
