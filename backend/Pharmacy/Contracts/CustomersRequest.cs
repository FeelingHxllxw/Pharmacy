
namespace Pharmacy.Contracts
{
    public record CustomersRequest(
        string Last_Name, 
        string First_Name, 
        string Middle_Name, 
        string Addres, 
        string City, 
        string Phone
        );
}
