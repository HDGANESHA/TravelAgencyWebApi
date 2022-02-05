using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;
using TravelAgencyWebApi.ViewModel;

namespace TravelAgencyWebApi.Repository
{
 public interface IPlansRepo
    {
        Task<List<Plans>> GetAllPlans();
        Task<int> AddPlan(Plans plans);
        Task UpdatePlan(Plans plans);

        Task<int> DeletePlan(int? id);

        Task<List<TravelViewModel>> GetAllPlansOfBus();
    }
}
