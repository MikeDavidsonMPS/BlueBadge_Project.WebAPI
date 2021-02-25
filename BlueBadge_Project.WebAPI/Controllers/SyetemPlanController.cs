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
    public class SystemPlanController : ApiController
    {
      
        [HttpPost]
        public IHttpActionResult Post(SystemPlanCreate sysPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSystemPlanService();

            if (!service.CreateSystemPlan(sysPlan))
                return InternalServerError();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            SystemPlanService sysPlanService = CreateSystemPlanService();
            var sysPlan = sysPlanService.GetSystemPlan();
            return Ok(sysPlan);
        }

        [HttpGet]
        public IHttpActionResult GetId(int sysId)
        {
            SystemPlanService sysPlanService = CreateSystemPlanService();
            var sysPlan = sysPlanService.GetSystemPlanById(sysId);
            return Ok(sysPlan);
        }

        [HttpPut]
        public IHttpActionResult UpdateSysPlan(SystemPlanEdit sysPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSystemPlanService();
            if (!service.UpdateSystemPlan(sysPlan))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int sysId)
        {
            var service = CreateSystemPlanService();
            if (!service.DeleteSystemPlan(sysId))
                return InternalServerError();
            return Ok();
        }


        //Need app user table done 
       private DietService CreateDietService()
        {
            var appId = Guid.Parse(User.Identity.GetSysPlanById());
            var systemPalnService = new SystemPlanService(userId);
            return syetemPlanService;
        }
    }
}

