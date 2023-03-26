using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CSharp.Tools.Exception
{
    internal class FutureBirthDateException : ArgumentOutOfRangeException
    {
        public FutureBirthDateException(DateTime message) : base("FutureBirthDateException") { }
    }
}
