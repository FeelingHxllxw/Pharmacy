
namespace Pharmacy.Contracts
{
    public record MedicinesRequest(
        string name,
        string type,
        string category,
        decimal price);
}
