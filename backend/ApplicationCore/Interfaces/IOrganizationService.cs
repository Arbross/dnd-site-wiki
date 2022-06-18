using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IOrganizationService
    {
        Task Create(Organization organization);
        Task<IEnumerable<Organization>> Get();
        Task<Organization> Get(Guid id);
        Task Update(Organization organization);
        Task Remove(Guid id);
    }
}
