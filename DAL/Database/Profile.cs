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
    
    public partial class Profile
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string bio { get; set; }
        public string dp { get; set; }
        public string instagram { get; set; }
        public string linkedin { get; set; }
        public string github { get; set; }
    
        public virtual User User { get; set; }
    }
}
