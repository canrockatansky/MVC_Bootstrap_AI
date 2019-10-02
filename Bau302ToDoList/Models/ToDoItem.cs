using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bau302ToDoList.Models
{
    public class ToDoItem:BaseEntity
    {
        [StringLength(200), Required(ErrorMessage = "Bu Alan Doldurulmalıdır!"), DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Tanımlama")]
        public string Description { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }

        [DisplayName("Kategori")]
        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [StringLength(200), DisplayName("DosyaEki")]
        public string Attachment { get; set; }

        [DisplayName("Departman")]
        public int? DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [DisplayName("Taraf")]
        public int? SideID { get; set; }
        [ForeignKey("SideID")]
        public virtual Side Side { get; set; }

        [DisplayName("Müşteri")]
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [DisplayName("Yönetici")]
        public int? ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        public virtual Contact Manager { get; set; }

        [DisplayName("Organizatör")]
        public int? OrganizatorID { get; set; }
        [ForeignKey("OrganizatorID")]
        public virtual Contact Organizator { get; set; }

        [DisplayName("Toplantı Tarihi")]
        [DataType("DateTime-Local")]
        [Required(ErrorMessage ="Tarih Girilmelidir!")]
        public DateTime MeetingDate { get; set; }

        [DisplayName("Planlanan Tarih")]
        [DataType("DateTime-Local")]
        [Required(ErrorMessage = "Tarih Girilmelidir!")]
        public DateTime PlannedDate { get; set; }

        [DisplayName("Bitirilme Tarihi")]
        [DataType("DateTime-Local")]
        [Required(ErrorMessage = "Tarih Girilmelidir!")]
        public DateTime FinishDate { get; set; }

        [DisplayName("Revize Tarihi")]
        [DataType("DateTime-Local")]
        [Required(ErrorMessage = "Tarih Girilmelidir!")]
        public DateTime ReviseDate { get; set; }

        [DisplayName("Görüşme Konusu")]
        public string ConversationSubject { get; set; }

        [DisplayName("Destekleyen Firma")]
        public string SupporterCompany { get; set; }

        [DisplayName("Destekleyen Doktor")]
        public string SupporterDoctor { get; set; }

        [DisplayName("Görüşme Katılımcı Sayısı")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public int ConversationAttendeeCount { get; set; }

        [DisplayName("Planlanan Organizasyon Tarihi")]
        [DataType("DateTime-Local")]
        [Required(ErrorMessage = "Tarih Girilmelidir!")]
        public DateTime ScheduledOrganizationDate { get; set; }

        [DisplayName("Mailleşme Konusu")]
        public string MaillingSubject { get; set; }

        [DisplayName("Afiş Konusu")]
        public string PosterSubject { get; set; }

        [DisplayName("Afiş Sayısı")]
        public int PosterCount { get; set; }

        [DisplayName("Uzaktan Eğitim")]
        public string ELearning { get; set; }

        [DisplayName("Tarama Türleri")]
        public string TypesOfScans { get; set; }

        [DisplayName("Taramalardaki Aso Sayısı")]
        public string AsoCountInScans { get; set; }

        [DisplayName("Organizasyon Türleri")]
        public string TypesOfOrganization { get; set; }

        [DisplayName("Organizasyondaki Aso Sayısı")]
        public string AsoCountInOrganization { get; set; }

        [DisplayName("Aşı Organizasyonu Türleri")]
        public string TypesOfVaccinationOrganization { get; set; }

        [DisplayName("Aşı Organizasyonundaki Aso Sayısı")]
        public string AsoCountInVaccinationOrganization { get; set; }

        [DisplayName("Afiş İçin Tazminat Miktarı")]
        public string AmoutOfCompensationForPoster { get; set; }

        [DisplayName("Kurumsal Verimlilik Raporu")]
        public string CorporateProductivityReport { get; set; }
    }
}