using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CSharp.Tools.Exception
{
    internal class OldBirthDateException : ArgumentOutOfRangeException
    {
        public OldBirthDateException(DateTime message) : base("OldBirthDateException") { }
    }
}
