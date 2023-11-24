﻿using System.Threading.Tasks;
using ToDoApp;

class Program
{
    static void Main(string[] args)
    {
        var tasks = new TaskCollection();

        while (true)
        {
            Console.Clear();
            tasks.Show();
            var cmd = GetCmd();
            if (cmd == "1")
            {
                AddTask(tasks);
            }
            else if (cmd == "2")
            {
                MarkTaskIsDone(tasks);
            }
        }
    }

    private static string? GetCmd()
    {
        Console.WriteLine("Hva vil du gjøre? ");
        Console.WriteLine("1 = Legg til ny");
        Console.WriteLine("2 = Marker fullført");
        var cmd = Console.ReadLine();
        return cmd;
    }

    private static void MarkTaskIsDone(TaskCollection tasks)
    {
        Console.WriteLine("Hvilken oppgave vil du markere fullført? (skriv inn nr til oppgaven)");
        var taskNoStr = Console.ReadLine();
        var taskNo = Convert.ToInt32(taskNoStr);
        if (taskNo < 1 || taskNo > tasks.GetCount())
        {
            Console.WriteLine("Skriv inn et gyldig tall");
        }
        else
        {
            tasks.MarkDone(taskNo);
        }
    }

    private static void AddTask(TaskCollection myTasks)
    {
        Console.WriteLine("Skriv inn navn:");
        var name = Console.ReadLine();
        Console.WriteLine("Skriv inn når den skal være ferdig(dd/mm/yyyy):");
        DateTime dueDate;
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDateFromUser))
        {
            dueDate = dueDateFromUser;
        }
        else
        {
            Console.WriteLine("Ugyldig datoformat. Bruker dagens dato.");
            dueDate = DateTime.Today;
        }
        myTasks.AddTask(name, dueDate);
    }
}