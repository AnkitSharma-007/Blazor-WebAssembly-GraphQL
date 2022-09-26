using System;
using System.Collections.Generic;

namespace BlazorWithGraphQL.Server.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
    }
}
