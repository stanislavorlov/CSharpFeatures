namespace CSharp9Demo
{
    internal sealed class PatternMatching
    {
        public static void Run()
        {
            var tax = GetTax(6);                        //10
            var tax2 = GetTax2(4);                      //5
            var discount = GetDiscount(new Book());     //0
            var discount2 = GetDiscount(new Product()); //25
            var price = GetPrice(new Product());        //25
            var price2 = GetPrice(new Book());          //0
        }

        //Relational patterns
        private static int GetTax(int categoryId) => categoryId switch
        {
            1 => 0,
            < 5 => 5,
            > 20 => 15,
            _ => 10
        };

        //Logical patterns (and/or)
        private static int GetTax2(int caterogyId) => caterogyId switch
        {
            0 or 1 => 0,
            > 1 and < 5 => 5,
            > 20 => 15,
            _ => 10
        };

        //Logical patterns (not)
        private static int GetDiscount(Product p)
        {
            if (p is not Book)
                return 25;

            return 0;
        }

        //Type patterns
        private static int GetPrice(Product p) => p switch
        {
            Book => 0,      //Book _ => 0 before c# 9
            _ => 25
        };

        public class Product
        {
            public string Name { get; set; }
            public int CategoryId { get; set; }
        }

        public class Book : Product
        {
            public string ISBN { get; set; }
        }
    }
}
