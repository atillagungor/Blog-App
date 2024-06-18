using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IPostDal :  IAsyncRepository<Post, Guid>,IRepository<Post, Guid>
{
}