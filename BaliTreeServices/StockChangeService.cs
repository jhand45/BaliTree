using System;
using System.Collections.Generic;
using System.Text;
using BaliTreeData;
using BaliTreeData.Models;

namespace BaliTreeServices
{
    public class StockChangeService : IStockChanges
    {
        private BaliTreeContext _context;

        public StockChangeService(BaliTreeContext context)
        {
            _context = context;
        }




        public static int Add(int Existing, int ToAdd)
        {
            return (Existing + ToAdd);
        }

        public static int Subtract(int Existing, int ToRemove)
        {
            return (Existing - ToRemove);
        }

        public int Adjusted(int Existing, int Adjusted)
        {
            return Add(Existing, Adjusted);
        }

        public int Broken(int Existing, int Broken)
        {
            return Subtract(Existing, Broken);
        }

        public int Recieved(int Existing, int Recieved)
        {
            return Add(Existing, Recieved);
        }

        public int Sold(int Existing, int Sold)
        {
            return Subtract(Existing, Sold);
        }

        public IEnumerable<StockType> GetAllStockTypes()
        {
            return _context.StockTypes;
        }
    }
}

