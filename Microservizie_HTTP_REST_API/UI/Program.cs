using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static async Task  Main(string[] args)
        {
           var client = new HttpClient();
           var utenteResponse = await client.GetStringAsync("https://localhost:5001/Utente?id=4");
            var cittaResponse = await client.GetStringAsync("https://localhost:7001/Citta?id=5");
           
           Console.WriteLine(utenteResponse);
            Console.WriteLine(cittaResponse);
        }
    }

    class Viewmodel
    {
        public string nomeutente {get;set;}
        public string cittaUtente {get;set;}
    }
}
