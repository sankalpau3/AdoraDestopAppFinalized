//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModernUIForWPFSample.WithoutBackButton
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseFab
    {
        public string UserName { get; set; }
        public string FabID { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    
        public virtual Fabric Fabric { get; set; }
        public virtual User User { get; set; }
    }
}
