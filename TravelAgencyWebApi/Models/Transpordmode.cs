using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Transpordmode
    {
        public Transpordmode()
        {
            Planprice = new HashSet<Planprice>();
        }

        public int Tid { get; set; }
        public string Tname { get; set; }
        public int PlanId { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual ICollection<Planprice> Planprice { get; set; }
    }
}
