using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Net;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class PlayerListService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PlayerList>> Get()
        {
            return await _unitOfWork.PlayerListRepository.GetAsync();
        }

        public async Task<PlayerList> Get(Guid id)
        {
            return await _unitOfWork.PlayerListRepository.GetByIdAsync(id);
        }

        public async Task Create(PlayerList playerList)
        {
            if (playerList == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            var obj = await _unitOfWork.PlayerListRepository.GetByIdAsync(playerList.Id);

            if (obj != null)
            {
                throw new HttpException("Object already exist.", HttpStatusCode.BadRequest);
            }

            await _unitOfWork.PlayerListRepository.InsertAsync(playerList);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(PlayerList playerList)
        {
            if (playerList == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            var obj = await _unitOfWork.PlayerListRepository.GetByIdAsync(playerList.Id);

            if (obj == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            _unitOfWork.PlayerListRepository.Update(playerList);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var obj = await _unitOfWork.PlayerListRepository.GetByIdAsync(id);

            if (obj == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _unitOfWork.PlayerListRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
