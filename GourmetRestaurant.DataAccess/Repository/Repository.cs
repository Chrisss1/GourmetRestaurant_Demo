using GourmetRestaurant.DataAccess.Data;
using GourmetRestaurant.DataAccess.Repository.IRepository;
using GourmetRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GourmetRestaurant.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
			//FoodType,Category => if we use only applicationdbcontext
			//_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
			this.dbSet = db.Set<T>();
        }
        public void Add(T entity)
		{
			dbSet.Add(entity);
		}
		//loading props from API
		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(includeProperties != null)
			{
				//abc,,xyz -> abc xyz
				foreach (var includeProperty in includeProperties.Split(
					new char[] {','},StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return query.ToList();
		}
		//search the id for delete or update methods.
		public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query = dbSet;
			if(filter != null)
			{
				query = query.Where(filter);
			}
			return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
