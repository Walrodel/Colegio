using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Core.Exceptions
{
    public class BusinessExeption : Exception
    {
        public BusinessExeption()
        {

        }

        public BusinessExeption(string message) : base(message)
        {

        }
    }
}
