using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheaterAdmin.Infrastructure.Persistence;
using TheaterAdmin.Domain.Common;
using TheaterAdmin.Infrastructure.Persistence.Common;
using AutoMapper;

namespace TheaterAdmin.Infrastructure.Repositories
{
    public class RepositoryBase<InfrastructureEntity, DomainEntity>
        where DomainEntity : BaseDomainEntity
        where InfrastructureEntity : BaseInfraestructureEntity
    {
        protected readonly TheaterDbContext _context;
        private readonly IMapper _mapper;

        public RepositoryBase(TheaterDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<DomainEntity>> GetAllAsync()
        {
            var list = await _context.Set<InfrastructureEntity>().ToListAsync();
            return _mapper.Map<List<DomainEntity>>(list);
        }

        internal async Task<IReadOnlyList<DomainEntity>> GetAsync(Expression<Func<InfrastructureEntity, bool>> predicate)
        {
            var list = await _context.Set<InfrastructureEntity>().Where(predicate).ToListAsync();
            return _mapper.Map<List<DomainEntity>>(list);
        }

        internal async Task<IReadOnlyList<DomainEntity>> GetAsync(Expression<Func<InfrastructureEntity, bool>> predicate = null,
                                       Func<IQueryable<InfrastructureEntity>, IOrderedQueryable<InfrastructureEntity>> orderBy = null,
                                       string includeString = null,
                                       bool disableTracking = true)
        {
            IQueryable<InfrastructureEntity> query = _context.Set<InfrastructureEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return _mapper.Map<IReadOnlyList<DomainEntity>>(await orderBy(query).ToListAsync());


            return _mapper.Map<IReadOnlyList<DomainEntity>>(await query.ToListAsync());
        }

        internal async Task<IReadOnlyList<DomainEntity>> GetAsync(Expression<Func<InfrastructureEntity, bool>> predicate = null,
                                     Func<IQueryable<InfrastructureEntity>, IOrderedQueryable<InfrastructureEntity>> orderBy = null,
                                     List<Expression<Func<InfrastructureEntity, object>>> includes = null,
                                     bool disableTracking = true)
        {

            IQueryable<InfrastructureEntity> query = _context.Set<InfrastructureEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return _mapper.Map<IReadOnlyList<DomainEntity>>(await orderBy(query).ToListAsync());


            return _mapper.Map<IReadOnlyList<DomainEntity>>(await query.ToListAsync());
        }

        public virtual async Task<DomainEntity> GetByIdAsync(int id)
        {
            InfrastructureEntity entity = await _context.Set<InfrastructureEntity>().FindAsync(id);

            return _mapper.Map<DomainEntity>(entity);
        }

        public async Task<DomainEntity> AddAsync(DomainEntity entity)
        {
            var entityMapped = _mapper.Map<InfrastructureEntity>(entity);
            _context.Set<InfrastructureEntity>().Add(entityMapped);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public async Task<DomainEntity> UpdateAsync(DomainEntity entity)
        //{
        //    _context.Entry(_mapper.Map<InfrastructureEntity>(entity)).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}

        public async Task DeleteAsync(DomainEntity entity)
        {
            _context.Set<InfrastructureEntity>().Remove(_mapper.Map<InfrastructureEntity>(entity));
            await _context.SaveChangesAsync();
        }

    }
}
