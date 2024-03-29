﻿using BlueBadge_Project.Data;
using BlueBadge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Service
{
    public class SystemPlanService
    {
        private readonly Guid _systemId;

        public SystemPlanService(Guid systemId)
        {
            _systemId = systemId;
        }

        public bool CreateSystemPlan(SystemPlanCreate plan)
        {
            var entity =
                new SystemPlan()
                {
                    SysId = plan.SysId,
                    UserId = _systemId,
                    FitnessId = _systemId,
                    DietId = _systemId,
                    //Name = plan.Name,
                    StartingWeight = plan.StartingWeight,
                    PlanGoal = plan.PlanGoal,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SystemPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }


        public SystemPlanDetail GetSysIdById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == id);
                return
                   new SystemPlanDetail
                   {
                       SysId = entity.SysId,
                       //Name = entity.Name,
                       StartingWeight = entity.StartingWeight,
                       PlanGoal = entity.PlanGoal,
                       CreatedUtc = DateTimeOffset.Now
                   };
            }
        }


        public bool UpdatePlan(SystemPlanEdit plan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == plan.SysId);

                //entity.Name = plan.Name;
                entity.StartingWeight = plan.StartingWeight;
                entity.PlanGoal = plan.PlanGoal;

                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }


        public bool DeletePlan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == id);

                ctx.SystemPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<SystemPlanListItems> GetSystemPlan()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SystemPlan
                        .Where(e => e.UserId == _systemId)

                        .Select(
                        e =>
                        new SystemPlanListItems
                        {
                            SysId = e.SysId,
                            //Name = e.Name,
                            StartingWeight = e.StartingWeight,
                            PlanGoal = e.PlanGoal,

                        }
                   );
                return query.ToArray();
            }
        }
    }
}
