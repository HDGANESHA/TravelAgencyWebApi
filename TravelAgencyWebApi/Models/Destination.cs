using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Destination
    {
        public Destination()
        {
            Covering = new HashSet<Covering>();
            Plans = new HashSet<Plans>();
        }

        public int DestinationId { get; set; }
        public string DestinationName { get; set; }

        public virtual ICollection<Covering> Covering { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
    }
}
