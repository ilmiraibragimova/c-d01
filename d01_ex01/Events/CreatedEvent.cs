using System.Data;

namespace d01_ex01.Events
{
    public record  CreatedEvent: Event
    {
        public CreatedEvent(string state) : base(state)
        {
            state = "new";
        }
    }
}