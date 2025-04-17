using System;
using Xunit;
using PXA.Aerie.Core;

namespace PXA.Aerie.Core.Tests
{
    public class MethodResultTests
    {
        [Fact]
        public void Success_ShouldCreateResult_WithValue()
        {
            var result = MethodResult<int>.Success(42);

            Assert.True(result.IsSuccess);
            Assert.Equal(42, result.Result);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void Failure_WithString_ShouldCreateFailure_WithException()
        {
            var result = MethodResult<int>.Failure("Something failed");

            Assert.False(result.IsSuccess);
            Assert.Equal("Something failed", result.ErrorMessage);
            Assert.NotNull(result.Exception);
        }

        [Fact]
        public void Failure_WithException_ShouldPreserveException()
        {
            var ex = new InvalidOperationException("fail");

            var result = MethodResult<int>.Failure(ex);

            Assert.False(result.IsSuccess);
            Assert.Equal("fail", result.ErrorMessage);
            Assert.Same(ex, result.Exception);
        }

        [Fact]
        public void UnwrapOrDefault_ShouldReturnValue_IfSuccess()
        {
            var result = MethodResult<string>.Success("Aerie");

            var value = result.UnwrapOrDefault("Fallback");

            Assert.Equal("Aerie", value);
        }

        [Fact]
        public void UnwrapOrDefault_ShouldReturnFallback_IfFailure()
        {
            var result = MethodResult<string>.Failure("No value");

            var value = result.UnwrapOrDefault("Fallback");

            Assert.Equal("Fallback", value);
        }

        [Fact]
        public void ImplicitCastToT_ShouldReturnValue_IfSuccess()
        {
            MethodResult<string> result = MethodResult<string>.Success("Phoenix");

            string value = result;

            Assert.Equal("Phoenix", value);
        }

        [Fact]
        public void ImplicitCastToT_ShouldThrow_IfFailure()
        {
            MethodResult<string> result = MethodResult<string>.Failure("error");

            var ex = Assert.Throws<Exception>(() =>
            {
                string value = result;
            });

            Assert.Equal("error", ex.Message);
        }

        [Fact]
        public void ImplicitCastToBool_ShouldMatchIsSuccess()
        {
            var good = MethodResult<int>.Success(1);
            var bad = MethodResult<int>.Failure("bad");

            Assert.True(good);
            Assert.False(bad);
        }

        [Fact]
        public void ImplicitCastToException_ShouldReturnException()
        {
            var ex = new ApplicationException("bad");
            var result = MethodResult<string>.Failure(ex);

            Exception? casted = result;

            Assert.Same(ex, casted);
        }
    }
}

