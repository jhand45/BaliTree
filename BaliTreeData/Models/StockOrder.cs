using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaliTreeData.Models
{
    public class StockOrder
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd yyyy}")]
        public DateTime Date { get; set; }
        public virtual ICollection<StockItem> StockItem { get; set; }
        //public int NunberOfStockItems { get; set; }

    }
}
