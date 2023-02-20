using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;

namespace AprajitaRetails.Server.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreGroupsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public StoreGroupsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/StoreGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreGroup>>> GetStoreGroups()
        {
          if (_context.StoreGroups == null)
          {
              return NotFound();
          }
            return await _context.StoreGroups.ToListAsync();
        }
        [HttpGet("AddDefault")]
        public async Task<ActionResult<IEnumerable<StoreGroup>>> GetAddDefaultStoreGroup()
        {
            if (_context.StoreGroups != null)
            {
                return NotFound();
            }
            StoreGroup group = new StoreGroup
            {
                GroupName="The Arvind Store", Remarks="Arvind Store Group",
                StoreGroupId="TAS", AppClientId=_context.AppClients.First().AppClientId
            };
           await _context.StoreGroups.AddAsync(group);
           await _context.SaveChangesAsync();

            return await _context.StoreGroups.ToListAsync();
        }

        // GET: api/StoreGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreGroup>> GetStoreGroup(string id)
        {
          if (_context.StoreGroups == null)
          {
              return NotFound();
          }
            var storeGroup = await _context.StoreGroups.FindAsync(id);

            if (storeGroup == null)
            {
                return NotFound();
            }

            return storeGroup;
        }

        // PUT: api/StoreGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreGroup(string id, StoreGroup storeGroup)
        {
            if (id != storeGroup.StoreGroupId)
            {
                return BadRequest();
            }

            _context.Entry(storeGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreGroupExists(id))
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

        // POST: api/StoreGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreGroup>> PostStoreGroup(StoreGroup storeGroup)
        {
          if (_context.StoreGroups == null)
          {
              return Problem("Entity set 'ARDBContext.StoreGroups'  is null.");
          }
            _context.StoreGroups.Add(storeGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StoreGroupExists(storeGroup.StoreGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStoreGroup", new { id = storeGroup.StoreGroupId }, storeGroup);
        }

        // DELETE: api/StoreGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreGroup(string id)
        {
            if (_context.StoreGroups == null)
            {
                return NotFound();
            }
            var storeGroup = await _context.StoreGroups.FindAsync(id);
            if (storeGroup == null)
            {
                return NotFound();
            }

            _context.StoreGroups.Remove(storeGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreGroupExists(string id)
        {
            return (_context.StoreGroups?.Any(e => e.StoreGroupId == id)).GetValueOrDefault();
        }
    }
}
