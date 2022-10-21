using LocalInversionOfControl.Example1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalInversionOfControl.Example2
{
    public class MySecondClass
    {
        public void Proccess(Person person)
        {
            //if (person.Names.Count == 0) { }
            //if (!person.Names.Any()) { }
            if (person.HasNo(p => p.Names)) { }
            if(person.HasSome(p => p.Names)) { }

            if(person.HasSome(p => p.Names).And.HasNo(p => p.Children)) { }
        }
    }
}
