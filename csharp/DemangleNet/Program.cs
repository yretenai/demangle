using System;
using Demangle;

namespace DemangleNet
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(Demangler.Demangle(arg) ?? arg);
            }
        }
    }
}
