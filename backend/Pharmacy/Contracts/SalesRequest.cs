namespace Pharmacy.Contracts
{
    public record SalesRequest(
        DateTime Sale_Date,
        Guid Medicine_Id,
        int Count,
        Guid Recipe_Id,
        Guid WorkerId);
   
}
