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
        }
    }
}
