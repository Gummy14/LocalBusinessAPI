using API.DBContexts;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessesController : ControllerBase
    {
        private MyDbContext dBContext;

        public BusinessesController (MyDbContext context)
        {
            dBContext = context;
        }

        [HttpGet("GetBusiness/{id}")]
        public Business GetBusiness(int id)
        {
            return dBContext.Businesses.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("GetAllBusinesses")]
        public IList<Business> GetAllBusinesses()
        {
            return dBContext.Businesses.ToList();
        }
    }
}
