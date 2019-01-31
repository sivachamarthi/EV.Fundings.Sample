using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Models.ResourceModels
{
    public class FundingModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsInvested { get; set; }

        [Required]
        [Range(100, 10000)]
        public decimal? InvestmentAmount { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
