using System;
using System.Collections.Generic;
using System.Net.Sockets;
using d01_ex01.Events;
using d01_ex01.Tasks;

namespace d01_ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            string metod;
            List<Task> task = new  List<Task>();
            while (true)
            {
                
                Console.WriteLine("Выберите задачу:"+
                                   "add, list, done, wontdo  или q(quit)" +
                                   "чтобы покинуть приложение");
                metod = Console.ReadLine();
                switch (metod)
                {
                    case "add":
                        addTask(task);
                        break;
                    case "list":
                        listTasks(task);
                        break;
                    case "done":
                        doneTask(task);
                        break;
                    case "wontdo":
                        wontDo(task);
                        break;
                    case "q":
                        return;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                        break;
                }
            }
        }

        static void addTask(List<Task> tasks)
        {
            Task task = new Task();
            Console.WriteLine("Введите заголовок:");
            task.Title = Console.ReadLine();
            Console.WriteLine("Введите описание");
            task.Summary = Console.ReadLine();                           
            Console.WriteLine("Введите срок");
            string pars = Console.ReadLine();
            if ("".Equals(pars))
                task.DueDate = DateTime.MinValue;
            else
            {
                try
                {
                    task.DueDate = DateTime.Parse(pars);
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                    return;
                }
            }
            Console.WriteLine("Введите тип");
            try
            {
                task.Type = Enum.Parse<TaskType>(Console.ReadLine());
            }
            catch (Exception)
            {
                
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                return;
                
            }
            Console.WriteLine("Установите приоритет");
            task.TaskPriority = Console.ReadLine();
            task.TaskState.Add(new CreatedEvent("new"));
            tasks.Add(task);
            Console.WriteLine(task);
        }

        static void listTasks(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пока пуст.");
                return;
            }
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine();
            }
        }

        static void doneTask(List<Task> tasks)
        {
            Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();
            int i;
            for (i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title.Equals(title))
                {
                    tasks[i].TaskState.Add(new TaskDoneEvent("done"));
                    Console.WriteLine("Задача [" + tasks[i].Title +
                    "] выполнена!");
                    break;
                }
            }
            if (i == tasks.Count)
                Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
        }
        static void wontDo(List<Task> tasks)
        {
            Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();
            int i;
            for (i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title.Equals(title))
                {
                    tasks[i].TaskState.Add(new TaskWontDoEvent("wontdo"));
                    Console.WriteLine("Задача [" + tasks[i].Title +
                                      "] неактуальна!");
                    break;
                }
            }
            if (i == tasks.Count)
                Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
        }
    }
}