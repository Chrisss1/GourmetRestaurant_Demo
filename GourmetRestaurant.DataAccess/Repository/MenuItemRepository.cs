﻿using GourmetRestaurant.DataAccess.Data;
using GourmetRestaurant.DataAccess.Repository.IRepository;
using GourmetRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetRestaurant.DataAccess.Repository
{
	public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
	{
		private readonly ApplicationDbContext _db;
		public MenuItemRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(MenuItem obj)
		{
			var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
			objFromDb.Name = obj.Name;
			objFromDb.Description = obj.Description;
			objFromDb.Price = obj.Price;
			objFromDb.CategoryId = obj.CategoryId;
			objFromDb.FoodTypeId = obj.FoodTypeId;
			if(objFromDb.Image != null)
			{
				objFromDb.Image = obj.Image;
			}
		}
	}
}
