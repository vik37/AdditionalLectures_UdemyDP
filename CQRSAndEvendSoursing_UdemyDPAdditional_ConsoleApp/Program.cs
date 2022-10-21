using System;

// CQRS - Command Query Responsibility Segregation
// CQS - Command Query Separation

// Command = do/change
namespace CQRSAndEvendSoursing_UdemyDPAdditional_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var p = new Person(eb);
            eb.Command(new ChangeAgeCommand(p, 123));

            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            int age = eb.Query<int>(new AgeQuery { Target = p });
            Console.WriteLine(age);

            eb.UndoLast();
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
        
    }
}
