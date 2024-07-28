using System;
using System.Collections.Generic;

namespace CartrigeAltstar.Model
{
    public class CartrigeModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<CartrigePurchase> CartrigePurchases { get; set; }
        public virtual ICollection<CartrigeIssue> CartrigeIssues { get; set; }

        public CartrigeModel()
        {
            CartrigePurchases = new HashSet<CartrigePurchase>();
            CartrigeIssues = new HashSet<CartrigeIssue>();
        }
    }

    public class CartrigePurchase
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        public virtual CartrigeModel CartrigeModel { get; set; }
    }

    public class CartrigeIssue
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public DateTime IssueDate { get; set; }
        public int Quantity { get; set; }
        public string Department { get; set; }

        public virtual CartrigeModel CartrigeModel { get; set; }
    }
}
