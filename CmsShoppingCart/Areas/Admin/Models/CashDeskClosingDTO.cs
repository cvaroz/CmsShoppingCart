using CmsShoppingCart.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CmsShoppingCart.Areas.Admin.Models
{
    [Table("tblCashDeskClosing")]
    public class CashDeskClosingDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public virtual UserDTO Users { get; set; }
    }
}
