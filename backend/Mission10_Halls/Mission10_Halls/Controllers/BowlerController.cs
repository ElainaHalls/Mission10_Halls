using Mission10_Halls.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mission10_Halls.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        
        public BowlerController(IBowlerRepository temp)
        {
            _bowlerRepository = temp;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {

            // Join Bowlers and Teams based on TeamID
            var bowlerData = _bowlerRepository.GetBowlersWithTeams().Select(b => new
            {
                bowlerID = b.BowlerID,
                bowlerFirstName = b.BowlerFirstName,
                bowlerMiddleInit = b.BowlerMiddleInit,
                bowlerLastName = b.BowlerLastName,
                teamName = b.Team?.TeamName,
                bowlerAddress = b.BowlerAddress,
                bowlerCity = b.BowlerCity,
                bowlerState = b.BowlerState,
                bowlerZip = b.BowlerZip,
                bowlerPhoneNumber = b.BowlerPhoneNumber,
            }).ToArray();

            return(bowlerData);
        }
    }
}
