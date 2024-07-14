using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public class PeriodDTO
    {
        public int ID { get; set; }
        public required string UserID { get; set; }

        public DateOnly? StartDate { get; set; } // inicio del period
        public DateOnly? EndDate { get; set; } // inicio del periodo

        public int TotalDaysActivesOnAPeriod { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Session>? Sessions { get; set; }
    }
}
