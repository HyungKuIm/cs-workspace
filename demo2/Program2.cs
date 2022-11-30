using System;
using System.Windows.Forms;

namespace demo2
{
    class Program2
    {
        static void SampleMethod(int value)
        {
            Console.WriteLine("Method with int parameter");
        }

        static void SampleMethod(decimal value)
        {
            Console.WriteLine("Method with decimal parameter");
        }

        static void SampleMethod(object value)
        {
            Console.WriteLine("Method with object parameter");
        }

        static void CallMethod(dynamic d)
        {
            SampleMethod(d);
        }

        static void main(string[] args)
        {
            //System.Console.WriteLine("Hello World! 2222");
            // System.Console.WriteLine(10);
            // System.Console.WriteLine(10.5m);
            // System.Console.WriteLine(10L);
            // System.Console.WriteLine("text");
            CallMethod(10);
            CallMethod(10.5m);
            CallMethod(10L);
            CallMethod("text");
        }
    }
}