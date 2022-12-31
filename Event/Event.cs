using Prism.Events;

namespace PrismPractice.Event
{
    public class Event : PubSubEvent<string> { }

    public class StringEvent : PubSubEvent<string> { }
}