using System;
using System.Collections.Generic;

namespace EV.Fundings.Api.Data.Entities
{
    public partial class Funding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsInvested { get; set; }
        public decimal? InvestmentAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
