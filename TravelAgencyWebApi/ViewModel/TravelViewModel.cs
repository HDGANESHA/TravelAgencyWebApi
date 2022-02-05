using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyWebApi.ViewModel
{
    public class TravelViewModel
    {
        public int Tid { get; set; }
        public string Tname { get; set; }
        public int PlanId { get; set; }

        public string PlanName { get; set; }
        public int DestinationId { get; set; }

 
      
        public string DestinationName { get; set; }

    }
}
