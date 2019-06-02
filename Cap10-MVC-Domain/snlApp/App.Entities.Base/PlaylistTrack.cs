namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("PlaylistTrack")]
    public partial class PlaylistTrack
    {
        [Key]
        [Column(Order =1)]
        public int PlaylistId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TrackId { get; set; }

        public virtual Track Track{ get; set; }

}
}
