using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using TSF.DVDCentral.BL.Models;

namespace BDF.DVDCentral.BL.Models
{
    public class ShoppingCart
    {

        public List<Movie> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }

        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public double TotalCost { get { return Items.Sum(i => i.Cost); } }
        public double Tax { get { return TotalCost * .05; } }
        public double TCt { get { return TotalCost + Tax; } }

        public ShoppingCart()
        {
            Items = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            if (!Items.Any(n => n.Id == movie.Id))
            {
                Items.Add(movie);
            }
            else
            {
                foreach (var item in Items.Where(n => n.Id == movie.Id))
                {
                    item.Quantity++;
                }
            }

            //TotalCost += movie.Cost;
        }

        public void Remove(Movie movie)
        {
            //foreach (var item in Items.Where(n => n.Id == movie.Id))
            //{
            //    TotalCost -= (item.Cost * item.Quantity);
            //}
            Items.Remove(movie);
        }

    }
}
