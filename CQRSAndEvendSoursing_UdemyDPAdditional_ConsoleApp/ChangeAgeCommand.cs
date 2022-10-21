using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSAndEvendSoursing_UdemyDPAdditional_ConsoleApp
{
    public class ChangeAgeCommand : Command
    {
        public Person Target;
        public int Age;
        public ChangeAgeCommand(Person target, int age)
        {
            Target = target;
            Age = age;
        }
    }
}
