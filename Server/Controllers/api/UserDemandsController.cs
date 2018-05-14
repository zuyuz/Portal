using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Server;
using AspNetCoreSpa.Server.Entities;
using AspNetCoreSpa.Server.ViewModels;
using AspNetCoreSpa_master.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreSpa.Server.Controllers.api
{
    [Produces("application/json")]
    [Route("api/UserDemands")]
    public class UserDemandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private SignInManager<ApplicationUser> _signInManager;

        public UserDemandsController(ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: api/UserDemands
        [HttpGet]
        public IEnumerable<UserDemand> GetUserDemands()
        {
            return _context.UserDemands;
        }
        // GET: api/SpecificUserDemands
        [HttpGet("UserDemands")]
        public async Task<IActionResult> GetUserDemandsAsync()
        {
            var demands = _context
                .UserDemands.Where(ud => ud.UserEmail != null).Include("Price");
            return Ok(demands);
        }
        // GET: api/SpecificUserDemands
        [HttpGet("SpecificUserDemands")]
        public async Task<IActionResult> GetSpecificUserDemandsAsync()
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var demands = _context
                .UserDemands.Include("Price").Where(ud => ud.UserEmail == user.Email);
            return Ok(demands);
        }

        // GET: api/UserDemands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDemand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDemand = await _context.UserDemands.SingleOrDefaultAsync(m => m.Id == id);

            if (userDemand == null)
            {
                return NotFound();
            }

            return Ok(userDemand);
        }

        // PUT: api/UserDemands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDemand([FromRoute] int id, [FromBody] UserDemand userDemand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDemand.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDemand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDemandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDemands
        [HttpPost]
        public async Task<IActionResult> PostUserDemand(string description, double price, int bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }
            var model = new UserDemand()
            {
                BookId = bookId,
                UserEmail = user.Email,
                Price = new Price()
                {
                    PriceType = PriceType.Paid,
                    Value = price
                },
                Description = description
            };

            _context.UserDemands.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDemand", new { id = model.Id }, model);
        }

        // DELETE: api/UserDemands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDemand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDemand = await _context.UserDemands.SingleOrDefaultAsync(m => m.Id == id);
            if (userDemand == null)
            {
                return NotFound();
            }

            _context.UserDemands.Remove(userDemand);
            await _context.SaveChangesAsync();

            return Ok(userDemand);
        }

        private bool UserDemandExists(int id)
        {
            return _context.UserDemands.Any(e => e.Id == id);
        }


        [HttpPost("Contract")]
        public async Task<IActionResult> PostContract(int id)
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var model = new Contract()
            {
                UserOfferId = id,
                UserEmail = user.Email
            };

            _context.Contracts.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOffer", new { id = model.Id }, model);
        }

        [HttpGet("ContractsByOwner")]
        public async Task<IActionResult> GetContractsByOwnerEmail()
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var temp = _context.UserDemands.Include("Price");
            var result = _context.Contracts.Where(c => temp.SingleOrDefault(offer => offer.Id == c.UserOfferId).UserEmail == user.Email).Select(c => new ContactsViewModel()
            {
                Id = c.Id,
                IsAllowed = c.IsAllowed,
                UserEmail = c.UserEmail,
                UserDemand = temp.SingleOrDefault(offer => offer.Id == c.UserOfferId)
            });

            return Ok(result);
        }

        [HttpGet("ContractsByAssignee")]
        public async Task<IActionResult> GetContractsByAssigneeEmail()
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var temp = _context.UserDemands.Include("Price");
            var result = _context.Contracts.Where(c => c.UserEmail == user.Email).Select(c => new ContactsViewModel()
            {
                Id = c.Id,
                IsAllowed = c.IsAllowed,
                UserEmail = c.UserEmail,
                UserDemand = temp.SingleOrDefault(offer => offer.Id == c.UserOfferId)
            });

            return Ok(result);
        }
        // PUT: api/UserDemands/5
        //[HttpPut("Contract")]
        //public async Task<IActionResult> PutContract(bool isAllowed, int contractId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Entry(contract).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserDemandExists(contract.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}