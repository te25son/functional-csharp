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
}
