using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfLikeDal : EfRepositoryBase<Like, Guid, BlogContext>, ILikeDal
{
    public EfLikeDal(BlogContext context) : base(context)
    {
    }
}