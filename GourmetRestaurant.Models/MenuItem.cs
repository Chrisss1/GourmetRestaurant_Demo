﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetRestaurant.Models
{
	public class MenuItem
	{
		[Key]
        public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
        public string Image { get; set; }
		[Range(1, 1000, ErrorMessage = "Price Should Be Between $1 and $1000")]
		public double Price { get; set; }
        public int FoodTypeId { get; set; }
		[ForeignKey("FoodTypeId")]
		public FoodType FoodType { get; set; }
		public int CategoryId { get; set; }
		//needless to use ForeignKey attribute
		public Category Category { get; set; }

    }
}