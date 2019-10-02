using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class Side:BaseEntity
    {
        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Ad")]
        public string Name { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}