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
        }
    }
}
