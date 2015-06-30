using AngularBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularBudget.Controllers
{
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public class ControllerParams
        {

            public int HId { get; set; }

        }

        public class IdParam
        {
            public int id { get; set; }
        }

        [HttpPost]
        [Route("GetGroup")]
        public async Task<List<Household>> GetGroup(ControllerParams selected)
        {
            return await db.GetGroup(selected.HId);
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<List<ApplicationUser>> GetUsers(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
        }

    }
}
