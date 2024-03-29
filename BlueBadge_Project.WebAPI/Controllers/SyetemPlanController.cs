﻿using BlueBadge_Project.Models;
using BlueBadge_Project.Service;
using Microsoft.AspNet.Identity;
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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            SystemPlanService systemPlanService = CreateSystemPlanService();
            var plan = systemPlanService.GetSystemPlan();
            return Ok(plan);
        }

        [HttpPost]
        public IHttpActionResult Post(SystemPlanCreate plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSystemPlanService();

            if (!service.CreateSystemPlan(plan))
                return InternalServerError();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            SystemPlanService systemPlanService = CreateSystemPlanService();
            var plan = systemPlanService.GetSysIdById(id);
            return Ok(plan);
        }

        private SystemPlanService CreateSystemPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var systemPlanService = new SystemPlanService(userId);
            return systemPlanService;
        }

        [HttpPut]
        public IHttpActionResult UpdatePlan(SystemPlanEdit plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSystemPlanService();

            if (!service.UpdatePlan(plan))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSystemPlanService();

            if (!service.DeletePlan(id))
                return InternalServerError();

            return Ok();
        }
    }
}

