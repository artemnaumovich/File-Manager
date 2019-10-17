using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM
{
    abstract class EventManagerBuilder
    {
        protected EventManager eventManager;

        public EventManager GetEventManager()
        {
            return eventManager;
        }

        public void CreateNewEventManager()
        {
            eventManager = new EventManager();
        }

        public abstract void BuildDateTime();
        public abstract void BuildTitle();
        public abstract void BuildDescription(string description);

    }

    class ChangeEventManagerBuilder : EventManagerBuilder
    {
        public override void BuildDateTime()
        {
            eventManager.SetDateTime();
        }
        public override void BuildTitle()
        {
            eventManager.SetTitle("Change");
        }
        public override void BuildDescription(string description)
        {
            eventManager.SetDescription(description);
        }

    }

    class MovingEventManagerBuilder : EventManagerBuilder
    {
        public override void BuildDateTime()
        {
            eventManager.SetDateTime();
        }
        public override void BuildTitle()
        {
            eventManager.SetTitle("Moving");
        }
        public override void BuildDescription(string description)
        {
            eventManager.SetDescription(description);
        }

    }

    class ErrorEventManagerBuilder : EventManagerBuilder
    {
        public override void BuildDateTime()
        {
            eventManager.SetDateTime();
        }
        public override void BuildTitle()
        {
            eventManager.SetTitle("Error");
        }
        public override void BuildDescription(string description)
        {
            eventManager.SetDescription(description);
        }

    }

}
