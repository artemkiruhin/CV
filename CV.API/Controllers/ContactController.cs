using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase {

        [HttpGet(Name = "All_")]
        public IEnumerable<CV.Models.Contact> GetAll() {
            using var db = new ContactDbContext();
            return db.GetAll();
        }

        

    }
}
