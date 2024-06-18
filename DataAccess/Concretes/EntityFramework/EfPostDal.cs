using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfPostDal : EfRepositoryBase<Post, Guid, BlogContext>, IPostDal
{
    public EfPostDal(BlogContext context) : base(context)
    {
    }
}