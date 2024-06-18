using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfCategoryDal : EfRepositoryBase<Category, Guid, BlogContext>, ICategoryDal
{
    public EfCategoryDal(BlogContext context) : base(context)
    {
    }
}