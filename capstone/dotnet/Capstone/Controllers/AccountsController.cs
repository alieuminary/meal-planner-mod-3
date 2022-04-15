using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDao accountDao;

        public AccountController(IAccountDao _accountDao)
        {
            accountDao = _accountDao;
        }

        [HttpGet()]
        public ActionResult<Accounts> GetAllAccounts()
        {
            IList<Accounts> accounts = accountDao.GetAllAccountsList();
            if (accounts == null)
            {
                return NoContent();
            }
            return Ok(accounts);
        }

        [HttpGet("{username}")]
        public ActionResult<Accounts> GetAccount(string username)
        {
            Accounts account = accountDao.GetAccount(username);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpGet("otheraccounts")]
        public ActionResult<Accounts> List()
        {
            string username = User.Identity.Name;
            IList<Accounts> accounts = accountDao.GetAllAccountsListButMe(username);
            if (accounts != null)
            {
                return Ok(accounts);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("post")]
        public ActionResult<Accounts> PostAccount(Accounts account)
        {
            Accounts postingAccount = accountDao.PostAccount(account);
            if (postingAccount != null)
            {
                return Created($"/accounts/{postingAccount.Username}", postingAccount);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public ActionResult<Accounts> UpdateAccount(Accounts account)
        {
            Accounts updatedAccount = accountDao.UpdateAccount(account);
            if (updatedAccount != null)
            {
                return Created($"/accounts/{updatedAccount.Username}", updatedAccount);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
