using System;

namespace SolidPrinciples
{
    public class MenuSpaghettiCode :IMenu
    {
        public void Start()
        {
            Console.WriteLine("p -> Prodotti");
            Console.WriteLine("m -> Magazzino");
            Console.WriteLine("c -> Clienti");
            
            Console.WriteLine("Selezionare una voce di menù");
            var menu = Console.ReadLine();

            if (menu =="p")
            {
                Console.WriteLine("r -> Ricerca");
                Console.WriteLine("a -> Aggiungi");
                Console.WriteLine("m -> modifica");
                Console.WriteLine("c -> cancella");

                Console.WriteLine("Selezionare una voce di menù");
                var subMenu = Console.ReadLine();  

                if (subMenu == "r")
                {
                    Console.WriteLine("Pagina Ricerca Prodotti");
                    return;
                }

                if (subMenu == "a")
                {
                    Console.WriteLine("Pagina Aggiungi Prodotti");
                    return;
                }

                if (subMenu == "m")
                {
                    Console.WriteLine($"Pagina Modifica Prodotti");
                    return;
                }

                if (subMenu == "c")
                {
                    Console.WriteLine($"Pagina Cancella Prodotti");
                    return;
                }
            }

            if(menu =="m")
            {
                Console.WriteLine("r -> Ricerca");
                Console.WriteLine("a -> Aggiungi");
                Console.WriteLine("m -> modifica");
                Console.WriteLine("c -> cancella");

                Console.WriteLine("Selezionare una voce di menù");
                var subMenu = Console.ReadLine();  

                if (subMenu == "r")
                {
                    Console.WriteLine("Pagina Ricerca Magazzino");
                    return;
                }

                if (subMenu == "a")
                {
                    Console.WriteLine("Pagina Aggiungi Magazzino");
                    return;
                }

                if (subMenu == "m")
                {
                    Console.WriteLine($"Pagina Modifica Magazzino");
                    return;
                }

                if (subMenu == "c")
                {
                    Console.WriteLine($"Pagina Cancella Magazzino");
                    return;
                }
            }

            if (menu =="c")
            {
                Console.WriteLine("r -> Ricerca");
                Console.WriteLine("a -> Aggiungi");
                Console.WriteLine("m -> modifica");
                Console.WriteLine("c -> cancella");

                Console.WriteLine("Selezionare una voce di menù");
                var subMenu = Console.ReadLine();  

                if (subMenu == "r")
                {
                    Console.WriteLine("Pagina Ricerca Clienti");
                    return;
                }

                if (subMenu == "a")
                {
                    Console.WriteLine("Pagina Aggiungi Clienti");
                    return;
                }

                if (subMenu == "m")
                {
                    Console.WriteLine($"Pagina Modifica Clienti");
                    return;
                }

                if (subMenu == "c")
                {

                    Console.WriteLine($"Pagina Cancella Clienti");
                    return;
                }
            }

            
        }
    }
}