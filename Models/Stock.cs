using System.ComponentModel.DataAnnotations;
namespace stockResearchAPI.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public string StockTicker { get; set; }
        public string StockName {get; set;}

        public CompanyEvent CompanyEvent { get; set; }
        public Research Research { get; set; }
    }
}
