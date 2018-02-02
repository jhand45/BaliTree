using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaliTreeData.Models
{
    public class StockItem
    {
        public int Id { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Cost Price")]
        public decimal CostPrice { get; set; }

        [DisplayName("Amount Recieved")]
        public int AmountRecieved { get; set; }

        public StockType Type { get; set; }

        public StockEvent Event { get; set; } //each item reflects a different event

//        public virtual ICollection<StockEvent> StockEvent {get; set;}
    }
}
