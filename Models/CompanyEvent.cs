using System.ComponentModel.DataAnnotations;
namespace stockResearchAPI.Models
{
    public class CompanyEvent
    {
        [Key]
        public int StockId { get; set; }
        public string StockTicker { get; set; }
        public string StockName { get; set; }
        public string Headline { get; set; }
        public string HeadlineDate { get; set; }
        public string Impact { get; set; }
    }
}
