namespace Pharmacy.Contracts
{
    public record RecipesResponse(
        Guid Id,
        Guid Customer_Id,
        string Name,
        DateTime IssueDate,
        string Doctor,
        string Diagnosis);
}
