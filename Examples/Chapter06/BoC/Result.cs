using Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter06.BoC
{
    public class ResultDto<T>
    {
        public bool Succeeded { get; }
        public bool Failed => !Succeeded;

        public T Data { get; }
        public Error Error { get; }

        public ResultDto(T data) { Succeeded = true; Data = data; }
        public ResultDto(Error error) { Error = error; }
    }

    public static class ResultExt
    {
        public static ResultDto<T> ToResult<T>(this Either<Error, T> either) =>
            either.Match(
                left: error => new ResultDto<T>(error),
                right: data => new ResultDto<T>(data));
    }
}
