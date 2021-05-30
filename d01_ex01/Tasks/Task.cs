using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using d01_ex01.Events;
using Microsoft.VisualBasic;

namespace d01_ex01.Tasks
{
    public class Task
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != "")
                    title = value;
                else
                {
                    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                    return;
                }
                
            }
        }
        private string summary;
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
            }
        }
        private DateTime  dueDate;

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }


        private TaskPriority? priority;
        public string TaskPriority
        {
            get
            {
                return priority.ToString();
            }
            set
            {
                if ("".Equals(value))
                    priority = Tasks.TaskPriority.Normal;
                else
                    priority = Enum.Parse<TaskPriority>(value);
            }
            
        }
        private TaskType type;
        public TaskType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
            
        }
        private List<Event> taskState = new List<Event>();
        public List<Event> TaskState
        {
            get
            {
                return taskState;
            }
            set
            {
                taskState = value;
            }
        }
        public Task()
        {
        }
        
        public override string ToString()
        {
            string date;
            if (DueDate == DateTime.MinValue)
                date = "";
            else
            {
                date = DueDate.ToString("d");
            }
            return ("-" + Title + "\n" +
            "[" + Type + "][" + TaskState.Last().State + "]" + "\n" +
            "Priority: " + TaskPriority + ", Due till " +
                date + "\n" + Summary);
        }

    }
    
}