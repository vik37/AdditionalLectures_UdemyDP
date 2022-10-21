using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeyondTheElviseOperator_UdemyDPAdditional_ConsoleApp
{
    public static class Maybe
    {
        public static TResult With<TInput, TResult>(this TInput obj,
            Func<TInput,TResult> evaluator)
            where TResult : class
            where TInput : class
        {
            if(obj == null) 
                return null;
            else return evaluator(obj);
        }
        public static TInput If<TInput>(this TInput obj,
            Func<TInput,bool> evaluator)
            where TInput : class
        {
            if(obj == null) return null;
            return evaluator(obj) ? obj : null; 
        }
        public static TInput Do<TInput>(this TInput obj, Action<TInput> action)
            where TInput : class
        {
            if(obj == null) return null;
            action(obj);
            return obj;
        }
        public static TResult Return<TInput, TResult>(this TInput obj,
            Func<TInput, TResult> evaluator, TResult failuer)
            where TInput : class
        {
            if (obj == null) return failuer;
            else return evaluator(obj);
        }
    }
}
