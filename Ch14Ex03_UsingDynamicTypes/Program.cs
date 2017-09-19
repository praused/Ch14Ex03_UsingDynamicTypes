using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;//this namespace contains RuntimeBinderException

namespace Ch14Ex03_UsingDynamicTypes
{

    class myClass1
    {
        public int Add(dynamic var1, dynamic var2)//note that dynamic can be used for method parameters
        {
            return var1 + var2;
        }
    }

    class myClass2
    {
    }

    class Program
    {
        static int callCount = 0;

        static dynamic GetValue()//note that dynamic can be used as a return type for a method
        {
            if (callCount++ == 0)
            {
                return new myClass1();
            }
            return new myClass2();
        }

        static void Main(string[] args)
        {
            try
            {
                dynamic firstResult = GetValue();
                dynamic secondResult = GetValue();
                Console.WriteLine($"The firstResult is {firstResult.ToString()}");
                Console.WriteLine($"The secondResult is {secondResult.ToString()}");
                Console.WriteLine($"FirstResult call: {firstResult.Add(2, 3)}");
                Console.WriteLine($"secondResult call: {secondResult.Add(2, 3)}");//throws an exception, as Add() does not exist on myClass2
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
