//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Token
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public string token1 { get; set; }
        public bool expired { get; set; }
    
        public virtual User User { get; set; }
    }
}
