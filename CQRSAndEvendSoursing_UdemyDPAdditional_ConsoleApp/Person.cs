using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSAndEvendSoursing_UdemyDPAdditional_ConsoleApp
{
    public class Person
    {
        private int age;
        EventBroker broker;
        public Person(EventBroker broker)
        {
            this.broker = broker;
            broker.Query += BrokerOnQuery;
            broker.Commands += BrokerOnCommand;
            
        }
        private void BrokerOnQuery(object sender, Query query)
        {
            var ac = query as AgeQuery;
            if (ac != null && ac.Target == this)
            {
                ac.Result = age;
            }
        }
        private void BrokerOnCommand(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if(cac != null && cac.Target == this)
            {
                if(cac.Register) broker.AllEvents.Add(new AgeChangeEvent(this, age, cac.Age));
                age = cac.Age;
            }
        }
        
    }
}
