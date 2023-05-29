using GourmetRestaurant.DataAccess.Data;
using GourmetRestaurant.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GourmetRestaurantWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Authorize]
        public IActionResult Get()
		{
			var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser");
			return Json(new {data = OrderHeaderList});
		}

	}
}
