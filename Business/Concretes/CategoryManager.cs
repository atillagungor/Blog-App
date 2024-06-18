using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest)
        {
            var existingCategory = await _categoryDal.GetAsync(c => c.Name == createCategoryRequest.Name);

            if (existingCategory != null)
            {
                throw new BusinessException("It's already a category with same name.", "DuplicateCategoryError");
            }

            var newCategory = new Category
            {
                Name = createCategoryRequest.Name
            };

            await _categoryDal.AddAsync(newCategory);

            return _mapper.Map<CreatedCategoryResponse>(newCategory);
        }

        public async Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            var category = await _categoryDal.GetAsync(c => c.Id == updateCategoryRequest.Id);

            if (category == null)
            {
                throw new BusinessException("Category does not exists.", "CategoryNotFoundError");
            }

            category.Name = updateCategoryRequest.Name;

            var updatedCategory = await _categoryDal.UpdateAsync(category);

            return _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        }

        public async Task<DeletedCategoryResponse> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest)
        {
            var category = await _categoryDal.GetAsync(c => c.Id == deleteCategoryRequest.Id);

            if (category == null)
            {
                throw new BusinessException("Category does not exists.", "CategoryNotFoundError");
            }

            var deletedCategory = await _categoryDal.DeleteAsync(category, true);

            return _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        }

        public async Task<DeletedCategoryResponse> DeleteById(Guid id)
        {
            var category = await _categoryDal.GetAsync(c => c.Id == id);

            if (category == null)
            {
                throw new BusinessException("Category does not exists.", "CategoryNotFoundError");
            }

            var deletedCategory = await _categoryDal.DeleteAsync(category, true);

            return _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        }

        public async Task<DeletedCategoryResponse> DeleteByMailAsync(string email)
        {
            var category = await _categoryDal.GetAsync(c => c.Name == email);

            if (category == null)
            {
                throw new BusinessException("Category does not exists.", "CategoryNotFoundError");
            }

            var deletedCategory = await _categoryDal.DeleteAsync(category, true);

            return _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        }

        public async Task<IPaginate<GetCategoryResponse>> GetListCategories(PageRequest pageRequest)
        {
            var categories = await _categoryDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

            return _mapper.Map<Paginate<GetCategoryResponse>>(categories);
        }
    }
}