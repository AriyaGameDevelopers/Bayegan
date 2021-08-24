using System;

namespace Bayegan.Exceptions
{
    public class TypeNotSupportedException: Exception
    {
        public TypeNotSupportedException(TypeCode type)
            :base($"'Nahid' not supported '{type}' type."){}
    }
}