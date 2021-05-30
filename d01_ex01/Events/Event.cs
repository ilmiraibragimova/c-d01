namespace d01_ex01.Events
{
    public abstract record Event
    { 
        public string State {get; set;}
        public Event(string state)
        {
            State = state;
        }
    }
}