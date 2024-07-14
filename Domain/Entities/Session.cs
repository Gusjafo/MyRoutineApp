using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// La sesion es única y va a contener la 
    ///  cantidad diaria de sets.
    /// Voy a crear una sesion cada vez que el 
    ///  usuario va a entrenar.
    /// Voy a crear una sesion para configurar 
    ///  un plan donde 'CreationDate' será nulo.
    /// </summary>
    public class Session
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "User ID")]
        public required string UserID { get; set; }


        /// <summary>
        /// Siendo 'CreationDate' nula, esta indicando que 
        ///  es configuración.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? CreationDate { get; set; }

        /// <summary>
        /// Esta propiedad registra el numero del dia
        ///  dentro del periodo donde se realizo actividad.
        ///  EJemplo: periodo con 'TotalDaysActivesOnAPeriod' = 4
        ///   el tercer dia de actividad sería => 'DayOfThePeriod' = 3
        /// </summary>
        [Required]
        public required int DayOfThePeriod { get; set; }


        /// <summary>
        /// PeriodID puede estar asociada a un periodo en particular
        ///  o ser 'nula', indicando que es configuracion.
        /// </summary>
        [ForeignKey("Period")]
        public int? PeriodID { get; set; }
        [JsonIgnore]
        public virtual Period? Period { get; set; }


        [ForeignKey("SessionID")]
        public virtual ICollection<Item>? Items { get; set; }
    }
}
