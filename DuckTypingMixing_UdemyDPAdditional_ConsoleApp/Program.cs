using System;
using System.Collections;
using System.Collections.Generic;

namespace DuckTypingMixing_UdemyDPAdditional_ConsoleApp
{
    #region Duck Typing
    // Can not Foo : IDisposable
    //ref struct Foo
    //{
    //    public void Dispose()
    //    {
    //        Console.WriteLine("Disposing Foo");
    //    }
    //}
    #endregion

    #region Mixin 
    #region 1st Example
    //interface IMyDisposable<T> : IDisposable
    //{
    //    void IDisposable.Dispose()
    //    {
    //        Console.WriteLine($"Disposing {typeof(T).Name}");
    //    }
    //}
    //public class MyClass : IMyDisposable<MyClass>
    //{ }
    #endregion
    #region 2nd Example
    interface IScalar<T> : IEnumerable<T>
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return (T)this;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class MyClass : IScalar<MyClass>
    {
        public override string ToString()
        {
            return "MyClass";
        }
    }
    #endregion
    #endregion
    class Program
    {        
        static void Main(string[] args)
        {

            // duck typing - when you can call a method from a particular class, even if that method isn't part of some interface,
            //               it just expects the name of the method.
            //using var foo = new Foo();

            // mixins  are ways of adding additional functionality to a class.
            // 1
            // using var mc = new MyClass();
            // 2
            var mc = new MyClass();
            foreach (var item in mc)
                Console.WriteLine(mc);

        }
    }
}
