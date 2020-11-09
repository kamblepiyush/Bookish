using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookish.Models;

namespace Bookish.ViewModel
{
    public class RandomViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}