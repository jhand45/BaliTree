using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaliTreeData.Models
{
    public class StockType
    {
        public int Id { get; set; }
        [DisplayName("Type of Good")]
        public string TypeName { get; set; }
        [DisplayName("Average Cost")]
        public decimal? AverageCost { get; set; }
        public decimal? RRP { get; set; }
        [DisplayName("In Stock")]
        public int InStock { get; set; }

    }
}
