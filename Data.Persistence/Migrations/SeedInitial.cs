using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Persistence.Migrations
{
    internal static class SeedInitial
    {
        public static void GetSeed(DbContext context)
        {
            var impart = new List<Impart>
            {
                new Impart {Id = 1, Name = "Bajo"},
                new Impart {Id = 2, Name = "Medio"},
                new Impart {Id = 3, Name = "Alto"}
            };
            impart.ForEach(i=>context.Set<Impart>().Add(i));

            var probability = new List<Probability>
            {
                new Probability {Id = 1, Name = "Bajo"},
                new Probability {Id = 2, Name = "Medio"},
                new Probability {Id = 3, Name = "Alto"}
            };
            probability.ForEach(i => context.Set<Probability>().Add(i));

            var project = new List<Project>
            {
                new Project {Id = 1, Cod = "Cod1", DateInitial = DateTime.Now, DateEnd = new DateTime(2018, 10, 1)},
                new Project {Id = 2, Cod = "Cod2", DateInitial = DateTime.Now, DateEnd = new DateTime(2018, 10, 1)},
                new Project {Id = 3, Cod = "Cod3", DateInitial = DateTime.Now, DateEnd = new DateTime(2018, 10, 1)}
            };
            project.ForEach(i => context.Set<Project>().Add(i));

            var risks = new List<Risks>
            {
                new Risks
                {
                    Id = 1,
                    Name = "Risk1",
                    MyImpart = impart[0],
                    MyProbability = probability[0],
                    MyProject = project[0]
                },
                new Risks
                {
                    Id = 2,
                    Name = "Risk2",
                    MyImpart = impart[1],
                    MyProbability = probability[1],
                    MyProject = project[1]
                },
                new Risks
                {
                    Id = 3,
                    Name = "Risk3",
                    MyImpart = impart[2],
                    MyProbability = probability[2],
                    MyProject = project[2]
                }
            };

            context.SaveChanges();
        }
    }
}
