using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Havbruksloggen.CodingChallenge.Core.UnitTests.Infrastructure
{
    internal static class EnumerableExtensions
    {
        public static Mock<DbSet<TEntity>> GetMockDbSet<TEntity>(this IEnumerable<TEntity> source)
            where TEntity : class
        {
            return source.AsQueryable().BuildMockDbSet();
        }

        public static DbSet<TEntity> GetMockDbSetObject<TEntity>(this IEnumerable<TEntity> source)
            where TEntity : class
        {
            return source.GetMockDbSet().Object;
        }
    }
}
