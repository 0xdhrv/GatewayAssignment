//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sql_demo.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public partial class tbl_product
    {
        public int product_id { get; set; }
        [DisplayName("Name")]
        public string product_name { get; set; }
        [DisplayName("Category")]
        public string product_category { get; set; }
        [DisplayName("Price")]
        public Nullable<long> price { get; set; }
        [DisplayName("Quantity")]
        public Nullable<long> quantity { get; set; }
        [DisplayName("Short Description")]
        public string short_desc { get; set; }
        [DisplayName("Long Description")]
        public string long_desc { get; set; }
        [DisplayName("Small Image")]
        public string small_image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [DisplayName("Long Image")]
        public string large_image { get; set; }
    }
}