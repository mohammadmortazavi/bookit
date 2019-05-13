using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookit.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public int Price { get; set; }

        public string Author { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
    }
}
