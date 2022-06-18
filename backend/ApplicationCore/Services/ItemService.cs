using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Net;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Item item)
        {
            if (item == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            if ((await _unitOfWork.ItemRepository.GetAsync()).Any(x => x.Name == item.Name))
            {
                throw new HttpException("Object already exist.", HttpStatusCode.BadRequest);
            }

            await _unitOfWork.ItemRepository.InsertAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var spell = await _unitOfWork.ItemRepository.GetByIdAsync(id);

            if (spell == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _unitOfWork.ItemRepository.DeleteAsync(spell);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Item> Get(Guid id)
        {
            var item = await _unitOfWork.ItemRepository.GetByIdAsync(id);

            if (item == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            return item;
        }

        public async Task<IEnumerable<Item>> Get()
        {
            return await _unitOfWork.ItemRepository.GetAsync();
        }

        public async Task Update(Item item)
        {
            _unitOfWork.ItemRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
