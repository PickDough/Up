namespace Up.Core.Repositories;

using Common.Dto;

public interface ICompanyRepository
{
    Task<Company> Get();
}
