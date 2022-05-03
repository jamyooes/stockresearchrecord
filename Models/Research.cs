using System.ComponentModel.DataAnnotations;
namespace stockResearchAPI.Models
{
    public class Research
    {
        [Key]
        public int StockId { get; set; }
        public string StockTicker { get; set; }
        public string StockName { get; set; }
        public string Sector { get; set; }
        public string Dilligence { get; set; }
    }
}
