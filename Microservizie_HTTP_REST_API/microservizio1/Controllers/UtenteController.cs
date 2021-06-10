using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace microservizio1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : ControllerBase
    {   
        private static int NumeroAccessi =0;
        
        [HttpGet]
        public IActionResult Get(int id)
        {

            NumeroAccessi ++;
            if (NumeroAccessi % 2 ==0)
                throw new Exception();
                
            return Ok( new 
            { 
                Id =id,
                Name = "Antonio"
            });
        }
    }
}