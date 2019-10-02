using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DisplayName("Oluşturulan Kullanıcı")]
        public string CreatedBy { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }

    }
}