using System;
using System.Collections.Generic;

namespace TravelAgencyWebApi.Models
{
    public partial class Covering
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; }
    }
}
