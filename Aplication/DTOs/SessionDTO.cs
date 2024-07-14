using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTOs
{
    public class SessionDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "User ID")]
        public required string UserID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? CreationDate { get; set; }

        public int DayOfThePeriod { get; set; }

        public int? PeriodID { get; set; }

        public virtual ICollection<Item>? Items { get; set; }
    }
}
