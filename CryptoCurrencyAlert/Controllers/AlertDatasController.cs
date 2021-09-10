using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoCurrencyAlert.Data;
using CryptoCurrencyAlert.Models;

namespace CryptoCurrencyAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AlertDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertData>>> GetAlertDatas()
        {
            return await _context.AlertDatas.ToListAsync();
        }

        // GET: api/AlertDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertData>> GetAlertData(int id)
        {
            var alertData = await _context.AlertDatas.FindAsync(id);

            if (alertData == null)
            {
                return NotFound();
            }

            return alertData;
        }

        // PUT: api/AlertDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertData(int id, AlertData alertData)
        {
            if (id != alertData.AlertDataID)
            {
                return BadRequest();
            }

            _context.Entry(alertData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertDataExists(id))
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

        // POST: api/AlertDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlertData>> PostAlertData(AlertData alertData)
        {
            _context.AlertDatas.Add(alertData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertData", new { id = alertData.AlertDataID }, alertData);
        }

        // DELETE: api/AlertDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertData(int id)
        {
            var alertData = await _context.AlertDatas.FindAsync(id);
            if (alertData == null)
            {
                return NotFound();
            }

            _context.AlertDatas.Remove(alertData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertDataExists(int id)
        {
            return _context.AlertDatas.Any(e => e.AlertDataID == id);
        }
    }
}
