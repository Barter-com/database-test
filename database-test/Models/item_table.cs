//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace database_test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class item_table
    {
        public string itemname { get; set; }
        public Nullable<int> itemownerID { get; set; }
    
        public virtual trader_index trader_index { get; set; }
    }
}