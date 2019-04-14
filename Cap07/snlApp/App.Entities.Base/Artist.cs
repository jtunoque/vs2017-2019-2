namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
    using System.Runtime.Serialization;

    [DataContract]
=======
   

>>>>>>> 649f73f661e41431d5a0ac1513b7ed345cf432b6
    [Table("Artist")]
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            Album = new HashSet<Album>();
        }

<<<<<<< HEAD
        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
=======
        public int ArtistId { get; set; }

>>>>>>> 649f73f661e41431d5a0ac1513b7ed345cf432b6
        [StringLength(120)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album> Album { get; set; }
    }
}
