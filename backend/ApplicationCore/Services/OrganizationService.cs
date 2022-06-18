using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Net;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Organization organization)
        {
            if (organization == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            if ((await _unitOfWork.OrganizationRepository.GetAsync()).Any(x => x.Name == organization.Name))
            {
                throw new HttpException("Object already exist.", HttpStatusCode.BadRequest);
            }

            await _unitOfWork.OrganizationRepository.InsertAsync(organization);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(id);

            if (organization == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _unitOfWork.OrganizationRepository.DeleteAsync(organization);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Organization> Get(Guid id)
        {
            var organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(id);

            if (organization == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            return organization;
        }

        public async Task<IEnumerable<Organization>> Get()
        {
            return await _unitOfWork.OrganizationRepository.GetAsync();
        }

        public async Task Update(Organization organization)
        {
            _unitOfWork.OrganizationRepository.Update(organization);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
