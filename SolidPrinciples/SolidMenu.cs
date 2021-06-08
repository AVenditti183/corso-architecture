using System;
using System.Linq;

namespace SolidPrinciples
{
    public class SolidMenu : IMenu
    {
        public void Start()
        {
            var voceMenuRicerca = new ItemMenu{
                        Descrizione ="Ricerca",
                        Command ="r"
                    };
            var voceMenuAggiungi = new ItemMenu{
                        Descrizione ="Aggiungi",
                        Command ="a"
                    };
            var voceMenuModifica = new ItemMenu{
                        Descrizione ="Modifica",
                        Command ="m"
                    };
            var voceMenuCancella = new ItemMenu{
                        Descrizione ="Cancella",
                        Command ="c"
                    };

            var voceMenuProdotti = new ItemMenu{
                        Descrizione ="Prodotti",
                        Command ="p",
                        SubMenu = new ItemMenu[]
                        {
                            voceMenuRicerca,
                            voceMenuAggiungi,
                            voceMenuModifica,
                            voceMenuCancella
                        }
                    };

            var voceMenuMagazzino = new ItemMenu{
                        Descrizione ="Magazzino",
                        Command ="m",
                        SubMenu = new ItemMenu[]
                        {
                            voceMenuRicerca,
                            voceMenuAggiungi,
                            voceMenuModifica,
                            voceMenuCancella
                        }
                    };
            
            var voceMenuClienti = new ItemMenu{
                        Descrizione ="Clienti",
                        Command ="c",
                        SubMenu = new ItemMenu[]
                        {
                            voceMenuRicerca,
                            voceMenuAggiungi,
                            voceMenuModifica,
                            voceMenuCancella
                        }
                    };

            var home = new ItemMenu[]
            {
               voceMenuProdotti,
               voceMenuMagazzino,
               voceMenuClienti

             };
            var msg ="Pagina";
            
            var menu = home.ToArray();
            while (true)
            {
                foreach (var item in menu)
                {
                    Console.WriteLine($"{item.Command} - {item.Descrizione}");
                }
                var command = Console.ReadLine();
                
                var itemMenu = menu.FirstOrDefault(o => o.Command == command);
                if (itemMenu == null)
                {
                    Console.WriteLine("Rotta non riconosciuta");
                    return;
                }
                msg+=$" {itemMenu.Descrizione}";
                if (itemMenu.SubMenu != null && itemMenu.SubMenu.Any())
                {
                    
                    menu = itemMenu.SubMenu;
                }
                else
                {
                    Console.WriteLine(msg);
                    return;
                }
            }
        }
    }
 
     public class ItemMenu
    {
        public string Descrizione { get; set; }
        public string Command { get; set; }
        public ItemMenu[] SubMenu { get; set; }
    }
}