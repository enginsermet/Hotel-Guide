using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelService.Data;
using HotelService.Entities;
using AutoMapper;
using HotelService.DTOs;

namespace HotelService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public ContactsController(HotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST: api/ContactInformation
        [HttpPost]
        [ActionName("Add")]
        public async Task<ActionResult<ContactInfo>> AddContactInfo(Guid hotelId, ContactInfoDto contactInfoDto)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'HotelDbContext.ContactInfo'  is null.");
            }

            var contact = _mapper.Map<ContactInfo>(contactInfoDto);
            contact.Id = Guid.NewGuid();
            contact.HotelId = hotelId;
            _context.Contacts.Add(contact);

            await _context.SaveChangesAsync();

            return CreatedAtAction("AddContactInfo", new { id = contact.Id }, contact);
        }

        // DELETE: api/ContactInformation/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteContactInfo(Guid id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contactInfo = await _context.Contacts.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ContactInfoExists(Guid id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
