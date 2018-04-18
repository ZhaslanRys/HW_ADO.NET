using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_ADO.NET
{
    public class Order
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int ShopperId { get; set; }
        public int Price { get; set; }
        public DateTime DateTransaction { get; set; }
    }
}
