namespace d01_ex01.Events
{
    public record TaskDoneEvent: Event
    {
        public TaskDoneEvent(string state) : base(state)
        {
            this.State = state;
        }
    }
}