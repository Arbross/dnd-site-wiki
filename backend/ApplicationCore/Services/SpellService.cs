using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Net;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class SpellService : ISpellsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpellService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Spell spell)
        {
            if (spell == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            if ((await _unitOfWork.SpellRepository.GetAsync()).Any(x => x.Name == spell.Name))
            {
                throw new HttpException("Object already exist.", HttpStatusCode.BadRequest);
            }

            await _unitOfWork.SpellRepository.InsertAsync(spell);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var spell = await _unitOfWork.SpellRepository.GetByIdAsync(id);

            if (spell == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _unitOfWork.SpellRepository.DeleteAsync(spell);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Spell> Get(Guid id)
        {
            var spell = await _unitOfWork.SpellRepository.GetByIdAsync(id);

            if (spell == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            return spell;
        }

        public async Task<IEnumerable<Spell>> Get()
        {
            return await _unitOfWork.SpellRepository.GetAsync();
        }

        public async Task Update(Spell spell)
        {
            _unitOfWork.SpellRepository.Update(spell);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
