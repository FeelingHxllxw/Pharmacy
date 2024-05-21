namespace Pharmacy.Contracts
{
    public record SalesResponse(
        Guid Id,
        DateTime Sale_Date,
        Guid Medicine_Id,
        string Medicine,
        int Count,
        Guid Recipe_Id,
        string Diagnosis,
        Guid WorkerId,
        string Name);
}
