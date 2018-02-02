using System;
using System.Collections.Generic;
using System.Text;

namespace BaliTreeData.Models
{
    public class StockEvent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public StockItem StockItem { get; set; }
        public Event EventType { get; set; }
        public int Change { get; set; } //number being added to taken, will need math functions for this
    }

    public enum Event
    {
        Recieved,
        Sold,
        Broken,
        Adjustment
    }
}
