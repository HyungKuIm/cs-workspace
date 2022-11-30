using System;
using System.Windows.Forms;

namespace demo2
{
    class Program
    {
        static void Add(dynamic d)
        {
            MessageBox.Show((d + d).ToString());
            //System.Console.WriteLine(d + d);
        }
        static void main(string[] args)
        {
            Add("Text");
            Add(10);
            Add(TimeSpan.FromMinutes(45));
            // System.Console.WriteLine("Hello World!");
        }
    }
}