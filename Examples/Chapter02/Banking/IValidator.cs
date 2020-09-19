using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter02.Banking
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}
