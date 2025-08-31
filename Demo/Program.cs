using System.Diagnostics.Metrics;

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
            #region Q12
            //12. Get the most expensive price among each category's products.

                    var expensiveByCategory = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                MostExpensive = g.Max(p => p.UnitPrice)
            });

            #endregion
            #region Q13
            //13. Get the products with the most expensive price in each category.
            var expensiveProducts = from p in ProductList
                                    group p by p.Category into categoryGroup
                                    let maxPrice = categoryGroup.Max(x => x.UnitPrice)
                                    from product in categoryGroup
                                    where product.UnitPrice == maxPrice
                                    select new
                                    {
                                        Category = categoryGroup.Key,
                                        Product = product.ProductName,
                                        Price = product.UnitPrice
                                    };

            #endregion
            #region Q14
            //14. Get the average price of each category's products.
                    var averagePriceByCategory = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new {
                Category = g.Key,
                AveragePrice = g.Average(p => p.UnitPrice)
            });

            #endregion
            #region LINQ - Ordering Operators
            //1. Sort a list of products by name
            var sortedProducts = ProductList
              .OrderBy(p => p.ProductName);
            #endregion
            
            #region Q02
            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var caseInsensitiveSort = Arr
                .OrderBy(word => word, StringComparer.OrdinalIgnoreCase);

            // Alternative using query syntax
            var caseInsensitiveSort = from word in Arr
                                      orderby word.ToLower()
                                      select word;
            #endregion
            #region Q03
            //3. Sort a list of products by units in stock from highest to lowest.
            var productsByStock = ProductList
            .OrderByDescending(p => p.UnitsInStock);

            #endregion
            #region Q04 
            //4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string [] Arr = {“zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine”};
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word);

            // Alternative using query syntax
            var sortedDigits = from word in Arr
                               orderby word.Length, word
                               select word;
            #endregion
            #region Q05
            //5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            //String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

            // Alternative using query syntax
            var sortedWords = from word in Arr
                              orderby word.Length, word.ToLower()
                              select word;
            #endregion
            #region Q06
            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var sortedProducts = ProductList
       .OrderBy(p => p.Category)
       .ThenByDescending(p => p.UnitPrice);

            // Alternative using query syntax
            var sortedProducts = from p in ProductList
                                 orderby p.Category, p.UnitPrice descending
                                 select p;

            #endregion
            #region Q07
            //7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            //String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(word => word.Length)
                .ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);

            // Alternative using query syntax
            var sortedWords = from word in Arr
                              orderby word.Length, word.ToLower() descending
                              select word;

            #endregion
            #region Q08

            // 8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            //string [] Arr = {“zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine”};
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = Arr
                .Where(word => word.Length > 1 && word[1] == 'i')  // Filter words with second letter 'i'
                .Reverse();                                         // Reverse the order

        
            // Using query syntax
            var result = from word in Arr
                         where word.Length > 1 && word[1] == 'i'
                         select word into filteredWord
                         orderby filteredWord descending  
                         select filteredWord;

            
            var filteredWords = Arr.Where(word => word.Length > 1 && word[1] == 'i').ToList();
            var reversedResult = filteredWords.AsEnumerable().Reverse();


            #endregion
            #region LINQ – Transformation Operators
            //1. Return a sequence of just the names of a list of products.
            var productNames = ProductList
             .Select(p => p.ProductName);
            #endregion
            #region Q02 
            //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            var wordCases = from word in words
                            select new
                            {
                                Original = word,
                                Uppercase = word.ToUpper(),
                                Lowercase = word.ToLower()
                            };
            #endregion

        }
    }
}
