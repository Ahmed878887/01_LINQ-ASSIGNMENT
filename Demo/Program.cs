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
            #region Q04
            //4. Get the total of the numbers in an array.
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int total = Arr.Sum();

            #endregion
            #region Q05
            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            int totalCharacters = words.Sum(word => word.Length);
            #endregion
            #region Q06
            //6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            int shortestLength = words.Min(word => word.Length);
            #endregion
            #region Q07
            //7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            int longestLength = words.Max(word => word.Length);
            #endregion
            #region Q08
            //8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = File.ReadAllLines("dictionary_english.txt");
            double averageLength = words.Average(word => word.Length);
            #endregion
            #region Q09
            //9. Get the total units in stock for each product category.
                    var categoryStock = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                TotalUnits = g.Sum(p => p.UnitsInStock)
            });
            #endregion
            #region Q10
            //10. Get the cheapest price among each category's products
            var cheapestByCategory = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new {
                    Category = g.Key,
                    CheapestPrice = g.Min(p => p.UnitPrice)
                });
            #endregion
            #region Q11
            //11. Get the products with the cheapest price in each category (Use Let)
            var cheapestProducts = from p in ProductList
                                   group p by p.Category into categoryGroup
                                   let minPrice = categoryGroup.Min(x => x.UnitPrice)
                                   from product in categoryGroup
                                   where product.UnitPrice == minPrice
                                   select new
                                   {
                                       Category = categoryGroup.Key,
                                       Product = product.ProductName,
                                       Price = product.UnitPrice
                                   };
            #endregion


        }
    }
}
