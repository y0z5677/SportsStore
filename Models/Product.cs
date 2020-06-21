using SportsStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreApp.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
