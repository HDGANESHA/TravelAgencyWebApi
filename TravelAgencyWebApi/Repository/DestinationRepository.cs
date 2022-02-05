using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;
using TravelAgencyWebApi.ViewModel;

namespace TravelAgencyWebApi.Repository
{
    public class DestinationRepository : IDestinationRepo
    {


        private readonly finalevaluationContext _context;



        public DestinationRepository(finalevaluationContext context)
        {
            _context = context;
        }

        public async Task<int> AddDestination(Destination destination)
        {
            if (_context != null)
            {
                await _context.Destination.AddAsync(destination);
                await _context.SaveChangesAsync();
                return destination.DestinationId;
            }
            return 0;
        }

        public async Task<int> DeleteDestination(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                   
                var destination = await _context.Destination.FirstOrDefaultAsync(dest => dest.DestinationId == id);
                //check condition
                if (destination != null)
                {
                    //deleting t
                    _context.Destination.Remove(destination);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Destination>> GetAllDestination()
        {
            if (_context != null)
            {
                return await _context.Destination.ToListAsync();
            }
            return null;
        }

        public async Task<List<DestinationViewModel>> GetAllDestinationplans()
        {


            if (_context != null)
            {
                return await(from t in _context.Transpordmode
                             from p in _context.Plans
                             from d in _context.Destination
                             from c in _context.Planprice
                             from s in _context.Planperiod
                             where t.PlanId == p.PlanId && p.DestinationId == d.DestinationId && c.PlanId==p.PlanId && s.PlanId ==p.PlanId
                            
                             select new DestinationViewModel
                             {
                                 DestinationId = d.DestinationId,
                                 DestinationName = d.DestinationName,
                                 Tid = t.Tid,
                                 Tname = t.Tname,
                                 PlanId = p.PlanId,
                                 PlanName = p.PlanName,
                                 PeriodId =s.PeriodId,
                                 Noofdays =s.Noofdays,
                                 Ppid= c.Ppid,
                                 Amount=c.Amount,

                             }
                              ).ToListAsync();

            }
            return null;
        }

        public async Task UpdateDestination(Destination destination)
        {
            if (_context != null)
            {
                _context.Entry(destination).State = EntityState.Modified;
                _context.Destination.Update(destination);

                await _context.SaveChangesAsync();
            }
        }


    }
}
