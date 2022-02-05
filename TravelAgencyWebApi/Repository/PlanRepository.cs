using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;
using TravelAgencyWebApi.ViewModel;

namespace TravelAgencyWebApi.Repository
{
    public class PlanRepository : IPlansRepo
    {

        private readonly finalevaluationContext _context;



        public PlanRepository(finalevaluationContext context)
        {
            _context = context;
        }

        public async Task<int> AddPlan(Plans plans)
        {
            if (_context != null)
            {
                await _context.Plans.AddAsync(plans);
                await _context.SaveChangesAsync();
                return plans.PlanId;
            }
            return 0;
        }

        public async Task<int> DeletePlan(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                  
                var plan = await _context.Plans.FirstOrDefaultAsync(pla => pla.PlanId == id);
                //check condition
                if (plan != null)
                {
                    //deleting 
                    _context.Plans.Remove(plan);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Plans>> GetAllPlans()
        {
            if (_context != null)
            {
                return await _context.Plans.ToListAsync();
            }
            return null;
        }

        public async Task<List<TravelViewModel>> GetAllPlansOfBus()
        {

            if (_context != null)
            {
                return await(from t in _context.Transpordmode
                             from p in _context.Plans
                             from d in _context.Destination
                             where t.PlanId == p.PlanId && p.DestinationId ==d.DestinationId && t.Tname =="car"
                             select new TravelViewModel
                             {
                                 Tid = t.Tid,
                                 Tname = t.Tname,
                                 PlanId = p.PlanId,
                                 PlanName = p.PlanName,
                                 DestinationId=d.DestinationId,
                                 DestinationName = d.DestinationName
                              }
                              ).ToListAsync();

            }
            return null;
        }

        public async Task UpdatePlan(Plans plans)
        {
            if (_context != null)
            {
                _context.Entry(plans).State = EntityState.Modified;
                _context.Plans.Update(plans);

                await _context.SaveChangesAsync();
            }
        }
    }
}
