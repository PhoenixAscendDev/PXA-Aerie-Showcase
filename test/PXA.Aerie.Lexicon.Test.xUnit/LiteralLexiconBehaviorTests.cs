using Xunit;
using PXA.Aerie.Lexicon;
using System.Collections.Generic;

namespace PXA.Aerie.Lexicon.Test.xUnit
{
    public class LiteralLexiconBehaviorTests
    {
        [Fact]
        public void Should_Return_Required_Default_When_Key_Not_Provided()
        {
            // Act: pass no overrides at all
            var lexicon = new DefaultLiteralLexicon();

            // Assert: required keys are populated
            var result = lexicon.Enabled;

            // We don’t assert on literal values — just that something was returned
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public void Override_Key_Should_Be_Reported_As_Found()
        {
            var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
            {
                ["ENABLED"] = "custom"
            });

            Assert.True(lex["ENABLED"].Found);
        }

        [Fact]
        public void Override_Key_Should_Preserve_Key_Name()
        {
            var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
            {
                ["ENABLED"] = "custom"
            });

            Assert.Equal("ENABLED", lex["ENABLED"].Key);
        }

        [Fact]
        public void Override_Key_Should_Return_Overridden_Value()
        {
            var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
            {
                ["ENABLED"] = "custom"
            });

            Assert.Equal("custom", lex["ENABLED"].Value);
        }


        [Fact]
        public void Should_Return_Unfound_Entry_When_Key_Is_Missing()
        {
            var lexicon = new DefaultLiteralLexicon();

            LexiconEntry entry = lexicon["DOES_NOT_EXIST"];

            Assert.False(entry.Found);
            Assert.Equal("DOES_NOT_EXIST", entry.Key);
            Assert.Null(entry.Value);
        }


        [Fact]
        public void Should_Return_Custom_Value_When_Key_Provided()
        {
            var input = new Dictionary<string, string>
            {
                ["CUSTOM"] = "abc123"
            };

            var lexicon = new DefaultLiteralLexicon(input);

            var result = lexicon["CUSTOM"];

            Assert.Equal("abc123", result);
        }


        public class LexiconCustomKeyTests
        {
            [Theory]
            [InlineData("email")]
            [InlineData("EMAIL")]
            [InlineData("Email")]
            [InlineData("email.pattern")]
            [InlineData("USER_ID")]
            [InlineData("x-header")]
            [InlineData("  spaced  ")]
            [InlineData("")]
            public void CustomKey_Should_Return_Exact_Stored_Value(string inputKey)
            {
                var value = $"value-for-{inputKey}";

                var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
                {
                    [inputKey] = value
                });

                var result = lex[inputKey];

                Assert.Equal(value, result.Value);
            }
        }

        [Fact]
        public void CaseVariant_lowercase_Should_Return_Expected_Value()
        {
            var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
            {
                ["email"] = "first",
                ["EMAIL"] = "second"
            });

            var result = lex["email"];

            Assert.Equal("second", result.Value);
        }

        [Fact]
        public void CaseVariant_allcaps_Should_Return_Expected_Value()
        {
            var lex = new DefaultLiteralLexicon(new Dictionary<string, string>
            {
                ["email"] = "first",
                ["EMAIL"] = "second"
            });

            var result = lex["EMAIL"];

            Assert.Equal("second", result.Value);
        }










    }
}
