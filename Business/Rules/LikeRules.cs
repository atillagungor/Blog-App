using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class LikeBusinessRules : BaseBusinessRules<Like>
    {
        private readonly ILikeDal _likeDal;

        public LikeBusinessRules(ILikeDal likeDal) : base(likeDal)
        {
            _likeDal = likeDal;
        }

        public async Task<bool> CanUserLikePost(Guid userId, Guid postId)
        {
            var existingLike = await _likeDal.GetAsync(l => l.UserId == userId && l.PostId == postId);

            if (existingLike != null)
            {
                throw new BusinessException("You already liked this post", "DuplicateLikeError");
            }

            return true;
        }
    }
}