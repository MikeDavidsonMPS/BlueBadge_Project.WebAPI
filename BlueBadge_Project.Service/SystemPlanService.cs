using BlueBadge_Project.Data;
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
        public bool CreateSystemPlan(SystemPlanCreate model)
        {
            var entity =
                new SystemPlan()
                {
                    //Name = model.Name,
                    StartingWeight = model.StartingWeight,
                    SystemPlanGoal = model.PlanGoal,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SystemPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public SystemPlanDetail GetSysIdById(int SysId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId && e.OwnerId == _userId);
                return
                   new SystemPlanDetail
                   {
                       //Name = entity.Name,
                       StartingWeight = entity.WeightLoss,
                       PlanGoal = entity.PlanGoal,
                       CreatedUtc = DateTimeOffset.Now
                   };
            }
        }
        public bool UpdateSystemPlan(SystemPlanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.SysId == model.SysId && e.OwnerId == _userId);

                //entity.Name = model.Name;
                entity.StartingWeight = model.StartingWeight;
                entity.PlanGoal = model.PlanGoal;

                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteSystemPlan(int sysId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SystemPlan
                    .Single(e => e.FitnessId == sysId && e.OwnerId == _userId);

                ctx.SystemPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
