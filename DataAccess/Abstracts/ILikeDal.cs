﻿using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ILikeDal : IAsyncRepository<Like ,Guid>,IRepository<Like, Guid>
{
}