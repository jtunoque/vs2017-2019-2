using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    [DataContract]
    public class ConsultaTracks
    {
        [DataMember]
        public int TrackId { get; set; }
        [DataMember]
        public string TrackName { get; set; }
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public string AlbumTitle { get; set; }
        [DataMember]
        public int MediaTypeId { get; set; }
        [DataMember]
        public string MediaTypeName { get; set; }
        [DataMember]
        public int GenreId { get; set; }
        [DataMember]
        public string GenreName { get; set; }
        [DataMember]
        public string Composer { get; set; }
        [DataMember]
        public int Milliseconds { get; set; }
        [DataMember]
        public int Bytes { get; set; }
        [DataMember]
        public string ArtistName { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public DateTime FechaConsulta { get; set; }
    }
}
