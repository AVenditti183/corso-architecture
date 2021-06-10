using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace microservizio2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Citta : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var client = new HttpClient();
            var ok = false;
            var numeroRetry = 0;
            var utenteResponse = "";
            while (!ok && numeroRetry < 3)
            {
                try
                {
                    utenteResponse = await client.GetStringAsync($"https://localhost:10001/Utente?id={id}");
                    ok = true;
                }
                catch
                {
                    await Task.Delay(200);
                    numeroRetry++;
                }
            }
            if( !ok)
                throw new Exception();

            return Ok(new
            {
                Id = id,
                Descrizione = "Fondi",
                UtenteResponce = utenteResponse
            });
        }
    }
}