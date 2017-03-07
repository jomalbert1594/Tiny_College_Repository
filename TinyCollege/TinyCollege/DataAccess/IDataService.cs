using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Nito.AsyncEx;
using TinyCollege.DataAccess.Ef;

namespace TinyCollege.DataAccess
{
    public interface IDataService<T> where T: class
    {
        void Add(T record);
        Task AddAsync(T record);
        Task AddAsync(T record, CancellationToken token);

        void AddRange(List<T> records);
        Task AddRangeAsync(List<T> records);
        Task AddRangeAsync(List<T> records, CancellationToken token);

        void Remove(T record);
        Task RemoveAsync(T record);
        Task RemoveAsync(T record, CancellationToken token);

        void RemoveRange(List<T> records);
        Task RemoveRangeAsync(List<T> records);
        Task RemoveRangeAsync(List<T> records, CancellationToken token);

        void Update(T record);
        Task UpdateAsync(T record);
        Task UpdateAsync(T record, CancellationToken token);

        void UpdateRange(List<T> records);
        Task UodateRangeAsync(List<T> records);
        Task UodateRangeAsync(List<T> records, CancellationToken token);

        T Get(Expression<Func<T, bool>> condition);
        Task<T> GetAsync(Expression<Func<T, bool>> condition);
        Task<T> GetAsync(Expression<Func<T, bool>> condition, CancellationToken token);


        List<T> GetRange(Expression<Func<T, bool>> condition);
        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition);
        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken token);

        List<T> GetRange();
        Task<List<T>> GetRangeAsync();
        Task<List<T>> GetRangeAsync(CancellationToken token);
    }


    public class EfDataService<T> : IDataService<T> where T : class, new()
    {
        public void Add(T record)
        {
            using (var context = new TinyCollegeContext())
            {
                context.Entry(record).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Task AddAsync(T record)
        {
            return AddAsync(record, CancellationToken.None);
        }

        public async Task AddAsync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    context.Entry(record).State = EntityState.Added;
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public void AddRange(List<T> records)
        {
            using (var context = new TinyCollegeContext())
            {
                foreach (var record in records)
                {
                    context.Entry(record).State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public Task AddRangeAsync(List<T> records)
        {
            return AddRangeAsync(records, CancellationToken.None);
        }

        public async Task AddRangeAsync(List<T> records, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    foreach (var record in records)
                    {
                        context.Entry(record).State = EntityState.Added;
                    }
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public void Remove(T record)
        {
            using (var context = new TinyCollegeContext())
            {
                context.Entry(record).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Task RemoveAsync(T record)
        {
            return RemoveAsync(record, CancellationToken.None);
        }

        public async Task RemoveAsync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    context.Entry(record).State = EntityState.Deleted;
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public void RemoveRange(List<T> records)
        {
            using (var context = new TinyCollegeContext())
            {
                foreach (var record in records)
                {
                    context.Entry(record).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public Task RemoveRangeAsync(List<T> records)
        {
            return RemoveRangeAsync(records, CancellationToken.None);
        }

        public async Task RemoveRangeAsync(List<T> records, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    foreach (var record in records)
                    {
                        context.Entry(record).State = EntityState.Deleted;
                    }
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public void Update(T record)
        {
            using (var context = new TinyCollegeContext())
            {
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Task UpdateAsync(T record)
        {
            return UpdateAsync(record, CancellationToken.None);
        }

        public async Task UpdateAsync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context =  new TinyCollegeContext())
                {
                    context.Entry(record).State = EntityState.Modified;
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public void UpdateRange(List<T> records)
        {
            using (var context = new TinyCollegeContext())
            {
                foreach (var record in records)
                {
                    context.Entry(record).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public Task UodateRangeAsync(List<T> records)
        {
            return UodateRangeAsync(records, CancellationToken.None);
        }

        public async Task UodateRangeAsync(List<T> records, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    foreach (var record in records)
                    {
                        context.Entry(record).State = EntityState.Modified;
                    }
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            using (var context = new TinyCollegeContext())
            {
                return context.Set<T>().FirstOrDefault(condition);
            }

        }

        public Task<T> GetAsync(Expression<Func<T, bool>> condition)
        {
            return GetAsync(condition, CancellationToken.None);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condition, CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                  return await context.Set<T>().FirstOrDefaultAsync(condition, token).ConfigureAwait(false);
                }
            }, token);
        }


        public List<T> GetRange()
        {
            using (var context = new TinyCollegeContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public Task<List<T>> GetRangeAsync()
        {
            return GetRangeAsync(CancellationToken.None);
        }

        public async Task<List<T>> GetRangeAsync(CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                   return await context.Set<T>().ToListAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public List<T> GetRange(Expression<Func<T, bool>> condition)
        {
            using (var context = new TinyCollegeContext())
            {
                return context.Set<T>().Where(condition).ToList();
            }
        }

        public Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition)
        {
            return GetRangeAsync(condition, CancellationToken.None);
        }

        public async Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                using (var context = new TinyCollegeContext())
                {
                    return await context.Set<T>().Where(condition).ToListAsync(token).ConfigureAwait(false);
                }
            }, token);
        }
    }
}
