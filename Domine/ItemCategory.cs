using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("ItemCategoryTbl")]
    public class ItemCategory
    {
        [Key]
        public Int64 ItemCategoryID {  get; set; }
        public string ItemCategoryName { get; set; }
        public bool ActiveFlag {  get; set; }
        public Int64 BillingCompanyID {  get; set; }
        public  virtual BillingCompany BillingCompany { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
