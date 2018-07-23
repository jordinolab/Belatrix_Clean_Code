using CleanCode._12_FullRefactoring.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode._12_FullRefactoring
{
    public class PostEntityRepository
    {
        private readonly PostEntityDbContext _dbContext;

        public PostEntityRepository()
        {

            _dbContext = new PostEntityDbContext();
        }

        public PostEntity GetPostEntity(int id)
        {
            return _dbContext.Posts.SingleOrDefault(p => p.Id == id);
        }

        public void SaveChanges(PostEntity entity)
        {
            _dbContext.Posts.Add(entity);
            _dbContext.SaveChanges();
        }

        #region Helpers

        public class DbSet<T> : IQueryable<T>
        {
            public void Add(T entity)
            {
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public Expression Expression
            {
                get { throw new NotImplementedException(); }
            }

            public Type ElementType
            {
                get { throw new NotImplementedException(); }
            }

            public IQueryProvider Provider
            {
                get { throw new NotImplementedException(); }
            }
        }

        public class PostEntityDbContext
        {
            public DbSet<PostEntity> Posts { get; set; }

            public void SaveChanges()
            {
            }
        }

        #endregion
    }
}
