using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, int stock)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Ürün adı boş olamaz.");
            if (price <= 0) throw new Exception("Fiyat sıfırdan büyük olmalıdır.");

            Name = name;
            Price = price;
            Stock = stock;
        }

        public void UpdateStock(int quantity)
        {
            int newStock = Stock + quantity;
            if (newStock < 0) throw new Exception("Stok yetersiz!");

            Stock = newStock;
            UpdatedDate = DateTime.Now;
        }
    }
}