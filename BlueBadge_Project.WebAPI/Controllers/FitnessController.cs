using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge_Project.WebAPI.Controllers
{
    [Authorize]
    public class DietController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(DietCreate diet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateDietService();
            if (!service.CreateDiet(diet))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            DietService dietService = CreateDietService();
            var diets = dietService.GetDiets();
            return Ok(diets);
        }
        [HttpGet]
        public IHttpActionResult Get(int dietId)
        {
            DietService dietService = CreateDietService();
            var diet = dietService.GetDietById(dietId);
            return Ok(diet);
        }
        [HttpPut]
        public IHttpActionResult Put(DietEdit diet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateDietService();
            if (!service.UpdateDiet(diet))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int dietId)
        {
            var service = CreateDietService();
            if (!service.DeleteDiet(dietId))
                return InternalServerError();
            return Ok();
        }


        //Need app user table done 
        //private DietService CreateDietService()
       // {
           // var appId = Guid.Parse(User.Identity.GetDietById());
           // var dietService = new DietService(userId);
           // return dietService;
       // }
    }
}
