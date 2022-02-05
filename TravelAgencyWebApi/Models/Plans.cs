using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Plans
    {
        public Plans()
        {
            Planperiod = new HashSet<Planperiod>();
            Planprice = new HashSet<Planprice>();
            Transpordmode = new HashSet<Transpordmode>();
        }

        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; }
        public virtual ICollection<Planperiod> Planperiod { get; set; }
        public virtual ICollection<Planprice> Planprice { get; set; }
        public virtual ICollection<Transpordmode> Transpordmode { get; set; }
    }
}
