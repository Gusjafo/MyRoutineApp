namespace Domain.Enums
{
    public enum Duration
    {
        day,
        week,
        two_weeks,
        three_weeks,
        month,
        two_months,
        quarter,            // three months
        semester,           // six month
        year
    }

    public enum Status
    {
        IsActive = 1,       // iniciado
        IsInactive = 0,     // guardado para posterior uso o completado
    }
}
