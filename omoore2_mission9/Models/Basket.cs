using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace omoore2_mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Book book, int qty, float price)
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


        public virtual void RemoveItem(Book boo)
        {
            Items.RemoveAll(x => x.Book.BookID == boo.BookID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);
            return sum;
        }


    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
