using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Tengo un DayOfPeriod configurado para 
    ///  cada dia dentro del periodo.
    /// Multiples Period a 1 Season
    /// </summary>
    public class Period
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "User ID")]
        public required string UserID { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; } // inicio del period

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? EndDate { get; set; } // inicio del periodo

        /// <summary>
        /// Este valor representa con un numero entero, la cantidad
        ///  de dias, dentro del periodo, donde se agenda una actividad.
        /// </summary>
        [Required]
        public int TotalDaysActivesOnAPeriod { get; set; }

        [Required]
        public Status Status { get; set; }


        [ForeignKey("PeriodID")]        
        public virtual ICollection<Session>? Sessions { get; set; }
    }
}
