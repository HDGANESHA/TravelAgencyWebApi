using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;

namespace TravelAgencyWebApi.Repository
{
    public class TransportRepository : ITransportRepo
    {

        private readonly finalevaluationContext _context;



        public TransportRepository(finalevaluationContext context)
        {
            _context = context;
        }


        public async Task<int> Addtravelmode(Transpordmode mode)
        {
            if (_context != null)
            {
                await _context.Transpordmode.AddAsync(mode);
                await _context.SaveChangesAsync();
                return mode.Tid;
            }
            return 0;
        }

        public async Task<int> Deletetravelmode(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                
                var transport = await _context.Transpordmode.FirstOrDefaultAsync(tra => tra.Tid == id);
                //check condition
                if (transport != null)
                {
                    //deleting 
                    _context.Transpordmode.Remove(transport);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Transpordmode>> GetAlltravelmode()
        {
            if (_context != null)
            {
                return await _context.Transpordmode.ToListAsync();
            }
            return null;
        }

        public async Task Updatetravelmode(Transpordmode mode)
        {
            if (_context != null)
            {
                _context.Entry(mode).State = EntityState.Modified;
                _context.Transpordmode.Update(mode);

                await _context.SaveChangesAsync();
            }
        }
    }
}
