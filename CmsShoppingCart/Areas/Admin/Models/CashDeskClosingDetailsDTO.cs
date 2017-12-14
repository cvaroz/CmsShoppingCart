using CmsShoppingCart.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CmsShoppingCart.Areas.Admin.Models
{
    [Table("tblCashDeskClosingDetails")]
    public class CashDeskClosingDetailsDTO
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CashDeskClosingId { get; set; }

                

        [ForeignKey("OrderId")]
        public virtual OrderDetailsDTO Orders { get; set; }
        [ForeignKey("UserId")]
        public virtual UserDTO Users { get; set; }
        [ForeignKey("CashDeskClosingId")]
        public virtual CashDeskClosingDTO CashDesksClosing { get; set; }

    }
}