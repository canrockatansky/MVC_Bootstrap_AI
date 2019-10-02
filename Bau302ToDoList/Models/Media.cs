using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class Media:BaseEntity
    {
        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Ad")]
        public string Name { get; set; }

        [DisplayName("Tanımlama")]
        public string Description { get; set; }

        [StringLength(200), DisplayName("Uzantı")]
        public string Extention { get; set; }

        [StringLength(200), DisplayName("Dosya Yolu")]
        public string FilePath { get; set; }

        [DisplayName("Dosya Boyutu")]
        public float FileSize { get; set; }

        [DisplayName("Yıl")]
        public int Year { get; set; }

        [DisplayName("Ay")]
        public int Month { get; set; }

        [StringLength(200), DisplayName("İçerik Tipi")]
        public string ContentType { get; set; }
    }
}