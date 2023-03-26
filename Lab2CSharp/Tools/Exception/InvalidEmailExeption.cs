using System;

namespace Lab2CSharp.Tools.Exception
{
    internal class InvalidEmailExeption : ArgumentException
    {
         public InvalidEmailExeption(string message) : base("InvalidEmailExeption") { }
    }
}
