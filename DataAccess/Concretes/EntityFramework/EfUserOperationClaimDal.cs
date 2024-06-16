using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;
public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, Guid, BlogContext>, IUserOperationClaimDal
{
    public EfUserOperationClaimDal(BlogContext context) : base(context)
    {
    }
}