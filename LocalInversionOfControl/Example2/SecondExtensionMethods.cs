using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalInversionOfControl.Example2
{
    public static class SecondExtensionMethods
    {
        public struct BoolMarker<T>
        {
            public bool Result;
            public T Self;
            public enum Operation
            {
                None, And, Or
            }
            internal Operation PendingOp;
            internal BoolMarker(bool result, T self, Operation pendingOp)
            {
                Result = result;
                Self = self;
                PendingOp = pendingOp;
            }
            public BoolMarker(bool result, T self)
                : this(result, self, Operation.None)
            { }
            public BoolMarker<T> And => new BoolMarker<T>(Result, Self, Operation.And);
            public static implicit operator bool(BoolMarker<T> marker)
            {
                return marker.Result;
            }
        }
        public static BoolMarker<TSubject> HasNo<TSubject, T>(this TSubject self,
                                                Func<TSubject, IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(!props(self).Any(),self);
        }
        public static BoolMarker<TSubject> HasSome<TSubject, T>(this TSubject self,
                                                Func<TSubject, IEnumerable<T>> props)
        {
            return new BoolMarker<TSubject>(props(self).Any(), self);
        }
        public static BoolMarker<T> HasNo<T, U>(this BoolMarker<T> marker,
                                                    Func<T, IEnumerable<U>> props)
        {
            if (marker.PendingOp == BoolMarker<T>.Operation.And && !marker.Result)
                return marker;
            return new BoolMarker<T>(!props(marker.Self).Any(), marker.Self);
        }
        //public static bool HasNo<TSubject, T>(this TSubject self, 
        //                                        Func<TSubject, IEnumerable<T>> props)
        //{
        //    return !props(self).Any();
        //}
        //public static bool HasSome<TSubject, T>(this TSubject self,
        //                                        Func<TSubject, IEnumerable<T>> props)
        //{
        //    return props(self).Any();
        //}
    }
}
