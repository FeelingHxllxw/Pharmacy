namespace Pharmacy.Contracts
{
    public record WorkersResponse(
        Guid Id, 
        string Last_Name, 
        string First_Name, 
        string Middle_Name, 
        DateTime Employment_Date,
        DateTime Birth_Date, 
        string Education);
}
