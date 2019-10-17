using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM
{
    class Director
    {
        private EventManagerBuilder eventManagerBuilder;

        public void SetEventManagerBuilder(EventManagerBuilder eventManagerBuilder)
        {
            this.eventManagerBuilder = eventManagerBuilder;
        }

        public EventManager GetEventManager()
        {
            return eventManagerBuilder.GetEventManager();
        }

        public void ConstructEventManager(string description)
        {
            eventManagerBuilder.CreateNewEventManager();
            eventManagerBuilder.BuildDateTime();
            eventManagerBuilder.BuildTitle();
            eventManagerBuilder.BuildDescription(description);
        }
    }
}
