namespace CsSQLT1
{
    class CsSQLT1Main
    {
        static void Main(string[] args)
        {
            ConnectDBT1Class.ConnectDBT1(
                "CREATE TABLE categories (" +
                "`id` int, " +
                "`category` varchar(30), " +
                "PRIMARY KEY (`id`)); " +
                "INSERT INTO categories VALUES " +
                "(1, 'Категория 1'), (2, 'Категория 2'), (3, 'Категория 3')"
                );
            ConnectDBT1Class.ConnectDBT1(
                "CREATE TABLE products (" +
                "`id` int, " +
                "`product` varchar(30), " +
                "PRIMARY KEY (`id`)); " +
                "INSERT INTO products VALUES " +
                "(1, 'Продукт 1'), (2, 'Продукт 2'), (3, 'Продукт 3'), (4, 'Продукт 4'), (5, 'Продукт 5')"
                );
            ConnectDBT1Class.ConnectDBT1(
                "CREATE TABLE prodtocats (" +
                "`product` int, " +
                "`category` int, " +
                "FOREIGN KEY (`product`) REFERENCES products(`id`), " +
                "FOREIGN KEY (`category`) REFERENCES categories(`id`)); " +
                "INSERT INTO prodtocats VALUES " +
                "(1, 3), (2, 1), (2, 2), (2, 3), (3, NULL), (4, 1), (5, 2)"
                );
            ConnectDBT1Class.ConnectDBT1(
                "SELECT products.product, categories.category " +
                "FROM products JOIN prodtocats ON products.id = prodtocats.product " +
                "LEFT JOIN categories ON categories.id = prodtocats.category " +
                "ORDER BY products.product"
                );
        }
    }
}