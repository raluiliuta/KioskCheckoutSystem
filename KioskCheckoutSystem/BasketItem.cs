namespace KioskCheckoutSystem
{
    public class BasketItem
    {
        public string ProductName { get; set; }
        public float Quantity { get; set; }

        public BasketItem(string name, float quantity)
        {
            ProductName = name;
            Quantity = quantity;
        }
    }
}
