using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class Contact:BaseEntity
    {
        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Ad")]
        public string FirstName { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Soyad")]
        public string LastName { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("E-Posta")]
        public string EMail { get; set; }

        [StringLength(20), DisplayName("Telefon")]
        public string Phone { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }

    }
}