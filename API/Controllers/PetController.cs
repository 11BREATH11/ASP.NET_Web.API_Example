using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BLL.Models;
using DAL.Models;

namespace API.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
		private readonly IMainService _mainService;

		public PetController(IMainService mainService)
	    {
		    _mainService = mainService;
	    }		

		[HttpGet]
		public PetsPageView GetPets(int userId,int pageNumber, int pageSize)
		{
			return _mainService.GetPetsView(userId,pageNumber, pageSize);
		}

		[HttpPost]
		public PetsView PostPet(Pets pet,int userId)
		{
			return _mainService.CreatePet(pet, userId);
		}

		[HttpDelete]
		public string DeletePet(int id)
		{
			_mainService.DeletePet(id);

            return "";
		}
	}
}
