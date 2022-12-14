using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSAndEvendSoursing_UdemyDPAdditional_ConsoleApp
{
    public class AgeChangeEvent : Event
    {
        public Person Target;
        public int OldValue, NewValue;
        public AgeChangeEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }
        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }
}
