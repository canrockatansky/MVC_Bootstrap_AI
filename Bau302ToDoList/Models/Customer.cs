using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class Customer:BaseEntity
    {
        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Ad")]
        public string Name { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("E-Posta")]
        public string EMail { get; set; }

        [StringLength(20), DisplayName("Telefon")]
        public string Phone { get; set; }

        [StringLength(20), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Faks")]
        public string Fax { get; set; }

        [StringLength(200), DisplayName("Web Sitesi")]
        public string WebSite { get; set; }

        [StringLength(4000), DisplayName("Adres")]
        public string Address { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}