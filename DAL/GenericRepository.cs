using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using API;


namespace DAL
{
	public class GenericRepository : IGenericRepository
	{
        #region Context Property
        DbContext _context;
		protected DbContext Context
		{
			get
			{
				return _context;
			}
			set
			{
				_context = value;
			}
		}
		#endregion

		#region Constructor

		public GenericRepository()
		{
            Database.SetInitializer<OwnersPetsContext>(new CreateDatabaseIfNotExists<OwnersPetsContext>());

            Context = new OwnersPetsContext();
        }
		#endregion

		#region Generic Repository
		public T Insert<T>(T model) where T : class
        {
            Context.Set<T>().Add(model);
            Context.SaveChanges();

            return model;
		}

		public T Update<T>(T model) where T : class
        {
            Context.Entry(model).State = EntityState.Modified;
            Context.SaveChanges();

            return model;
		}

		public void Delete<T>(T model) where T : class
        {
            Context.Set<T>().Remove(model);
            Context.SaveChanges();
            
		}

		public DbSet<T> Table<T>() where T : class
		{
		    return Context.Set<T>();
		}

		public IEnumerable<T> SelectAll<T>() where T : class
		{
            return Context.Set<T>().AsNoTracking().AsEnumerable();
        }

        public T Select<T>(int pk) where T : class
        {
            return Context.Set<T>().Find(pk);
        }


        #endregion

        #region IDispose Region
        private bool _disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this._disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

	}
}
