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
    public class BuisnessHoursController : ControllerBase
    {
        private MyDbContext dBContext;

        public BuisnessHoursController(MyDbContext context)
        {
            dBContext = context;
        }

        [HttpGet("GetBusinessHours/{businessId}")]
        public IList<BusinessHours> GetBusinessHours(int businessId)
        {
            return dBContext.BusinessHours.Where(x => x.BusinessId == businessId).ToList();
        }

        [HttpGet("GetAllBusinessesHours")]
        public IList<BusinessHours> GetAllBusinessHours()
        {
            return dBContext.BusinessHours.ToList();
        }
    }
}
