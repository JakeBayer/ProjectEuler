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
        private List<List<ProductSumExists>>[] ProductAndSumGridsByK = new List<List<ProductSumExists>>[MAX_K + 1];
        
        public Problem88()
        {
            for (int i = 0; i < ProductAndSumGridsByK.Count(); i++)
            {
                ProductAndSumGridsByK[i] = new List<List<ProductSumExists>>();
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

            var productSumGrid = ProductAndSumGridsByK[k];
            while (productSumGrid.Count <= product)
            {
                productSumGrid.Add(new List<ProductSumExists>());
            }

            var sumList = productSumGrid[product];
            while (sumList.Count <= sum - k)
            {
                sumList.Add(ProductSumExists.Unknown);
            }

            if (sumList[sum - k] == ProductSumExists.True) return true;
            if (sumList[sum - k] == ProductSumExists.False) return false;

            int a = 1;
            while (a <= k)
            {
                if (product % a == 0 && ProductSumOfSizeKExists(k - 1, sum - a, product / a))
                {
                    sumList[sum - k] = ProductSumExists.True;
                    return true;
                }
                a++;
            }
            sumList[sum - k] = ProductSumExists.False;
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
