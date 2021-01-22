using API.DBContexts;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalBusinessesController : ControllerBase
    {
        private MyDbContext dBContext;

        public LocalBusinessesController (MyDbContext context)
        {
            dBContext = context;
        }

        [HttpGet("GetLocalBusinesses")]
        public IList<LocalBusiness> GetLocalBusinesses()
        {
            return dBContext.LocalBusinesses.ToList();
        }

        [HttpGet("GetFirstLocalBusiness")]
        public LocalBusiness GetFirstLocalBusiness()
        {
            return dBContext.LocalBusinesses.FirstOrDefault();
        }
    }
}
