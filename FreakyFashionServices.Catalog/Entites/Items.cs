namespace FreakyFashionServices.Catalog.Entites
{
    public class Items
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal availableStock { get; protected set; }

        public Items(string name, string description, decimal price, decimal availableStock)
        {
            Name = name;
            Description = description;
            Price = price;
            this.availableStock = availableStock;
        }

        public Items(int id, string name, string description, decimal price, decimal availableStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            this.availableStock = availableStock;
        }
    }
}
