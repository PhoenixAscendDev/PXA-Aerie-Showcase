using System;
using Xunit;
using PXA.Aerie.Core;

namespace PXA.Aerie.Core.Tests
{
    public class MethodResultGenericTypeTests
    {
        public class CustomPayload
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        public void Should_Handle_Int_Type(int input)
        {
            var result = MethodResult<int>.Success(input);
            Assert.True(result.IsSuccess);
            Assert.Equal(input, result.Result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Should_Handle_Bool_Type(bool flag)
        {
            var result = MethodResult<bool>.Success(flag);
            Assert.True(result.IsSuccess);
            Assert.Equal(flag, result.Result);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Handle_String_Type(string input)
        {
            var result = MethodResult<string>.Success(input);
            Assert.True(result.IsSuccess);
            Assert.Equal(input, result.Result);
        }

        [Fact]
        public void Should_Handle_DateTime_Type()
        {
            var now = DateTime.UtcNow;
            var result = MethodResult<DateTime>.Success(now);
            Assert.True(result.IsSuccess);
            Assert.Equal(now, result.Result);
        }

        [Fact]
        public void Should_Handle_Object_Type()
        {
            var obj = new object();
            var result = MethodResult<object>.Success(obj);
            Assert.True(result.IsSuccess);
            Assert.Equal(obj, result.Result);
        }

        [Fact]
        public void Should_Handle_Custom_Class_Type()
        {
            var payload = new CustomPayload { Id = 1, Name = "Phoenix" };
            var result = MethodResult<CustomPayload>.Success(payload);
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Result.Id);
            Assert.Equal("Phoenix", result.Result.Name);
        }

        [Fact]
        public void Should_Return_Default_When_Custom_Type_Fails()
        {
            var result = MethodResult<CustomPayload>.Failure("fail");

            Assert.False(result.IsSuccess);
            Assert.Null(result.Result);
        }
    }
}
