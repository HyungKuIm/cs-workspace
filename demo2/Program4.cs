using System;
using System.Dynamic;
using System.Windows.Forms;

namespace demo2
{
    class SimpleDynamicExample : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            System.Console.WriteLine("Invoked: {0}({1})", binder.Name, string.Join(", ", args));
            result = null;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "Fetched: " + binder.Name;
            return true;
        }
    }

    class Program4
    {
        static void Main(string[] args)
        {
            dynamic example = new SimpleDynamicExample();
            example.CallSomeMethod("x", 10);
            System.Console.WriteLine(example.SomeProperty);                
        }
    }
}