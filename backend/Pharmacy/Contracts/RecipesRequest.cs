namespace Pharmacy.Contracts
{
    public record RecipesRequest(
        Guid Customer_Id,
        DateTime IssueDate,
        string Doctor,
        string Diagnosis
    );
}
