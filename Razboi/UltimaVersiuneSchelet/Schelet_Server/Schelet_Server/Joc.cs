//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schelet_Server
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class Joc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joc()
        {
            this.JocJucators = new HashSet<JocJucator>();
        }
    
        public int id { get; set; }
        public Nullable<int> castigator { get; set; }
        public string carticastigator { get; set; }
        public string listcartidisponibi { get; set; }
        public Nullable<int> rand { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JocJucator> JocJucators { get; set; }
    }
}
