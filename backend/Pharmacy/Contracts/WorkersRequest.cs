
namespace Pharmacy.Contracts
{
    public record WorkersRequest(
        string Last_name,
        string First_Name, 
        string Middle_Name, 
        DateTime Employment_Date, 
        DateTime Birth_Date, 
        string Education
    );
}
