namespace Pharmacy.Contracts
{
    public record CustomersResponse(
        Guid Id, 
        string Last_Name, 
        string First_Name, 
        string Middle_Name, 
        string Addres, 
        string City, 
        string Phone);
}
