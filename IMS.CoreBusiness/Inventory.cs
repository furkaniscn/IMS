﻿using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        [Required]
        [StringLength(150)]
        public string InventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0")]
        public int InventoryQuantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
        public double InventoryPrice { get; set; }
    }
}
