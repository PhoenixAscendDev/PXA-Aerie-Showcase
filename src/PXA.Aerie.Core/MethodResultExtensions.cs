using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXA.Aerie.Core
{
    public static class MethodResultExtensions
    {
        public static T UnwrapOrThrow<T>(this MethodResult<T> result)
        {
            if (!result.IsSuccess)
                throw result.Exception ?? new InvalidOperationException("MethodResult was not successful.");
            return result.Result!;
        }

        public static bool TryGetValue<T>(this MethodResult<T> result, out T value)
        {
            if (result.IsSuccess && result.Result is not null)
            {
                value = result.Result;
                return true;
            }

            value = default!;
            return false;
        }
    }
}

