using System;
using Xunit;
using PXA.Aerie.Core;

namespace PXA.Aerie.Core.Tests
{
    public class MethodResultExtensionsTests
    {
        [Fact]
        public void UnwrapOrThrow_ShouldReturnValue_IfSuccessful()
        {
            var result = MethodResult<string>.Success("Feather");

            var value = result.UnwrapOrThrow();

            Assert.Equal("Feather", value);
        }

        [Fact]
        public void UnwrapOrThrow_ShouldThrowException_IfFailure()
        {
            var result = MethodResult<string>.Failure("error");

            var ex = Assert.Throws<Exception>(() => result.UnwrapOrThrow());
            Assert.Equal("error", ex.Message);
        }

        [Fact]
        public void TryGetValue_ShouldReturnTrueAndOutput_WhenSuccessful()
        {
            var result = MethodResult<int>.Success(99);

            var success = result.TryGetValue(out int value);

            Assert.True(success);
            Assert.Equal(99, value);
        }

        [Fact]
        public void TryGetValue_ShouldReturnFalseAndDefault_WhenFailure()
        {
            var result = MethodResult<int>.Failure("fail");

            var success = result.TryGetValue(out int value);

            Assert.False(success);
            Assert.Equal(default, value);
        }

        [Fact]
        public void TryGetValue_ShouldReturnFalse_WhenSuccessButNullResult()
        {
            var result = MethodResult<string>.Success(null);

            var success = result.TryGetValue(out var value);

            Assert.False(success);
            Assert.Null(value);
        }
    }
}
