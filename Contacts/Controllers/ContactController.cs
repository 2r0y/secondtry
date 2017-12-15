using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
            _context = context;

            if (_context.Contacts.Count() == 0)
            {
                _context.Contacts.Add(new Contact { Name = "John" });
                _context.SaveChanges();
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }
    }
}
