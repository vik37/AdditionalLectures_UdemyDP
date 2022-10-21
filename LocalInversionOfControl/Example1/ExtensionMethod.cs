using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalInversionOfControl.Example1
{
    public static class ExtensionMethod
    {
        public static T AddTo<T>(this T self, params ICollection<T>[] colls)
        {
            foreach (var coll in colls)
                coll.Add(self);
            return self;
        }
        public static bool IsOneOf<T>(this T self, params T[] values)
        {
            return values.Contains(self);
        }
    }
}
