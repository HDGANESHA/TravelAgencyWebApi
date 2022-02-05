using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyWebApi.ViewModel
{
    public class DestinationViewModel
    {

        public int Tid { get; set; }
        public string Tname { get; set; }
        public int PlanId { get; set; }

        public string PlanName { get; set; }
        public int DestinationId { get; set; }

        public int PeriodId { get; set; }
        public byte Noofdays { get; set; }
        public int Ppid { get; set; }
        public int Amount { get; set; }

        public string DestinationName { get; set; }
    }
}
