using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;
using TravelAgencyWebApi.ViewModel;

namespace TravelAgencyWebApi.Repository
{
  public  interface IDestinationRepo
    {
        Task<List<Destination>> GetAllDestination();
        Task<int> AddDestination(Destination destination);
        Task UpdateDestination(Destination destination);
        Task<int> DeleteDestination(int? id);

        Task<List<DestinationViewModel>> GetAllDestinationplans();
    }
}
