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
	public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
	{
		private readonly ApplicationDbContext _db;
		public FoodTypeRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Update(FoodType obj)
		{
			var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
			objFromDb.Name = obj.Name;
		}
	}
}
