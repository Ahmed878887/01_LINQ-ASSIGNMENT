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
        }
    }
}
