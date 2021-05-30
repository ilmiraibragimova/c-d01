namespace d01_ex01.Events
{
    public record TaskWontDoEvent: Event
    {
        public TaskWontDoEvent(string state) : base(state)
        {
            state = "wontdo";
        }
    }
}