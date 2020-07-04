namespace Havbruksloggen.CodingChallenge.Core.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext>
        where TEntity : class
        where TContext: class
    {
        protected TContext DbContext { get; }

        public RepositoryBase(TContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
