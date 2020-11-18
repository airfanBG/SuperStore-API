using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels
{
    public class TopSellerDto
    {
        public string SellerNumber { get; set; }
        public string Sellername { get; set; }
        public int TotalSelled { get; set; }
        public DateTime Date { get; set; }
    }
}
