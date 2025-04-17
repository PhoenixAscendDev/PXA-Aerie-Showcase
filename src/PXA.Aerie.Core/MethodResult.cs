using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Core
{
    public class MethodResult
    {
        public bool IsSuccess => Exception == null;

        public Exception? Exception { get; init; }
        public string? ErrorMessage { get; init; }
        public string? FailureCode { get; init; }
        public List<string> InfoMessages { get; init; } = new();

        public MethodResult ThrowIfFailed()
        {
            if (!IsSuccess && Exception is not null)
                throw Exception;
            return this;
        }

        public static MethodResult Success(string message) =>
            new MethodResult { InfoMessages = new List<string> { message } };


        public static MethodResult Failure(Exception error) =>
            new MethodResult { Exception = error, ErrorMessage = error.Message };
        public static MethodResult Failure(string error) =>
            new MethodResult { Exception = new Exception(error), ErrorMessage = error };

        public static implicit operator bool(MethodResult result) => result.IsSuccess;

        public static implicit operator Exception?(MethodResult result) => result.Exception;
    }

    public class MethodResult<T> : MethodResult
    {

        public MethodResult()
        { }
        public MethodResult(T? result)
        {
            Result = result;
        }

        public T? Result { get; init; }

        public T UnwrapOrDefault(T fallback) => IsSuccess ? Result! : fallback;

        public static MethodResult<T> Success(T value) =>
        new MethodResult<T> {  Result = value };


        public new static MethodResult<T> Failure(string error) =>
            new MethodResult<T> { Exception = new Exception(error), ErrorMessage = error };

        public new static MethodResult<T> Failure(Exception error) =>
           new MethodResult<T> { Exception = error, ErrorMessage = error.Message };

        public  static MethodResult<T> Failure<T>(string error) =>
            new MethodResult<T> { Exception = new Exception(error), ErrorMessage = error };

        public static MethodResult<T> Failure<T>(Exception error) =>
           new MethodResult<T> { Exception = error, ErrorMessage = error.Message };

        
        public static implicit operator T(MethodResult<T> result)
        {
            if (!result.IsSuccess)
                throw result.Exception ?? new InvalidOperationException("MethodResult was not successful.");
            return result.Result!;
        }

        public static implicit operator bool(MethodResult<T> result) => result.IsSuccess;

        public static implicit operator Exception?(MethodResult<T> result) => result.Exception;
    }
}
