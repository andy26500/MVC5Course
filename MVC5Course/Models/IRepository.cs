﻿

using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVC5Course.Models
{ 
	public interface IRepository<T> 
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Delete(T entity);
	}
}

