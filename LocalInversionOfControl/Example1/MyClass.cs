using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace LocalInversionOfControl.Example1
{
    public class MyClass
    {
        public void AddingNumbers()
        {
            var list = new List<int>();
            list.Add(24); // list is in control
            var list2 = new List<int>();
            //24.AddTo(list).AddTo(list2); // value is in control
            24.AddTo(list,list2); 
        }
        public void ProccessCommand(string opcode)
        {
            //if (opcode == "AND" || opcode == "OR" || opcode == "XOR") { }
            //if (new[] { "AND", "OR", "HOR" }.Contains(opcode)) { }
            //if("AND OR XOR".Split(' ').Contains(opcode)) { }

            if (opcode.IsOneOf("AND", "OR", "XOR")) { }
        }
    }
}
