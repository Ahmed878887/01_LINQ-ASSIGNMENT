namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Element Operators

            //1. Get first Product out of Stock 
            var firstOutOfStockProduct = ProductList
             .FirstOrDefault(p => p.UnitsInStock == 0);


            #endregion
            #region Q02
            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is 

            var expensiveProduct = ProductList
             .FirstOrDefault(p => p.UnitPrice > 1000);
            #endregion
            #region Q03
            //3. Retrieve the second number greater than 5 
            //Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var secondNumberGreaterThan5 = Arr
            .Where(n => n > 5)
            .OrderBy(n => n)
            .ElementAt(1);
            #endregion
            #region LINQ - Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array
            //Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddCount = Arr.Count(n => n % 2 != 0);
            #endregion

            #region Q02
            //2. Return a list of customers and how many orders each has.

            var customerOrderCounts = CustomerList
    .Select(c => new {
        Customer = c.CompanyName,
        OrderCount = c.Orders.Count()
    });
            #endregion

            #region Q03
            //3. Return a list of categories and how many products each has

            var categoryProductCounts = ProductList
    .GroupBy(p => p.Category)
    .Select(g => new {
        Category = g.Key,
        ProductCount = g.Count()
    });
            #endregion
        }
    }
}
