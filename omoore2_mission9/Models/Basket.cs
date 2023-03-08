using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omoore2_mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book book, int qty, float price)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookID == book.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty,
                    Price = price
                }) ;
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);
            return sum;
        }


    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
