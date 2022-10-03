namespace ShelestApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agent")]
    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            ProductSale = new HashSet<ProductSale>();
            Shop = new HashSet<Shop>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int AgentTypeID { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string INN { get; set; }

        [StringLength(9)]
        public string KPP { get; set; }

        [StringLength(100)]
        public string DirectorName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public int Priority { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int Discount
        {
            get
            {
                decimal salesSum = 0;
                foreach (ProductSale sale in ProductSale)
                {
                    salesSum += sale.ProductCount * sale.Product.MinCostForAgent;
                }
                if (salesSum < 10000)
                    return 0;
                else if (salesSum > 10000 && salesSum < 50000)
                    return 5;
                else if (salesSum > 50000 && salesSum < 150000)
                    return 10;
                else if (salesSum > 150000 && salesSum < 500000)
                    return 20;
                else if (salesSum > 500000)
                    return 25;
                else return 0;
            }
        }
        public int SalesQtyPerLastYear
        {
            get
            {
                int qty = 0;
                foreach (ProductSale sale in ProductSale)
                {
                    if (sale.SaleDate.Year + 1 > DateTime.Now.Year)
                    {
                        qty += sale.ProductCount;
                    }
                }
                return qty;
            }
        }
        public virtual AgentType AgentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }
    }
}
