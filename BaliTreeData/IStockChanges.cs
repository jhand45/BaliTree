using BaliTreeData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaliTreeData
{
    public interface IStockChanges
    {
        int Recieved (int Existing, int Recieved);
        int Sold(int Existing, int Sold);
        int Broken(int Existing, int Broken);
        int Adjusted(int Existing, int Current);

        IEnumerable<StockType> GetAllStockTypes();
    }
}
