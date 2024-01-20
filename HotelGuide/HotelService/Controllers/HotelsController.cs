using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelService.Data;
using HotelService.Entities;
using HotelService.DTOs;
using AutoMapper;

namespace HotelService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public HotelsController(HotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        [ActionName("Officials")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            List<HotelDto> hotels = new List<HotelDto>();

            foreach (var hotel in await _context.Hotels.ToListAsync())
            {
                hotels.Add(_mapper.Map<HotelDto>(hotel));
            }
            return hotels;
        }

        // GET: api/Hotels/Details/5
        //Returns detailed information about the hotel, including contact information
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<ActionResult<HotelDetailsDto>> GetHotelDetails(Guid id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            HotelDetailsDto hotelDetailsDto = new HotelDetailsDto();

            _mapper.Map(hotel, hotelDetailsDto);

            foreach (var contact in await _context.Contacts.Where(c => c.HotelId == id).ToListAsync())
            {
                hotelDetailsDto.ContactInformation.Add(_mapper.Map<ContactInfoDto>(contact));
            }

            if (hotelDetailsDto == null)
            {
                return NotFound();
            }

            return hotelDetailsDto;
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        [ActionName("Update")]
        public async Task<IActionResult> PutHotel(Guid id, HotelDto hotelDto)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return BadRequest();
            }

            _mapper.Map(hotelDto, hotel);
            _context.Hotels.Update(hotel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        //POST: api/Hotels
        //Creates a new hotel record
        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult<CreateHotelDto>> PostHotel(CreateHotelDto createHotelDto)
        {
            if (createHotelDto == null)
            {
                return BadRequest();
            }
            var hotel = _mapper.Map<Hotel>(createHotelDto);
            hotel.UUID = Guid.NewGuid();

            var contact = _mapper.Map<ContactInfo>(createHotelDto);
            contact.Id = Guid.NewGuid();
            contact.HotelId = hotel.UUID;
            _context.Hotels.Add(hotel);
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateHotel", new { id = hotel.UUID }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(Guid id)
        {
            return (_context.Hotels?.Any(e => e.UUID == id)).GetValueOrDefault();
        }
    }
}
