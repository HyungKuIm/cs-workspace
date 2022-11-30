using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Forms;

namespace demo2
{
    class Program3
    {
        static void main(string[] args)
        {
           dynamic expando = new ExpandoObject();
           expando.SomeData = "Some data";
           Action<string> action = input => System.Console.WriteLine("The input was {0}", input);
           expando.FakeMethod = action;

           System.Console.WriteLine(expando.SomeData);
           expando.FakeMethod("hello");

           IDictionary<string, object> dictionary = expando;
           System.Console.WriteLine("Keys: {0}", string.Join(", ", dictionary.Keys));

           dictionary["OtherData"] = "other";
           System.Console.WriteLine(expando.OtherData);
        }
    }
}