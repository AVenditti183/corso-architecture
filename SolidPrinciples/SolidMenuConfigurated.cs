using System;

using System.Linq;
namespace SolidPrinciples
{
    public class SolidMenuConfigurated : IMenu
    {
        private readonly ItemMenu[] home;
        public SolidMenuConfigurated(ItemMenu[] home)
        {
            this.home = home;
        }
        
        public void Start()
        {
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
}