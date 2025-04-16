using Domine.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("ItemTbl")]
    public class Item
    {
        [Key]
        public Int64 ItemID {  get; set; }
        public string ItemName {  get; set; }
        public string ItemDescription { get; set; }
        public string ItemCode {  get; set; }
        public string MobileNumber {  get; set; }    
       public Int64 UnitID {  get; set; }
        public virtual Unit Unit { get; set; }
        public bool IsActive {  get; set; }
        public IsProductOrServiceEnum IsProductOrService { get; set; }
        public virtual List<SalesInvoiceDet> SalesInvoiceDets { get; set; }
        public Int64 ItemCategoryID {  get; set; }
        public virtual ItemCategory ItemCategory { get; set; }  
        public virtual List<PurchaseOrderDet> PurchaseOrderDets { get; set; }




    }
}
