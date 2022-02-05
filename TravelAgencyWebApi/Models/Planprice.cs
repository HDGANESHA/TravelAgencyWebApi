using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Planprice
    {
        public int Ppid { get; set; }
        public int Amount { get; set; }
        public int PeriodId { get; set; }
        public int Tid { get; set; }
        public int PlanId { get; set; }

        public virtual Planperiod P { get; set; }
        public virtual Plans Plan { get; set; }
        public virtual Transpordmode Transpordmode { get; set; }
    }
}
