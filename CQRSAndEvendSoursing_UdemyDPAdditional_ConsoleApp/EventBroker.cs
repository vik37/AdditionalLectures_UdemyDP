using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRSAndEvendSoursing_UdemyDPAdditional_ConsoleApp
{
    public class EventBroker
    {
        // all events that happend.
        public IList<Event> AllEvents = new List<Event>();

        // Commands
        public event EventHandler<Command> Commands;

        // Query
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }
        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T) q.Result;
        }
        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangeEvent;
            if(ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.OldValue) { Register = false});
                AllEvents.Remove(e);
            }
        }
    }
}
