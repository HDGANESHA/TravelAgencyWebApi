using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Planperiod
    {
        public Planperiod()
        {
            Planprice = new HashSet<Planprice>();
        }

        public int PeriodId { get; set; }
        public byte Noofdays { get; set; }
        public int PlanId { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual ICollection<Planprice> Planprice { get; set; }
    }
}
