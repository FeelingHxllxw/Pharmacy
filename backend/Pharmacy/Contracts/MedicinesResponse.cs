namespace Pharmacy.Contracts
{
    public record MedicinesResponse(
        Guid code,
        string name,
        string type,
        string category,
        decimal price);
}
