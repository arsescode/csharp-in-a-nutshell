using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4.Classes
{
    // Delegate for the event
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    // Publisher class
    public class Stock
    {
        public string Symbol { get; }
        private decimal price;

        // Event declaration
        public event PriceChangedHandler PriceChanged;

        public Stock(string symbol, decimal initialPrice)
        {
            Symbol = symbol;
            price = initialPrice;
        }

        // Property to update the price and raise the event
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    decimal oldPrice = price;
                    price = value;

                    // Raising the event
                    PriceChanged?.Invoke(oldPrice, price);
                }
            }
        }
    }

    // Subscriber class
    public class StockDisplay
    {
        public void Subscribe(Stock stock)
        {
            stock.PriceChanged += OnPriceChanged;
        }
        public void UnSubscribe(Stock stock)
        {
            stock.PriceChanged -= OnPriceChanged;
        }

        // Event handler method
        private void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"Stock price changed from {oldPrice:C} to {newPrice:C}");
        }
    }
}
