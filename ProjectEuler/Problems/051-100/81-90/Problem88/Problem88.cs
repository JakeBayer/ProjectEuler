using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem88 : IProblem
    {
        private enum ProductSumExists
        {
            True = 1,
            False = -1,
            Unknown = 0,
        };

        private const int MAX_K = 12000;
        private Dictionary<int, Dictionary<int, bool>>[] ProductAndSumGridsByK = new Dictionary<int, Dictionary<int, bool>>[MAX_K + 1];
        
        public Problem88()
        {
            for (int i = 0; i < ProductAndSumGridsByK.Count(); i++)
            {
                ProductAndSumGridsByK[i] = new Dictionary<int, Dictionary<int, bool>>();
            }
        }

        private bool ProductSumOfSizeKExists(int k, int sum, int product)
        {
            if (sum < k || sum > product + k -1)
            {
                return false;
            }
            if (k == 1)
            {
                return sum == product;
            }
            if (sum - k + 1 == product)
            {
                return true;
            }

            var productSumGrid = ProductAndSumGridsByK[k];
            if (!productSumGrid.ContainsKey(product))
            {
                productSumGrid.Add(product, new Dictionary<int, bool>());
            }

            var sumList = productSumGrid[product];
            if (sumList.ContainsKey(sum))
            {
                return sumList[sum];
            }

            int a = 2;
            while (a <= k)
            {
                if (product % a == 0 && ProductSumOfSizeKExists(k - 1, sum - a, product / a))
                {
                    sumList.Add(sum, true);
                    return true;
                }
                a++;
            }
            sumList.Add(sum, false);
            return false;
        }



        public string Run()
        {
            List<int> minProdSums = new List<int>();
            for (int k = 2; k <= MAX_K; k++)
            {
                for (int m = k; m <= 2*k; m++)
                {
                    if (ProductSumOfSizeKExists(k, m, m))
                    {
                        minProdSums.Add(m);
                        break;
                    }
                }
            }

            return minProdSums.Distinct().Sum().ToString();
        }
    }
}
