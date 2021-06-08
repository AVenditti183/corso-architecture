using System;

namespace SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //IMenu menu = new MenuSpaghettiCode();
            //var menu = new SolidMenu();
            var vociMenuStr = System.IO.File.ReadAllText($@"{System.IO.Directory.GetCurrentDirectory()}\menu.json");
            var vociMenu = System.Text.Json.JsonSerializer.Deserialize<ItemMenu[]>(vociMenuStr);
            var menu = new SolidMenuConfigurated(vociMenu);
            menu.Start();
        }
    }
}
