﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine
{
    [Table("CityTbl")]
    public class City
    {
        [Key]
        public Int64 CityID {  get; set; }
        public string CityName { get; set; }      
        public Int64 StateID {  get; set; }
        public virtual State State { get; set; }
        public virtual List<CustomerORParty> CustomerORParties { get; set; }
        public virtual List<SupplierORVender> SupplierORVenders { get; set; }
        public virtual List<BillingCompany> BillingCompanies { get; set; }
    }
}
