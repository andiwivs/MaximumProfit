using System;

namespace Thomas.MaximumProfit.Core
{
    public class ProfitEvaluator
    {

        public int GetMaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2)
                return 0;

            int firstProfit = prices[1] - prices[0];
            int maxProfit = firstProfit;
            int profit;

            for (int i = 0; i < prices.Length; i++)
            {
                profit = GetMaxProfitByOrdinal(prices, firstProfit, i);
                maxProfit = Math.Max(maxProfit, profit);
            }

            return maxProfit;
        }

        private int GetMaxProfitByOrdinal(int[] prices, int firstProfit, int ordinal)
        {
            int ordinalMax = firstProfit;
            int profit;

            for (int i = ordinal + 1; i < prices.Length; i++)
            {
                profit = prices[i] - prices[ordinal];
                ordinalMax = Math.Max(ordinalMax, profit);
            }

            return ordinalMax;
        }
    }
}
