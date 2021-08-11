using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Test2.Tasks;

/*L’utente può:
- Visualizzare i tasks;
- Aggiungere nuovi tasks;
- Eliminare i tasks;
- Filtrare i task per importanza;*/

namespace Test2
{
    class GestioneTasks
    {
        public static List<Tasks> tasks = new List<Tasks>();
        static string path = @"C:\Users\Elena\Documents\Avanade\Week2\Day4\Test2\Tasks.txt";

        public static void MostraTasks(List<Tasks> tasks)
        {
            if (tasks.Count > 0)
            {
                int count = 1;
                foreach (Tasks task1 in tasks)
                {
                    Console.WriteLine($"{count} -> Materia: {task1.Descrizione} Data: {task1.Scadenza} Tipo: {task1.Priorita}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Non ci sono task.");
            }
        }
        public static void MostraTasks()
        {
            MostraTasks(tasks);
        }

        public static void AggiungiTasks()
        {
            Tasks task1 = new Tasks();

            Console.WriteLine("Inserisci la descrizione del task");
            task1.Descrizione = Console.ReadLine();

            bool isDateTime = false;
            DateTime dataScadenza = new DateTime();

            do
            {
                Console.WriteLine("Inserisci la data di scadenza");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out dataScadenza);
            } while (!isDateTime || dataScadenza < DateTime.Now);

            task1.Scadenza = dataScadenza;
            task1.Priorita = ScegliTipologiaTask();

            tasks.Add(task1);
        }

        public static Livello ScegliTipologiaTask()
        {
            bool isInt = false;
            int tipoTask = 0;
            do
            {
                Console.WriteLine($"Premi {(int)Livello.Basso} per scegliere un livello di priorità {Livello.Basso}");
                Console.WriteLine($"Premi {(int)Livello.Medio} per scegliere un livello di priorità {Livello.Medio}");
                Console.WriteLine($"Premi {(int)Livello.Alto} per scegliere un livello di priorità {Livello.Alto}");

                isInt = int.TryParse(Console.ReadLine(), out tipoTask);
            } while (!isInt || tipoTask < 0 || tipoTask > 2);

            return (Livello)tipoTask;
        }

        public static void EliminaTasks()
        {
            MostraTasks();

            Tasks TaskDaEliminare = ScegliTask();

            tasks.Remove(TaskDaEliminare);
        }

        public static Tasks ScegliTask()
        {
            bool isInt = false;
            int numTask = 0;
            do
            {
                Console.WriteLine("Inserisci il numero del task");
                isInt = int.TryParse(Console.ReadLine(), out numTask);
            } while (!isInt || numTask < 0 || numTask > tasks.Count);

            return tasks.ElementAt(numTask - 1);
        }

        public static void FiltraTasks()
        {
            Console.WriteLine("Scegli il tipo di task da filtrare");

            Livello tipoTask = ScegliTipologiaTask();

            List<Tasks> tasksFiltrati = new List<Tasks>();

            foreach (Tasks task1 in tasks)
            {
                if (task1.Priorita == tipoTask)
                {
                    tasksFiltrati.Add(task1);
                }
            }

            if (tasksFiltrati.Count > 0)
            {
                MostraTasks(tasksFiltrati);
            }
            else
            {
                Console.WriteLine("Non sono presenti task di tipo {tipoTask}");
            }
        }

        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Tasks");
                sw.WriteLine();
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Tasks task1 in tasks)
                {
                    sw.WriteLine($"Materia: {task1.Descrizione} Data: {task1.Scadenza} Tipo: {task1.Priorita}");
                }
            }
        }
    }
}
