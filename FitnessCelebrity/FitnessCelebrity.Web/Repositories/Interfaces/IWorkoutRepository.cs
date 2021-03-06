﻿using FitnessCelebrity.Web.Data;
using FitnessCelebrity.Web.Models;
using FitnessCelebrity.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IWorkoutRepository : IBaseRepository<Workout>
    {
        Task<PagingList<Workout>> Get(PageableUserIdRequest request);
        new Task<Workout> GetById(long id);
        Task UpdateFitnessPaths(long id, Workout workout);
        Task UpdateMovements(long id, Workout workout);
        Task UpdateEntity(long id, Workout workout);

        Task<PagingList<Workout>> SearchWorkouts(PageableQueryRequest request);
    }
}
