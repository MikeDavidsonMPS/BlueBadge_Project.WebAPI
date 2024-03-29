﻿using BlueBadge_Project.Data;
using BlueBadge_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Service
{
    public class DietService
    {
        private readonly Guid _userId;

        public DietService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDiet(DietCreate model)
        {
            var entity =
                new DietPlan()
                {
                    Name = model.Name,
                    //DietDesc = model.DietDesc,
                    BalancedDiet = model.BalancedDiet,
                    Protein = model.Protein,
                    Vegatarian = model.Vegatarian,
                    Carbo = model.Carbo,
                    DietaryRestrictions = model.DietaryRestrictions,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DietPlan.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }


        public DietDetail GetDietById(int DietId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == DietId); // ---> needs AppID created to fix
                return
                    new DietDetail
                    {
                        Name = entity.Name,
                        //DietDesc = entity.DietDesc,
                        BalancedDiet = entity.BalancedDiet,
                        Protein = entity.Protein,
                        Vegatarian = entity.Vegatarian,
                        Carbo = entity.Carbo,
                        DietaryRestrictions = entity.DietaryRestrictions,
                        CreatedUtc = DateTimeOffset.Now
                    };
            }
        }


        public bool UpdateDiet(DietEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == model.DietId);// -->needs AppID created to fix

                entity.Name = model.Name;
                //entity.DietDesc = model.DietDesc;
                entity.BalancedDiet = model.BalancedDiet;
                entity.Protein = model.Protein;
                entity.Vegatarian = model.Vegatarian;
                entity.Carbo = model.Carbo;
                entity.DietaryRestrictions = model.DietaryRestrictions;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() > 0;
            }
        }


        public bool DeleteDiet(int dietId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .DietPlan
                    .Single(e => e.DietId == dietId);// -->needs AppID created to fix

                ctx.DietPlan.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }


        // HELPER METHOD
        // SEE ALL NOTES FOR SPECIFIC USER
        public IEnumerable<DietListItems> GetDiets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DietPlan
                        .Where(e => e.DietId == _userId)// -->needs AppID created to fix

                        .Select(
                        e =>
                        new DietListItems
                        {
                            DietId = e.DietId,
                            Name = e.Name,
                            //DietDesc = e.DietDesc,
                            CreatedUtc = e.CreatedUtc,

                        }
                   );
                return query.ToArray();
            }
        }

    }
}
