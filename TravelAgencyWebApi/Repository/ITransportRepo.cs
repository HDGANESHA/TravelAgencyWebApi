using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;

namespace TravelAgencyWebApi.Repository
{
   public interface ITransportRepo
    {
        Task<List<Transpordmode>> GetAlltravelmode();
        Task<int> Addtravelmode(Transpordmode mode);
        Task Updatetravelmode(Transpordmode mode);

        Task<int> Deletetravelmode(int? id);
    }
}
