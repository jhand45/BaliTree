using BaliTreeData;
using System;

namespace BaliTreeServices
{
    public class AnalyticsService : IAnalytics
    {
        public int CostPerItem(int costs, int delivered)
        {
            return (costs/delivered);
        }
    }
}
