using System;
namespace stockResearchAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }

        public string statusDescription { get; set; }

        public List<Stock> stock { get; set; } = new List<Stock> { };

    }
}
