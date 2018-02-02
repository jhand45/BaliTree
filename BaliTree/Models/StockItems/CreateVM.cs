using BaliTreeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaliTree.Models.StockItems
{
    public class CreateVM
    {
        public StockItem StockItem { get; set; }
//        public StockEvent StockEvent { get; set; }
        public IEnumerable<StockType> AllTypes { get; set; }
    }
}
