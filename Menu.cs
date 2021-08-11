using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{

    /*L’utente può:
- Visualizzare i tasks;
- Aggiungere nuovi tasks;
- Eliminare i tasks;
- Filtrare i task per importanza;*/


    class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Tasks");

            bool vuoiContinuare = true;

            do
            {
                Console.WriteLine("Premi 1 per visualizzare i tasks");
                Console.WriteLine("Premi 2 per inserire un nuovo task");
                Console.WriteLine("Premi 3 per eliminare un task");
                Console.WriteLine("Premi 4 per filtrare i task per importanza");
                Console.WriteLine("Premi 0 per uscire");

                bool isInt = true;
                int scelta = 0;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out scelta);
                } while (!isInt);

                switch (scelta)
                {
                    case 1:
                        GestioneTasks.MostraTasks();
                        break;
                    case 2:
                        GestioneTasks.AggiungiTasks();
                        break;
                    case 3:
                        GestioneTasks.EliminaTasks();
                        break;
                    case 4:
                        GestioneTasks.FiltraTasks();
                        break;
                    case 0:
                        vuoiContinuare = false;
                        GestioneTasks.SalvaSuFile();
                        break;
                    default:
                        Console.WriteLine("Hai sbagliato, inserisci un numero valido");
                        break;
                }

            } while (vuoiContinuare);
        }
    }
}
