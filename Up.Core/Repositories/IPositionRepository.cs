namespace Up.Core.Repositories;

using Common.Dto;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetAll();
}
