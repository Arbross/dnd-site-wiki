using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

namespace Infrastracture.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRepository<User> _userRepository;
        private IRepository<SkillsCha> _skillsChaRepository;
        private IRepository<SkillsDex> _skillsDexRepository;
        private IRepository<SkillsInt> _skillsIntRepository;
        private IRepository<SkillsStr> _skillsStrRepository;
        private IRepository<SkillsWis> _skillsWisRepository;
        private IRepository<Item> _itemRepository;
        private IRepository<Spell> _spellRepository;
        private IRepository<Modificators> _modificatorsRepository;
        private IRepository<Characteristics> _characteristicsRepository;
        private IRepository<Organization> _organizationRepository;
        private IRepository<PlayerList> _playerListRepository;
        private IRepository<Appearance> _appearanceRepository;

        private readonly DatabaseContext context;
        public UnitOfWork(DatabaseContext _context)
        {
            context = _context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(context);
                }

                return _userRepository;
            }
        }
        public IRepository<SkillsCha> SkillsChaRepository
        {
            get
            {
                if (_skillsChaRepository == null)
                {
                    _skillsChaRepository = new Repository<SkillsCha>(context);
                }

                return _skillsChaRepository;
            }
        }
        public IRepository<SkillsDex> SkillsDexRepository
        {
            get
            {
                if (_skillsDexRepository == null)
                {
                    _skillsDexRepository = new Repository<SkillsDex>(context);
                }

                return _skillsDexRepository;
            }
        }
        public IRepository<SkillsInt> SkillsIntRepository
        {
            get
            {
                if (_skillsIntRepository == null)
                {
                    _skillsIntRepository = new Repository<SkillsInt>(context);
                }

                return _skillsIntRepository;
            }
        }
        public IRepository<SkillsStr> SkillsStrRepository
        {
            get
            {
                if (_skillsStrRepository == null)
                {
                    _skillsStrRepository = new Repository<SkillsStr>(context);
                }

                return _skillsStrRepository;
            }
        }
        public IRepository<SkillsWis> SkillsWisRepository
        {
            get
            {
                if (_skillsWisRepository == null)
                {
                    _skillsWisRepository = new Repository<SkillsWis>(context);
                }

                return _skillsWisRepository;
            }
        }
        public IRepository<Item> ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new Repository<Item>(context);
                }

                return _itemRepository;
            }
        }
        public IRepository<Spell> SpellRepository
        {
            get
            {
                if (_spellRepository == null)
                {
                    _spellRepository = new Repository<Spell>(context);
                }

                return _spellRepository;
            }
        }
        public IRepository<Modificators> ModificatorsRepository
        {
            get
            {
                if (_modificatorsRepository == null)
                {
                    _modificatorsRepository = new Repository<Modificators>(context);
                }

                return _modificatorsRepository;
            }
        }
        public IRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new Repository<Organization>(context);
                }

                return _organizationRepository;
            }
        }
        public IRepository<Characteristics> CharacteristicsRepository
        {
            get
            {
                if (_characteristicsRepository == null)
                {
                    _characteristicsRepository = new Repository<Characteristics>(context);
                }

                return _characteristicsRepository;
            }
        }
        public IRepository<PlayerList> PlayerListRepository
        {
            get
            {
                if (_playerListRepository == null)
                {
                    _playerListRepository = new Repository<PlayerList>(context);
                }

                return _playerListRepository;
            }
        }
        public IRepository<Appearance> AppearanceRepository
        {
            get
            {
                if (_appearanceRepository == null)
                {
                    _appearanceRepository = new Repository<Appearance>(context);
                }

                return _appearanceRepository;
            }
        }

        async Task IUnitOfWork.SaveChangesAsync() => await context.SaveChangesAsync();
        void IUnitOfWork.SaveChanges() => context.SaveChanges();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
