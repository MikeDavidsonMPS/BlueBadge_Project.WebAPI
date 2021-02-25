using BlueBadge_Project.Models;
using BlueBadge_Project.Service;
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
        public IHttpActionResult Post(FitnessCreate fit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFitnessService();
            if (!service.CreateFit(fit))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            FitnessService fitnessService = CreateFitService();
            var fits = fitnessService.GetFit();
            return Ok(fit);
        }
        [HttpGet]
        public IHttpActionResult GetId(int fitId)
        {
            FitnessService fitService = CreateFitService();
            var fit = fitService.GetFitById(fitId);
            return Ok(fit);
        }
        [HttpPut]
        public IHttpActionResult UpdateFittness(FitnessEdit fit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFitnessService();
            if (!service.UpdateDiet(fit))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteFittness(int fitId)
        {
            var service = CreateFitnessService();
            if (!service.DeleteFit(fitId))
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
