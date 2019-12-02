using ClassLibraryVbNet;
using System;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass tc = new TestClass();
            string cad = "";
            tc.prueba(ref cad);
            Console.WriteLine(cad);
        }
    }
}
