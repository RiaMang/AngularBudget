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
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
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
        [Route("GetAccounts")]
        public async Task<List<Account>> GetAccounts(ControllerParams selected)
        {
            return await db.GetAccounts(selected.HId);
        }
    }
}
